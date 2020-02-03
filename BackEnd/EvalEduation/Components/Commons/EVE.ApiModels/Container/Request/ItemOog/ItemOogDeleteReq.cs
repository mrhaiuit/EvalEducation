using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemOogDeleteValidator))]
    public class ItemOogDeleteReq : ItemOogBaseReq
    {
    }

    public class ItemOogDeleteValidator : AbstractValidator<ItemOogDeleteReq>
    {
    }
}
