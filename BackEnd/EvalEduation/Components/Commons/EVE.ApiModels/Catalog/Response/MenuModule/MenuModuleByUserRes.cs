using System.Collections.Generic;
using EVE.Data;

namespace EVE.ApiModels.Catalog.Response.MenuGroup
{
    public class MenuModuleByUserRes
    {
        public MenuModuleByUserRes()
        {
        }

        public string MODULE_CODE { get; set; }

        public string MODULE_NAME { get; set; }

        public short? IDX { get; set; }

        public List<MenuGroupByUserRes> GROUPS { get; set; }
    }

    public class MenuGroupByUserRes
    {
        public MenuGroupByUserRes()
        {
        }


        public string GROUP_CODE { get; set; }

        public string GROUP_NAME { get; set; }

        public short? IDX { get; set; }

        public string IMAGE { get; set; }

        public List<MenuItemByUserRes> ITEMS { get; set; }
    }

    public class MenuItemByUserRes
    {
        public MenuItemByUserRes()
        {
        }


        public string MENU_ITEM_CODE { get; set; }

        public string MENU_ITEM_NAME { get; set; }

        public string FORM_CODE { get; set; }

        public int DISPLAY_TYPE { get; set; }

        public short? IDX { get; set; }

        public string IMAGE { get; set; }
    }
}
