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

        [StringValue("YardArea đã tồn tại")]
        YardAreaHasExist = 500500,

        [StringValue("YardArea không tồn tại")]
        YardAreaNotExist = 500600,

        [StringValue("SysCodes đã tồn tại")]
        SysCodesHasExist = 500700,

        [StringValue("SysCodes không tồn tại")]
        SysCodesNotExist = 500800,

        [StringValue("MenuGroup đã tồn tại")]
        MenuGroupHasExist = 500900,

        [StringValue("MenuGroup không tồn tại")]
        MenuGroupNotExist = 500010,

        [StringValue("MenuItem đã tồn tại")]
        MenuItemHasExist = 500110,

        [StringValue("MenuItem không tồn tại")]
        MenuItemNotExist = 500210,

        [StringValue("OperationMethod đã tồn tại")]
        OperationMethodHasExist = 500310,

        [StringValue("OperationMethod không tồn tại")]
        OperationMethodNotExist = 500410,

        [StringValue("LineOper đã tồn tại")]
        LineOperHasExist = 500510,

        [StringValue("LineOper không tồn tại")]
        LineOperNotExist = 500610,

        [StringValue("Depot đã tồn tại")]
        DepotHasExist = 500710,

        [StringValue("Depot không tồn tại")]
        DepotNotExist = 500810,

        [StringValue("Mã khách hàng đã tồn tại")]
        CustomerHasExist = 500910,

        [StringValue("Mã khách hàng không tồn tại")]
        CustomerNotExist = 500020,

        [StringValue("Iso đã tồn tại")]
        IsoHasExist = 500120,

        [StringValue("Iso không tồn tại")]
        IsoNotExist = 500220,

        [StringValue("Module code đã tồn tại")]
        ModuleCodeHasExist = 500320,

        [StringValue("Module code không tồn tại")]
        ModuleCodeNotExist = 500420,

        [StringValue("Phân quyền cho nhóm người dùng này đã tồn tại")]
        UserClassMenuItemHasExist = 500520,

        [StringValue("Phân quyền cho nhóm người dùng này không tồn tại")]
        UserClassMenuItemNotExist = 500620,

        [StringValue("Xe này đã tồn tại")]
        TruckHasExist = 500720,

        [StringValue("Xe này không tồn tại")]
        TruckNotExist = 500820,

        [StringValue("Nhóm người dùng cho user này không tồn tại")]
        OperatorUserClassSiteNotExist = 500920,

        [StringValue("Nhóm người dùng cho user này đã tồn tại")]
        OperatorUserClassSiteHasExist = 500030,

        [StringValue("Menu item action cho nhóm người dùng này không tồn tại")]
        UserClassFormActionNotExist =500130,

        [StringValue("TRUCK_TRANSACT này không tồn tại")]
        TrkTransactNotExist = 500230,

        [StringValue("TRUCK_TRANSACT này đã tồn tại")]
        TrkTransactHasExist = 500330,

        [StringValue("Pregate Transact này không tồn tại")]
        PregateTransactNotExist = 500430,

        [StringValue("Pregate Transact này đã tồn tại")]
        PregateTransactHasExist = 500530,

        [StringValue("TRK_ID này không tồn tại")]
        TrkIdNotExist = 500430,

        [StringValue("TRK_ID này đã tồn tại")]
        TrkIdHasExist = 500530,

        [StringValue("ITEM này không tồn tại")]
        ItemNotExist = 500630,

        [StringValue("ITEM này đã tồn tại")]
        ItemHasExist = 500730,

        [StringValue("ITEM_REEFER này không tồn tại")]
        ItemReeferNotExist = 500830,

        [StringValue("ITEM_REEFER này đã tồn tại")]
        ItemReeferHasExist = 500930,

        [StringValue("ITEM_CHARGES này không tồn tại")]
        ItemChargesNotExist = 500040,

        [StringValue("ITEM_CHARGES này đã tồn tại")]
        ItemChargesHasExist = 500140,

        [StringValue("ITEM_DAMAGE này không tồn tại")]
        ItemDamageNotExist = 500240,

        [StringValue("ITEM_DAMAGE này đã tồn tại")]
        ItemDamageHasExist = 500340,

        [StringValue("ITEM_LOCATION này không tồn tại")]
        ItemLocationNotExist = 500440,

        [StringValue("ITEM_LOCATION này đã tồn tại")]
        ItemLocationHasExist = 500540,

        [StringValue("ITEM_OOG này không tồn tại")]
        ItemOogNotExist = 500640,

        [StringValue("ITEM_OOG này đã tồn tại")]
        ItemOogHasExist = 500740,

        [StringValue("VES_CD này không tồn tại")]
        VesselsNotExist = 500840,

        [StringValue("VES_CD này đã tồn tại")]
        VesselsHasExist = 500940,

        [StringValue("PORT này không tồn tại")]
        PortCodeNotExist = 500050,

        [StringValue("PORT này đã tồn tại")]
        PortCodeHasExist = 500150,

        #endregion


    }
}
