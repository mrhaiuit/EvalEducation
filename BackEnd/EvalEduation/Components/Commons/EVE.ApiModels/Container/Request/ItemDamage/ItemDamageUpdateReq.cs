using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemDamageUpdateValidator))]
    public class ItemDamageUpdateReq : ItemDamageInsertReq
    {
    }

    public class ItemDamageUpdateValidator : AbstractValidator<ItemDamageUpdateReq>
    {
    }
}
