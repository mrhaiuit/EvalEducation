using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(EduProvinceInsertValidator))]
    public class EduProvinceInsertReq : EduProvinceBaseReq
    {
        public string EduProvinceName { get; set; }
        public Nullable<int> Idx { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public string MinistryofEducationaCode { get; set; }
    }

    public class EduProvinceInsertValidator : AbstractValidator<EduProvinceInsertReq>
    {
        public EduProvinceInsertValidator()
        {
            RuleFor(c => c.EduProvinceId)
                    .NotNull()
                    .NotEmpty();
        }
    }
}
