using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE.Data;

namespace EVE.ApiModels.Authentication.Response.UserClassFormAction
{
    public class ActionDisplayByUserClassFormRes
    {
        public ActionDisplayByUserClassFormRes() { }

        public string MENU_ITEM_ACTION_CODE { get; set; }
        public string USER_CLASS { get; set; }
        public string MENU_ITEM_CODE { get; set; }
        public string FORM_ACTION { get; set; }
        public bool DISPLAY_FLG { get; set; } = false;
    } 
}
