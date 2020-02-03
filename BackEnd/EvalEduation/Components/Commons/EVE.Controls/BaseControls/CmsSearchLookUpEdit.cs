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
    [UserRepositoryItem("RegisterEVESearchLookUpEdit")]
    public class RepositoryItemEVESearchLookUpEdit : RepositoryItemSearchLookUpEdit
    {
        static RepositoryItemEVESearchLookUpEdit()
        {
            RegisterEVESearchLookUpEdit();
        }

        public const string CustomEditName = "EVESearchLookUpEdit";

        public RepositoryItemEVESearchLookUpEdit()
        {
            InitializeComponent();
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterEVESearchLookUpEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EVESearchLookUpEdit),
                typeof(RepositoryItemEVESearchLookUpEdit), typeof(EVESearchLookUpEditViewInfo), new EVESearchLookUpEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemEVESearchLookUpEdit source = item as RepositoryItemEVESearchLookUpEdit;
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
            // RepositoryItemEVESearchLookUpEdit
            // 
            this.DisplayMember = "Display";
            this.NullText = "...";
            this.ValueMember = "Value";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }

    [ToolboxItem(true)]
    public class EVESearchLookUpEdit : SearchLookUpEdit
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
        static EVESearchLookUpEdit()
        {
            RepositoryItemEVESearchLookUpEdit.RegisterEVESearchLookUpEdit();
        }

        public EVESearchLookUpEdit()
        {
            this.KeyUp += EVESearchLookUpEdit_KeyUp;
        }

        private void EVESearchLookUpEdit_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemEVESearchLookUpEdit Properties => base.Properties as RepositoryItemEVESearchLookUpEdit;

        public override string EditorTypeName => RepositoryItemEVESearchLookUpEdit.CustomEditName;

        protected override PopupBaseForm CreatePopupForm()
        {
            return new EVESearchLookUpEditPopupForm(this);
        }
    }

    public class EVESearchLookUpEditViewInfo : SearchLookUpEditBaseViewInfo
    {
        public EVESearchLookUpEditViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class EVESearchLookUpEditPainter : ButtonEditPainter
    {
        public EVESearchLookUpEditPainter()
        {
        }
    }

    public class EVESearchLookUpEditPopupForm : PopupSearchLookUpEditForm
    {
        public EVESearchLookUpEditPopupForm(EVESearchLookUpEdit ownerEdit) : base(ownerEdit)
        {
        }
    }
}
