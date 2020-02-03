using DevExpress.XtraEditors;

namespace EVE.Controls
{
    public static class SearchLookupEditExtensions
    {
        public static void SetMember(this SearchLookUpEdit control,
                                     string displayMember,
                                     string valueMember)
        {
            control.Properties.DisplayMember = displayMember;
            control.Properties.ValueMember = valueMember;
        }
    }
}
