using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemDeleteValidator))]
    public class ItemDeleteReq : ItemBaseReq
    {
    }

    public class ItemDeleteValidator : AbstractValidator<ItemDeleteReq>
    {
    }
}
