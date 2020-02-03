using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemGetByIdValidator))]
    public class ItemGetByIdReq : ItemBaseReq
    {
    }

    public class ItemGetByIdValidator : AbstractValidator<ItemGetByIdReq>
    {
    }
}
