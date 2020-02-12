using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using EVE.ApiModels.Authentication.Request;
using EVE.Bussiness;
using EVE.Commons;
using EVE.Data;
using EVE.WebApi.Authentication.Helper;
using EVE.WebApi.Shared;
using EVE.WebApi.Shared.Response;

namespace EVE.WebApi.Controllers
{
    [RoutePrefix("auth")]
    public class AuthenticationController : BaseController
    {
        private readonly ILoginBE _loginBE;
        public AuthenticationController(ILoginBE loginBE,
                               IMapper mapper) : base(mapper)
        {
            _loginBE = loginBE;
        }

        [HttpPost]
        [Route("logon")]
        public async Task<HttpResponseMessage> Login(LoginReq req)
        {
            var employee = await _loginBE.GetEmployeeByAccount(req);
            if (employee != null)
            {
                var curTime = DateTime.Now;

                var logonUser = new LoginUser
                {
                    UserName = employee.UserName,
                    UserId = employee.EmployeeCode,
                    IpAddress = AppUtil.GetClientIp(Request),
                    LoginDate = curTime,
                    UpdTs = curTime
                };

               await _loginBE.SaveLogin(logonUser);

                return this.OkResult(new
                {
                    logonUser.IpAddress,
                    logonUser.UserName,
                    USER_ID = logonUser.UserId.Trim(),
                    logonUser.LoginDate,
                    logonUser.UpdTs
                });
            }

            return this.ErrorResult(new Error(EnumError.LogonInvalid));
        }

       
    }
}
