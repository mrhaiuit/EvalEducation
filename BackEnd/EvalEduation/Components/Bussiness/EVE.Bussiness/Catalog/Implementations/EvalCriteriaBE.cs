using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public class EvalCriteriaBE : BaseBE<EvalCriteria>, IEvalCriteriaBE
    {
        public EvalCriteriaBE(IUnitOfWork<EVEEntities> uoW) : base(uoW)
        {
        }
        public async Task<EvalCriteria> GetById(EvalCriteriaBaseReq req)
        {
            var obj = await GetAsync(c => c.EvalCriteriaId == req.EvalCriteriaId);
            if(obj != null
               && obj.Any())
            {
                return obj.FirstOrDefault();
            }

            return null;
        }

    }
}
