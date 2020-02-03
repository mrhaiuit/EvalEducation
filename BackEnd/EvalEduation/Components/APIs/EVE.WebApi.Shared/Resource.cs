//using System;

//namespace EVE.WebApi.Shared
//{
//    public class Resource
//    {
//        private static readonly Lazy<Resource> _lazyInstance = new Lazy<Resource>(() => new Resource());

//        #region Group 4xx[xxx]
//        private Error _arrayIsNullOrEmpty; //400000
//        private Error _userNameIsNullOrEmpty; //400100
//        private Error _passwordIsNullOrEmpty; //400200
//        private Error _userClassIsNullOrEmpty; //400300
//        private Error _siteIdIsNullOrEmpty; //400400
//        private Error _agentIdIsNullOrEmpty; //400500
//        private Error _areaIsNullOrEmpty; //400600
//        private Error _stackIsNullOrEmpty; //400700
//        private Error _codeTpIsNullOrEmpty; //400800
//        private Error _codeRefIsNullOrEmpty; //400900
//        private Error _menuModuleIsNullOrEmpty; //400010
//        private Error _groupCodeIsNullOrEmpty; //400110
//        private Error _menuItemCodeIsNullOrEmpty; //400210
//        private Error _operationMethodIsNullOrEmpty; //400310
//        private Error _lineOperIsNullOrEmpty; //400410
//        private Error _depotIsNullOrEmpty; //400510
//        private Error _customerNoIsNullOrEmpty; //400610
//        private Error _isoIsNullOrEmpty; //400710
//        #endregion

//        #region Grop 5xx[xxx]

//        private Error _badRequest; //500000
//        private Error _logonInvalid; //500100
//        private Error _userClassInvalid; //500200
//        private Error _agentIdHasExist; //500300
//        private Error _agentNotExist; //500400
//        private Error _yardAreaHasExist; //500500
//        private Error _yardAreaNotExist; //500600
//        private Error _sysCodesHasExist; //500700
//        private Error _sysCodesNotExist; //500800
//        private Error _menuGroupHasExist; //500900
//        private Error _menuGroupNotExist; //500010
//        private Error _menuItemHasExist; //500110
//        private Error _menuItemNotExist; //500210
//        private Error _operationMethodHasExist; //500310
//        private Error _operationMethodNotExist; //500410
//        private Error _lineOperHasExist; //500510
//        private Error _lineOperNotExist; //500610
//        private Error _depotHasExist; //500710
//        private Error _depotNotExist; //500810
//        private Error _customerNoHasExist; //500910
//        private Error _customerNoNotExist; //500020
//        private Error _isoHasExist; //500120
//        private Error _isoNotExist; //500220

//        #endregion

//        /**********************************************************/

//        /// <summary>
//        ///     C'tor
//        /// </summary>
//        public Resource()
//        {
//            Init();
//        }

//        /// <summary>
//        ///     Instance resource
//        /// </summary>
//        public static Resource Instance
//        {
//            get { return _lazyInstance.Value; }
//        }

//        #region 400000: Array Detail not null or empty

//        /// <summary>
//        ///     400100:ArrayDetail = null Or Empty
//        /// </summary>
//        public Error ArrayDetailIsNullOrEmpty
//        {
//            get
//            {
//                if (_arrayIsNullOrEmpty == null)
//                {
//                    Init();
//                }
//                return _arrayIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400100: Username not null or empty

//        /// <summary>
//        ///     400100:Username is null or empty
//        /// </summary>
//        public Error UsernameIsNullOrEmpty
//        {
//            get
//            {
//                if (_userNameIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _userNameIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400200: Password not null or empty

//        /// <summary>
//        ///     400200: Password is null or empty
//        /// </summary>
//        public Error PasswordIsNullOrEmpty
//        {
//            get
//            {
//                if (_passwordIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _passwordIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400300: UserClass not null or empty

//        /// <summary>
//        ///     400300: UserClass is null or empty
//        /// </summary>
//        public Error UserClassIsNullOrEmpty
//        {
//            get
//            {
//                if (_userClassIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _userClassIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400400: SiteId is null or empty

//        /// <summary>
//        ///     400400: Site id is null or empty
//        /// </summary>
//        public Error SiteIdIsNullOrEmpty
//        {
//            get
//            {
//                if (_siteIdIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _siteIdIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400500: AgentId is null or empty

//        /// <summary>
//        ///     400500: AgentId is null or empty
//        /// </summary>
//        public Error AgentIdIsNullOrEmpty
//        {
//            get
//            {
//                if (_agentIdIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _agentIdIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400600: Area is null or empty

//        /// <summary>
//        ///     400600: Area is null or empty
//        /// </summary>
//        public Error AreaIsNullOrEmpty
//        {
//            get
//            {
//                if (_areaIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _areaIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400700: Stack is null or empty

//        /// <summary>
//        ///     400700: AgentId is null or empty
//        /// </summary>
//        public Error StackIsNullOrEmpty
//        {
//            get
//            {
//                if (_stackIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _stackIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400800: CodeTp is null or empty

//        /// <summary>
//        ///     400800: CodeTp is null or empty
//        /// </summary>
//        public Error CodeTpIsNullOrEmpty
//        {
//            get
//            {
//                if (_codeTpIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _codeTpIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400900: CodeRef is null or empty

//        /// <summary>
//        ///     400900: CodeRef is null or empty
//        /// </summary>
//        public Error CodeRefIsNullOrEmpty
//        {
//            get
//            {
//                if (_codeRefIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _codeRefIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400010: Menu module is null or empty

//        /// <summary>
//        ///     400010: Menu module is null or empty
//        /// </summary>
//        public Error MenuModuleIsNullOrEmpty
//        {
//            get
//            {
//                if (_menuModuleIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _menuModuleIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400110: Group code is null or empty

//        /// <summary>
//        ///     400110: Group code is null or empty
//        /// </summary>
//        public Error GroupCodeIsNullOrEmpty
//        {
//            get
//            {
//                if (_groupCodeIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _groupCodeIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400210: Menu item code is null or empty

//        /// <summary>
//        ///     400210: Menu item code is null or empty
//        /// </summary>
//        public Error MenuItemCodeIsNullOrEmpty
//        {
//            get
//            {
//                if (_menuItemCodeIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _menuItemCodeIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400310: Operation method is null or empty

//        /// <summary>
//        ///     400310: Operation method is null or empty
//        /// </summary>
//        public Error OperationMethodIsNullOrEmpty
//        {
//            get
//            {
//                if (_operationMethodIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _operationMethodIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400410: Line oper is null or empty

//        /// <summary>
//        ///     400410: Line oper is null or empty
//        /// </summary>
//        public Error LineOperIsNullOrEmpty
//        {
//            get
//            {
//                if (_lineOperIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _lineOperIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400510: Depot is null or empty

//        /// <summary>
//        ///     400510: Depot is null or empty
//        /// </summary>
//        public Error DepotIsNullOrEmpty
//        {
//            get
//            {
//                if (_depotIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _depotIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400610: CustomerNo is null or empty

//        /// <summary>
//        ///     400610: CustomerNo is null or empty
//        /// </summary>
//        public Error CustomerNoIsNullOrEmpty
//        {
//            get
//            {
//                if (_customerNoIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _customerNoIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 400710: Iso is null or empty

//        /// <summary>
//        ///     400710: Iso is null or empty
//        /// </summary>
//        public Error IsoIsNullOrEmpty
//        {
//            get
//            {
//                if (_isoIsNullOrEmpty == null)
//                {
//                    Init();
//                }

//                return _isoIsNullOrEmpty;
//            }
//        }

//        #endregion

//        #region 500000: Bad request

//        /// <summary>
//        ///     500000: Bad request
//        /// </summary>
//        public Error BadRequest
//        {
//            get
//            {
//                if (_badRequest == null)
//                {
//                    Init();
//                }

//                return _badRequest;
//            }
//        }

//        #endregion

//        #region 500100: Logon invalid

//        /// <summary>
//        ///     500100:Wrong username or password
//        /// </summary>
//        public Error LogonInvalid
//        {
//            get
//            {
//                if (_logonInvalid == null)
//                {
//                    Init();
//                }

//                return _logonInvalid;
//            }
//        }

//        #endregion

//        #region 500200: UserClass invalid

//        /// <summary>
//        ///     500200: UserClass invalid
//        /// </summary>
//        public Error UserClassInvalid
//        {
//            get
//            {
//                if (_userClassInvalid == null)
//                {
//                    Init();
//                }

//                return _userClassInvalid;
//            }
//        }

//        #endregion

//        #region 500300: AgentId has exist

//        /// <summary>
//        ///     500300: AgentId has exist
//        /// </summary>
//        public Error AgentIdHasExist
//        {
//            get
//            {
//                if (_agentIdHasExist == null)
//                {
//                    Init();
//                }

//                return _agentIdHasExist;
//            }
//        }

//        #endregion

//        #region 500400: Agent not exist

//        /// <summary>
//        ///     500400: Agent not exist
//        /// </summary>
//        public Error AgentNotExist
//        {
//            get
//            {
//                if (_agentNotExist == null)
//                {
//                    Init();
//                }

//                return _agentNotExist;
//            }
//        }

//        #endregion

//        #region 500500: YardArea has exist

//        /// <summary>
//        ///     500500: YardArea has exist
//        /// </summary>
//        public Error YardAreaHasExist
//        {
//            get
//            {
//                if (_yardAreaHasExist == null)
//                {
//                    Init();
//                }

//                return _yardAreaHasExist;
//            }
//        }

//        #endregion

//        #region 500600: YardArea not exist

//        /// <summary>
//        ///     500600: YardArea not exist
//        /// </summary>
//        public Error YardAreaNotExist
//        {
//            get
//            {
//                if (_yardAreaNotExist == null)
//                {
//                    Init();
//                }

//                return _yardAreaNotExist;
//            }
//        }

//        #endregion

//        #region 500700: SysCodes has exist

//        /// <summary>
//        ///     500700: SysCodes has exist
//        /// </summary>
//        public Error SysCodesHasExist
//        {
//            get
//            {
//                if (_sysCodesHasExist == null)
//                {
//                    Init();
//                }

//                return _sysCodesHasExist;
//            }
//        }

//        #endregion

//        #region 500800: SysCodes not exist

//        /// <summary>
//        ///     500800: SysCodes not exist
//        /// </summary>
//        public Error SysCodesNotExist
//        {
//            get
//            {
//                if (_sysCodesNotExist == null)
//                {
//                    Init();
//                }

//                return _sysCodesNotExist;
//            }
//        }

//        #endregion

//        #region 500900: Menu group has exist

//        /// <summary>
//        ///     500900: Menu group has exist
//        /// </summary>
//        public Error MenuGroupHasExist
//        {
//            get
//            {
//                if (_menuGroupHasExist == null)
//                {
//                    Init();
//                }

//                return _menuGroupHasExist;
//            }
//        }

//        #endregion

//        #region 500010: Menu group not exist

//        /// <summary>
//        ///     500010: Menu group not exist
//        /// </summary>
//        public Error MenuGroupNotExist
//        {
//            get
//            {
//                if (_menuGroupNotExist == null)
//                {
//                    Init();
//                }

//                return _menuGroupNotExist;
//            }
//        }

//        #endregion

//        #region 500110: Menu item has exist

//        /// <summary>
//        ///     500110: Menu item has exist
//        /// </summary>
//        public Error MenuItemHasExist
//        {
//            get
//            {
//                if (_menuItemHasExist == null)
//                {
//                    Init();
//                }

//                return _menuItemHasExist;
//            }
//        }

//        #endregion

//        #region 500210: Menu item not exist

//        /// <summary>
//        ///     500210: Menu item not exist
//        /// </summary>
//        public Error MenuItemNotExist
//        {
//            get
//            {
//                if (_menuItemNotExist == null)
//                {
//                    Init();
//                }

//                return _menuItemNotExist;
//            }
//        }

//        #endregion

//        #region 500310: Operation method has exist

//        /// <summary>
//        ///     500310: Operation method has exist
//        /// </summary>
//        public Error OperationMethodHasExist
//        {
//            get
//            {
//                if (_operationMethodHasExist == null)
//                {
//                    Init();
//                }

//                return _operationMethodHasExist;
//            }
//        }

//        #endregion

//        #region 500410: Operation method not exist

//        /// <summary>
//        ///     500410: Operation method not exist
//        /// </summary>
//        public Error OperationMethodNotExist
//        {
//            get
//            {
//                if (_operationMethodNotExist == null)
//                {
//                    Init();
//                }

//                return _operationMethodNotExist;
//            }
//        }

//        #endregion

//        #region 500510: Line oper has exist

//        /// <summary>
//        ///     500510: Line oper has exist
//        /// </summary>
//        public Error LineOperHasExist
//        {
//            get
//            {
//                if (_lineOperHasExist == null)
//                {
//                    Init();
//                }

//                return _lineOperHasExist;
//            }
//        }

//        #endregion

//        #region 500610: Line oper not exist

//        /// <summary>
//        ///     500610: Line oper not exist
//        /// </summary>
//        public Error LineOperNotExist
//        {
//            get
//            {
//                if (_lineOperNotExist == null)
//                {
//                    Init();
//                }

//                return _lineOperNotExist;
//            }
//        }

//        #endregion

//        #region 500710: Depot has exist

//        /// <summary>
//        ///     500710: Depot has exist
//        /// </summary>
//        public Error DepotHasExist
//        {
//            get
//            {
//                if (_depotHasExist == null)
//                {
//                    Init();
//                }

//                return _depotHasExist;
//            }
//        }

//        #endregion

//        #region 500810: Depot not exist

//        /// <summary>
//        ///     500810: Depot not exist
//        /// </summary>
//        public Error DepotNotExist
//        {
//            get
//            {
//                if (_depotNotExist == null)
//                {
//                    Init();
//                }

//                return _depotNotExist;
//            }
//        }

//        #endregion

//        #region 500910: CustomerNo has exist

//        /// <summary>
//        ///     500910: CustomerNo has exist
//        /// </summary>
//        public Error CustomerNoHasExist
//        {
//            get
//            {
//                if (_customerNoHasExist == null)
//                {
//                    Init();
//                }

//                return _customerNoHasExist;
//            }
//        }

//        #endregion

//        #region 500020: CustomerNo not exist

//        /// <summary>
//        ///     500020: CustomerNo not exist
//        /// </summary>
//        public Error CustomerNoNotExist
//        {
//            get
//            {
//                if (_customerNoNotExist == null)
//                {
//                    Init();
//                }

//                return _customerNoNotExist;
//            }
//        }

//        #endregion

//        #region 500120: Iso has exist

//        /// <summary>
//        ///     500120: Iso has exist
//        /// </summary>
//        public Error IsoHasExist
//        {
//            get
//            {
//                if (_isoHasExist == null)
//                {
//                    Init();
//                }

//                return _isoHasExist;
//            }
//        }

//        #endregion

//        #region 500220: Iso not exist

//        /// <summary>
//        ///     500220: Iso not exist
//        /// </summary>
//        public Error IsoNotExist
//        {
//            get
//            {
//                if (_isoNotExist == null)
//                {
//                    Init();
//                }

//                return _isoNotExist;
//            }
//        }

//        #endregion

//        private void Init()
//        {
//            #region 400000: ArrayDetail not null or empty

//            if (_arrayIsNullOrEmpty == null)
//            {
//                _arrayIsNullOrEmpty = new Error("400000", "Chi tiết không được để trống");
//            }

//            #endregion

//            #region 400100: Username not null or empty

//            if (_userNameIsNullOrEmpty == null)
//            {
//                _userNameIsNullOrEmpty = new Error("400100", "Tên đăng nhập không được để trống");
//            }

//            #endregion

//            #region 400200: Password not null or empty

//            if (_passwordIsNullOrEmpty == null)
//            {
//                _passwordIsNullOrEmpty = new Error("400200", "Mật khẩu không được để trống");
//            }

//            #endregion

//            #region 400300: UserClass not null or empty

//            if (_userClassIsNullOrEmpty == null)
//            {
//                _userClassIsNullOrEmpty = new Error("400300", "Nhóm người dùng không được để trống");
//            }

//            #endregion

//            #region 400400: SiteId is null or empty

//            if (_siteIdIsNullOrEmpty == null)
//            {
//                _siteIdIsNullOrEmpty = new Error("400400", "SiteId không được để trống");
//            }

//            #endregion

//            #region 400500: AgentId is null or empty

//            if (_agentIdIsNullOrEmpty == null)
//            {
//                _agentIdIsNullOrEmpty = new Error("400500", "Mã khách hàng không được để trống");
//            }

//            #endregion

//            #region 400600: Area is null or empty

//            if (_areaIsNullOrEmpty == null)
//            {
//                _areaIsNullOrEmpty = new Error("400600", "Khu vực không được để trống");
//            }

//            #endregion

//            #region 400700: Stack is null or empty

//            if (_stackIsNullOrEmpty == null)
//            {
//                _stackIsNullOrEmpty = new Error("400700", "Stack không được để trống");
//            }

//            #endregion

//            #region 400800: CodeTp is null or empty

//            if (_codeTpIsNullOrEmpty == null)
//            {
//                _codeTpIsNullOrEmpty = new Error("400800", "CodeTp không được để trống");
//            }

//            #endregion

//            #region 400900: CodeRef is null or empty

//            if (_codeRefIsNullOrEmpty == null)
//            {
//                _codeRefIsNullOrEmpty = new Error("400900", "CodeRef không được để trống");
//            }

//            #endregion

//            #region 400010: Menu module is null or empty

//            if (_menuModuleIsNullOrEmpty == null)
//            {
//                _menuModuleIsNullOrEmpty = new Error("400010", "MENU_MODULE không được để trống");
//            }

//            #endregion

//            #region 400110: Group code is null or empty

//            if (_groupCodeIsNullOrEmpty == null)
//            {
//                _groupCodeIsNullOrEmpty = new Error("400110", "GROUP_CODE không được để trống");
//            }

//            #endregion

//            #region 400210: Menu item code is null or empty

//            if (_menuItemCodeIsNullOrEmpty == null)
//            {
//                _menuItemCodeIsNullOrEmpty = new Error("400210", "MENU_ITEM_CODE không được để trống");
//            }

//            #endregion

//            #region 400310: Operation method is null or empty

//            if (_operationMethodIsNullOrEmpty == null)
//            {
//                _operationMethodIsNullOrEmpty = new Error("400310", "OPERATION_METHOD không được để trống");
//            }

//            #endregion

//            #region 400410: Line oper is null or empty

//            if (_lineOperIsNullOrEmpty == null)
//            {
//                _lineOperIsNullOrEmpty = new Error("400410", "LINE_OPER không được để trống");
//            }

//            #endregion

//            #region 400510: Depot is null or empty

//            if (_depotIsNullOrEmpty == null)
//            {
//                _depotIsNullOrEmpty = new Error("400510", "DEPOT không được để trống");
//            }

//            #endregion

//            #region 400610: CustomerNo is null or empty

//            if (_customerNoIsNullOrEmpty == null)
//            {
//                _customerNoIsNullOrEmpty = new Error("400610", "CustomerNo không được để trống");
//            }

//            #endregion

//            #region 400710: Iso is null or empty

//            if (_isoIsNullOrEmpty == null)
//            {
//                _isoIsNullOrEmpty = new Error("400710", "Iso không được để trống");
//            }

//            #endregion

//            #region 500000: Bad request

//            if (_badRequest == null)
//            {
//                _badRequest = new Error("500000", "Something wrong :(");
//            }

//            #endregion

//            #region 500100: Logon invalid

//            if (_logonInvalid == null)
//            {
//                _logonInvalid = new Error("500100", "Tên đăng nhập hoặc mật khẩu không chính xác");
//            }

//            #endregion

//            #region 500200: UserClass invalid

//            if (_userClassInvalid == null)
//            {
//                _userClassInvalid = new Error("500200", "Người dùng không thuộc nhóm này");
//            }

//            #endregion

//            #region 500300: AgentId has exist

//            if (_agentIdHasExist == null)
//            {
//                _agentIdHasExist = new Error("500300", "Mã khách hàng đã tồn tại trong site này");
//            }

//            #endregion

//            #region 500400: Agent not exist

//            if (_agentNotExist == null)
//            {
//                _agentNotExist = new Error("500400", "Khách hàng không tồn tại");
//            }

//            #endregion

//            #region 500500: YardArea has exist

//            if (_yardAreaHasExist == null)
//            {
//                _yardAreaHasExist = new Error("500500", "YardArea đã tồn tại trong site này");
//            }

//            #endregion

//            #region 500600: Agent not exist

//            if (_yardAreaNotExist == null)
//            {
//                _yardAreaNotExist = new Error("500600", "YardArea không tồn tại");
//            }

//            #endregion

//            #region 500700: SysCodes has exist

//            if (_sysCodesHasExist == null)
//            {
//                _sysCodesHasExist = new Error("500700", "SysCodes đã tồn tại");
//            }

//            #endregion

//            #region 500800: SysCodes not exist

//            if (_sysCodesNotExist == null)
//            {
//                _sysCodesNotExist = new Error("500800", "SysCodes không tồn tại");
//            }

//            #endregion

//            #region 500900: MenuGroup has exist

//            if (_menuGroupHasExist == null)
//            {
//                _menuGroupHasExist = new Error("500900", "MenuGroup đã tồn tại");
//            }

//            #endregion

//            #region 500010: MenuGroup not exist

//            if (_menuGroupNotExist == null)
//            {
//                _menuGroupNotExist = new Error("500010", "MenuGroup không tồn tại");
//            }

//            #endregion

//            #region 500110: MenuItem has exist

//            if (_menuItemHasExist == null)
//            {
//                _menuItemHasExist = new Error("500110", "MenuItem đã tồn tại");
//            }

//            #endregion

//            #region 500210: MenuItem not exist

//            if (_menuItemNotExist == null)
//            {
//                _menuItemNotExist = new Error("500210", "MenuItem không tồn tại");
//            }

//            #endregion

//            #region 500310: Operation method has exist

//            if (_operationMethodHasExist == null)
//            {
//                _operationMethodHasExist = new Error("500310", "OperationMethod đã tồn tại");
//            }

//            #endregion

//            #region 500410: Operation method not exist

//            if (_operationMethodNotExist == null)
//            {
//                _operationMethodNotExist = new Error("500410", "OperationMethod không tồn tại");
//            }

//            #endregion

//            #region 500510: Line oper has exist

//            if (_lineOperHasExist == null)
//            {
//                _lineOperHasExist = new Error("500510", "LineOper đã tồn tại");
//            }

//            #endregion

//            #region 500610: Line oper not exist

//            if (_lineOperNotExist == null)
//            {
//                _lineOperNotExist = new Error("500610", "LineOper không tồn tại");
//            }

//            #endregion

//            #region 500710: Depot has exist

//            if (_depotHasExist == null)
//            {
//                _depotHasExist = new Error("500710", "Depot đã tồn tại");
//            }

//            #endregion

//            #region 500810: Depot not exist

//            if (_depotNotExist == null)
//            {
//                _depotNotExist = new Error("500810", "Depot không tồn tại");
//            }

//            #endregion

//            #region 500910: CustomerNo has exist

//            if (_customerNoHasExist == null)
//            {
//                _customerNoHasExist = new Error("500910", "CustomerNo đã tồn tại");
//            }

//            #endregion

//            #region 500020: CustomerNo not exist

//            if (_customerNoNotExist == null)
//            {
//                _customerNoNotExist = new Error("500020", "CustomerNo không tồn tại");
//            }

//            #endregion

//            #region 500120: Iso has exist

//            if (_isoHasExist == null)
//            {
//                _isoHasExist = new Error("500120", "Iso đã tồn tại");
//            }

//            #endregion

//            #region 500220: Iso not exist

//            if (_isoNotExist == null)
//            {
//                _isoNotExist = new Error("500220", "Iso không tồn tại");
//            }

//            #endregion
//        }
//    }
//}
