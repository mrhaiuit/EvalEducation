using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace EVE.Controls
{
    public static class DialogBox
    {
        public static void Infomation()
        {
            XtraMessageBox.Show("Dữ liệu đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string text)
        {
            XtraMessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Warnning(string text)
        {
            XtraMessageBox.Show(text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="infoString">Sequence information to show</param>
        public static void Infomation(string infoString)
        {
            XtraMessageBox.Show(infoString, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Question()
        {
            return XtraMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="questionString">Sequence information to show</param>
        /// <returns>Yes: Agree; No: Disagree</returns>
        public static DialogResult Question(string questionString)
        {
            return XtraMessageBox.Show(questionString, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private static DevExpress.Utils.WaitDialogForm wdf = null;

        public static void ShowWaitDialog(string caption, string title)
        {
            if (title == "")
                wdf = new DevExpress.Utils.WaitDialogForm(caption);
            else
                wdf = new DevExpress.Utils.WaitDialogForm(caption, title);
            wdf.ShowInTaskbar = false;
        }

        public static void ShowWaitDialog(string caption, string title, Form frm)
        {
            if (title == "")
                wdf = new DevExpress.Utils.WaitDialogForm(caption);
            else
                wdf = new DevExpress.Utils.WaitDialogForm(caption, title, new System.Drawing.Size(250, 60), frm);
            wdf.ShowInTaskbar = false;
            wdf.StartPosition = FormStartPosition.CenterParent;
        }

        public static void SetCaption(string caption)
        {
            wdf.SetCaption(caption);
        }

        public static void CloseWaitDialog()
        {
            try
            {
                wdf.Close();
            }
            catch { }
        }

        public static void Dispose()
        {
            try
            {
                wdf.Dispose();
            }
            catch { }
        }

        public static DevExpress.Utils.WaitDialogForm WaitingForm()
        {
            return new DevExpress.Utils.WaitDialogForm("Đang xử lý. Vui lòng chờ...", "EVE");
        }
        public static DevExpress.Utils.WaitDialogForm WaitingForm(string inform)
        {
            return new DevExpress.Utils.WaitDialogForm(inform, "EVE");
        }

    }
}
