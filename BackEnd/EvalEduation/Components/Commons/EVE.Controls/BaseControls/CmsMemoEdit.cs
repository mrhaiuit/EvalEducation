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

namespace EVE.Controls
{
    [UserRepositoryItem("RegisterEVEMemoEdit")]
    public class RepositoryItemEVEMemoEdit : RepositoryItemMemoEdit
    {
        static RepositoryItemEVEMemoEdit()
        {
            RegisterEVEMemoEdit();
        }

        public const string CustomEditName = "EVEMemoEdit";

        public RepositoryItemEVEMemoEdit()
        {
        }

        public override string EditorTypeName => CustomEditName;

        public static void RegisterEVEMemoEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EVEMemoEdit), typeof(RepositoryItemEVEMemoEdit), typeof(EVEMemoEditViewInfo), new EVEMemoEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemEVEMemoEdit source = item as RepositoryItemEVEMemoEdit;
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
    public class EVEMemoEdit : MemoEdit
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
        static EVEMemoEdit()
        {
            RepositoryItemEVEMemoEdit.RegisterEVEMemoEdit();
        }

        public EVEMemoEdit()
        {
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemEVEMemoEdit Properties => base.Properties as RepositoryItemEVEMemoEdit;

        public override string EditorTypeName => RepositoryItemEVEMemoEdit.CustomEditName;
    }

    public class EVEMemoEditViewInfo : MemoEditViewInfo
    {
        public EVEMemoEditViewInfo(RepositoryItem item) : base(item)
        {
        }
    }

    public class EVEMemoEditPainter : MemoEditPainter
    {
        public EVEMemoEditPainter()
        {
        }
    }
}
