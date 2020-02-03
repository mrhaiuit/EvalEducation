using EVE.Commons;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(PortCodeInsertValidator))]
    public class PortCodeInsertReq : PortCodeBaseReq
    {
        public string UN_PORT { get; set; }

        public string UN_COUNTRY { get; set; }

        public string DESCR { get; set; }

        public string TERMINAL_FLG { get; set; }

        public string UN_PORTCODE { get; set; }
    }

    public class PortCodeInsertValidator : AbstractValidator<PortCodeInsertReq>
    {
        public PortCodeInsertValidator()
        {
            RuleFor(c => c.PORT)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int) EnumError.PortIsNullOrEmpty).ToString());
        }
    }
}
