using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemOogUpdateValidator))]
    public class ItemOogUpdateReq : ItemOogInsertReq
    {
    }

    public class ItemOogUpdateValidator : AbstractValidator<ItemOogUpdateReq>
    {
    }
}
