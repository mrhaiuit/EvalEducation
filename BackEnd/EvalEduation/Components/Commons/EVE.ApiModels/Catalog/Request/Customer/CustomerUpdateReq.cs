using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(CustomerUpdateValidator))]
    public class CustomerUpdateReq : CustomerInsertReq
    {
    }

    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateReq>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(c => c.CUST_REG_NO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CustomerNoIsNullOrEmpty).ToString());
        }
    }
}
