using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EVE.Commons;
using EVE.WebApi.Shared.Response;

namespace EVE.WebApi.Shared.Filter
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        //private static IDictionary<string, Error> _dicError;

        //private void Init()
        //{
        //    if(_dicError == null)
        //    {
        //        _dicError = new Dictionary<string, Error>
        //                    {
        //                            {Resource.Instance.UsernameIsNullOrEmpty.ErrorCode, Resource.Instance.UsernameIsNullOrEmpty}, //400100
        //                            {Resource.Instance.PasswordIsNullOrEmpty.ErrorCode, Resource.Instance.PasswordIsNullOrEmpty}, //400200
        //                            {Resource.Instance.UserClassIsNullOrEmpty.ErrorCode, Resource.Instance.UserClassIsNullOrEmpty}, //400300
        //                            {Resource.Instance.SiteIdIsNullOrEmpty.ErrorCode, Resource.Instance.SiteIdIsNullOrEmpty}, //400400
        //                            {Resource.Instance.AgentIdIsNullOrEmpty.ErrorCode, Resource.Instance.AgentIdIsNullOrEmpty}, //400500
        //                            {Resource.Instance.AreaIsNullOrEmpty.ErrorCode, Resource.Instance.AreaIsNullOrEmpty}, //400600
        //                            {Resource.Instance.StackIsNullOrEmpty.ErrorCode, Resource.Instance.StackIsNullOrEmpty}, //400700
        //                            {Resource.Instance.CodeTpIsNullOrEmpty.ErrorCode, Resource.Instance.CodeTpIsNullOrEmpty}, //400800
        //                            {Resource.Instance.CodeRefIsNullOrEmpty.ErrorCode, Resource.Instance.CodeRefIsNullOrEmpty}, //400900
        //                            {Resource.Instance.MenuModuleIsNullOrEmpty.ErrorCode, Resource.Instance.MenuModuleIsNullOrEmpty}, //400010
        //                            {Resource.Instance.GroupCodeIsNullOrEmpty.ErrorCode, Resource.Instance.GroupCodeIsNullOrEmpty}, //400110
        //                            {Resource.Instance.MenuItemCodeIsNullOrEmpty.ErrorCode, Resource.Instance.MenuItemCodeIsNullOrEmpty}, //400210
        //                            {Resource.Instance.OperationMethodIsNullOrEmpty.ErrorCode, Resource.Instance.OperationMethodIsNullOrEmpty}, //400310
        //                            {Resource.Instance.LineOperIsNullOrEmpty.ErrorCode, Resource.Instance.LineOperIsNullOrEmpty}, //400410
        //                            {Resource.Instance.DepotIsNullOrEmpty.ErrorCode, Resource.Instance.DepotIsNullOrEmpty}, //400510
        //                            {Resource.Instance.CustomerNoIsNullOrEmpty.ErrorCode, Resource.Instance.CustomerNoIsNullOrEmpty}, //400610
        //                            {Resource.Instance.IsoIsNullOrEmpty.ErrorCode, Resource.Instance.IsoIsNullOrEmpty}, //400710
        //                            {Resource.Instance.BadRequest.ErrorCode, Resource.Instance.BadRequest}, //500000
        //                            {Resource.Instance.LogonInvalid.ErrorCode, Resource.Instance.LogonInvalid}, //500100
        //                            {Resource.Instance.UserClassInvalid.ErrorCode, Resource.Instance.UserClassInvalid}, //500200
        //                            {Resource.Instance.AgentIdHasExist.ErrorCode, Resource.Instance.AgentIdHasExist}, //500300
        //                            {Resource.Instance.AgentNotExist.ErrorCode, Resource.Instance.AgentNotExist}, //500400
        //                            {Resource.Instance.YardAreaHasExist.ErrorCode, Resource.Instance.YardAreaHasExist}, //500500
        //                            {Resource.Instance.YardAreaNotExist.ErrorCode, Resource.Instance.YardAreaNotExist}, //500600
        //                            {Resource.Instance.SysCodesHasExist.ErrorCode, Resource.Instance.SysCodesHasExist}, //500700
        //                            {Resource.Instance.SysCodesNotExist.ErrorCode, Resource.Instance.SysCodesNotExist}, //500800
        //                            {Resource.Instance.MenuGroupHasExist.ErrorCode, Resource.Instance.MenuGroupHasExist}, //500900
        //                            {Resource.Instance.MenuGroupNotExist.ErrorCode, Resource.Instance.MenuGroupNotExist}, //500010
        //                            {Resource.Instance.MenuItemHasExist.ErrorCode, Resource.Instance.MenuItemHasExist}, //500110
        //                            {Resource.Instance.MenuItemNotExist.ErrorCode, Resource.Instance.MenuItemNotExist}, //500210
        //                            {Resource.Instance.OperationMethodHasExist.ErrorCode, Resource.Instance.OperationMethodHasExist}, //500310
        //                            {Resource.Instance.OperationMethodNotExist.ErrorCode, Resource.Instance.OperationMethodNotExist}, //500410
        //                            {Resource.Instance.LineOperHasExist.ErrorCode, Resource.Instance.LineOperHasExist}, //500510
        //                            {Resource.Instance.LineOperNotExist.ErrorCode, Resource.Instance.LineOperNotExist}, //500610
        //                            {Resource.Instance.DepotHasExist.ErrorCode, Resource.Instance.DepotHasExist}, //500710
        //                            {Resource.Instance.DepotNotExist.ErrorCode, Resource.Instance.DepotNotExist}, //500810
        //                            {Resource.Instance.CustomerNoHasExist.ErrorCode, Resource.Instance.CustomerNoHasExist}, //500910
        //                            {Resource.Instance.CustomerNoNotExist.ErrorCode, Resource.Instance.CustomerNoNotExist}, //500020
        //                            {Resource.Instance.IsoHasExist.ErrorCode, Resource.Instance.IsoHasExist}, //500120
        //                            {Resource.Instance.IsoNotExist.ErrorCode, Resource.Instance.IsoNotExist}, //500220
        //                    };
        //    }
        //}

        public override void OnActionExecuting(HttpActionContext context)
        {
            var modelState = context.ModelState;

            if(!modelState.IsValid)
            {
                object tmp;
                if(context.ActionArguments.TryGetValue("req", out tmp))
                {
                    //Init();
                    var response = new BaseResponse<string>(string.Empty);
                    var errorCodes = new List<string>();
                    var msgs = new List<string>();
                    var attr = string.Empty;
                    int errorCode = 0;
                    string msg = string.Empty;
                    var error = default(Error);
                    for (int i = 0; i < modelState.Count; i++)
                    {
                        if(modelState.Values.ElementAt(i)
                                     .Errors.Any())
                        {
                            attr = modelState.Keys.ElementAt(i)
                                             .Replace("req.", "");
                            errorCode = ConvertUtils.TryConvertToInt32(modelState.Values.ElementAt(i)
                                                                                 .Errors[modelState.Values.ElementAt(i)
                                                                                                   .Errors.Count - 1]
                                                                                 .ErrorMessage);
                            errorCodes.Add(errorCode.ToString());

                            msg = ((EnumError)errorCode).GetStringValue();
                            error = new Error(errorCode.ToString(), msg);
                            error.UpdateAttribute(attr);
                            msgs.Add(error.Message);
                        }
                    }

                    response.UpdateMessageError(new Error(string.Join("|", errorCodes), string.Join("|", msgs)));

                    context.Response = context.Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
