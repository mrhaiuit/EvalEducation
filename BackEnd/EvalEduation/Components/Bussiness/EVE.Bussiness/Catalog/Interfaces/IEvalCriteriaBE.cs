using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public interface IEvalCriteriaBE : IBaseBE<EvalCriteria>
    {

        Task<EvalCriteria> GetById(EvalCriteriaBaseReq req);
    }
}
