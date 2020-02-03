using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemDamageDeleteValidator))]
    public class ItemDamageDeleteReq : ItemDamageBaseReq
    {
    }

    public class ItemDamageDeleteValidator : AbstractValidator<ItemDamageDeleteReq>
    {
    }
}
