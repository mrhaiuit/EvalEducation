using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemChargesGetByIdValidator))]
    public class ItemChargesGetByIdReq : ItemChargesBaseReq
    {
    }

    public class ItemChargesGetByIdValidator : AbstractValidator<ItemChargesGetByIdReq>
    {
    }
}
