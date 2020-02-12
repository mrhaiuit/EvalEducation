using EVE.Commons.Attribute;

namespace EVE.Commons
{
    public enum EnumError
    {
        #region 400xxx

        [StringValue("Chi tiết không được để trống")]
        ArrayDetailIsNullOrEmpty = 400000,

        [StringValue("Tên đăng nhập không được để trống")]
        UsernameIsNullOrEmpty = 400100,

        [StringValue("Mật khẩu không được để trống")]
        PasswordIsNullOrEmpty = 400200,

        [StringValue("Nhóm người dùng không được để trống")]
        UserClassIsNullOrEmpty = 400300,

        [StringValue("SiteId không được để trống")]
        SiteIdIsNullOrEmpty = 400400,

        [StringValue("Mã khách hàng không được để trống")]
        AgentIdIsNullOrEmpty = 400500,

        [StringValue("Khu vực không được để trống")]
        AreaIsNullOrEmpty = 400600,

        [StringValue("Stack không được để trống")]
        StackIsNullOrEmpty = 400700,

        [StringValue("CodeTp không được để trống")]
        CodeTpIsNullOrEmpty = 400800,

        [StringValue("CodeRef không được để trống")]
        CodeRefIsNullOrEmpty = 400900,

        [StringValue("MENU_MODULE không được để trống")]
        MenuModuleIsNullOrEmpty = 400010,

        [StringValue("GROUP_CODE không được để trống")]
        GroupCodeIsNullOrEmpty = 400110,

        [StringValue("MENU_ITEM_CODE không được để trống")]
        MenuItemCodeIsNullOrEmpty = 400210,

        [StringValue("OPERATION_METHOD không được để trống")]
        OperationMethodIsNullOrEmpty = 400310,

        [StringValue("LINE_OPER không được để trống")]
        LineOperIsNullOrEmpty = 400410,

        [StringValue("DEPOT không được để trống")]
        DepotIsNullOrEmpty = 400510,

        [StringValue("Mã khách hàng không được để trống")]
        CustomerNoIsNullOrEmpty = 400610,

        [StringValue("Iso không được để trống")]
        IsoIsNullOrEmpty = 400710,

        [StringValue("Module Code không được để trống")]
        ModuleCodeIsNullOrEmpty = 400810,

        [StringValue("Truck key không được để trống")]
        TruckKeyIsNullOrEmpty = 400910,

        [StringValue("Truck key không được để trống")]
        MenuItemActionCodeIsNullOrEmpty = 400020,

        [StringValue("EIR_ID không được để trống")]
        EirIdIsNullOrEmpty = 400120,

        [StringValue("TRK_ID không được để trống")]
        TrkIdIsNullOrEmpty = 400220,

        [StringValue("VES_CD không được để trống")]
        VesCdIsNullOrEmpty = 400320,

        [StringValue("PORT không được để trống")]
        PortIsNullOrEmpty = 400420,

        #endregion

        #region 500xxx

        [StringValue("Something wrong :(")]
        BadRequest = 500000,

        [StringValue("Tên đăng nhập hoặc mật khẩu không chính xác")]
        LogonInvalid = 500100,

        [StringValue("Người dùng không thuộc nhóm này")]
        UserClassInvalid = 500200,

        [StringValue("Mã khách hàng đã tồn tại")]
        AgentHasExist = 500300,

        [StringValue("Khách hàng không tồn tại")]
        AgentNotExist = 500400,

        [StringValue("Phòng đào tạo đã tồn tại")]
        EduDepartmentHasExist = 500500,

        [StringValue("Phòng đào tạo không tồn tại")]
        EduDepartmentNotExist = 500600,

        [StringValue("Nhân viên đã tồn tại")]
        EmployeeHasExist = 500700,

        [StringValue("Nhân viên không tồn tại")]
        EmployeeNotExist = 500800,

        [StringValue("Nhân viên đã tồn tại")]
        MenuGroupHasExist = 500900,

        [StringValue("MenuGroup không tồn tại")]
        MenuGroupNotExist = 500010,

        [StringValue("Sở giáo dục đã tồn tại")]
        EduProvinceHasExist = 500110,

        [StringValue("Sở giáo dục không tồn tại")]
        EduProvinceNotExist = 500210,

        [StringValue("Tiêu chí đã tồn tại")]
        EvalCriteriaHasExist = 500310,

        [StringValue("Tiêu chí không tồn tại")]
        EvalCriteriaNotExist = 500410,

        [StringValue("EvalDetail đã tồn tại")]
        EvalDetailHasExist = 500510,

        [StringValue("EvalDetail không tồn tại")]
        EvalDetailNotExist = 500610,

        [StringValue("EvalGuide đã tồn tại")]
        EvalGuideHasExist = 500710,

        [StringValue("EvalGuide không tồn tại")]
        EvalGuideNotExist = 500810,

        [StringValue("UserGroupEmployee đã tồn tại")]
        UserGroupEmployeeHasExist = 500910,

        [StringValue("UserGroupEmployee không tồn tại")]
        UserGroupEmployeeNotExist = 500020,

        [StringValue("EvalMaster đã tồn tại")]
        EvalMasterHasExist = 500120,

        [StringValue("EvalMaster không tồn tại")]
        EvalMasterNotExist = 500220,

        [StringValue("EvalPeriod đã tồn tại")]
        EvalPeriodHasExist = 500320,

        [StringValue("EvalPeriod không tồn tại")]
        EvalPeriodNotExist = 500420,

        [StringValue("Phân quyền cho nhóm người dùng này đã tồn tại")]
        UserClassMenuItemHasExist = 500520,

        [StringValue("Phân quyền cho nhóm người dùng này không tồn tại")]
        UserClassMenuItemNotExist = 500620,

        [StringValue("EvalResult đã tồn tại")]
        EvalResultHasExist = 500720,

        [StringValue("EvalResult không tồn tại")]
        EvalResultNotExist = 500820,

        [StringValue("Nhóm người dùng cho user này không tồn tại")]
        OperatorUserClassSiteNotExist = 500920,

        [StringValue("Nhóm người dùng cho user này đã tồn tại")]
        OperatorUserClassSiteHasExist = 500030,

        [StringValue("Menu item action cho nhóm người dùng này không tồn tại")]
        UserClassFormActionNotExist =500130,

        [StringValue("EvalStandard này không tồn tại")]
        EvalStandardNotExist = 500230,

        [StringValue("EvalStandard này đã tồn tại")]
        EvalStandardHasExist = 500330,

        [StringValue("EvalState này không tồn tại")]
        EvalStateNotExist = 500430,

        [StringValue("EvalState này đã tồn tại")]
        EvalStateHasExist = 500530,

        [StringValue("EvalTypeBE này không tồn tại")]
        EvalTypeBENotExist = 500430,

        [StringValue("EvalTypeBE này đã tồn tại")]
        EvalTypeBEHasExist = 500530,

        [StringValue("FormGroup này không tồn tại")]
        FormGroupNotExist = 500630,

        [StringValue("FormGroup này đã tồn tại")]
        FormGroupHasExist = 500730,

        [StringValue("FormCode này không tồn tại")]
        FormsNotExist = 500830,

        [StringValue("FormCode này đã tồn tại")]
        FormsHasExist = 500930,

        [StringValue("LoginUser này không tồn tại")]
        LoginUserNotExist = 500040,

        [StringValue("LoginUser này đã tồn tại")]
        LoginUserHasExist = 500140,

        [StringValue("School này không tồn tại")]
        SchoolNotExist = 500240,

        [StringValue("School này đã tồn tại")]
        SchoolHasExist = 500340,

        [StringValue("SchoolLevel này không tồn tại")]
        SchoolLevelNotExist = 500440,

        [StringValue("SchoolLevel này đã tồn tại")]
        SchoolLevelHasExist = 500540,

        [StringValue("UserGroup này không tồn tại")]
        UserGroupNotExist = 500640,

        [StringValue("UserGroup này đã tồn tại")]
        UserGroupHasExist = 500740,

        [StringValue("UserGroupForm này không tồn tại")]
        UserGroupFormNotExist = 500840,

        [StringValue("UserGroupForm này đã tồn tại")]
        UserGroupFormHasExist = 500940,

        [StringValue("EvalType này không tồn tại")]
        EvalTypeNotExist = 500050,

        [StringValue("Ward này không tồn tại")]
        WardNotExist = 500060,
        [StringValue("Province này không tồn tại")]
        ProvinceNotExist = 500070,

        [StringValue("District này không tồn tại")]
        DistrictNotExist = 500070,

        [StringValue("Country này không tồn tại")]
        CountryNotExist = 500080,

        #endregion


    }
}
