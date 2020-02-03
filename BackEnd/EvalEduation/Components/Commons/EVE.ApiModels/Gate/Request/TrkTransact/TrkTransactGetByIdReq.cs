using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Gate
{
    [Validator(typeof(TrkTransactGetByIdValidator))]
    public class TrkTransactGetByIdReq : TrkTransactBaseReq
    {
    }

    public class TrkTransactGetByIdValidator : AbstractValidator<TrkTransactGetByIdReq>
    {
    }
}
