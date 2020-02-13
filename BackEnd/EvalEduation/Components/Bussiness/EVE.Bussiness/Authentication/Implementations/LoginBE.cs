using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request;
using EVE.Commons;
using EVE.Data;

namespace EVE.Bussiness
{
    public class LoginBE : BaseBE<Employee>, ILoginBE
    {
        private IUserGroupEmployeeBE UserGroupEmployeeBE { get; set; }
        public LoginBE(IUnitOfWork<EVEEntities> uoW, IUserGroupEmployeeBE userGroupEmployeeBE) : base(uoW)
        {
            UserGroupEmployeeBE = userGroupEmployeeBE;
        }

        #region ILogonUserBE Members

        public async Task<Employee> GetEmployeeByAccount(LoginReq req)
        {
            try
            {
                req.PassWord = OperPwdEncode(req.PassWord);
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

        public async Task<bool> SaveLogin(LoginUser loginUser)
        {
            try
            {
                var logonRepository = _uoW.Repository<LoginUser>();
                var result = logonRepository.Insert(loginUser);
                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<UserGroup_Employee>> GetUserGroupByUserName(string userName)
        {
            var obj = await UserGroupEmployeeBE.GetAsync(p => p.Employee.UserName == userName);
            if (obj != null
               && obj.Any())
            {
                return obj.ToList();
            }

            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Encode input string to value number
        /// </summary>
        /// <param name="passpwd"></param>
        /// <returns></returns>
        private string OperPwdEncode(string passpwd)
        {
            string returnValue = " ";
            int i = 1;
            int k;
            double strPwd = 0;
            var ArrPwd = new int[31];

            foreach (char ch in passpwd)
            {
                if(ch.ToString()
                     .IsNumber())
                {
                    ArrPwd[i] = ch.CheckIntEx();
                }
                else
                {
                    ArrPwd[i] = ch;
                }

                i++;
            }

            for (k = 1; k <= i - 1; k++)
            {
                strPwd = strPwd + ArrPwd[k];

                strPwd = strPwd * (k + i);
            }

            returnValue = strPwd.ToString();

            return returnValue;
        }
    }
}
