using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkTransactUpdateValidator))]
    public class TrkTransactUpdateReq : TrkTransactInsertReq
    {
    }

    public class TrkTransactUpdateValidator : AbstractValidator<TrkTransactUpdateReq>
    {
    }
}
