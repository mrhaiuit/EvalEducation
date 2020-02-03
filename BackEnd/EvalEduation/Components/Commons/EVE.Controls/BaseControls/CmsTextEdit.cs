using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Popup;
using System.Windows.Forms;

namespace EVE.Controls.BaseControls
{
    [UserRepositoryItem("RegisterEVETextEdit")]
    public class RepositoryItemEVETextEdit : RepositoryItemTextEdit
    {
        static RepositoryItemEVETextEdit()
        {
            RegisterEVETextEdit();
        }

        public const string CustomEditName = "EVETextEdit";

        public RepositoryItemEVETextEdit()
        {
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterEVETextEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EVETextEdit), typeof(RepositoryItemEVETextEdit), typeof(EVETextEditViewInfo), new EVETextEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemEVETextEdit source = item as RepositoryItemEVETextEdit;
                if (source == null) return;
                //
            }
            finally
            {
                EndUpdate();
            }
        }
    }

    [ToolboxItem(true)]
    public class EVETextEdit : TextEdit
    {
        bool isRequire;
        public bool IsRequire
        {
            get
            {
                return isRequire;
            }
            set
            {
                isRequire = value;
                if (isRequire)
                    BackColor = System.Drawing.Color.LightGoldenrodYellow;
                else
                    BackColor = Color.White;
            }
        }
        static EVETextEdit()
        {
            RepositoryItemEVETextEdit.RegisterEVETextEdit();
        }

        public EVETextEdit()
        {
            this.KeyUp += EVETextEdit_KeyUp;
        }

        private void EVETextEdit_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemEVETextEdit Properties => base.Properties as RepositoryItemEVETextEdit;

        public override string EditorTypeName => RepositoryItemEVETextEdit.CustomEditName;
    }

    public class EVETextEditViewInfo : TextEditViewInfo
    {
        public EVETextEditViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class EVETextEditPainter : TextEditPainter
    {
        public EVETextEditPainter()
        {
        }
    }
}
