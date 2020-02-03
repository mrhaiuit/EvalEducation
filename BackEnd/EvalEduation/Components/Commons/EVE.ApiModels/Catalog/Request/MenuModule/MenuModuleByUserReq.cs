using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(MenuModuleByUserReqValidator))]
    public class MenuModuleByUserReq
    {
        public string OPERATOR { get; set; }
    }

    public class MenuModuleByUserReqValidator : AbstractValidator<MenuModuleByUserReq>
    {
        public MenuModuleByUserReqValidator()
        {
            RuleFor(c => c.OPERATOR)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.UsernameIsNullOrEmpty).ToString());
        }
    }
}
