using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorGetByIdValidator))]
    public class OperatorGetByIdReq : OperatorBaseReq
    {

    }

    public class OperatorGetByIdValidator : AbstractValidator<OperatorGetByIdReq>
    {
        public OperatorGetByIdValidator()
        {
            RuleFor(c => c.SITE_ID)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
            RuleFor(c => c.OPER_NAME)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }

    }
}
