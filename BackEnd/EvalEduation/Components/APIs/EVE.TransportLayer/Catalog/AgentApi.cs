using System.Collections.Generic;
using System.Threading.Tasks;
using EVE.Commons.Response;
using EVE.Data;

namespace EVE.TransportLayer
{
    public interface IAgentApi
    {
        //Task<ClientResponse<List<AGENT>>> GetAll();

        //Task<ClientResponse<AGENT>> GetById(string siteId,
        //                                    string agentId);
    }

    public class AgentApi : IAgentApi
    {
        #region IAgentApi Members

        //public async Task<ClientResponse<List<AGENT>>> GetAll()
        //{
        //    var response = await HttpUtils<ClientResponse<List<AGENT>>>.Get($"{AppUtil.BaseCatalogUrl}/agent/all", null);
        //    return response;
        //}

        //public async Task<ClientResponse<AGENT>> GetById(string siteId,
        //                                                 string agentId)
        //{
        //    var response = await HttpUtils<ClientResponse<AGENT>>.Get($"{AppUtil.BaseCatalogUrl}/agent/getById", new
        //                                                                                                         {
        //                                                                                                                 SITE_ID = siteId,
        //                                                                                                                 AGENT = agentId
        //                                                                                                         });
        //    return response;
        //}

        #endregion
    }
}
