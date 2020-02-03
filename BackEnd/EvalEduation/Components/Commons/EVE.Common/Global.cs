using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EVE.Commons
{
    sealed partial class mGlobal
    {
        //Public BillingSysOn As Boolean = False

        public const string gISO_20 = "22G0";
        public const string gISO_40 = "42G0";
        public const string gISO_45 = "L5G0";
        public const int gtimeOut = 300;
        public const string EdiInDir = "c:\\topo_edi\\in\\";
        public const string EdiOutDir = "c:\\topo_edi\\out\\";
        public const string EdiExtension = "edi";
        public const string gIsAnMST = "Y";
        public const string gIsNotAnMST = "N";
        public const string gStatusBooking = "BK";
        public const string gStatusDelivered = "DE";
        public const string gStatusDischarged = "DS";
        public const string gStatusFromEmpty = "FE";
        public const string gStatusImportDelivery = "ID";
        public const string gStatusReceived = "RE";
        public const string gStatusStuffer = "SF";
        public const string gStatusStripper = "ST";

        public const float TwentyFoot = 20;
        public const float TwentyOneFoot = 21;
        public const float FortyFoot = 40;
        public const float Forty8Foot = 48;
        public const float Forty5Foot = 45;
        public const float Fifty1Foot = 51;

        public const float FullHeight = 2.1F;

        public const float TwentyFootTare = 2.5F;
        public const float FortyFootTare = 3.5F;
        public const int g45FtTEUs = 3;

        public const float interCoupler = 0.025F;


        public const int WagSeqCol = 0;
        public const int WagClCol = 1;
        public const int WagNoCol = 2;
        public const int WagPlatCol = 3;
        public const int WagLenPlatCol = 4;
        public const int WagSlotCol = 5;
        public const int WagGridCol = 6;
        public const int WagTierCol = 7;
        public const int WagTrnArea = 8;
        public const int WagTrackNo = 9;
        public const int WagSEGNO = 10;
        public const int WagSEGpos = 11;
        public const int WagCtrNoCol = 12;
        public const int WagArrTSCol = 13;
        public const int WagCtrCategoryCol = 14;
        public const int WagCtrLinerCol = 15;
        public const int WagLenCol = 16;
        public const int WagCHeightCol = 17;
        public const int WagCWeightCol = 18;
        public const int WagShipperCol = 19;
        public const int WagDestCol = 20;
        public const int TFC_CODE_Col = 21;
        public const int CommodCol = 22;
        public const int WagHazCol = 23;
        public const int WagReeferCol = 24;
        public const int WagDoorDirCol = 25;
        public const int WagPlatHtCol = 26;
        public const int WagCtrKeyCol = 27;
        public const int WagMaxSlotsCol = 28;
        public const int WagWagLenCol = 29;
        public const int WagPlatSlotCol = 30;
        public const int WagABCol = 31;
        public const int WagWagWtCol = 32;
        public const int WagPlatCogCol = 33;
        public const int WagPlatMassCol = 34;
        public const int WagTopLiftCol = 35;
        public const int WagDest1Col = 36;
        public const int WagDest2Col = 37;
        public const int WagHeightCol = 38;
        public const int WagWeightCol = 39;
        public const int WagWtCol = 40;

        public const int FlexCols = 41;


        public const string UsedSlot = "XXXXXXXX";
        public const string DefaultDoorDir = "A"; //Aft
        public const string TierTextTop = "Top";
        public const string TierTextBot = "Bottom";
        public const string WagMarkOff = "MarkOf";

        public const int SeqNoCol = 0;
        public const int BillOptsCol = 1;
        public const int UnitsCol = 2;
        public const int UnitChargeCol = 3;
        public const int TotalChargeCol = 4;
        public const int BillOptsDescCol = 5;
        public const int g_TrainLenth = 700;
        public const float g_TrainHeight = 4.2F;
        public const int g_maxTUE = 75;
        public const int TopoGreen = 0x41F878; //&H8000&
        public const string mDefaultStack = "HP1";

        public const int mColour = 0xC000;
        public const short CB_SETDROPPEDWIDTH = 0x160;
        public const short CB_SETITEMHEIGHT = 0x154;
        public const short CB_SHOWDROPDOWN = 0x14F;
        public const short CB_LIMITTEXT = 0x141;
        public const short LB_FINDSTRING = 0x18F;
        public const string LINER_DEFAULT = "STD";
        public const string SECTION_NAME = "TopO Geometry";
        public const short STILL_ACTIVE = 0x103;
        public const short PROCESS_QUERY_INFORMATION = 0x400;

        /// <summary>
        ///     Port of of this port
        /// </summary>
        public const string gThisPort = ""; //VNTCT

        public static bool DesignMode = true;

        public static string ReConnectionTopO;

        //Public gErrMsgRs As datatable
        public static DataTable gErrMsgRs;
        

        public static bool gCapture_captions = false;

        public static bool DO_TEST_ON;

        //Public gfrmOperLogin As frmOperLogin
        public static string gstrUserClass;
        public static string gstrUserId;
        public static string gUserClass;
        public static string gstrUserPwd;
        public static string gDataBase;
        public static string gDSN;
        public static string gDbUser;
        public static string gPwdIP;
        public static string gPwdPort;
        public static string gDBPwd;

        public static bool gTopOInitConfig;
        public static long LoginTime;
        public static string gConnectType;
        public static string gstrUserName;
        public static int gItemkey;
        public static string gContainKey;
        public static string gVesID;
        public static string g_checkUserName;
        public static string g_checkUserPwd;
        public static string strTableName;
        public static string gstrMsg;
        public static string g_LocalHostName;
        public static string g_AppName;

        public static string g_TfcCode;
        public static string gDB;
        public static string gDBdesc;
        public static bool gCalledFromHelp;


        public static string PhotoSelected;
        public static string AsignPhoto;
        public static int gstartGrid;
        public static string goperator;
        public static int gendGrid;
        public static float ggridSize;
        public static int gnumberLines;
        public static int gTrnKey;
        public static string gRD_flag;
        public static string StationId;
        public static bool gTrnGeoHasCtrs;
        public static int gTrnGeoTrnKey;
        public static string gTrnGeoService;
        public static string gTrnGeoSchedTs;
        public static double gCellColour;
        public static double gForeColour;
        public static string gstrGlobalCtrNo;
        public static string gstrEIRPLD;

        public static string gCtrSize;
        public static string gType;
        public static string gCtrHeight;
        public static int gBkgKey;
        public static string gstrTrkGross;

        public static float ggross_weight;
        public static float gbase_charge;
        public static float gincremental_charge;
        public static float gbotlift_charge;
        public static float gdgs_charge;
        public static float gtotal_charge;
        public static string gJ25ContainerNumber;
        public static int gJ25ContainerKey;
        public static string gJ25JobOrder;
        public static string gJ25JobOrderVesId;
        public static string gJ25InvoiceNo;
        public static string gJ25InvoiceDt;
        public static string gSQLTransBlock;
        public static string StrYes_No;
        public static string DummyCtrNo;
        public static string g_CtrNo;
        public static string CtrNo_YesNo;
        public static int OK_Cancel;
        public static string destStn;
        public static string gWagonClass;
        public static string gDestStn1;
        public static string gDestStn2;
        public static string g_ipAddress;
        //Public gSiteId As String
        public static string gHomePort;
        public static string gLoadPort;
        public static string strStack;
        public static string strX;
        public static string strY;
        public static string strZ;

        public static string g_DepTrnId;
        public static string g_DepSchedTs;
        public static string g_ArrTrnId;
        public static string g_ArrSchedTs;
        public static string g_SchedTs;


        public static string G_StrDMY;
        public static string G_StrDMYHM;
        public static string G_StrDMYHMS;

        public static string G_DBStrDMY;
        public static string G_DBStrDMYHM;
        public static string G_DBStrDMYHMS;

        //public static string gRpt_connection;

        public static string gClientLogo;
        public static string gCallingForm;
        public static string gDBName;

        public static string gSiteId = ""; //STD
        public static string gSID = "";
        public static string gDataSource = "";


        public static ComboBox[] CbBoxArr;
        public static int CbBoxCnt;

        // Determine site has TopX system
        // ===============================================================================
        public static bool IsConnect;

        public static bool gTopX;

        public static bool gflgLogIn;
        public static string g_DBName;

        // ===============================================================================
        public static string NullDate;
        public static string NullDateHM;
        public static string NullDateHMS;

        public static string StrDMY;
        public static string StrDMYHM;
        public static string StrDMYHMS;

        public static string DBStrDMY;
        public static string DBStrDMYH24M;
        public static string DBStrDMYH24MS;
        // ===============================================================================

        public static Color WHITE = Color.FromArgb(255, 255, 255);
        public static Color YELLOW = Color.FromArgb(255, 255, 192);
        public static Color GRAY = SystemColors.ButtonFace; //System.Drawing.SystemColors.GrayText;

        // TopO special structures definition.
        // ================================================================================


        //==================== item audit flg variables ============================

        public static string ITEM_NO_FLG;
        public static string LIFT_METHOD_FLG;
        public static string ISO_FLG;
        public static string TYNES_FLG;
        public static string ITEM_TYPE_FLG;
        public static string LENGTH_FLG;
        public static string height_flg;
        public static string TARE_FLG;
        public static string GROSS_FLG;
        public static string ITEM_CLASS_FLG;
        public static string FEL_FLG;
        public static string COMMOD_FLG;
        public static string SHIPPER_FLG;
        public static string AGENT_FLG;
        public static string ARR_TS_FLG;
        public static string ARR_CAR_FLG;
        public static string ARR_BY_FLG;
        public static string DEP_TS_FLG;
        public static string DEP_CAR_FLG;
        public static string DEP_BY_FLG;
        public static string ORG_PORT_FLG;
        public static string LOAD_PORT_FLG;
        public static string DISCH_PORT_FLG;
        public static string FDISCH_PORT_FLG;
        public static string RELEASE_NO_FLG;
        public static string SPEC_HNDL_FLG;
        public static string CONSIGNEE_FLG;
        public static string CONSIGNOR_FLG;
        public static string OOG_TOP_FLG;
        public static string OOG_LEFT_FLG;
        public static string OOG_RIGHT_FLG;
        public static string OOG_FRONT_FLG;
        public static string OOG_BACK_FLG;
        public static string IS_DAMAGED_FLG;
        public static string IS_ATTCH_FLG;
        public static string IS_FOLDED_FLG;
        public static string IS_REEFER_FLG;
        public static string SRC_STN_FLG;
        public static string DEST_STN_FLG;
        public static string FIN_DEST_FLG;
        public static string BKG_WEIGHT_FLG;
        public static string BKG_TRN_ID_FLG;
        public static string BKG_SCHED_TS_FLG;
        public static string BKG_TS_FLG;
        public static string BKG_CL_FLG;
        public static string BKG_NO_FLG;
        public static string IS_DANGEROUS_FLG;
        public static string DGS_MIN_FLG;
        public static string IS_COMMENTS_FLG;
        public static string RAIL_CON_NOTE_FLG;
        public static string SEAL_NO_FLG;
        public static string CHARGE_TO_FLG;
        public static string ACC_NO_FLG;
        public static string FOOD_STUFF_FLG;
        public static string DISPCH_ID_FLG;
        public static string RECEIVER_ID_FLG;
        public static string TOP_LIFT_FLG;
        public static string BOTTOM_LIFT_FLG;
        public static string FORK_LIFT_FLG;
        public static string DBL_STACK_FLG;
        public static string NETT_FLG;
        public static string WIDTH_FLG;
        public static string ECN_FLG;
        public static string VES_CD_FLG;
        public static string VOY_NO_FLG;
        public static string SCA_KEY_FLG;

        // ==================== Added for UTPK Indonesia ====================

        public static string gImportExport;
        public static string gstrActivity;
        public static string gstrEquipType;
        public static string gstrJobService;
        public static string gstrYrdActivity;
        public static string gJournalCd;
        public static string gCurrency;
        public static string gAmount;
        public static string gstrCtrlength;
        public static string gstrFEOR;
        public static string gstrOOGflag;
        public static string gStrUnitsCharged;
        public static string gstrService;
        public static string gstrServiceGp;
        public static short gintUnits;
        public static string gstrOceanInterisland;
        public static string gstrStartWorkTs;
        public static string gstrPlanDate;
        public static string gstrExportImport;
        public static double gdblM3;
        public static double gdblTons;
        public static string gstrHazNonHaz;
        public static string gstrFromRfrTs;
        public static string gstrFromDwellTs;
        public static string gstrToDwellTs;
        public static string gstrStartGP3Ts;
        public static string gstrCHEId;
        public static int glngCargoKey;
        public static short gUnitCharge;
        public static bool CtrExistflg = false;

        // ====================================== end of file ============================
        // ===============================================================================


        public static bool gSwapYardXY;
        public static string Label_DateFmt;

        public static int gLanguage;
        public static bool frmVesChargesOn;

        public static string RenomCode;
        public static string mWhoPays;
        public static string mIC_TYPE;
        public static string mIC_LENGTH;
        public static string mIC_STS;
        public static bool Billing_System;
        public static bool Stradle_System;

        //From Utils 5 =======================================================================

        public static string gCheckFlgCtrNoSeries;


        // Global variables.
        // ===============================================================================
        public static string gTime_To_Run;
        public static string gPasswdDesc;
        public static string gPrinterCaption;
        public static int ReConnectCount;
        // ===============================================================================
        // Global variables For Form Resize.
        // ===============================================================================

        // ===============================================================================
        public static string PathOrant;
        // ===============================================================================
        // Global Shell out to a 32-bit application and wait until task completes
        // ===============================================================================

        public static Control gObj;
        public static string gDateType;
        public static string gDateSeparator;
        public static string gDecimal;
        public static string gDigitGroup;
        public static CultureInfo gNumberFormat = new CultureInfo("vi-VN");
        public static int gMDI_TOP;
        public static int gMDI_LEFT;

        public static object gErrorsExecute;
        public static object gErrorsSQL;
        public static object gErrorsMsg;
        public static bool gReset_Multi_L;
        //End Utils 5 =======================================================================


        //From Utils 4 =======================================================================

        public static bool SetFormFieldHelp;

        public static string g_RptName;
        public static int g_paramCnt;
        public static bool g_paramFlg;

        public static string strJobOrderNo_Ctr;
        public static string strJobOrderNo_JO;

        public static string strFormName;

        //Public gcnnOracle_Report As ADODB.Connection
        public static string g_strDB_Id;
        public static bool CaptionFlg;
        public static string LanguageFlg;
        public static string LanguageSelected;


        public static string strPaperSize;

        public static double totalTaxAmount;
        public static double grandTotal;

        //End Utils 4 =======================================================================

        //From Utils 6 =======================================================================

        public static strRecVes RecVes;

        // unused variables
        public static int unUsed_Int = -1;
        public static int ZERO = 0;
        public static int MINUS_ONE = -1;
        public static string unUsed_string = " ";
        public static bool unUsed_bool = false;
        public static string NULL_STR = null;
        public static int ONE = 1;
        public static bool FALSE = false;
        public static bool TRUE = true;
        public static Form frmNULL = null;
        public static string EMPTY_STR = "";
        public static string SPACE = " ";

        //------------- global variable for Container forms -------------------

        /// <summary>
        ///     Constanst for parameter keyword in error message
        /// </summary>
        public static readonly string ERR_MES_PARAM_KEYWORD = "<P>";

        /// <summary>
        ///     Max value for numeric value
        ///     such as weight,length...
        /// </summary>
        public static double maxRBSValue999999 = 99999;

        /// <summary>
        ///     Define local cultural for the whole system
        /// </summary>
        public static CultureInfo loCalCountryCultural;

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int BringWindowToTop(int hwnd);

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int IsWindow(int hwnd);

        [DllImport("kernel32", EntryPoint = "GetDateFormatA", ExactSpelling = true, CharSet = CharSet.Ansi,
            SetLastError = true)]
        public static extern int GetDateFormat(int Locale, int dwFlags, ref SYSTEMTIME lpDate, string lpFormat,
            string lpDateStr, int cchDate);

        // ===============================================================================
        [DllImport("shell32.dll", EntryPoint = "ShellExecuteA", ExactSpelling = true, CharSet = CharSet.Ansi,
            SetLastError = true)]
        public static extern int ShellExecute(int hwnd, string lpOperation, string lpFile, string lpParameters,
            string lpDirectory, int nShowCmd);

        [DllImport("user32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetWindowPlacement(int hwnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi,
            SetLastError = true)]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, ref int lParam);

        [DllImport("kernel32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int OpenProcess(int dwDesiredAccess, int bInheritHandle, int dwProcessId);

        [DllImport("kernel32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetExitCodeProcess(int hProcess, ref int lpExitCode);

        [DllImport("kernel32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void Sleep(int dwMilliseconds);

        public struct AttachType
        {
            public string CtrNo;
            public string ISO;
            public int Item_key;
            public string item_id;
            public DateTime upd_ts;
        }

        public struct ChassisType
        {
            public string HIST_FLG;
            public string R_D;
            public string X;
            public string Y;
            public DateTime arr_ts;
            public string chassis_id;
            public double chassis_size;
            public DateTime dep_ts;
            public string equip_name;
            public string owner;
            public string pool_name;
            public string stack;
            public string stk_class;
            public string stk_pch;
            public DateTime upd_ts;
            public string z;
        }

        public struct CommentType
        {
            public string CtrNo;
            public int Item_key;
            public string comment_cd;
            public string comments;
            public DateTime upd_ts;
        }

        public struct ControlPositionType
        {
            public float LEFT_Renamed;
            public float TOP;
            public float Width;
            public float height;
            public float m_FormHgt;
            public float m_FormWid;
        }

        public struct Ctr_Detail
        {
            public int ItemKey;
            public string ItemLen;
            public string ItemNo;
            public string ItemStatus;
            public string Itemtype;
            public string ProcFlg;
        }

        public struct DamageType
        {
            public string CtrNo;
            public int Item_key;
            public DateTime crt_ts;
            public string damage_cd;
            public string damage_desc;
            public string damage_level;
            public string fixedup_oper;
            public DateTime fixedup_ts;
        }

        public struct GensetType
        {
            public string HIST_FLG;
            public string R_D;
            public string X;
            public string Y;
            public DateTime arr_ts;
            public DateTime dep_ts;
            public string equip_name;
            public string gen_set_id;
            public double gen_size;
            public string owner;
            public string stack;
            public string stk_class;
            public string stk_pch;
            public DateTime upd_ts;
            public string z;
        }

        public struct HazType
        {
            public string CtrNo;
            public int Item_key;
            public string dgs_class;
            public float gross;
            public float nett_qty;
            public int no_packs;
            public string pkg_group;
            public string pkg_type;
            public string sub_risk;
            public string trade_name;
            public string un_no;
            public DateTime upd_ts;
        }

        public struct INSERT_UPDATE_TYPE
        {
            public string COLUMN_NAME;
            public string DATA_TYPE;
            public string TABLE_NAME;
            public string Value;
        }

        public struct ITEM_DETAILS
        {
            public string BK_WT;
            public int PKG_QTY;
            public string SO_NO;
            public string TFC_CODE;
            public string pkg_type;
        }

        public struct ItemChargesRec
        {
            public int Item_key;
            public string Yard_activity;
            public string billing_component;
            public string currency;
            public DateTime invoice_dt;
            public DateTime invoiced_flag;
            public string job_service;
            public string journal_account;
            public double total_amount;
            public double unit_amount;
            public short units_charged;
        }

        public struct ItemRec
        {
            public string ArrBy;
            public string ArrTs;
            public string Attach;
            public string BlkCasual;
            public string BookWeight;
            public string ChargeToName;
            public string ChilledTmp;
            public string Class_Renamed;
            public string CommodDesc;
            public string ConeeDesc;
            public string ConorDesc;
            public string CtrISO;
            public string CtrNo;
            public string CtrTEU;
            public string DblStack;
            public string DepBy;
            public string DepTs;
            public string DestStn;
            public string DoorDir;
            public string FEL;
            public string FinalDest;
            public string FoodStuff;
            public string FrozenTmp;
            public string GrossW;
            public string Haz;
            public string HazMin;
            public string Length;
            public string Location;
            public string OBack;
            public string OFront;
            public string OLeft;
            public string ORight;
            public string OTop;
            public string OverDim;
            public string REEFER;
            public string RailCNote;
            public string SealNo;
            public string Shipper;
            public string Slot;
            public string SrcStn;
            public string Stops;
            public string TareW;
            public string WagSeq;
            public string WagonCl;
            public string accNo;
            public string arrcar;
            public string botLift;
            public string chargeTo;
            public string comments;
            public string commodity;
            public string consignee;
            public string consignor;
            public string ctrHeight;
            public string ctrLoadError;
            public string depcar;
            public string finDest;
            public string forkLift;
            public string grid;
            public string siteId;
            public string tier;
            public string topLift;
            public string wagonId;
        }

        public struct POINTAPI
        {
            public int X;
            public int Y;
        }

        public struct RECT
        {
            public int Bottom;
            public int LEFT_Renamed;
            public int Right_Renamed;
            public int TOP;
        }

        public struct SYSTEMTIME
        {
            public short wDay;
            public short wDayOfWeek;
            public short wHour;
            public short wMilliseconds;
            public short wMinute;
            public short wMonth;
            public short wSecond;
            public short wYear;
        }

        public struct StopType
        {
            public string CtrNo;
            public int Item_key;
            public string clr_by;
            public DateTime clr_ts;
            public DateTime crt_ts;
            public string stop_cd;
            public string stop_desc;
            public DateTime upd_ts;
        }

        public struct TrnCtrNo
        {
            public string ctr_no;
        }

        public struct TrnGeoClient
        {
            public string wagon_client;
        }

        public struct TrnGeoDest
        {
            public string wagon_dest_stn;
            public string wagon_src_stn;
        }

        public struct TrnGeoMark
        {
            public string marked_off;
        }

        public struct TrnGeoSeqNo
        {
            public short seqNo;
        }

        public struct TrnGeoWagRec
        {
            public string wagon_ArrTS;
            public int wagon_ContainerCount;
            public string wagon_DamageFlag;
            public string wagon_FEL;
            public string wagon_InspectionDate;
            public string wagon_SEG_No;
            public string wagon_SEG_Pos;
            public string wagon_TrackNo;
            public string wagon_TrnArea;
            public string wagon_Type;
            public string wagon_bot_slot_1_10;
            public string wagon_class;
            public string wagon_depth_1_10;
            public string wagon_dest_stn1;
            public string wagon_dest_stn2;
            public string wagon_grid_no;
            public string wagon_height;
            public string wagon_id;
            public string wagon_length;
            public string wagon_marked_off;
            public string wagon_max_slots;
            public string wagon_perm_client_id;
            public string wagon_seq_no;
            public string wagon_swl;
            public string wagon_swl_slot_1_10;
            public string wagon_tare;
            public string wagon_top_slot_1_10;
            public string wagon_wheel_1_11;
        }

        public struct TrnRatingsModsType
        {
            public string SRC_STN;
            public string client;
            public string commod_cd;
            public string ctr_no;
            public string dest_stn;
            public string gross_weight;
            public string row_no;
        }

        public struct TrnRatingsType
        {
            public float base_charge;
            public float botlift_charge;
            public bool cancel_button;
            public float dgs_charge;
            public float incremental_charge;
            public float total_charge;
        }

        public struct TrnRatingsWeightType
        {
            public bool cancel_button;
            public float gross_weight;
        }

        public struct TrnWagPlatWts
        {
            public float platform1_ctr_wt;
            public float platform1_gross;
            public float platform1_mass;
            public float platform2_ctr_wt;
            public float platform2_gross;
            public float platform2_mass;
            public float platform3_ctr_wt;
            public float platform3_gross;
            public float platform3_mass;
            public float platform4_ctr_wt;
            public float platform4_gross;
            public float platform4_mass;
            public float platform5_ctr_wt;
            public float platform5_gross;
            public float platform5_mass;
            public string wagon_class;
            public float wagon_ctr_wt;
            public string wagon_id;
            public float wagon_max_slots;
            public int wagon_seq_no;
            public float wagon_swl;
            public float wagon_tare;
        }

        public struct WINDOWPLACEMENT
        {
            public int Length;
            public int flags;
            public POINTAPI ptMaxPosition;
            public POINTAPI ptMinPosition;
            public RECT rcNormalPosition;
            public int showCmd;
        }

        public struct WarkatType
        {
            public string JOB_SERVICE_CD;
            public string upd_ts;
            public int warkat_amount;
            public string warkat_date;
            public string warkat_no;
        }

        public struct itemtype
        {
            public string BKG_NO;
            public string Item_No;
            public int Item_key;
        }

        public struct paramType
        {
            public int PARAM_POS;
            public string PARAM_TYPE;
            public string param_name;
            public string param_value;
            public DateTime upd_ts;
        }

        public struct strRecVes
        {
            public string CALL_SIGN;
            public string OUT_VOYAGE;
            public string TFC_CODE;
            public string VES_CD; //21/11/10 JV
            public string VES_ID;
            public string VES_NAME;
        }


        //---------------------------------------------------------------------
        public const string WS_INSERT = "I"; //Working status
        public const string WS_UPDATE = "U";
    }
}
