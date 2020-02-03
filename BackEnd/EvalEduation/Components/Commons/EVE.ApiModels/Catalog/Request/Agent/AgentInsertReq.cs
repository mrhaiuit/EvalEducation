using System;
using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(AgentInsertValidator))]
    public class AgentInsertReq : AgentBaseReq
    {
        public string LINE_OPER { get; set; }

        public string LINE_PRINT_SEPARATE { get; set; }

        public DateTime AS_AT_TS { get; set; }

        public DateTime EXPIRY_TS { get; set; }

        public string CONT_TYPE { get; set; }

        public string FEL { get; set; }
    }

    public class AgentInsertValidator : AbstractValidator<AgentInsertReq>
    {
        public AgentInsertValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.SiteIdIsNullOrEmpty).ToString());
            RuleFor(c => c.AGENT1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.AgentIdIsNullOrEmpty).ToString());
        }
    }
}
