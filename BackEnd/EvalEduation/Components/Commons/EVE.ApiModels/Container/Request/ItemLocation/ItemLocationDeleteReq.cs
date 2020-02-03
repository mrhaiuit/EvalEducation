using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemLocationDeleteValidator))]
    public class ItemLocationDeleteReq : ItemLocationBaseReq
    {
    }

    public class ItemLocationDeleteValidator : AbstractValidator<ItemLocationDeleteReq>
    {
    }
}
