using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(CustomerDeleteValidator))]
    public class CustomerDeleteReq : CustomerBaseReq
    {
    }

    public class CustomerDeleteValidator : AbstractValidator<CustomerDeleteReq>
    {
        public CustomerDeleteValidator()
        {
            RuleFor(c => c.CUST_REG_NO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CustomerNoIsNullOrEmpty).ToString());
        }
    }
}
