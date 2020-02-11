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

namespace EVE.WebApi.Authentication.Controllers
{
    [RoutePrefix("catalog")]
    public class CatalogController : BaseController
    {
        private readonly ILoginBE _loginBE;
        public CatalogController(ILoginBE loginBE,
                               IMapper mapper) : base(mapper)
        {
            _loginBE = loginBE;
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
        public HttpResponseMessage GetById([FromUri] EmployeeGetByIdReq req)
        {
            //var agent = _logonUserBe.GetById(req);
            //if(agent != null)
            //{
            //    return this.OkResult(agent.RemoveWhiteSpace());
            //}

            return this.ErrorResult(new Error(EnumError.AgentNotExist));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert(EmployeeInsertReq req)
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
        public async Task<HttpResponseMessage> Update(EmployeeUpdateReq req)
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
        public async Task<HttpResponseMessage> Delete(EmployeeDeleteReq req)
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
