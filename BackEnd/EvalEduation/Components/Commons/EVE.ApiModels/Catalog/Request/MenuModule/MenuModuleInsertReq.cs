using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuModuleInsertValidator))]
    public class MenuModuleInsertReq : MenuModuleBaseReq
    {
        public string GROUP_NAME { get; set; }

        public short? IDX { get; set; }

        public string IMAGE { get; set; }
    }

    public class MenuModuleInsertValidator : AbstractValidator<MenuModuleInsertReq>
    {
        public MenuModuleInsertValidator()
        {
            RuleFor(c => c.MODULE_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.ModuleCodeIsNullOrEmpty).ToString());
        }
    }
}
