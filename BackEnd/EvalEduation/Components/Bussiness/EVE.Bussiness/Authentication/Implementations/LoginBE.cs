using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request;
using EVE.Commons;
using EVE.Data;

namespace EVE.Bussiness
{
    public class LoginBE : BaseBE<Employee>, ILoginBE
    {
        public LoginBE(IUnitOfWork<EVEEntities> uoW) : base(uoW)
        {
        }

        #region ILogonUserBE Members

        public async Task<Employee> GetEmployeeByAccount(LoginReq req)
        {
            try
            {
                req.PassWord = req.PassWord.EncodePassword();
                var users = await GetAsync(c => c.UserName == req.UserName && c.Password == req.PassWord);
                if (users != null
                   && users.Any())
                {
                    return users.FirstOrDefault();
                }
                return null;
            }
            catch(Exception ex)
            {

                return null;
            }
        }

        public async Task< bool> SaveLogin(LoginUser loginUser)
        {
            try
            {
                var logonRepository = _uoW.Repository<LoginUser>();
              var result=  logonRepository.Insert(loginUser);
                if (result != null)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

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
