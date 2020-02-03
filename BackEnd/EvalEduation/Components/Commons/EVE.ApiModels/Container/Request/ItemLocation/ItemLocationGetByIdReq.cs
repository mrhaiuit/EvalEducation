using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemLocationGetByIdValidator))]
    public class ItemLocationGetByIdReq : ItemLocationBaseReq
    {
    }

    public class ItemLocationGetByIdValidator : AbstractValidator<ItemLocationGetByIdReq>
    {
    }
}
