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
    [UserRepositoryItem("RegisterEVESpinEdit")]
    public class RepositoryItemEVESpinEdit : RepositoryItemSpinEdit
    {
        static RepositoryItemEVESpinEdit()
        {
            RegisterEVESpinEdit();
        }

        public const string CustomEditName = "EVESpinEdit";

        public RepositoryItemEVESpinEdit()
        {
            InitializeComponent();
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterEVESpinEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EVESpinEdit), typeof(RepositoryItemEVESpinEdit), typeof(EVESpinEditViewInfo), new EVESpinEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemEVESpinEdit source = item as RepositoryItemEVESpinEdit;
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
            // RepositoryItemEVESpinEdit
            // 
            this.DisplayFormat.FormatString = "{0:#,0.##}";
            this.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.EditFormat.FormatString = "{0:#,0.##}";
            this.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }

    [ToolboxItem(true)]
    public class EVESpinEdit : SpinEdit
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
        static EVESpinEdit()
        {
            RepositoryItemEVESpinEdit.RegisterEVESpinEdit();
        }

        public EVESpinEdit()
        {
            this.KeyUp += EVESpinEdit_KeyUp;
        }

        private void EVESpinEdit_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemEVESpinEdit Properties => base.Properties as RepositoryItemEVESpinEdit;

        public override string EditorTypeName => RepositoryItemEVESpinEdit.CustomEditName;
    }

    public class EVESpinEditViewInfo : BaseSpinEditViewInfo
    {
        public EVESpinEditViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class EVESpinEditPainter : ButtonEditPainter
    {
        public EVESpinEditPainter()
        {
        }
    }
}
