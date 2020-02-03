using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemReeferGetByIdValidator))]
    public class ItemReeferGetByIdReq : ItemReeferBaseReq
    {
    }

    public class ItemReeferGetByIdValidator : AbstractValidator<ItemReeferGetByIdReq>
    {
    }
}
