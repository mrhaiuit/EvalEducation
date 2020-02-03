using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuModuleUpdateValidator))]
    public class MenuModuleUpdateReq : MenuModuleInsertReq
    {
    }

    public class MenuModuleUpdateValidator : AbstractValidator<MenuModuleUpdateReq>
    {
        public MenuModuleUpdateValidator()
        {
            RuleFor(c => c.MODULE_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }
    }
}
