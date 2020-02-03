using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemReeferUpdateValidator))]
    public class ItemReeferUpdateReq : ItemReeferInsertReq
    {
    }

    public class ItemReeferUpdateValidator : AbstractValidator<ItemReeferUpdateReq>
    {
    }
}
