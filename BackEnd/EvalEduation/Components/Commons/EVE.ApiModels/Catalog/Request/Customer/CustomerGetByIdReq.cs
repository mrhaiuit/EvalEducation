using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(CustomerGetByIdValidator))]
    public class CustomerGetByIdReq : CustomerBaseReq
    {
    }

    public class CustomerGetByIdValidator : AbstractValidator<CustomerGetByIdReq>
    {
        public CustomerGetByIdValidator()
        {
            RuleFor(c => c.CUST_REG_NO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CustomerNoIsNullOrEmpty).ToString());
        }
    }
}
