using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemChargesDeleteValidator))]
    public class ItemChargesDeleteReq : ItemChargesBaseReq
    {
    }

    public class ItemChargesDeleteValidator : AbstractValidator<ItemChargesDeleteReq>
    {
    }
}
