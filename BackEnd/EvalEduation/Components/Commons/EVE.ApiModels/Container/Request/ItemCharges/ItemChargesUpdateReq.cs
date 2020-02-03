using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Container.Request
{
    [Validator(typeof(ItemChargesUpdateValidator))]
    public class ItemChargesUpdateReq : ItemChargesInsertReq
    {
    }

    public class ItemChargesUpdateValidator : AbstractValidator<ItemChargesUpdateReq>
    {
    }
}
