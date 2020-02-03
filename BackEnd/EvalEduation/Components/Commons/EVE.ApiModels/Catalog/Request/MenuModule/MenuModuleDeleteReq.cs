using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuModuleDeleteValidator))]
    public class MenuModuleDeleteReq : MenuModuleBaseReq
    {
    }

    public class MenuModuleDeleteValidator : AbstractValidator<MenuModuleDeleteReq>
    {
        public MenuModuleDeleteValidator()
        {
            RuleFor(c => c.MODULE_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }
    }
}
