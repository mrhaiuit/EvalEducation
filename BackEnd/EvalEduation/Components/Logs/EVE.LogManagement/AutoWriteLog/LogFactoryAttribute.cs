using System;
using System.Collections.Generic;
using System.Diagnostics;
using Castle.DynamicProxy;
using EVE.LogManagement.Logs;
using EVE.LogManagement.Utils;
using TimeUUID;

namespace EVE.LogManagement.AutoWriteLog
{
    /*
     *  - Log được chia ra 4 loại: None, BugLogic, Exception, Trace
     *  + None: không ghi log
     *  + Exception: log khi có lỗi exception
     *      - Input.
     *      - Exception ex.
     *      - Method Name.
     *      - Namespace
     *      - ServerIp.
     *      - TransactionId.
     *      - Guid.
     *      *** Chỉ cần OnExit
     *      *** Là exception là lỗi cần fix gấp. Không quan tâm đến tgian thực thi
     *      
     *  + Trace: mục đích để do thời gian thực thi nhằm đánh giá sức khỏe hệ thống.
     *      - Input.
     *      - Output.
     *      - TransactionId.
     *      - Guid.
     *      - Method Name.
     *      - ServerIp.
     *      *** Kết hợp giữa OnEntry + OnExit để đo tgian thực thi.
     *      
     *  + BugLogic: Không phải là exception, đây là các hàm bị lỗi logic do người dùng nhập sai tham số, sai kiểu dữ liệu, dữ liệu không hợp lệ,....
     *    Lấy message trong object Response.
     */
    public class CallLogger : IInterceptor
    {
        private readonly string _path;

        public CallLogger()
        {
        }

        public CallLogger(string path) : this()
        {
            if (!string.IsNullOrEmpty(path)
               && !path.EndsWith("\\"))
            {
                path += "\\";
            }

            _path = path;
        }

        private readonly List<string> _ignoreMethods = new List<string>
                                                       {
                                                               "Dispose",
                                                               "Initialize",
                                                               "get_DefaultMargin",
                                                               "get_DefaultMinimumSize",
                                                               "get_DefaultMaximumSize",
                                                               "get_DefaultSize",
                                                               "get_RightToLeft",
                                                               "get_Text",
                                                               "get_AllowFormSkin",
                                                               "GetAllowSkin",
                                                               "GetSkinPainterType",
                                                               "GetCreateParams",
                                                               "get_CreateParams",
                                                               "set_RightToLeft",
                                                               "get_RightToLeftLayout",
                                                               "set_RightToLeftLayout",
                                                               "CheckRightToLeft",
                                                               "get_ShowMdiChildCaptionInParentTitle",
                                                               "get_MdiChildCaptionFormatString",
                                                               "get_Site",
                                                               "get_MinimumSize",
                                                               "get_MaximumSize",
                                                               "get_IsSuspendRedraw",
                                                               "get_AllowMdiBar",
                                                               "get_CloseBox",
                                                               "get_EnableAcrylicAccent",
                                                               "CreateDefaultAppearance",
                                                               "get_BackColor",
                                                               "get_BackgroundImage",
                                                               "get_BackgroundImageLayout",
                                                               "GetService",
                                                               "get_Font",
                                                               "get_CanRaiseEvents",
                                                               "get_AutoSize",
                                                               "get_AutoScroll",
                                                               "AdjustFormScrollbars",
                                                               "get_LayoutEngine",
                                                               "OnBindingContextChanged",
                                                               "set_BindingContext",
                                                               "get_BindingContext",
                                                               "get_DefaultPadding",
                                                               "get_DisplayRectangle",
                                                               "get_Anchor",
                                                               "get_AutoScrollOffset",
                                                               "get_ContextMenu",
                                                               "get_ContextMenuStrip",
                                                               "get_DefaultCursor",
                                                               "get_Cursor",
                                                               "get_Dock",
                                                               "get_Focused",
                                                               "ShouldDrawClientBackground",
                                                               "WndProc",
                                                               "get_ForeColor",
                                                               "get_AutoScaleBaseSize",
                                                               "get_AutoValidate",
                                                               "get_AllowDrop",
                                                               "DefWndProc",
                                                               "SizeFromClientSize",
                                                               "OnMove",
                                                               "OnLocationChanged",
                                                               "OnHandleCreated",
                                                               "OnInvalidated",
                                                               "NotifyInvalidate",
                                                               "OnStyleChanged",
                                                               "CreateHandle",
                                                               "get_AutoScaleBaseSize",
                                                               "get_AutoValidate",
                                                               "UpdateWindowThemeCore"
                                                       };

        #region IInterceptor Members

        /// <summary>
        ///     Tự động bắt và ghi log
        /// </summary>
        /// <param name="invocation"></param>
        /// <desc>
        ///     Trong 1 function xảy ra 3 loại log:
        ///     * Log được quản lý:
        ///     - Các log được Wrapper trong đối tượng LogResponse
        ///     * Log không được quản lý:
        ///     - Do y/c tích hợp phần ghi log vào hệ thống hiện tại, nên các log chỗ Service, WCF không được wrapper trong
        ///     LogResponse
        ///     - Các log này chia làm 2 loại:
        ///     ** Log Trace:
        ///     - Không xuất hiện lỗi random, chỉ cần ghi lại thời gian thực thi.
        ///     ** Random Exception:
        ///     - Log exception xảy ra random.
        /// </desc>
        public void Intercept(IInvocation invocation)
        {
            if(_ignoreMethods.Contains(invocation.Method.Name))
            {
                invocation.Proceed();
                return;
            }
            
            var serverIp = LogUtils.GetLocalIPAddress(System.Net.Sockets.AddressFamily.InterNetwork);// "192.168.1.1";
            var logType = LogTypes.None;
            var message = string.Empty;
            var errorCode = string.Empty;
            var transactionId = string.Empty;

            var watch = Stopwatch.StartNew();
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex) // trường hợp exception-random
            {
                logType = LogTypes.Exception;
                message = ex.ToString();
                errorCode = "R-EXCEPTION-500";
            }
            finally
            {
                watch.Stop();
            }

            if (invocation.ReturnValue is LogResponse) // trường hợp được wrapper trong LogResponse
            {
                var returnObj = invocation.ReturnValue as LogResponse;
                if (returnObj == null)
                    return;

                logType = returnObj.LogType;
                message = returnObj.Message;
                errorCode = returnObj.ErrorCode;
                transactionId = returnObj.TransactionId;
            }
            else // trường hợp log trace không được wrapper trong LogResponse
            {
                if (logType == LogTypes.None)
                {
                    logType = LogTypes.Trace;
                }

            }

            var logDetails = new LogDetails
            {
                Data = new Data
                {
                    Parameters = invocation.Arguments,
                    ReturnValue = invocation.ReturnValue
                },
                Location = new Location
                {
                    Function = invocation.Method.Name,
                    ClassName = invocation.TargetType.Name,
                    Namespace = invocation.TargetType.Namespace
                },
                ErrorCode = errorCode,
                Identity = Identity.Next(), //TimeUUID.GuidGenerator.GenerateTimeBasedGuid(DateTime.Now),// DateTime.UtcNow will bester.
                LogType = logType,
                Message = message,
                Server = serverIp,
                TransactionId = transactionId,
                Client = LogUtils.GetClientIP(),
                Elapsed = watch.ElapsedMilliseconds,
                ExecDate = DateTime.Now
            };
            logDetails.WriteDebugLogBySerilog(_path);
        }

        #endregion
    }
}
