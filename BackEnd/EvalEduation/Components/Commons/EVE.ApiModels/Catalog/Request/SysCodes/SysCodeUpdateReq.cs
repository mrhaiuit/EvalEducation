using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using System;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(SysCodeUpdateValidator))]
    public class SysCodeUpdateReq : SysCodeInsertReq
    {
        public DateTime UPD_TS { get; set; }
    }

    public class SysCodeUpdateValidator : AbstractValidator<SysCodeUpdateReq>
    {
        public SysCodeUpdateValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.CODE_TP)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CodeTpIsNullOrEmpty).ToString());
            RuleFor(c => c.CODE_REF)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CodeRefIsNullOrEmpty).ToString());
        }
    }
}
