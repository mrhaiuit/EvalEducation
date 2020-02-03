using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request.Account;
using EVE.Data;

namespace EVE.Bussiness
{
    public interface ILoginBE : IBaseBE<Employee>
    {
        Task<Employee> GetOperator(LogonReq req);

        Task<bool> SaveLogon(LoginUser logonUser);

        Task<Employee> GetById(OperatorBaseReq req);
    }
}
