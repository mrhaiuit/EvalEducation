using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemReeferDeleteValidator))]
    public class ItemReeferDeleteReq : ItemReeferBaseReq
    {
    }

    public class ItemReeferDeleteValidator : AbstractValidator<ItemReeferDeleteReq>
    {
    }
}
