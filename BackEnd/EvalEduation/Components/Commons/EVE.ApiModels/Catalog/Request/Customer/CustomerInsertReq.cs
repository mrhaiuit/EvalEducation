using EVE.Commons;
using EVE.WebApi.Shared;
using FluentValidation;
using FluentValidation.Attributes;

namespace EVE.ApiModels.Catalog
{
    [Validator(typeof(CustomerInsertValidator))]
    public class CustomerInsertReq : CustomerBaseReq
    {
        public string SITE_ID { get; set; }

        public string TAX_FILE_NO { get; set; }

        public string CUST_TYPE { get; set; }

        public string FULL_NAME { get; set; }

        public string PHONE { get; set; }

        public string FAX { get; set; }

        public string MOBILE { get; set; }

        public string ADDR1 { get; set; }

        public string ADDR2 { get; set; }

        public string ADDR3 { get; set; }

        public string ADDR4 { get; set; }

        public string EMAIL { get; set; }

        public string CONTACT_NAME { get; set; }

        public string ACC_NO { get; set; }

        public string STOP_YN { get; set; }

        public string OPER_NAME { get; set; }

        public string PAY_COD { get; set; }

        public string IS_FREIGHT_FORWARDER { get; set; }

        public string COUNTRY { get; set; }

        public string LICENSE_NUMBER { get; set; }

        public string BANK_ID { get; set; }

        public string CUST_GROUP { get; set; }

        public short? MAX_STORAGE_DAYS { get; set; }

        public string COMMENTS { get; set; }

        public string CMID { get; set; }

        public string ACC_CATEGORY { get; set; }

        public string EXACT_PROC_FLG { get; set; }

        public string IS_TOKEN_REG { get; set; }

        public string EMAIL_THC { get; set; }

        public string E_INVOICE_ISSUE_FLG { get; set; }

        public string AGENT_CODE { get; set; }

        public string BILL_AGENT { get; set; }
    }

    public class CustomerInsertValidator : AbstractValidator<CustomerInsertReq>
    {
        public CustomerInsertValidator()
        {
            RuleFor(c => c.CUST_REG_NO)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage(((int)EnumError.CustomerNoIsNullOrEmpty).ToString());
        }
    }
}
