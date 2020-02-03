using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(OperatorMethodUpdateValidator))]
    public class OperationMethodUpdateReq : OperationMethodInsertReq
    {
    }

    public class OperatorMethodUpdateValidator : AbstractValidator<OperationMethodUpdateReq>
    {
        public OperatorMethodUpdateValidator()
        {
            RuleFor(c => c.OPERATION_METHOD1)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.OperationMethodIsNullOrEmpty).ToString());
        }
    }
}
