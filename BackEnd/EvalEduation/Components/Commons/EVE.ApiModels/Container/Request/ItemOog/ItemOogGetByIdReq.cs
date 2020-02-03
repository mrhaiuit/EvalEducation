using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemOogGetByIdValidator))]
    public class ItemOogGetByIdReq : ItemOogBaseReq
    {
    }

    public class ItemOogGetByIdValidator : AbstractValidator<ItemOogGetByIdReq>
    {
    }
}
