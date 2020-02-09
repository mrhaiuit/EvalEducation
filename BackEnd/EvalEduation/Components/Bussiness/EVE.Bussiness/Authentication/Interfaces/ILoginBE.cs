﻿using System.Threading.Tasks;
using EVE.ApiModels.Authentication.Request;
using EVE.Data;

namespace EVE.Bussiness
{
    public interface ILoginBE : IBaseBE<Employee>
    {
        Task<Employee> GetEmployeeByAccount(LoginReq req);

        Task<bool> SaveLogin(LoginUser logonUser);

        Task<Employee> GetById(EmployeeBaseReq req);
    }
}
