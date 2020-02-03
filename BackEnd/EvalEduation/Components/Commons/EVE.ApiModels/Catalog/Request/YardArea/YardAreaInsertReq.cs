using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(YardAreaInsertValidator))]
    public class YardAreaInsertReq : YardAreaBaseReq
    {
        public string X1 { get; set; }

        public string X2 { get; set; }

        public string REGION { get; set; }

        public DateTime? FR_DATE { get; set; }

        public DateTime? TO_DATE { get; set; }

        public string CUSTOM_AREA { get; set; }

        public string MANAGE_BY { get; set; }

        public string CFS_AREA { get; set; }

        public string STUFF_STRIP_AREA { get; set; }

        public int? MAX_TEU { get; set; }

        public string DIRECT_LOAD_DISCH_AREA { get; set; }

        public string EXPORT_AREA { get; set; }

        public string SCAN_AREA { get; set; }

        public string PTI_AREA { get; set; }

        public string WEIGHTING_AREA { get; set; }

        public string CTN_TYPE { get; set; }

        public string IS_VIRTUAL_HEAP_STACK { get; set; }

        public string VHS_TYPE { get; set; }

        public int? MAX_TEU80 { get; set; }

        public int? MAX_TEU90 { get; set; }
    }

    public class YardAreaInsertValidator : AbstractValidator<YardAreaInsertReq>
    {
        public YardAreaInsertValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.AREA)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.AreaIsNullOrEmpty).ToString());
            RuleFor(c => c.STACK)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.StackIsNullOrEmpty).ToString());
        }

        public override ValidationResult Validate(ValidationContext<YardAreaInsertReq> context)
        {
            return context.InstanceToValidate == null
                           ? new ValidationResult(new[] {new ValidationFailure("Request", "Request can not null")})
                           : base.Validate(context);
        }
    }
}
