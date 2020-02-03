using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorMethodGetByIdValidator))]
    public class OperationMethodGetByIdReq : OperationMethodBaseReq
    {
    }

    public class OperatorMethodGetByIdValidator : AbstractValidator<OperationMethodGetByIdReq>
    {
        public OperatorMethodGetByIdValidator()
        {
            RuleFor(c => c.OPERATION_METHOD1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.OperationMethodIsNullOrEmpty).ToString());
        }
    }
}
