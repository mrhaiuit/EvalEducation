// <copyright file="GlobalSettings.cs" company="TCIS">
// Copyright (c) .  All rights reserved.  Reproduction or transmission in 
// whole or in part, in any form or by any means, electronic, mechanical or 
// otherwise, is prohibited without the prior written consent of the copyright 
// owner.
// </copyright>
//
// <summary>
// </summary>
// <remarks>
// </remarks>
// <history>
// Date         Release         Task            Who         Summary
// ===================================================================================
// 24/09/2012   1.0.0.0                         LKTL        Created
// </history>
using System;
using System.Linq;
using System.Globalization;
using System.Configuration;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using Autofac;
using Autofac.Core;

// ReSharper disable All


namespace EVE.Commons
{
    public static class GlobalSettings
    {

        public static string NullDate = "31/12/1900";
        public static string NullDateHM = "31/12/1900 00:00";
        public static string NullDateHMS = "31/12/1900 00:00:00";

        public static string StrDMY = "dd/MM/yyyy";
        public static string StrDMYHM = "dd/MM/yyyy HH:mm";
        public static string StrYYYY = "yyyy";
        public static string StrDMYHMS = "dd/MM/yyyy HH:mm:ss";

        public static string DbStrDMY = "\'dd/MM/yyyy\'";
        public static string DbStrDMYH24M = "\'dd/MM/yyyy HH24:MI\'";
        public static string DbStrDMYH24MS = "\'dd/MM/yyyy HH24:MI:SS\'";

        public static string StrYMDSql = "yyyy-MM-dd";

        public static string StrYMDInterface = "yyyyMMdd";
        public static string StrHMSInterface = "HHmmss";

        public static string StrHMTimeSpan = "HH:mm";
        public static string StrHMSTimeSpan = "HH:mm:ss";
        public static string DecimalSeparator = ",";
        public static string DigitGroup = ".";
        public static string Comma = ",";
        public static string FORMAT_NUMBER = "#,##0.##";
        public static string CHECK_TRUCK_IMO = "CHK_TRK_IMO";
        public static string CHK_TRK_IO = "CHK_TRK_IO";
        public static string TRUCK_VIO_INTERNAL_BN = "PTTRUCK";
        public static string[] STRING_DILIMITER = new string[] { "//__//__//" };
        public static string DILIMITER = "__//";
        public static string NewLine = "\r\n";
        public static string DoubleNewLine = "\r\n\r\n";

        public static string DebitInternalBookNumber = "DEBIT"; //Số nội bộ của phí phát hành cho Đăng ký nợ
        public static string PTDieuChinhHD = "PTDCHD"; // số quyển nội bộ PT điều chỉnh hóa đơn
        public static string FormatInvoiceNumber = "0000000"; 

        //
        public static int IntDefaultValue = int.MinValue;
        public static long LongDefaultValue = long.MinValue;
        public static double DoubleDefaultValue = double.MinValue;
        public static float FloatDefaultNotSetValue = float.MinValue;
        public static string StringDefaultValue = null;
        public static string ObjectDefaultValue = null;
        public static DateTime DateTimeDefaultValue = DateTime.MinValue;
        public static int UnAssignedTemperature = 9999;
        public static DateTime MaxExpiryTime = new DateTime(2050, 12, 31);
        public static int DefaultOOgValue = 99;

        public static int PrecisonUSD = 2;
        public static int PrecisonVND = 2;
        public static string OK = "OK";
        public static string ERROR = "ERROR";
        private static Form _activeForm = null;
        private static string _activeFormCode = string.Empty;
        private static string _activeFormDesc = string.Empty;
        public static Form MdiMainForm = null;
        public const string EDI_FUNCTION_DELETE = "D";
        public const string EDI_FUNCTION_UPDATE = "U";
        public const string EDI_FUNCTION_NEW = "N";

        public static IContainer Container;

        /// <summary>
        /// PTI overdue: 30 days
        /// </summary>
        public static int PtiOverDue = 30;
        public static string[] DAMAGE_BY = { "*", "_", "&", "%", "@" };

        public static Configuration TopoConfiguration = null;

        public enum TERMINAL_TYPE { IMPORT, EXPORT };

        public static string LAST_USER_DIR = "";
        

        private static string localIpAddress;

        /// <summary>
        /// Define local culture for the whole system
        /// </summary>
        public static CultureInfo LocalCultureInfo = new CultureInfo("vi-VN");

        /// <summary>
        /// Specifies date time format. 
        /// This property might be used in datetime convert functions.
        /// </summary>
        public static DateTimeFormatInfo DateTimeFormat
        {
            get
            {
                DateTimeFormatInfo dateInfo = new DateTimeFormatInfo { ShortDatePattern = StrDMY, DateSeparator = "/", TimeSeparator = ":" };
                return dateInfo;
            }
        }



        private static bool _allowCustomsClearanceBeforeGateIn;
        /// <summary>
        /// Allow save in C80 whenever container is not gate in
        /// </summary>
        public static bool AllowCustomsClearanceBeforeGateIn
        {
            get
            {
                return _allowCustomsClearanceBeforeGateIn;
            }

            set { _allowCustomsClearanceBeforeGateIn = value; }
        }


        /// <summary>
        /// SITE ID
        /// </summary>
        public static string SiteId
        {
            get;
            set;
        }
        /// <summary>
        /// Home Port
        /// </summary>
        public static string HomePort
        {
            get;
            set;
        }

        /// <summary>
        /// User Id
        /// </summary>
        public static string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// User Class
        /// </summary>
        public static string UserClass
        {
            get;
            set;
        }

        /// <summary>
        /// User Full Name
        /// </summary>
        public static string UserFullName
        {
            get;
            set;
        }

        /// <summary>
        /// User Department code
        /// </summary>
        public static string UserDeptCode
        {
            get;
            set;
        }

        /// <summary>
        /// Cashier Id
        /// </summary>
        public static string CashierId
        {
            get;
            set;
        }

        /// <summary>
        /// Cashier Id
        /// </summary>
        public static string CashierName
        {
            get;
            set;
        }

        /// <summary>
        /// Store db connection to application configuration file
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="homePort"></param>
        static public void SaveSiteDefintion(string siteId, string homePort)
        {
            if (siteId.IsEmpty() || homePort.IsEmpty())
            {
                return;
            }

            Configuration appConfiguration = TopoConfiguration;

            //Store the given site id to App.config
            appConfiguration.AppSettings.Settings["SiteId"].Value = siteId;

            //Encrypt the given home port to App.config
            appConfiguration.AppSettings.Settings["HomePort"].Value = homePort;

            //Refesh configuration manager
            appConfiguration.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");

        }

        /// <summary>
        /// Store usernaem and user class to application cofiguration file
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userClass"></param>
        static public void SaveLastUserInfos(string userId, string userClass)
        {
            Configuration appConfiguration = TopoConfiguration;

            //Store the given site id to App.config
            appConfiguration.AppSettings.Settings["UserId"].Value = userId;

            //Encrypt the given home port to App.config
            appConfiguration.AppSettings.Settings["UserClass"].Value = userClass;

            //Refesh configuration manager
            appConfiguration.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");

        }

        private static string rsaPrivateKey;
        public static string RSAPrivateKey
        {
            get
            {
                rsaPrivateKey = "<RSAKeyValue><Modulus>wSqd2OPYl2c+U2iaWUyNWEFd8Tnh1HdX+XuFipkNOe1f8EI0MbV7iC90d+fVxx94BCMypC+/ntCuogU3eBYxzL6cHKwxnmHjcLlUME0kcfxs6xxFH+tJtQn4NwYXEwmYZ9Yaiq6NGuhwfSCu7BShWi/OsEFMkKVapGSuJnjoj4s=</Modulus>";
                rsaPrivateKey += "<Exponent>AQAB</Exponent><P>+5nMLdNDUl8/yUIWN/jEKXLaXojQDkJ5igDs+gV7B9d7GszOtnnYUREj5f4qd0GqMwvFDidYKUIba3dVBaCKvQ==</P><Q>xItCJvX5T+PhRdK3ZfPuKQbH8smodqG2Zt7/He4Jg7ep8QLYUnu91/bIMI7SC+pCj9olTP/NbCtrx3T3R15L5w==</Q>";
                rsaPrivateKey += "<DP>fcaCtZ3ZF8KZ5ohtBwoLNhU+aOfH6nj8vSp9TPeUa3UjC2C7Lal3o/8HjSAkJn3jEaWemta8UdPEVVLQZAG/mQ==</DP><DQ>APvRcPB6NvQlBHxxfokiAAKQrZ5kwXM9vnYPQM8YLRiWOSaSfpcv9AzAI74TPwwFGUM2PJRrKsds2qqzMiA+sQ==</DQ>";
                rsaPrivateKey += "<InverseQ>hmAHlTzUU6s7VmAyMp4WVCh2YIDdHI3AX4dQ6vHEAiE5qRgXTL6yNvyORAKbilKjoZWWYELi+2xbl6tKU1e7zA==</InverseQ>";
                rsaPrivateKey += "<D>BkiwoeGnpiVBrcz1WHpZDsnxmGtdoV/QiNkv2vZnq77BJDvDHurcfe2tSElOdw/bA6dxek3jWfNH+xVYXJu8OvJURS8qwiNNv8m2DivNEHsi4vdXNYLrQo0ycR2WIoiPHJEgJo+4giUH7c/6kqSUwV6NpAJ8rSLzf8OinspW7CE=</D></RSAKeyValue>";
                return rsaPrivateKey;
            }
        }

        private static string rsaPublicKey;
        public static string RSAPublicKey
        {
            get
            {
                rsaPublicKey = "<RSAKeyValue><Modulus>wSqd2OPYl2c+U2iaWUyNWEFd8Tnh1HdX+XuFipkNOe1f8EI0MbV7iC90d+fVxx94BCMypC+/ntCuogU3eBYxzL6cHKwxnmHjcLlUME0kcfxs6xxFH+tJtQn4NwYXEwmYZ9Yaiq6NGuhwfSCu7BShWi/OsEFMkKVapGSuJnjoj4s=</Modulus>";
                rsaPublicKey += "<Exponent>AQAB</Exponent></RSAKeyValue>";
                return rsaPublicKey;
            }
        }

        public static string IssueInvoiceDep { get; set; }

        [DllImport("user32.dll")]

        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]

        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        static extern IntPtr GetActiveWindow();


        static string CaptionWindowLabel = string.Empty;
        static string IDWindowLabel = string.Empty;
        public static bool gbViewDataOnly;
        public static string InstanceSeq = string.Empty;
        

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        static public int GetLastInputTime()
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            int envTicks = Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                var lastInputTick = lastInputInfo.dwTime.CheckIntEx();

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : idleTime);
        }

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        /////////////////////////////////////////////
        /////////////////////////////////////////////
        #region PROPERTIES trao doi XML voi HAI QUAN

        private static string _portName;
        /// <summary>
        /// Port Name
        /// </summary>
        public static string PortName
        {
            get
            {
                if (_portName.IsEmpty())
                {
                    _portName = "Cảng TÂN CẢNG - CÁT LÁI";
                }
                return _portName;
            }

            set { _portName = value; }
        }

        private static string _intfLogDir;
        /// <summary>
        /// Log directory: thu muc chua text log trao doi thong tin HQ
        /// </summary>
        public static string IntfLogDir
        {
            get
            {
                if (_intfLogDir.IsEmpty())
                {
                    string rootDir = System.IO.Directory.GetDirectoryRoot(System.IO.Directory.GetCurrentDirectory());
                    _intfLogDir = rootDir + "INTF_CUSTOMS_LOG\\";
                }
                return _intfLogDir;
            }

            set { _intfLogDir = value; }
        }

        private static string _smartDeviceLogDir;
        /// <summary>
        /// Log directory: thu muc chua text log trao doi thong tin HQ
        /// </summary>
        public static string SmartDeviceLogDir
        {
            get
            {
                if (_smartDeviceLogDir.IsEmpty())
                {
                    string rootDir = System.IO.Directory.GetDirectoryRoot(System.IO.Directory.GetCurrentDirectory());
                    _smartDeviceLogDir = rootDir + "PREGATE_LOGS\\";
                }
                return _smartDeviceLogDir;
            }

            set { _smartDeviceLogDir = value; }
        }

        #endregion

     
        public static int ConsigneeLengthToCompare => ConfigurationManager.AppSettings["ConsigneeLengthToCompare"].CheckIntEx();
        public static int MaxLengthConsignee => ConsigneeLengthToCompare <= 0 ? 35 : ConsigneeLengthToCompare;
    }
}
