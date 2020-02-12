using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request;
using EVE.Commons;
using EVE.Data;

namespace EVE.Bussiness
{
    public class EmployeeBE : BaseBE<Employee>, IEmployeeBE
    {
        public EmployeeBE(IUnitOfWork<EVEEntities> uoW) : base(uoW)
        {
        }
        public async Task<Employee> GetById(EmployeeBaseReq req)
        {
            var obj = await GetAsync(c => c.EmployeeId == req.EmployeeId);
            if(obj != null
               && obj.Any())
            {
                return obj.FirstOrDefault();
            }

            return null;
        }

    }
}
