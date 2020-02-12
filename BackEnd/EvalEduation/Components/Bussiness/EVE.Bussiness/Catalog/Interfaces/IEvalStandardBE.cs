using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public interface IEvalStandardBE : IBaseBE<EvalStandard>
    {

        Task<EvalStandard> GetById(EvalStandardBaseReq req);
    }
}
