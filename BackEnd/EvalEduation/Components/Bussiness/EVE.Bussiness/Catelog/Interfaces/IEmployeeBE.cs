using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request;
using EVE.Data;

namespace EVE.Bussiness
{
    public interface IEmployeeBE : IBaseBE<Employee>
    {

        Task<Employee> GetById(EmployeeBaseReq req);
    }
}
