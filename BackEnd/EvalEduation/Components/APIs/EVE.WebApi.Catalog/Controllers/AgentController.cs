using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using EVE.ApiModels.Catalog;
using EVE.Commons;
using EVE.Data;
using EVE.WebApi.Shared;
using EVE.WebApi.Shared.Response;

namespace EVE.WebApi.Catalog.Controllers
{
    [RoutePrefix("api/agent")]
    public class AgentController : BaseController
    {

        public AgentController(IMapper mapper) : base(mapper)
        {
        }

        [Route("all")]
        public async Task<HttpResponseMessage> GetAll()
        {
            //var agents = await _agentBe.GetAllAsync();
            //if(agents != null
            //   && agents.Any())
            //{
            //    return this.OkResult(agents.ToList()
            //                               .RemoveWhiteSpaceForList());
            //}

            return this.OkResult();
        }

        //[Route("getById")]
        //public async Task<HttpResponseMessage> GetById([FromUri] AgentGetByIdReq req)
        //{
        //    //var agent = await _agentBe.GetById(req);
        //    //if(agent != null)
        //    //{
        //    //    return this.OkResult(agent.RemoveWhiteSpace());
        //    //}

        //    return this.ErrorResult(new Error(EnumError.AgentNotExist));
        //}

        //[HttpPost]
        //public async Task<HttpResponseMessage> Insert(AgentInsertReq req)
        //{
        //    //var existAgent = await _agentBe.GetById(req);
        //    //if(existAgent != null)
        //    //{
        //    //    return this.ErrorResult(new Error(EnumError.AgentHasExist));
        //    //}

        //    //_agentBe.Insert(Mapper.Map<AGENT>(req));
        //    return this.OkResult();
        //}

        //[HttpPut]
        //public async Task<HttpResponseMessage> Update(AgentUpdateReq req)
        //{
        //    //var agent = await _agentBe.GetById(req);
        //    //if(agent == null)
        //    //{
        //    //    return this.ErrorResult(new Error(EnumError.AgentNotExist));
        //    //}

        //    //Mapper.Map(req, agent);

        //    //_agentBe.Update(agent);

        //    return this.OkResult();
        //}

        //[HttpDelete]
        //public async Task<HttpResponseMessage> Delete(AgentDeleteReq req)
        //{
        //    //var agent = await _agentBe.GetById(req);
        //    //if(agent == null)
        //    //{
        //    //    return this.ErrorResult(new Error(EnumError.AgentNotExist));
        //    //}

        //    //_agentBe.Delete(agent);

        //    return this.OkResult();
        //}
    }
}
