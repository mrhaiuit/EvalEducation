using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemDamageGetByIdValidator))]
    public class ItemDamageGetByIdReq : ItemDamageBaseReq
    {
    }

    public class ItemDamageGetByIdValidator : AbstractValidator<ItemDamageGetByIdReq>
    {
    }
}
