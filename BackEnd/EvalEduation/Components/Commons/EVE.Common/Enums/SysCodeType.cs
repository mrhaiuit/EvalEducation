

using System;

namespace EVE.Commons
{
    /// <summary>
    /// The class includes all Sys Code constant defined in project 
    /// </summary>
    public sealed class SysCodeType : StringEnumClass
    {

        #region SYS_CODES

        /// <summary>
        /// "LINE". System code for Line Oper
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LineOper = new SysCodeType("LINE");

        /// <summary>
        /// "VESCD". System code for Vessel code
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VesselCode = new SysCodeType("VESCD");

        /// <summary>
        /// "WPOD". System code for Convert code
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ConvertCode = new SysCodeType("CONVERT_CODE");

        /// <summary>
        /// "WDEP". System code for Category
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Category = new SysCodeType("IMPEXP");

        /// <summary>
        /// "SERVICE". System code for Category
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Service = new SysCodeType("SERVICE");

        /// <summary>
        /// "EIREXTRAINFO". System code for Category
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType EirExtraInfo = new SysCodeType("EIREXTRAINFO");

        /// <summary>
        /// "CUST". System code for Depot Code
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DepotCode = new SysCodeType("DEPOTCODE");

        /// <summary>
        /// "EXCEL". System code for Excel Template
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ExcelTemplate = new SysCodeType("EXCEL");

        /// <summary>
        /// "MENUITEM". System code for MenuItem
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MenuItem = new SysCodeType("MENUITEM");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Country = new SysCodeType("COUNTRY");

        /// <summary>
        /// "VGMCATE". System code for VGM check by category
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VgmCategory = new SysCodeType("VGMCATE");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType EmptyDelvBookingRegLineOpers = new SysCodeType("EMPTYDELVREG");

        /// <summary>
        /// "METHODMAPPING". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MethodMappings = new SysCodeType("METHODMAPPING");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType BookingRule = new SysCodeType("BOOKINGRULE");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType EmptyRecvBookingRegLineOpers = new SysCodeType("EMPTYRECVREG");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType FullRecvBookingRegLineOpers = new SysCodeType("FULLRECVREG");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SealRegLineOpers = new SysCodeType("SEALREG");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LinerStorareChargeForCustomer = new SysCodeType("LINERDEMCUS");

        /// <summary>
        /// "EXPDEMCUS". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ExportStorareChargeForCustomer = new SysCodeType("EXPDEMCUS");

        /// <summary>
        /// "COUNTRY". System code for country
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LinerReeferChargeForCustomer = new SysCodeType("LINEREFERCUS");

        /// <summary>
        /// "SLOT_CODE". System code for Slot Code
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SlotCodeType = new SysCodeType("SLOT_CODE");

        /// <summary>
        /// "STOPTYPE". System code for StopType
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType StopType = new SysCodeType("STOPTYPE");

        /// <summary>
        /// "FE". System code for container's status (Full/Empty)
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ContStatus = new SysCodeType("FE");
        
        /// <summary>
        /// "GRADE". System code for container's grade type (A/B/C/D)
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Grade = new SysCodeType("GRADE");

        /// <summary>
        /// "TEMPUNITS". System code for reefer temperature unit (C/F/...)
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType TempUnits = new SysCodeType("TEMPUNITS");

        /// <summary>
        /// "COMMENT". System code for Comment code 
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CommentCd = new SysCodeType("COMMENT");

        /// <summary>
        /// "LENGTH". System code for Ctr Length
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ContLength = new SysCodeType("LENGTH");

        /// <summary>
        /// CTRTYPE. Container Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CtrType = new SysCodeType("CTRTYPE");

        
        /// <summary>
        /// "ChargeType". System code for Charge Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ChargeType = new SysCodeType("CHARGETYPE");

        /// <summary>
        /// "InvoiceType". System code for Invoice Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType InvoiceType = new SysCodeType("INVOICETYPE");

        /// <summary>
        /// "Currency". System code for Currency
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Currency = new SysCodeType("CURRENCY");

        /// <summary>
        /// "SealType". System code for Seal type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SealType = new SysCodeType("SEALTYPE");
        
        /// <summary>
        /// "UnitCd". System code for unit code
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType UnitCode = new SysCodeType("UNITCD");

        /// <summary>
        /// "ImpStatus". System code for import list status
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ImportListStatus = new SysCodeType("IMPSTATUS");

        /// <summary>
        /// "PayMethod". System code for payment method
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType PayMethod = new SysCodeType("PAYMETHOD");

        /// <summary>
        /// "LenUnits". System code for length unit : cm/ inch
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LenUnits = new SysCodeType("LENUNITS");

        /// <summary>
        /// "SERVPROVID". Service provider
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ServiceProvider = new SysCodeType("SERVPROVID");

        /// <summary>
        /// "WORKERTEAM". Worker team
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType WorkerTeam = new SysCodeType("WORKERTEAM");

        /// <summary>
        /// "CARGOTYPE". Cargo Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CargoType = new SysCodeType("CARGOTYPE");

        /// <summary>
        /// "MAXGROSS". maximum weight 
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MaxGross = new SysCodeType("MAXGROSS");

        /// <summary>
        /// "MINGROSS". minimum weight 
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MinGross = new SysCodeType("MINGROSS");

        /// <summary>
        /// "HEIGHT". Container height
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CtnrHeight = new SysCodeType("HEIGHT");

        /// <summary>
        /// "SYSTEM". System information
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SystemInfo = new SysCodeType("SYSTEM");

        /// <summary>
        /// "PARAREPORT". report parameter
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ReportPara = new SysCodeType("PARAREPORT");


        /// <summary>
        /// "SERVICECD". Service codes
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ServiceCode = new SysCodeType("SERVICECD");

        /// <summary>
        /// "WHOPAYS". Who pays
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType WhoPays = new SysCodeType("WHOPAYS");

        /// <summary>
        /// "OPTYPE". Operation Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType OperationType = new SysCodeType("OPTYPE");

        /// <summary>
        /// "CTRCLASS". Container class: Containerized or Non-Containerized
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CtnrClass = new SysCodeType("CTRCLASS");

        /// <summary>
        /// "COMMODITY". Commodity
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Commodity = new SysCodeType("COMMODITY");

        /// <summary>
        /// "DEPOTTYPE". Depot type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DepotType = new SysCodeType("DEPOTTYPE");


        /// <summary>
        /// "DAMAGEBY". Damage cause
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DamageBy = new SysCodeType("DAMAGEBY");

        /// <summary>
        /// "DAMAGELOC". Damage location
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DamageLoc = new SysCodeType("DAMAGELOC");

        /// <summary>
        /// "IMDGCAT". IMDG Category
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ImdgCategory = new SysCodeType("IMDGCAT");

        /// <summary>
        /// "PKGTYPE". Package Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType PkgType = new SysCodeType("PKGTYPE");

        /// <summary>
        /// "RADUNITS". Radio Activity Units
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType RadUnits = new SysCodeType("RADUNITS");


        /// <summary>
        /// "MPCLASS". Marine Pollutant Class
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MpClass = new SysCodeType("MPCLASS");


  /// <summary>
        /// "LINEGROUP". Define group of liner for same policy
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LineGroup = new SysCodeType("LINEGROUP");

        /// <summary>
        /// "CHETYPE". Che Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CheType = new SysCodeType("CHETYPE");

        /// <summary>
        /// "RFTYPE". RF Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType RfType = new SysCodeType("RFTYPE");

        
        /// <summary>
        /// "CHETYPE". Che Type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CatType = new SysCodeType("CATTYPE");

        /// <summary>
        /// "MANAGEBY". MANAGED BY
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ManageBy = new SysCodeType("MANAGEBY");

        /// <summary>
        /// "COMPANY". COMPANY
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Company = new SysCodeType("COMPANY");

        /// <summary>
        /// "VENTUNIT". VENTUNIT
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VentUnit = new SysCodeType("VENTUNIT");


        /// <summary>
        /// "CHEOWNER". CHE OWNER
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CheOwner = new SysCodeType("CHEOWNER");

        /// <summary>
        /// "YARDAREA". YARDAREA
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType YardArea = new SysCodeType("YARDAREA");

        /// <summary>
        /// "PTIOPERMETHOD". PTI operation method
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType PtiOperMethod = new SysCodeType("PTIMETHOD");

        /// <summary>
        /// "RFMNTROPER". Reefer monitor oper
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ReeferMonitorOper = new SysCodeType("RFMNTROPER");

        /// <summary>
        /// "VSSCPROV". VS-SC Provider
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VSSCProvider = new SysCodeType("VSSCPROV");

        /// <summary>
        /// "VSSCSERVICE". VS-SC Service
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VSSCService = new SysCodeType("VSSCSERVICE");

        /// <summary>
        /// "RD". Receival or Delivery
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ROrD = new SysCodeType("RD");

        /// <summary>
        /// "CARTYPE". Transport type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CarType = new SysCodeType("CARTYPE");

        /// <summary>
        /// "VESTYPE". Vessel type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VesType = new SysCodeType("VESTYPE");

        /// <summary>
        /// "MEANSOFTRANS". Means of transport - Phương tiện vận tải
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MeansOfTrans = new SysCodeType("MEANSOFTRANS");

        /// <summary>
        /// "CARRIER". Carrier type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Carrier = new SysCodeType("CARRIER");

        /// <summary>
        /// "USAGEMETHOD". Usage
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType UsageMethod = new SysCodeType("USAGEMETHOD");

        /// <summary>
        /// BILL_TYPE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType BillType = new SysCodeType("BILL_TYPE");

        /// <summary>
        /// "CHARGEGROUP". Group
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ChargeGroup = new SysCodeType("CHARGEGROUP");


        /// <summary>
        /// STFSTRPMETHD
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType StuffStripMethod = new SysCodeType("STFSTRPMETHD");

        /// <summary>
        /// USERCLASS
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType UserClass  = new SysCodeType("USERCLASS");

        /// <summary>
        /// CUSTOMERGP
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CUSTOMERGP = new SysCodeType("CUSTOMERGP");

        /// <summary>
        /// CUSTTYPE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CUSTTYPE = new SysCodeType("CUSTTYPE");

        /// <summary>
        /// BANKNAME
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType BANKNAME = new SysCodeType("BANKNAME");

        /// <summary>
        /// TERMINALID
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType TerminalId = new SysCodeType("TERMINALID");

        /// <summary>
        /// Operation TERMINALID
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VesTerminalId = new SysCodeType("VESTERMID");

        /// <summary>
        /// SITEID
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SiteId = new SysCodeType("SITE_ID");

        /// <summary>
        /// QUAYROTATE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType QuayRotate = new SysCodeType("QUAYROTATE");

        /// <summary>
        /// INTCHEID
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType IntCheId = new SysCodeType("INTCHEID");

        /// <summary>
        /// FE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Fel = new SysCodeType("FE");

        /// <summary>
        /// THC
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType THC = new SysCodeType("THC");

        /// <summary>
        /// VESCHARGES
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VESCHARGES = new SysCodeType("VESCHARGES");

        /// <summary>
        /// YRDSTRG
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType YRDSTRG = new SysCodeType("YRDSTRG");

        /// <summary>
        /// CTRCHARGES
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CTRCHARGES = new SysCodeType("CTRCHARGES");
        
        /// <summary>
        /// DEPARTMENTS
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DEPARMENTS = new SysCodeType("DEPARTMENTS");

        /// <summary>
        /// DEPARTMENT
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DEPARTMENT = new SysCodeType("DEPARTMENT");

        /// <summary>
        /// CABHOOK_DEPT : cable hook request department
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CABHOOK_DEPT = new SysCodeType("CABHOOK_DEPT");

        /// <summary>
        /// ROUNDMOVES
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ROUNDMOVES = new SysCodeType("ROUNDMOVES");

        /// <summary>
        /// YCSBATCHTYPE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType YardConsolBatchType = new SysCodeType("YCSBATCHTYPE");

        /// <summary>
        /// REQUESTBY
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SphdRequestBy = new SysCodeType("REQUESTBY");

        /// <summary>
        /// Type of Strip and Stuff
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType OpType = new SysCodeType("OPTYPE");

        /// <summary>
        /// Report Signature
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ReportSignature = new SysCodeType("SIGNATURE");

        /// <summary>
        /// Stevedore Company: Đơn vị móc cáp, kiểm tra container
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType StevedoreCompany = new SysCodeType("STEVEDORE");

        /// <summary>
        /// RFCHCKEXCEPT. List of liner does not need to check expired reef fee
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LinerRfCheckingExcept = new SysCodeType("RFCHCKEXCEPT");

        /// <summary>
        /// SUB_DEPT_CODE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SubDeptCode = new SysCodeType("DEPT_SUB");

        /// <summary>
        /// THC_SITE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ThcSite = new SysCodeType("THC_SITE");

        /// <summary>
        /// Checking - dịch vụ kiểm tra container
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Checking = new SysCodeType("CHECKING");

        /// <summary>
        /// VGMCOMP - VGM Company
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VgmComp = new SysCodeType("VGMCOMP");

        /// <summary>
        /// VGMMETHOD - VGM Method
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType VgmMethod = new SysCodeType("VGMMETHOD");

        /// <summary>
        /// VGMMETHOD - VGM Method
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType SmartGate = new SysCodeType("SMARTGATE");

        /// <summary>
        /// MoveType
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MoveType = new SysCodeType("MOVETYPE");

        /// <summary>
        /// TRK_IO_LIMIT
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType TrkIOLimit = new SysCodeType("TRK_IO_LIMIT");

        /// <summary>
        /// CHK_TRK_IMO
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ChkTrkImo = new SysCodeType("CHK_TRK_IMO");
         
        /// <summary>
        /// CHK_TRK_IO
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ChkTrkIO = new SysCodeType("CHK_TRK_VIO");

        /// <summary>
        /// DOCUMENT_TP
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DocumentTp = new SysCodeType("DOCUMENT_TP");

        /// <summary>
        /// LINER_E_GROUP
        /// Việc mở quyền C01 cho De6 chị hiểu, tuy nhiên chị muốn giải pháp tốt hơn cho De6 và cũng tránh rủi ro cho De6 khi sử dụng C01 +  đồng thời vẫn giữ nguyên số liệu trong Hệ thống đúng theo khai báo lúc nhập về, thay vì nếu De6 chỉnh lại chủ khai thác của cont trong C01 từ lúc nhập về để cấp cont, sẽ làm khác đi so với khai báo lúc đầu, số liệu không đồng nhất theo chứng từ. Về lâu dài sau này sẽ không phải là MAE, mà sẽ là CMA, APL, hoặc các Hãng khác cũng cấp tương tự như vậy.
        /// Chắc chị phải trao đổi dài dòng dưới đây thì mới làm rõ được nội dung chị đề nghị, chứ ko phải cảnh báo đơn thuần CKT tại Gate-in như em đang nghĩ (vì nội dung này đã có từ lâu rồi và là điều kiện bắt buộc cho cấp rỗng chứ ko phải chỉ có cho riêng MAE). Cụ thể:
        /// -	Phiếu XNB ghi chủ khai thác MAE.
        /// -	De6 gate in Cont TGHU1234567 có chủ khai thác trong tồn là MCC, hệ thống sẽ cảnh báo sai Chủ khai thác. Đối với chương trình hiện tại thì “chốt chặt” không cho qua, tuy nhiên đối với RIÊNG trường hợp chủ khai thác MAE, MCC, SMR  thì MỞ : Yes or No. Người sử dụng sẽ chọn Yes = đồng ý cấp khác chủ khai thác MCC.  Như vậy là OK, vì thỏa mãn các yêu cầu sau:
        /// o	De6 sẽ không  vào C01 chỉnh sửa chủ khai thác của TGHU1234567 từ MCC thành MAE để đồng nhất với Phiếu XNB rồi mới cấp. Việc này sẽ giúp số liệu của TGHU vẫn đúng theo chứng từ khai báo lúc nhập về.
        /// o	Sau này bên nào đó có tra cứu lại TGHU trong Hệ thống thì vẫn thấy lúc nhập về là MCC đúng với khai báo.
        /// o	Hãng tàu cũng nhận được số liệu đúng là MCC, theo như Hãng tàu khai báo lúc đầu chứ không phải MAE  Việc này thuận tiện cho Báo cáo lưu bãi sau này, vì Hãng tàu thanh toán theo Line, mỗi Line có 1 HD riêng, chính sách riêng. Nếu MCC và MAE sau này khác đơn giá lưu bãi thì việc chỉnh sửa của De6 trong C01 sẽ làm cho số liệu sai đi, tính toán sai đơn giá
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType LinerEmptyGroup = new SysCodeType("LINER_E_GRP");

        /// <summary>
        /// Free minutes when truck gate in or gate out with 02 methods
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType TruckOprExtra = new SysCodeType("TRK_OP_EXTRA");

        /// <summary>
        /// CTL, GNA: đơn vị sở hữu
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Owner = new SysCodeType("OWNER");

        /// <summary>
        /// Tg1SCD.SPECHL
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Spechl = new SysCodeType("SPECHL");

        /// <summary>
        /// Tg1SCD.MVRECD
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType Mvrecd = new SysCodeType("MVRECD");

        /// <summary>
        /// ONLY_READ_IP
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType AccessReadOnlyDataIpList = new SysCodeType("ONLY_READ_IP");

        /// <summary>
        /// CABLEHOOK_TP
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CableHookType = new SysCodeType("CABLEHOOK_TP");

        /// <summary>
        /// CH_BARGE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CableHookBargeMethod = new SysCodeType("CH_BARGE");

        /// <summary>
        /// CH_VESSEL
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CableHookVesselMethod = new SysCodeType("CH_VESSEL");

        /// <summary>
        /// CH_YARD
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CableHookYardMethod = new SysCodeType("CH_YARD");
        /// <summary>
        /// HH_DIC
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType HHDic = new SysCodeType("HH_DIC");

        /// <summary>
        /// NO_DISC_SITE
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType NoDiscountSite = new SysCodeType("NO_DISC_SITE");

        /// <summary>
        /// MAX_TRANSIT : max container transit in a bill to create order no
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType MaxTransitInBill = new SysCodeType("MAX_TRANSIT");

        /// <summary>
        /// OPS_ROLE :
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType OpsDept = new SysCodeType("OPS_DEPT");

        /// <summary>
        /// OPS_ROLE :
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType OpsRole = new SysCodeType("OPS_ROLE");

        /// <summary>
        /// CUS_SCANNER: Mã máy soi hải quan
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CusScanner = new SysCodeType("CUS_SCANNER");

        /// <summary>
        /// Khách hàng thân thiết
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ChargeKhtt = new SysCodeType("CHARGE_KHTT");

        /// <summary>
        /// DOC_OBJ_TP: Loại đối tượng upload tài liệu
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType DocObjTp = new SysCodeType("DOC_OBJ_TP");

        /// <summary>
        /// STOPMULTIIMO: Check kiểm tra stop multi
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType StopMultiImo = new SysCodeType("STOPMULTIIMO");

        /// <summary>
        /// REVENUESITE: Xác định đơn vị thu phí cho báo cáo chia doanh thu
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType RevenueSite = new SysCodeType("REVENUESITE");

        /// <summary>
        /// INVMAXROW: Xác định số dòng tối đa trên 1 hóa đơn
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType INVMAXROW = new SysCodeType("INVMAXROW");

        /// <summary>
        /// IMOCHECKRULE: Tiêu chí check stop imo C31
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ImoCheckRule = new SysCodeType("IMOCHECKRULE");

        /// <summary>
        /// UNOCHECKRULE: Tiêu chí check stop unno C31
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType UnnoCheckRule = new SysCodeType("UNOCHECKRULE");

        /// <summary>
        /// YARDAREA_RPT: Phân loại khu vực bãi. Dùng để báo cáo.
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType YardAreaRpt = new SysCodeType("YARDAREA_RPT");

        /// <summary>
        /// CONVERT_BLK: Danh sách block code convert 
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType ConvertBlockCode = new SysCodeType("CONVERT_BLK");


        /// <summary>
        /// REVENUE_CFG: Cấu hình chia doanh thu
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType RevenueCfg = new SysCodeType("REVENUE_CFG");


        public static readonly SysCodeType TruckConfirm = new SysCodeType("TRUCK_CFG");
        public static readonly SysCodeType StopCont = new SysCodeType("STOP_CONT");
        public static readonly SysCodeType LocTruck = new SysCodeType("LOC_TRUCK");

        /// <summary>
        /// CONTTRUCKTEM: Cấu hình Cont/Xe ra vào tạm
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CONTTRUCKTEMP = new SysCodeType("CONTTRUCKTEM");

        /// <summary>
        /// Filter file Type:  
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType FILTER_FILE = new SysCodeType("FILTER_FILE");
        public static readonly SysCodeType CUSTOMS_CAT = new SysCodeType("CUSTOMS_CAT");

        public static readonly SysCodeType KETHUATK = new SysCodeType("KETHUATK");

        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType EDO = new SysCodeType("EDO");

        public static readonly SysCodeType VESVOYCHANGE = new SysCodeType("VESVOYCHANGE");

        public static readonly SysCodeType LINEREDO = new SysCodeType("LINEREDO");

        public static readonly SysCodeType LINEREDO_F = new SysCodeType("LINEREDO_F");

        public static readonly SysCodeType LINER_OTM= new SysCodeType("LINER_OTM");

        /// <summary>
        /// "SealType". System code for Seal type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType REG_SRC_DATA = new SysCodeType("REG_SRC_DATA");

        /// <summary>
        /// "SealType". System code for Seal type
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType CONFIG_TYPE = new SysCodeType("CONFIG_TYPE");

        /// <summary>
        /// "UsersDeleteDebitHasEir" danh sách users được phép xóa Debit khi đã có số phiếu Eir.....
        /// </summary>
        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType UsersDeleteDebitHasEir = new SysCodeType("DELETE_DEBIT");

        [CustomTypeEditorBrowsable(true)]
        public static readonly SysCodeType STFSTRPMETHD = new SysCodeType("STFSTRPMETHD");


        //@@dungv2:
        //https://pms.snp.com.vn/browse/TOPO-1134   
        //[Task] Thêm chỉ định cont tank khi GateIn tại T01, hiện thị S14 tại T00
        public static readonly SysCodeType TankContainer = new SysCodeType("TANK_CONT");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private SysCodeType(String code)
            : base(code)
        {

        }

        #endregion
        
    }
}


