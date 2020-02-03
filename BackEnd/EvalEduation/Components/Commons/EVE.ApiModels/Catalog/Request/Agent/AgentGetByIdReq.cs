using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(AgentGetByIdValidator))]
    public class AgentGetByIdReq : AgentBaseReq
    {
    }

    public class AgentGetByIdValidator : AbstractValidator<AgentGetByIdReq>
    {
        public AgentGetByIdValidator()
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
