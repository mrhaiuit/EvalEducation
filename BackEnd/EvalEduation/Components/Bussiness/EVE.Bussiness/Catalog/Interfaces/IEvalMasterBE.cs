using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public interface IEvalMasterBE : IBaseBE<EvalMaster>
    {

        Task<EvalMaster> GetById(EvalMasterBaseReq req);
    }
}
