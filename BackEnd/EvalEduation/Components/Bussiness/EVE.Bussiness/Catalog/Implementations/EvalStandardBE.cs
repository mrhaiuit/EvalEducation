using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Catalog;
using EVE.Data;

namespace EVE.Bussiness
{
    public class EvalStandardBE : BaseBE<EvalStandard>, IEvalStandardBE
    {
        public EvalStandardBE(IUnitOfWork<EVEEntities> uoW) : base(uoW)
        {
        }
        public async Task<EvalStandard> GetById(EvalStandardBaseReq req)
        {
            var obj = await GetAsync(c => c.EvalStandardId == req.EvalStandardId);
            if(obj != null
               && obj.Any())
            {
                return obj.FirstOrDefault();
            }

            return null;
        }

    }
}
