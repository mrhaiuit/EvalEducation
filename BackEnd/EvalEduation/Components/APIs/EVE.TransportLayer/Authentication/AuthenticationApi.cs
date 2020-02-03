using System.Collections.Generic;
using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request.Account;
using EVE.Commons.Response;
using EVE.Data;

namespace EVE.TransportLayer
{
    public interface IApiAuthentication
    {
        Task<ClientResponse<LogonResponse>> Login(string userName,
                                                  string passWord);

        //Task<ClientResponse<List<OPERATOR>>> GetAll();

        //Task<ClientResponse<List<OPERATOR>>> GetById(string siteId,
        //                                             string operName);

        //Task<ClientResponse<object>> Insert(OperatorInsertReq req);

        //Task<ClientResponse<object>> Update(OperatorUpdateReq req);

        //Task<ClientResponse<object>> Delete(OperatorDeleteReq req);
    }
    public class ApiAuthentication : IApiAuthentication
    {
        #region IApiAuthentication Members

        public async Task<ClientResponse<LogonResponse>> Login(string userName,
                                                               string passWord)
        {
            var logonResponse = await HttpUtils<ClientResponse<LogonResponse>>.Post($"{AppUtil.BaseAuthenticationUrl}/account/logon", new
                                                                                                                                      {
                                                                                                                                              OPER_NAME
                                                                                                                                                      = userName
                                                                                                                                                              .Trim(),
                                                                                                                                              OPER_PWD
                                                                                                                                                      = passWord
                                                                                                                                                              .Trim()
                                                                                                                                      });
            return logonResponse;
        }

        //public async Task<ClientResponse<List<OPERATOR>>> GetAll()
        //{
        //    var response = await HttpUtils<ClientResponse<List<OPERATOR>>>.Get($"{AppUtil.BaseAuthenticationUrl}/account/all", null);
        //    return response;
        //}

        //public async Task<ClientResponse<List<OPERATOR>>> GetById(string siteId,
        //                                                          string operName)
        //{
        //    var response = await HttpUtils<ClientResponse<List<OPERATOR>>>.Get($"{AppUtil.BaseAuthenticationUrl}/account/getById", new
        //                                                                                                                           {
        //                                                                                                                                   SITE_ID =
        //                                                                                                                                           siteId,
        //                                                                                                                                   OPER_NAME =
        //                                                                                                                                           operName
        //                                                                                                                           });
        //    return response;
        //}

        //public async Task<ClientResponse<object>> Insert(OperatorInsertReq req)
        //{
        //    var response = await HttpUtils<ClientResponse<object>>.Post($"{AppUtil.BaseAuthenticationUrl}/account/Insert", req);
        //    return response;
        //}

        //public async Task<ClientResponse<object>> Update(OperatorUpdateReq req)
        //{
        //    var response = await HttpUtils<ClientResponse<object>>.Put($"{AppUtil.BaseAuthenticationUrl}/account/Update", req);
        //    return response;
        //}

        //public async Task<ClientResponse<object>> Delete(OperatorDeleteReq req)
        //{
        //    var response = await HttpUtils<ClientResponse<object>>.Delete($"{AppUtil.BaseAuthenticationUrl}/account/Delete", req);
        //    return response;
        //}

        #endregion
    }
}
