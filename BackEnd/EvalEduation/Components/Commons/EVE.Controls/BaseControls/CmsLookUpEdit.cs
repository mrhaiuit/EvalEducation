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
    [UserRepositoryItem("RegisterEVELookUpEdit")]
    public class RepositoryItemEVELookUpEdit : RepositoryItemLookUpEdit
    {
        static RepositoryItemEVELookUpEdit()
        {
            RegisterEVELookUpEdit();
        }

        public const string CustomEditName = "EVELookUpEdit";

        public RepositoryItemEVELookUpEdit()
        {
            InitializeComponent();
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterEVELookUpEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EVELookUpEdit), typeof(RepositoryItemEVELookUpEdit), typeof(EVELookUpEditViewInfo), new EVELookUpEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemEVELookUpEdit source = item as RepositoryItemEVELookUpEdit;
                if (source == null) return;
                //
            }
            finally
            {
                EndUpdate();
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // RepositoryItemEVELookUpEdit
            // 
            this.NullText = "...";
            this.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.PopupFormMinSize = new System.Drawing.Size(300, 300);
            this.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }

    [ToolboxItem(true)]
    public class EVELookUpEdit : LookUpEdit
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

        static EVELookUpEdit()
        {
            RepositoryItemEVELookUpEdit.RegisterEVELookUpEdit();
            
        }

        public EVELookUpEdit()
        {
            this.KeyUp += EVELookUpEdit_KeyUp;
        }

        private void EVELookUpEdit_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                this.EditValue = null;
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return )
            {
                SendKeys.Send("{TAB}");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemEVELookUpEdit Properties => base.Properties as RepositoryItemEVELookUpEdit;

        public override string EditorTypeName => RepositoryItemEVELookUpEdit.CustomEditName;

        protected override PopupBaseForm CreatePopupForm()
        {
            return new EVELookUpEditPopupForm(this);
        }
    }

    public class EVELookUpEditViewInfo : LookUpEditViewInfo
    {
        public EVELookUpEditViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class EVELookUpEditPainter : ButtonEditPainter
    {
        public EVELookUpEditPainter()
        {
        }
    }

    public class EVELookUpEditPopupForm : PopupLookUpEditForm
    {
        public EVELookUpEditPopupForm(EVELookUpEdit ownerEdit) : base(ownerEdit)
        {
        }
    }
}
