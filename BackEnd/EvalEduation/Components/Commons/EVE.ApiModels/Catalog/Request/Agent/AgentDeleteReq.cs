using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(AgentDeleteValidator))]
    public class AgentDeleteReq : AgentBaseReq
    {
    }

    public class AgentDeleteValidator : AbstractValidator<AgentDeleteReq>
    {
        public AgentDeleteValidator()
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
