using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkTransactDeleteValidator))]
    public class TrkTransactDeleteReq : TrkTransactBaseReq
    {
    }

    public class TrkTransactDeleteValidator : AbstractValidator<TrkTransactDeleteReq>
    {
    }
}
