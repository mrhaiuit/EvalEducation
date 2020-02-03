using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemLocationUpdateValidator))]
    public class ItemLocationUpdateReq : ItemLocationInsertReq
    {
    }

    public class ItemLocationUpdateValidator : AbstractValidator<ItemLocationUpdateReq>
    {
    }
}
