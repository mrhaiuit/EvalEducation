using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using EVE.ApiModels.Authentication.Request.Account;
using EVE.Commons;
using EVE.Data;
using EVE.WebApi.Authentication.Helper;
using EVE.WebApi.Shared;
using EVE.WebApi.Shared.Response;

namespace EVE.WebApi.Authentication.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        public AccountController()
        {
        }

        [HttpPost]
        [Route("logon")]
        public async Task<HttpResponseMessage> Logon(LogonReq req)
        {
            //var user = await _logonUserBe.GetOperator(req);
            //if(user != null)
            //{
            //    var curTime = DateTime.Now;

            //    var logonUser = new LOGON_USER
            //                    {
            //                            USER_NAME = user.FULL_NAME,
            //                            USER_ID = user.OPER_NAME,
            //                            IP_ADDRESS = AppUtil.GetClientIp(Request),
            //                            LOGON_DATE = curTime,
            //                            UPD_TS = curTime
            //                    };

            //    _logonUserBe.SaveLogon(logonUser);

            //    return this.OkResult(new
            //                         {
            //                                 logonUser.IP_ADDRESS,
            //                                 logonUser.USER_NAME,
            //                                 USER_ID = logonUser.USER_ID.Trim(),
            //                                 logonUser.LOGON_DATE,
            //                                 logonUser.UPD_TS
            //                         });
            //}

            return this.ErrorResult(new Error(EnumError.LogonInvalid));
        }

        [Route("all")]
        public async Task<HttpResponseMessage> GetAll()
        {
            //var agents = await _logonUserBe.GetAllAsync();
            //if(agents != null
            //   && agents.Any())
            //{
            //    return this.OkResult(agents.ToList()
            //                               .RemoveWhiteSpaceForList());
            //}

            return this.OkResult();
        }

        [Route("getById")]
        public HttpResponseMessage GetById([FromUri] OperatorGetByIdReq req)
        {
            //var agent = _logonUserBe.GetById(req);
            //if(agent != null)
            //{
            //    return this.OkResult(agent.RemoveWhiteSpace());
            //}

            return this.ErrorResult(new Error(EnumError.AgentNotExist));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert(OperatorInsertReq req)
        {
            //var existAgent = await _logonUserBe.GetById(req);
            //if(existAgent != null)
            //{
            //    return this.ErrorResult(new Error(EnumError.AgentHasExist));
            //}

            //_logonUserBe.Insert(Mapper.Map<OPERATOR>(req));
            return this.OkResult();
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update(OperatorUpdateReq req)
        {
            //var agent = await _logonUserBe.GetById(req);
            //if(agent == null)
            //{
            //    return this.ErrorResult(new Error(EnumError.AgentNotExist));
            //}

            //Mapper.Map(req, agent);

            //_logonUserBe.Update(agent);

            return this.OkResult();
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(OperatorDeleteReq req)
        {
            //var agent = await _logonUserBe.GetById(req);
            //if(agent == null)
            //{
            //    return this.ErrorResult(new Error(EnumError.AgentNotExist));
            //}

            //_logonUserBe.Delete(agent);

            return this.OkResult();
        }
    }
}
