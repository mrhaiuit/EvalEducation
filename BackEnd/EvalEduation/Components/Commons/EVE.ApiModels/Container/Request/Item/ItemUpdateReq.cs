using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemUpdateValidator))]
    public class ItemUpdateReq : ItemInsertReq
    {
    }

    public class ItemUpdateValidator : AbstractValidator<ItemUpdateReq>
    {
    }
}
