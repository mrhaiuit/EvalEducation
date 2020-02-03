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
    [UserRepositoryItem("RegisterEVEDateEdit")]
    public class RepositoryItemEVEDateEdit : RepositoryItemDateEdit
    {
        static RepositoryItemEVEDateEdit()
        {
            RegisterEVEDateEdit();
        }
        private IContainer components;
        public const string CustomEditName = "EVEDateEdit";

        public RepositoryItemEVEDateEdit()
        {
            InitializeComponent();
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterEVEDateEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EVEDateEdit), typeof(RepositoryItemEVEDateEdit), typeof(EVEDateEditViewInfo), new EVEDateEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemEVEDateEdit source = item as RepositoryItemEVEDateEdit;
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
            ((System.ComponentModel.ISupportInitialize)(this.CalendarTimeProperties)).BeginInit();
            // 
            // RepositoryItemEVEDateEdit
            // 
            this.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DisplayFormat.FormatString = "{0:dd/MM/yyyy HH:mm}";
            this.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.EditFormat.FormatString = "{0:dd/MM/yyyy HH:mm}";
            this.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Mask.EditMask = "dd/MM/yyyy HH:mm";
            this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.MinValue = new System.DateTime(1900, 12, 31, 23, 59, 0, 0);
            this.NullDate = "12/31/1900 11:59 PM";
            ((System.ComponentModel.ISupportInitialize)(this.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }

    [ToolboxItem(true)]
    public class EVEDateEdit : DateEdit
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
        static EVEDateEdit()
        {
            RepositoryItemEVEDateEdit.RegisterEVEDateEdit();
        }

        public EVEDateEdit()
        {
            this.KeyUp += EVEDateEdit_KeyUp;
        }

        private void EVEDateEdit_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemEVEDateEdit Properties => base.Properties as RepositoryItemEVEDateEdit;

        public override string EditorTypeName => RepositoryItemEVEDateEdit.CustomEditName;

        protected override PopupBaseForm CreatePopupForm()
        {
            return new EVEDateEditPopupForm(this);
        }
    }

    public class EVEDateEditViewInfo : DateEditViewInfo
    {
        public EVEDateEditViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class EVEDateEditPainter : ButtonEditPainter
    {
        public EVEDateEditPainter()
        {
        }
    }

    public class EVEDateEditPopupForm : PopupDateEditForm
    {
        public EVEDateEditPopupForm(EVEDateEdit ownerEdit) : base(ownerEdit)
        {
        }
    }
}
