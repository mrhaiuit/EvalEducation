using System;
using System.Linq;
using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request.Account;
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

        public async Task<Employee> GetOperator(LogonReq req)
        {
            req.UserName = OperPwdEncode(req.UserName);
            var users = await GetAsync(c => c.EmployeeCode == req.PassWord && c.Password == req.PassWord);
            if(users != null
               && users.Any())
            {
                return users.FirstOrDefault();
            }

            return null;
        }

        public async Task< bool> SaveLogon(LoginUser loginUser)
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

        public async Task<Employee> GetById(OperatorBaseReq req)
        {
            var fixLengthReq = req.FixLength(_uoW.Context, nameof(Employee));
            var operators = await GetAsync(c => string.Equals(c.SITE_ID, fixLengthReq.SITE_ID) && string.Equals(c.OPER_NAME, fixLengthReq.OPER_NAME));
            if(operators != null
               && operators.Any())
            {
                return operators.FirstOrDefault();
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
