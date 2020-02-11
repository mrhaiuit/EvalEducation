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

        #region ILogonUserBE Members

        public async Task<Employee> GetById(EmployeeBaseReq req)
        {
            var operators = await GetAsync(c => string.Equals(c.EmployeeId, req.EmployeeId) );
            if(operators != null
               && operators.Any())
            {
                return operators.FirstOrDefault();
            }

            return null;
        }

        #endregion
    }
}
