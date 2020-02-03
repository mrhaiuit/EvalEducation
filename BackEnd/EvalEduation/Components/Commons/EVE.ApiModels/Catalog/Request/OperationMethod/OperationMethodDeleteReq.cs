using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorMethodDeleteValidator))]
    public class OperationMethodDeleteReq : OperationMethodBaseReq
    {
    }

    public class OperatorMethodDeleteValidator : AbstractValidator<OperationMethodDeleteReq>
    {
        public OperatorMethodDeleteValidator()
        {
            RuleFor(c => c.OPERATION_METHOD1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.OperationMethodIsNullOrEmpty).ToString());
        }
    }
}
