using System.Collections.Generic;

namespace EVE.ApiModels.Catalog.Response.MenuGroup
{
    public class MenuModuleByUserClassRes
    {
        public string MODULE_CODE { get; set; }

        public string MODULE_NAME { get; set; }

        public string GROUP_CODE { get; set; }

        public string GROUP_NAME { get; set; }

        public string MENU_ITEM_CODE { get; set; }

        public string MENU_ITEM_NAME { get; set; }

        public short? IDX { get; set; }

        public string IMAGE { get; set; }

        public bool ISACCESSABLE { get; set; }

        public List<FormActionByUserClass> FormActions { get; set; } = new List<FormActionByUserClass>();
    }

    public class FormActionByUserClass
    {
        public string FormActionCode { get; set; }

        public string FormActionName { get; set; }

        public bool IsAccessable { get; set; }
    }
}
