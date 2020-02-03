using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuGroupInsertValidator))]
    public class MenuGroupInsertReq : MenuGroupBaseReq
    {
        public string GROUP_NAME { get; set; }

        public short? IDX { get; set; }

        public string IMAGE { get; set; }
    }

    public class MenuGroupInsertValidator : AbstractValidator<MenuGroupInsertReq>
    {
        public MenuGroupInsertValidator()
        {
            RuleFor(c => c.MENU_MODULE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.MenuModuleIsNullOrEmpty).ToString());
            RuleFor(c => c.GROUP_CODE)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.GroupCodeIsNullOrEmpty).ToString());
        }
    }
}
