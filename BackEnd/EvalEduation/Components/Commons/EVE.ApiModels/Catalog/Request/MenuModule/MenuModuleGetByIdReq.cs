using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuModuleGetByIdValidator))]
    public class MenuModuleGetByIdReq : MenuModuleBaseReq
    {

    }

    public class MenuModuleGetByIdValidator : AbstractValidator<MenuModuleGetByIdReq>
    {
        public MenuModuleGetByIdValidator()
        {
            RuleFor(c => c.MODULE_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }
    }
}
