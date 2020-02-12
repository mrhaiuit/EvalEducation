using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Authentication.Request
{
    [Validator(typeof(OperatorInsertValidator))]
    public class EmployeeInsertReq : EmployeeBaseReq
    {
        public string EmployeeCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MinistryofEducationaCode { get; set; }
        public Nullable<int> EduProvinceId { get; set; }
        public Nullable<int> EduDepartmentId { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Remarks { get; set; }
        public string EduLevelCode { get; set; }
    }

    public class OperatorInsertValidator : AbstractValidator<EmployeeInsertReq>
    {
        public OperatorInsertValidator()
        {
            RuleFor(c => c.EmployeeId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.SiteIdIsNullOrEmpty).ToString());
        }
    }
}
