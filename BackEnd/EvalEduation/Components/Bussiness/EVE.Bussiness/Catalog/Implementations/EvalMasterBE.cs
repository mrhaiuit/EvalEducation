using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public class EvalMasterBE : BaseBE<EvalMaster>, IEvalMasterBE
    {
        public EvalMasterBE(IUnitOfWork<EVEEntities> uoW) : base(uoW)
        {
        }
        public async Task<EvalMaster> GetById(EvalMasterBaseReq req)
        {
            var obj = await GetAsync(c => c.EvalMasterId == req.EvalMasterId);
            if(obj != null
               && obj.Any())
            {
                return obj.FirstOrDefault();
            }

            return null;
        }

    }
}
