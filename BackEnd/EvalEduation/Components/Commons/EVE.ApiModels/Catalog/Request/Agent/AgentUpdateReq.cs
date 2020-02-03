using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(AgentUpdateValidator))]
    public class AgentUpdateReq : AgentInsertReq
    {
    }

    public class AgentUpdateValidator : AbstractValidator<AgentUpdateReq>
    {
        public AgentUpdateValidator()
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
