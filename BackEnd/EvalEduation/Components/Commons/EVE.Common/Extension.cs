// <copyright file="Extension.cs" company="TCIS">
// Copyright (c) .  All rights reserved.  Reproduction or transmission in 
// whole or in part, in any form or by any means, electronic, mechanical or 
// otherwise, is prohibited without the prior written consent of the copyright 
// owner.
// </copyright>
//
// <summary>
// Thêm 1 số Functions liên quan đến chuẩn hóa các Control textbox, richtext, combobox: color, keypress,...
// </summary>
// <remarks>
// </remarks>
// <history>
// Date         Release         Task            Who         Summary
// ===================================================================================
// 24/09/2012   1.0.0.0                         LKTL        Created
// 30/06/2013   1.0.0.1                         THHUNG      Add
// </history>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Data;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Cryptography;
using EVE.Commons.Attribute;
using EVE.Data;

namespace EVE.Commons
{
    public static class Extension
    {
        #region Control

        public static void SetPositionToCenterParent(this Control ctl, System.Windows.Forms.Form parentForm)
        {
            var parent = parentForm;

            if (parent != null)
            {
                Point location = parent.PointToScreen(ctl.Location);
                ctl.Location = new Point(location.X + (parent.Width - ctl.Width) / 2, location.Y + (parent.Height - ctl.Height) / 2);
            }
        }

        private static readonly Dictionary<Type, Action<Control>> ControlDefaultClearTexts = new Dictionary
            <Type, Action<Control>>
            {
                {typeof (TextBox), c => c.ResetText()},
                {typeof (MaskedTextBox), c => c.ResetText()},
                {typeof (RichTextBox), c => c.ResetText()},
                {typeof (ComboBox), c => c.ResetText()},
                //{typeof (CheckBox), c => ((CheckBox) c).Checked = false},
                {typeof (GroupBox), c => (c).Controls.ClearControls()},
                {typeof (Panel), c => (c).Controls.ClearControls()}
            };

        private static void FindAndInvokeClearText(Type type, Control control)
        {
            if (ControlDefaultClearTexts.ContainsKey(type))
            {
                ControlDefaultClearTexts[type].Invoke(control);
                return;
            }

            //Invoke the base type if custom control
            if (type.BaseType != null && ControlDefaultClearTexts.ContainsKey(type.BaseType))
            {
                ControlDefaultClearTexts[type.BaseType].Invoke(control);
            }
        }

        public static bool IsControlInput(this Control control)
        {
            if (control is TextBox || control is MaskedTextBox || control is RichTextBox)
            {
                return true;
            }

            var baseType = control.GetType().BaseType;
            if (baseType == typeof(TextBox) || baseType == typeof(MaskedTextBox) || baseType == typeof(RichTextBox))
            {
                return true;
            }

            return false;
        }

        public static bool IsAllControlHasValue(this IEnumerable<Control> controls)
        {
            return controls == null || controls.All(obj => obj.Text != string.Empty);
        }

        public static bool IsMandatoryHasValue(this IEnumerable<Control> controls)
        {
            return controls == null || controls.All(obj => !((dynamic)obj).MandatoryField || ((dynamic)obj).Text != string.Empty);
        }

        public static bool IsMandatoryHasValue(this Control control)
        {
            var baseType = control.GetType().BaseType;

            var validControl = (control is TextBox || control is MaskedTextBox || control is RichTextBox ||
                                control is ComboBox) ||
                               (baseType == typeof(TextBox) || baseType == typeof(MaskedTextBox) ||
                                baseType == typeof(RichTextBox) || baseType == typeof(ComboBox));

            if (validControl)
            {
                try
                {

                    dynamic obj = control;
                    if (!obj.ReadOnly && obj.MandatoryField && obj.Text == string.Empty)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            }

            if (control.HasChildren)
            {
                return control.Controls.Cast<Control>().All(subControl => subControl.IsMandatoryHasValue());
            }

            return true;
        }

        /// <summary>
        /// Clear Text on control and its child control
        /// </summary>
        /// <param name="controls"></param>
        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                FindAndInvokeClearText(control.GetType(), control);
            }
        }

        public static void ClearControls<T>(this Control.ControlCollection controls) where T : class
        {
            if (!ControlDefaultClearTexts.ContainsKey(typeof(T))) return;

            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(T))
                {
                    FindAndInvokeClearText(typeof(T), control);
                }
            }
        }

        public static void SetEnableControlsText(this Control.ControlCollection controls, bool value)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox || control is ComboBox || control is RichTextBox || control is MaskedTextBox)
                {
                    control.Enabled = value;
                }
            }
        }

        public static void SetEnableControls<T>(this Control.ControlCollection controls, bool value) where T : class
        {
            if (!ControlDefaultClearTexts.ContainsKey(typeof(T))) return;

            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(T))
                {
                    control.Enabled = value;
                }
            }
        }

        public static void SelectNextActiveControl(this Control control)
        {
            var baseType = control.GetType().BaseType;

            var validControl = (control is TextBox || control is MaskedTextBox ||
                                control is ComboBox) || control is CheckBox || control is RadioButton ||
                               (baseType == typeof(TextBox) || baseType == typeof(MaskedTextBox) || baseType == typeof(ComboBox));
            if (validControl)
            {
                var parentForm = control;
                while (parentForm != null)
                {
                    if (parentForm is System.Windows.Forms.Form)
                    {
                        parentForm.SelectNextControl(control, true, true, true, true);
                        return;
                    }

                    parentForm = parentForm.Parent;

                }
            }
        }

        public static void SelectPreviousActiveControl(this Control control)
        {
            var baseType = control.GetType().BaseType;

            var validControl = (control is TextBox || control is MaskedTextBox ||
                                control is ComboBox) || control is CheckBox || control is RadioButton ||
                               (baseType == typeof(TextBox) || baseType == typeof(MaskedTextBox) || baseType == typeof(ComboBox));
            if (validControl)
            {
                var parentForm = control;
                while (parentForm != null)
                {
                    if (parentForm is System.Windows.Forms.Form)
                    {
                        parentForm.SelectNextControl(control, false, true, true, true);
                        return;
                    }

                    parentForm = parentForm.Parent;

                }
            }
        }

        /// <summary>
        /// Check if control has textbox and textbox is empty or whitespace
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool IsEmptyText(this Control control)
        {
            if (control is TextBox || control is MaskedTextBox || control is ComboBox || control is RichTextBox)
            {
                return string.IsNullOrWhiteSpace(control.Text);
            }

            return false;
        }

        /// <summary>
        /// The functions set the given control to state of error by setting it's back color to red and set focus on it
        /// </summary>
        /// <param name="control"></param>
        public static void SetError(this Control control)
        {
            //control.BackColor = Color.Cyan;
            //control.Text = string.Empty;
            control.FocusEx();

        }

        public static void SetWaitCursor(this Control control)
        {
            if (control != null)
            {
                control.Cursor = Cursors.WaitCursor;
            }
        }

        public static void SetDefaultCursor(this Control control)
        {
            if (control != null)
            {
                control.Cursor = Cursors.Default;
            }
        }

        #region delay set focus to control

        private delegate void ChangeFocusDelegate(Control ctl);
        /// <summary>
        /// This extension method is able to be used inside a  Enter, GotFocus, Leave, LostFocus, Validating, or Validated event handler to set focus to a control 
        /// </summary>
        /// <param name="control"></param>
        public static void FocusEx(this Control control)
        {
            control.BeginInvoke(new ChangeFocusDelegate(ChangeFocus), control);
        }

        /// <summary>
        /// Set focus on the given control
        /// </summary>
        /// <param name="ctl"></param>
        private static void ChangeFocus(Control ctl)
        {
            ctl.Focus();
        }

        #endregion


        #region Delay select text in a text box

        private delegate void DelaySelectDelegate(Control ctl, int selectionStart, int selectionLenght);

        /// <summary>
        /// This extension method is able to be used inside a  Enter, GotFocus, Leave, LostFocus, Validating, or Validated event handler to set focus to a control 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="selectionStart"></param>
        /// <param name="selectionLength"></param>
        public static void SetDelaySelectText(this Control control, int selectionStart, int selectionLength)
        {
            control.BeginInvoke(new DelaySelectDelegate(DelaySelect), control, selectionStart, selectionLength);
        }

        /// <summary>
        /// Set focus on the given control
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="selectionStart"></param>
        /// <param name="selectionLenght"></param>
        private static void DelaySelect(Control ctl, int selectionStart, int selectionLenght)
        {
            var textBox = (TextBoxBase)ctl;
            textBox.SelectionStart = selectionStart;
            textBox.SelectionLength = selectionLenght;

        }


        #endregion


        public static void AppendText(this RichTextBox box, string text, Color color, int fontSize = 0)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;

            if (fontSize != 0)
            {
                box.SelectionFont = new Font("Tahoma", fontSize);
            }

            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        #region Normalize Control

        ///thhung add 30-06-2013
        /// <summary>
        /// Gán các hàm kiểm tra Valid data cho TextBox trong control hoặc Form
        /// </summary>
        public static void AssignValidDataEvent(this Control obj, EventHandler eventHander)
        {
            foreach (Control txt in obj.Controls)
            {
                //chỉ valid TextBox, RichText, ComboBox
                if (txt is TextBox || txt is RichTextBox || txt is ComboBox)
                {
                    if (eventHander != null)
                    {
                        //Luôn đảm bảo chỉ đăng ký duy nhất 1 eventHander
                        txt.Validated -= eventHander;
                        txt.Validated += eventHander;
                    }
                }
            }
        }

        /// <summary>
        /// Gán tất cả các Control TextBox cho sự kiện Focus
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="eventHander"></param>
        public static void AssignFocusEvent(this Control obj, EventHandler eventHander)
        {
            foreach (Control txt in obj.Controls)
            {
                //chỉ valid TextBox, RichText, ComboBox
                if (txt is TextBox || txt is RichTextBox || txt is ComboBox)
                {
                    if (eventHander != null)
                    {
                        //Luôn đảm bảo chỉ đăng ký duy nhất 1 eventHander
                        txt.GotFocus -= eventHander;
                        txt.GotFocus += eventHander;

                    }
                }
            }
        }

        public static void AssignLostFocusEvent(this Control obj, EventHandler eventHander)
        {
            foreach (Control txt in obj.Controls)
            {
                //chỉ valid TextBox, RichText, ComboBox
                if (txt is TextBox || txt is RichTextBox || txt is ComboBox)
                {
                    if (eventHander != null)
                    {
                        //Luôn đảm bảo chỉ đăng ký duy nhất 1 eventHander
                        txt.LostFocus -= eventHander;
                        txt.LostFocus += eventHander;

                    }
                }
            }
        }

        public static void AssignKeyUpEvent(this Control obj, KeyEventHandler eventHander)
        {
            foreach (Control txt in obj.Controls)
            {
                //chỉ valid TextBox, RichText, ComboBox
                if (txt is TextBox || txt is RichTextBox || txt is ComboBox)
                {
                    if (eventHander != null)
                    {
                        //Luôn đảm bảo chỉ đăng ký duy nhất 1 eventHander
                        txt.KeyUp -= eventHander;
                        txt.KeyUp += eventHander;

                    }
                }
            }
        }

        public static void AssignTextChangedEvent(this Control obj, EventHandler eventHander)
        {
            foreach (Control txt in obj.Controls)
            {
                //chỉ valid TextBox, RichText, ComboBox
                if (txt is TextBox || txt is RichTextBox || txt is ComboBox)
                {
                    if (eventHander != null)
                    {
                        //Luôn đảm bảo chỉ đăng ký duy nhất 1 eventHander
                        txt.TextChanged -= eventHander;
                        txt.TextChanged += eventHander;

                    }
                }
            }
        }

        public static void ControlLostFocus(this Control obj, object sender, EventArgs e)
        {

            //Phục hồi lại BackGround của Control
            if (sender is TextBox || sender is RichTextBox || sender is ComboBox)
            {
                Control parent = ((Control)sender).Parent;

                if (parent.Controls.ContainsKey("txtSaveInfo8080"))
                {
                    ((Control)sender).BackColor = parent.Controls["txtSaveInfo8080"].BackColor;
                }
            }
            //throw new NotImplementedException();
        }

        public static void ControlGotFocus(this Control obj, object sender, EventArgs e)
        {
            //Save lại BackGround của Control
            if (sender is TextBox || sender is RichTextBox || sender is ComboBox)
            {
                Control parent = ((Control)sender).Parent;

                if (!parent.Controls.ContainsKey("txtSaveInfo8080"))
                {
                    var saveInfo = new TextBox { Name = "txtSaveInfo8080" };
                    parent.Controls.Add(saveInfo);
                    saveInfo.Visible = false;
                }
                //Save lại BK color
                parent.Controls["txtSaveInfo8080"].BackColor = ((Control)sender).BackColor;

                ((Control)sender).BackColor = Color.LightBlue;
            }
        }
        /// <summary>
        /// Auto move next control
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ControlKeyUp(this Control obj, object sender, KeyEventArgs e)
        {
            if (sender is TextBox || sender is RichTextBox || sender is ComboBox)
            {

                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (sender is TextBox && ((TextBox)sender).Multiline && !((TextBox)sender).ReadOnly)
                    {
                        return;
                    }

                    if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Down)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    if (e.KeyCode == Keys.Up)
                    {
                        SendKeys.Send("+{TAB}");
                    }
                }

            }
        }

        /// <summary>
        /// Convert về chữ hoa
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ControlTextChanged(this Control obj, object sender, EventArgs e)
        {
            //Không xét Password textbox
            if (sender is TextBox || sender is ComboBox)
            {
                var textBox = sender as TextBox;
                if (textBox != null)
                {
                    if (textBox.UseSystemPasswordChar)
                    {
                        return;
                    }
                    TextBox testTextBox = textBox;

                    if (Char.IsLetterOrDigit(testTextBox.PasswordChar)
                        || Char.IsPunctuation(testTextBox.PasswordChar)
                        || Char.IsSymbol(testTextBox.PasswordChar)
                        || Char.IsSeparator(testTextBox.PasswordChar)
                        )
                    {
                        return;
                    }
                }

                int maxLen = (sender is TextBox) ? ((TextBox)sender).MaxLength : ((ComboBox)sender).MaxLength;
                int len = ((Control)sender).Text.Trim().Length;

                int curCaret = (sender is TextBox) ? ((TextBox)sender).SelectionStart : ((ComboBox)sender).SelectionStart;

                if (maxLen <= 15)
                {
                    ((Control)sender).Text = ((Control)sender).Text.ToUpper();

                    var box = sender as TextBox;
                    if (box != null)
                    {
                        box.SelectionStart = curCaret + 1;
                    }
                    var comboBox = sender as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.SelectionStart = curCaret + 1;
                    }
                }

                if ((sender is TextBox && len == ((TextBox)sender).MaxLength) ||
                        (sender is ComboBox && len == ((ComboBox)sender).MaxLength)
                   )
                {

                    SendKeys.Send("{TAB}");
                }

            }
        }

        

        /// <summary>
        /// Set form default location
        /// </summary>
        /// <param name="frm"></param>
        public static void FormDefaultLocation(this System.Windows.Forms.Form frm)
        {
            if (frm.IsMdiChild)
            {
                frm.Top = 0;
                frm.Left = 0;
            }
            else
            {
                frm.Top = Convert.ToInt32((Screen.PrimaryScreen.Bounds.Height / 2) - (frm.Height / 2));
                frm.Left = Convert.ToInt32((Screen.PrimaryScreen.Bounds.Width / 2) - (frm.Width / 2));
            }
        }

        #endregion


        /// <summary>
        /// accept only numeric charater, "+", "-", Tab, Backspace, Enter
        /// if bDecimalNumber=true (field is decimal number), then ".",  ", " can be accpeted
        /// this funciton is called from "KeyPress" event of the TextBox
        /// </summary>
        /// <param name="e"></param>
        /// <param name="bDecimalNumber"></param>
        public static void AcceptNumericChar(ref KeyPressEventArgs e, bool bDecimalNumber)
        {
            bool bAcceptChar = false;

            bAcceptChar = (Char.IsDigit(e.KeyChar) ||
                          (e.KeyChar == '+') ||
                          (e.KeyChar == '-') ||
                          (e.KeyChar == (Char)Keys.Tab) ||
                          (e.KeyChar == (Char)Keys.Back) ||
                          (e.KeyChar == (Char)Keys.Enter));
            if (bDecimalNumber)
                bAcceptChar = bAcceptChar ||
                              (e.KeyChar == '.') ||
                              (e.KeyChar == ',');
            if (!bAcceptChar)
            {
                MessageBox.Show("Field must be numeric!.", "Error", MessageBoxButtons.OK);
                e.Handled = true;                       //reject keystroke
            }
        }

        #endregion

        #region CAST base type object

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringEx(this string str, int startIndex, int length)
        {
            try
            {
                if (str == null)
                {
                    return string.Empty;
                }

                if (startIndex + length <= str.Length)
                {
                    return str.Substring(startIndex, length);
                }

                return str.Substring(startIndex);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string SubstringEx(this string str, int startIndex)
        {
            if (str == null)
            {
                return "";
            }

            if (startIndex < str.Length)
            {
                return str.Substring(startIndex);
            }
            return "";
        }



        public static string GetNumberFromStr(this string input)
        {
            // Split on one or more non-digit characters.
            var numRegx = new Regex(@"-*\d{1,9}\.\d{1,9}|-*\d{1,9}");
            //@"([0-9]+)|([-][0-9]+)"

            var numbers = numRegx.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();

            //string[] numbers = System.Text.RegularExpressions.Regex.Split(input, @"\-*\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    double result;
                    if (double.TryParse(value, out result))
                    {
                        return value;
                    }
                }
            }

            return "";
        }

        public static bool IsValidTemperarure(this string input)
        {
            if (input.IsNumber())
            {
                return true;
            }

            var temp = input.SubstringEx(0, input.Length - 1);
            var unit = input.SubstringEx(temp.Length);

            if (!temp.IsNumber())
            {
                return false;
            }

            if (unit.ToUpper() != "C" && unit.ToUpper() != "F")
            {
                return false;
            }

            return true;

        }

        public static bool IsValidVent(this string input)
        {
            if (input.IsNumber())
            {
                return false;
            }

            var vent = input.SubstringEx(0, 1);
            var unit = "";

            if (!vent.IsNumber())
            {
                return false;
            }

            //while (vent.IsNumber() && vent.Length < input.Length)
            //{
            //    vent = input.SubstringEx(0, vent.Length + 1);
            //}

            vent = input.GetNumberFromStr();

            unit = input.SubstringEx(vent.Length);

            var VentUnit = new[] { "%", "M3", "M3/H", "M3H", "CBM", "CBMH", "CBM/H" };

            if (!VentUnit.Contains(unit.ToUpper()))
            {
                return false;
            }

            return true;

        }


        public static string GetTempUnitFromStr(this string input)
        {
            // Split on one or more letter characters.
            var letterRegx = new Regex(@"[CFcf]");
            //@"([0-9]+)|([-][0-9]+)"

            var letters = letterRegx.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();

            //string[] numbers = System.Text.RegularExpressions.Regex.Split(input, @"\-*\D+");
            foreach (string value in letters)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }

            return "C";
        }

        public static string GetVentUnitFromStr(this string input)
        {
            if (input.TrimEx().Contains("%"))
            {
                return "%";
            }

            if (input.TrimEx().ToUpper().Contains("M3"))
            {
                return "M3";
            }

            return "%";
        }



        public static string RemoveMultipleWhiteSpaces(this string s)
        {
            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            return regex.Replace(s, " ").ToUpper();
        }

        public static string RemoveCharacterAtFirstAndLastEx(this string s, string character)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            // remove comma in last
            while (s.EndsWith(character))
                s = s.Substring(0, s.Length - 1);

            // remove comma in last
            while (s.StartsWith(character))
                s = s.Substring(1, s.Length - 1);

            return s;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEx(this string str)
        {
            if (str == null)
            {
                return "";
            }

            return str.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEx(this object str)
        {
            if (str == null)
            {
                return "";
            }

            return Convert.ToString(str).Trim();
        }

        /// <summary>
        /// Return string value, if object is null return empty string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringEx(this object str)
        {
            if (str == null)
            {
                return "";
            }


            return str.ToString();
        }

        public static string ToStringOracle(this string pStrInput)
        {
            string strOutput;
            string strTmp;
            int i;
            int strLen;

            strOutput = "";
            strLen = pStrInput.Length;

            for (i = 0; i < strLen; i++)
            {
                strTmp = pStrInput.SubstringEx(i, 1);
                if (strTmp != "\'")
                {
                    strOutput = strOutput + strTmp;
                    //if (strTmp == "+")
                    //{
                    //    strOutput = strOutput + "&";
                    //}
                    //else
                    //{
                    //    strOutput = strOutput + strTmp;
                    //}
                }
                else
                {
                    strOutput = strOutput + "\'\'";
                }
            }
            return strOutput.CheckBlankEx();
        }


        public static string ToUpperFirstAndLowerString(this string pStrInput)
        {
            if (pStrInput.TrimEx().Length <= 0)
            {
                return "";
            }

            return pStrInput.SubstringEx(0, 1).ToUpper() + pStrInput.SubstringEx(1).ToLower();
        }

        /// <summary>
        /// If the given string is null or empty, the function returns a space (' ') instead.
        /// Otherwise, the function returns a trimmed string.
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string CheckBlankEx(this string strInput)
        {
            if (strInput == null)
            {
                return " ";
            }

            if (strInput.Trim() == "")
            {
                return " ";
            }

            return strInput.Trim();
        }

        /// <summary>
        /// Check if string is null or empty then return space
        /// otherwise return trim of itself        
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckBlankEx(this object str)
        {
            if (str == null)
                return " ";

            string returnVal = str.TrimEx();

            if (returnVal == "")
                return " ";

            return returnVal;
        }

        /// <summary>
        /// Convert object to bool value
        /// if can not, return 0
        /// </summary>
        /// <param name="inputVal"></param>
        /// <returns></returns>
        public static bool CheckBooleanEx(this object inputVal)
        {
            if (inputVal == null)
                return false;

            bool retValue;

            if (Boolean.TryParse(inputVal.TrimEx(), out retValue))
            {
                return (bool)retValue;
            }

            return false;
        }

        /// <summary>
        /// Convert object to int value
        /// if can not, return 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CheckIntEx(this object str)
        {
            if (str == null)
                return 0;

            Double retValue;

            if (Double.TryParse(str.TrimEx(), out retValue))
            {
                return (int)retValue;
            }

            //if (Int32.TryParse(str.TrimEx(), out retValue))
            //{
            //    return retValue;
            //}

            return 0;
        }

        public static decimal CheckDecimalEx(this object str)
        {
            if (str == null)
                return (decimal)0.0;

            decimal retValue;
            if (decimal.TryParse(str.TrimEx(), out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// convert object to double value
        /// if can not return 0.0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double CheckDoubleEx(this object str)
        {
            if (str == null)
                return 0.0;

            double retValue;
            if (Double.TryParse(str.TrimEx(), out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// convert object to long value
        /// if can not reuturn 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long CheckLongEx(this object str)
        {
            if (str == null)
                return 0;

            long retValue;
            if (Int64.TryParse(str.TrimEx(), out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// Return string with fix size
        /// </summary>
        /// <returns></returns>
        public static string FixString(this string str, int size)
        {
            string result;

            if (str.Length > size)
            {
                result = str.SubstringEx(0, size);
            }
            else
            {
                var format = $"{{0, {-size}}}";
                result = string.Format(format, str);
            }

            return result;
        }

        /// <summary>
        /// Check if input string is null or empty/whitespace only
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsEmpty(this object str)
        {
            return IsEmptyEx(str.ToStringEx());
        }

        public static bool IsEmptyEx(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// Check if input string is alphabet character
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsAlphabet(this string str)
        {
            string checkStr = str.ToUpper();

            if (checkStr.Trim().Length == 0)
                return false;

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                if (!('A' <= checkStr[i] && checkStr[i] <= 'Z'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check input string is Digit characters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDigit(this string str)
        {
            string checkStr = str;

            if (checkStr.Trim().Length == 0)
            {
                return false;
            }

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                if (!('0' <= checkStr[i] && checkStr[i] <= '9'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check if input string is number
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str)
        {
            if (str.Length == 0)
                return false;

            double retValue;
            return (Double.TryParse(str.TrimEx(), out retValue));
        }

        /// <summary>
        /// Get length of string in byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int LengthByte(this string str)
        {
            byte[] unicodeByte = Encoding.Unicode.GetBytes(str);
            return Encoding.Unicode.GetCharCount(unicodeByte);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubStringByte(this string str, int length)
        {
            int byteCount = 0;
            char[] buffer = new char[1];
            for (int i = 0; i < str.Length; i++)
            {
                buffer[0] = str[i];
                byteCount += Encoding.UTF8.GetByteCount(buffer);
                if (byteCount > length)
                {
                    // Couldn't add this character. Return its index
                    return str.Substring(0, i);
                }
            }
            return str;
        }

        public static string RejectMarks(this string text)
        {
            var pattern = new string[7];
            var replaceChar = new char[14];

            // Khởi tạo giá trị thay thế

            replaceChar[0] = 'a';
            replaceChar[1] = 'd';
            replaceChar[2] = 'e';
            replaceChar[3] = 'i';
            replaceChar[4] = 'o';
            replaceChar[5] = 'u';
            replaceChar[6] = 'y';
            replaceChar[7] = 'A';
            replaceChar[8] = 'D';
            replaceChar[9] = 'E';
            replaceChar[10] = 'I';
            replaceChar[11] = 'O';
            replaceChar[12] = 'U';
            replaceChar[13] = 'Y';

            //Mẫu cần thay thế tương ứng

            pattern[0] = "(á|à|ả|ã|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ)"; //letter a
            pattern[1] = "đ"; //letter d
            pattern[2] = "(é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ)"; //letter e
            pattern[3] = "(í|ì|ỉ|ĩ|ị)"; //letter i
            pattern[4] = "(ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ)"; //letter o
            pattern[5] = "(ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự)"; //letter u
            pattern[6] = "(ý|ỳ|ỷ|ỹ|ỵ)"; //letter y

            for (int i = 0; i < pattern.Length; i++)
            {
                MatchCollection matchs = Regex.Matches(text, pattern[i], RegexOptions.IgnoreCase);
                foreach (Match m in matchs)
                {
                    char ch = char.IsLower(m.Value[0]) ? replaceChar[i] : replaceChar[i + 7];
                    text = text.Replace(m.Value[0], ch);
                }
            }
            return text;
        }

        public static string RejectMarksRegex(this string ip_str_change)
        {
            if (ip_str_change.IsEmpty())
            {
                return ip_str_change;
            }

            var v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = ip_str_change.Normalize(NormalizationForm.FormD);

            var ret = v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            var value = ret.PureASCII();

            return value;

        }

        public static string PureASCII(this string input)
        {
            var min = '\u0000';
            var max = '\u007F';
            return new string(input.Where(c => (c >= min && c < max)).ToArray());
        }

        /// <summary>
        /// Find findVal in the InString whole word only, if found return true,
        /// false otherwise
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="findVal"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static bool ContainsEx(this string inString, string findVal, string splitChar = "")
        {
            if (splitChar.IsEmpty())
            {
                return inString == findVal;
            }

            string[] list = inString.ToUpper().Split(splitChar.ToCharArray());
            findVal = findVal.ToUpper().TrimEx();
            return list.Any(t => t.TrimEx() == findVal);
        }

        /// <summary>
        /// Remove all empty, blank chracter in string
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string RemoveBlank(this string inString)
        {
            if (inString.IsEmpty())
            {
                return inString;
            }

            var strOutput = inString.ToCharArray().Where(c => c != ' ' && c != '\t' && c != '\r' && c != '\n').Aggregate("", (current, c) => current + c);

            return strOutput.TrimEx();
        }

        /// <summary>
        /// replace all \t \r \n by empty character 
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string ReplaceBlank(this string inString)
        {
            if (inString.IsEmpty())
            {
                return inString;
            }

            var strOutput = "";
            foreach (char c in inString)
            {
                if (c == '\t' || c == '\r' || c == '\n' || c == (char)0xA0)
                {
                    strOutput = strOutput + " ";
                }
                else
                {
                    strOutput = strOutput + c;
                }
            }

            return strOutput.TrimEx();
        }

        /// <summary>
        /// Get number digit character in string
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string GetNumericChar(this string inString)
        {
            var strOutput = inString.ToCharArray().Where(Char.IsDigit).Aggregate("", (current, c) => current + c);

            return strOutput.TrimEx();
        }

        /// <summary>
        /// Check if given Iso string is define for gerneral container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoGeneral(this string iso)
        {
            return ("0".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        /// <summary>
        /// Check if given Iso string is define for reefer container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoReefer(this string iso)
        {
            return ("34R".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsIsoDry(this string iso)
        {
            return ("0G".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }
        /// <summary>
        /// Check if given Iso string is define for flatrack container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoFlatRack(this string iso)
        {
            return ("P6".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsIsoOog(this string iso)
        {
            return ("O5P6".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsIsoTank(this string iso)
        {
            return ("T7".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }
        /// <summary>
        /// Check if given Iso string is define for onpen top container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoOpenTop(this string iso)
        {
            return ("5".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsDeliveryOperType(this string operationType)
        {
            return (operationType == "DELV" || operationType == "EDELV" || operationType == "DEPOTDELV");
        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="taxFileNo"></param>
        /// <returns></returns>
        public static bool IsValidTaxFileNo(this string taxFileNo)
        {
            if (taxFileNo.TrimEx().Length < 5)
            {
                return false;
            }

            if (taxFileNo.ToUpper().ToCharArray().Any(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*?~".Contains(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="sealNo"></param>
        /// <returns></returns>
        public static bool IsValidSealNo(this string sealNo)
        {
            if (sealNo.IsEmpty())
            {
                return false;
            }

            if (sealNo.Length > 20)
            {
                return false;
            }

            return !sealNo.IsContainUnicode();

        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="bookNo"></param>
        /// <returns></returns>
        public static bool IsValidBookNo(this string bookNo)
        {
            if (bookNo.IsEmpty())
            {
                return true;
            }

            if (bookNo.ToUpper().ToCharArray().Any(c => !"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Contains(c)))
            {
                return false;
            }

            if (bookNo.Length > 20)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="billingNo"></param>
        /// <returns></returns>
        public static bool IsValidBillNo(this string billingNo)
        {
            if (billingNo.IsEmpty())
            {
                return true;
            }

            if (billingNo.ToUpper().ToCharArray().Any(c => !"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Contains(c)))
            {
                return false;
            }

            if (billingNo.Length > 20)
            {
                return false;
            }

            return true;
        }

        public static bool IsContainUnicode(this string input)
        {
            const int MaxAnsiCode = 127;
            return input.Any(c => c > MaxAnsiCode);
        }


        /// <summary>
        /// Check if given Iso string is define for tank container
        /// abcd: ab70 -> ab79
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsTank(this string iso)
        {
            var tmp = iso.SubstringEx(2, 2).ToUpper();
            return (tmp.CheckIntEx() >= 70 && tmp.CheckIntEx() <= 79);
        }

        /// <summary>
        /// Check if given port string is define for local port
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool IsDomesticPort(this string port)
        {
            if (port == null)
            {
                return false;
            }

            return (port.SubstringEx(0, 2).ToUpper() == "VN");
        }

        /// <summary>
        /// The function check to see if the given object is set to a value that is different from default value
        /// This function is used to check value of a field of DbTable drived classes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotSetValue(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            if (obj.GetType() == typeof(int))
            {
                return (int)obj == GlobalSettings.IntDefaultValue;
            }

            if (obj.GetType() == typeof(long))
            {
                return (long)obj == GlobalSettings.LongDefaultValue;
            }
            if (obj.GetType() == typeof(double))
            {
                return (double)obj == GlobalSettings.DoubleDefaultValue;
            }
            if (obj.GetType() == typeof(float))
            {
                return (float)obj == GlobalSettings.FloatDefaultNotSetValue;
            }
            if (obj.GetType() == typeof(string))
            {
                return (string)obj == GlobalSettings.StringDefaultValue;
            }
            if (obj.GetType() == typeof(DateTime))
            {
                return (DateTime)obj == GlobalSettings.DateTimeDefaultValue;
            }
            throw new NotSupportedException("The IsNotSetValue method doesn't support this type.");
        }

        /// <summary>
        /// Format number to string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="numOfDec"></param>
        /// <returns></returns>
        public static string FormatNum(this object input, int numOfDec)
        {
            string value = input.ToStringEx();

            if (value.IsNumber())
            {

                decimal decNumber = Convert.ToDecimal(value);

                string result;
                if (numOfDec > 0)
                {
                    //result = String.Format("{0:0,0.00}", decNumber);

                    string sNumDecimal = "";
                    for (int i = 0; i < numOfDec; i++)
                    {
                        sNumDecimal += "0";
                    }

                    string sFormatPattern = "{0:#,0." + sNumDecimal + "}";
                    result = String.Format(sFormatPattern, decNumber);
                }
                else
                {
                    decNumber = decNumber.ToString().CheckIntEx();
                    result = $"{decNumber:#,0}";           //Hao, 26/08/2010
                }

                return result;
            }

            return value;

        }



        /// <summary>
        /// Remvoe single qoute from input string
        /// </summary>
        /// <param name="pStrInput"></param>
        /// <returns></returns>
        public static string DeleteSingleQuote(this string pStrInput)
        {
            if (pStrInput == null)
            {
                return null;
            }
            if (pStrInput.IsEmpty())
            {
                return "";
            }

            int i;

            string strOutput = "";
            int strLen = pStrInput.Length;

            for (i = 0; i < strLen; i++)
            {
                string strTmp = pStrInput.SubstringEx(i, 1);
                if (strTmp != "\'")
                {
                    strOutput = strOutput + strTmp;
                }
            }
            return strOutput;
        }

        public static string AppendSingleQuote(this string pStrInput)
        {
            if (pStrInput == null)
            {
                return null;
            }
            if (pStrInput.IsEmpty())
            {
                return "";
            }

            pStrInput = pStrInput.RemoveMultipleWhiteSpaces();
            while (pStrInput.Contains("''"))
            {
                pStrInput = pStrInput.Replace("''", "'");
            }

            return pStrInput.Replace("'", "''");
        }

        /// <summary>
        /// Round a number to accounting number
        /// Sai so lam tron cho phep = 0.5% neu so nho hon 1
        /// </summary>
        public static double RoundDoubleEx(this double piNumber, int maxPrecion = 10)
        {
            double ret = piNumber;
            int i = 0;

            if (ret == 0.0)
            {
                return piNumber;
            }

            //var precionNumber = (piNumber - Math.Truncate(piNumber)).ToString().SubstringEx(0, 2+maxPrecion).CheckDoubleEx();

            var intNumber = Math.Truncate(piNumber);

            var precionNum = piNumber - intNumber;

            precionNum = Math.Round(precionNum, 10);

            double retNum = precionNum.ToString("0.0000000000").SubstringEx(0, 2 + maxPrecion).CheckDoubleEx();
            var checkNum = precionNum.ToString("0.0000000000").SubstringEx(2 + maxPrecion, 1).CheckIntEx();

            if (checkNum >= 5)
            {
                retNum = (retNum * Math.Pow(10, maxPrecion) + 1) / Math.Pow(10, maxPrecion);
            }

            var result = Math.Round(intNumber + retNum, maxPrecion);

            return result;


        }

        /// <summary>
        /// Convert a number to accounting string , apply for Calculate Amount
        /// </summary>
        public static string ToAccountingStringEx(this double piNUmber, int piDecimal = 2, bool isVNDFormat = false)
        {
            string result = "";
            double retVal = piNUmber;

            if (piNUmber != 0)
            {

                if (Math.Abs(piNUmber) < 1)
                {
                    int i = 0;
                    while (i < 10)
                    {
                        if (Math.Abs(piNUmber - piNUmber.RoundDoubleEx(i)) / piNUmber < 0.001)
                        // if < 1 return the value round exact 1/1000 dvduoc 30-03-2012
                        {
                            retVal = piNUmber.RoundDoubleEx(i);
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    retVal = piNUmber.RoundDoubleEx(piDecimal);
                }
            }

            if (retVal == 0)
            {
                if (piDecimal == 0)
                {
                    result = "0";
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    result = "0." + lsFormat;
                }

            }
            else if (Math.Abs(piNUmber) < 1)
            {
                result = retVal.ToString().Replace(",", ".");
            }
            else
            {
                if (piDecimal == 0)
                {
                    if (Math.Abs(retVal) < 1000)
                        result = retVal.ToString("0");
                    else
                        result = retVal.ToString("0,0");
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    if (Math.Abs(retVal) < 1000)
                        result = retVal.ToString("0." + lsFormat);
                    else
                        result = retVal.ToString("0,0." + lsFormat);
                }
            }

            if (isVNDFormat)
            {
                result = result.Replace(".", "@");
                result = result.Replace(",", ".");
                result = result.Replace("@", ",");
            }
            return result;
        }

        public static string ToAccountingVNPTStringEx(this double piNUmber, int piDecimal = 2, bool isVNDFormat = false)
        {
            string result = "";
            double retVal = piNUmber;

            if (piNUmber != 0)
            {

                if (Math.Abs(piNUmber) < 1)
                {
                    int i = 0;
                    while (i < 10)
                    {
                        if (Math.Abs(piNUmber - piNUmber.RoundDoubleEx(i)) / piNUmber < 0.001)
                        {
                            retVal = piNUmber.RoundDoubleEx(i);
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    retVal = piNUmber.RoundDoubleEx(piDecimal);
                }
            }

            if (retVal == 0)
            {
                if (piDecimal == 0)
                {
                    result = "0";
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    result = "0." + lsFormat;
                }

            }
            else if (Math.Abs(piNUmber) < 1)
            {
                result = retVal.ToString().Replace(",", ".");
            }
            else
            {
                if (piDecimal == 0)
                {
                    if (Math.Abs(retVal) < 1000)
                        result = retVal.ToString("0");
                    else
                        result = retVal.ToString("0,0");
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    result = retVal.ToString("0." + lsFormat);
                }
            }
            return result;
        }

        /// <summary>
        /// Convert a number to accounting string , apply for Calculate Amount
        /// </summary>
        public static string ToVNDDisplayString(this double piNUmber)
        {
            int piDecimal = 0;

            string result = "";
            double retVal = piNUmber;

            var deNumber = piNUmber - piNUmber.RoundDoubleEx(0);

            if (deNumber != 0)
            {
                piDecimal = piNUmber.ToString().Length - piNUmber.RoundDoubleEx(0).ToString().Length - 1;
            }

            string lsFormat = "000000".Substring(0, piDecimal);


            if (retVal == 0)
            {
                return retVal.ToString();
            }

            if (piDecimal == 0)
            {
                if (Math.Abs(retVal) < 1000)
                    result = retVal.ToString("0");
                else
                    result = retVal.ToString("0,0");
            }
            else
            {
                if (Math.Abs(retVal) < 1000)
                    result = retVal.ToString("0." + lsFormat);
                else
                    result = retVal.ToString("0,0." + lsFormat);
            }

            result = result.Replace(".", "@");
            result = result.Replace(",", ".");
            result = result.Replace("@", ",");

            return result;
        }

        /// <summary>
        /// Hiển thị tiền tệ theo chuẩn Việt Nam
        /// </summary>
        /// <param name="piNUmber"></param>
        /// <returns></returns>
        public static string ToAccountingStringVn(this double piNUmber)
        {
            var retVal = piNUmber.ToString("#,##0.00");
            retVal = retVal.Replace(".", "@");
            retVal = retVal.Replace(",", ".");
            retVal = retVal.Replace("@", ",");
            return retVal;
        }

        /// <summary>
        /// convert chuỗi hiển thị tiền tệ theo chuẩn Việt Nam về kiểu số
        /// </summary>
        /// <param name="psNUmber"></param>
        /// <returns></returns>
        public static double AccountingStringVnToNumber(this string psNUmber)
        {
            var retVal = psNUmber;
            retVal = retVal.Replace(".", "@");
            retVal = retVal.Replace(",", ".");
            retVal = retVal.Replace("@", ",");
            return retVal.CheckDoubleEx();
        }

        public static double StringToNumber(this string psInput)
        {
            if (psInput.IsEmpty())
            {
                return 0;
            }
            var retVal = psInput;
            var commaIdx = psInput.LastIndexOf(',');
            var dotIdx = psInput.LastIndexOf('.');

            if (commaIdx >= 0 && dotIdx >= 0)
            {
                if (dotIdx > commaIdx)
                {
                    retVal = retVal.Replace(",", "");
                    return retVal.CheckDoubleEx();
                }

                if (dotIdx < commaIdx)
                {
                    retVal = retVal.Replace("", "");
                    retVal = retVal.Replace(",", ".");
                    return retVal.CheckDoubleEx();
                }
            }

            if (commaIdx >= 0)
            {
                if (psInput.Count(c => c == ',') > 1 || (psInput.SubstringEx(commaIdx + 1).Length % 3 == 0))
                {
                    retVal = retVal.Replace(",", "");
                }
                else
                {
                    retVal = retVal.Replace(",", ".");
                }

                return retVal.CheckDoubleEx();
            }

            if (psInput.Count(c => c == '.') > 1)
            {
                retVal = retVal.Replace(".", "");
            }

            return retVal.CheckDoubleEx();
        }

        #endregion

        #region Value OBJECT

        /// <summary>
        /// Reset các dữ liệu của Object, các dữ liệu có kiểu : string, số, ngày. 
        /// Các object khác thì gán về null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void ClearScalarData(this Object obj)
        {
            PropertyInfo[] propsInfo = obj.GetType().GetProperties();
            foreach (PropertyInfo property in propsInfo)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                switch (property.PropertyType.Name)
                {
                    case "Int16":
                        property.SetValue(obj, 0, null);
                        break;
                    case "Int32":
                        property.SetValue(obj, 0, null);
                        break;
                    case "Int64":
                        property.SetValue(obj, 0, null);
                        break;
                    case "Double":
                        property.SetValue(obj, 0.0, null);
                        break;
                    case "Float":
                        property.SetValue(obj, 0.0, null);
                        break;
                    case "String":
                        property.SetValue(obj, "", null);
                        break;
                    case "DateTime":
                        property.SetValue(obj, GlobalSettings.DateTimeDefaultValue, null);
                        break;
                        //property.SetValue(obj, null, null);
                }

            }
        }

        /// <summary>
        /// Copy các dữ liệu của Object, các dữ liệu có kiểu : string, số, ngày. 
        /// Các kiểu dữ liệu object khác thì gán tham chiếu.
        /// </summary>
        /// <returns></returns>
        public static void CopyDataTo(this Object fromObj, Object toObj)
        {
            if (fromObj.GetType().ToString() != toObj.GetType().ToString())
            {
                throw new Exception($"Different type {fromObj.GetType()} & {toObj.GetType()}");

            }

            PropertyInfo[] propsInfo = fromObj.GetType().GetProperties();
            foreach (PropertyInfo property in propsInfo)
            {
                if (!property.CanWrite)
                {
                    continue;
                }
                property.SetValue(toObj, property.GetValue(fromObj, null), null);
            }
        }
        /// <summary>
        /// sai khác : trả về false, giống nhau về dữ liệu trả về true
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="toObj"></param>
        /// <returns></returns>
        public static bool CompareData(this Object fromObj, Object toObj)
        {
            if (fromObj.GetType().ToString() != toObj.GetType().ToString())
            {
                throw new Exception($"Different type {fromObj.GetType()} & {toObj.GetType()}");

            }

            PropertyInfo[] propsInfo = fromObj.GetType().GetProperties();
            foreach (PropertyInfo property in propsInfo)
            {

                var val1 = property.GetValue(fromObj, null);
                var val2 = property.GetValue(toObj, null);

                if (val1 == null)
                {
                    val1 = "";
                }

                if (val2 == null)
                {
                    val2 = "";
                }


                if (val1.ToString() != val2.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Coppy assigned field from fromObj to toObj object
        /// Only mapping field which fromObj has assign data, the rest other field of toObj still remain
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="toObj"></param>
        public static void MappingAssignedDataTo(this Object fromObj, Object toObj)
        {
            if (fromObj.GetType().ToString() != toObj.GetType().ToString())
            {
                throw new Exception($"Different type {fromObj.GetType()} & {toObj.GetType()}");
            }

            PropertyInfo[] propsInfo = fromObj.GetType().GetProperties();
            foreach (PropertyInfo property in propsInfo)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                var value = property.GetValue(fromObj, null);

                if (value == null || value.IsNotSetValue())
                {
                    continue;
                }

                property.SetValue(toObj, value, null);
            }
        }

        #endregion

        #region DATETIME

        public static string DateToString(this DateTime date)
        {
            if (!date.IsNullDateTime())
            {
                return date.ToString(GlobalSettings.StrDMY);
            }

            return string.Empty;
            //GlobalSettings.NullDateHM
        }

        public static string TimeToString(this DateTime date)
        {
            return date.ToString(GlobalSettings.StrHMTimeSpan);
        }

        public static string DateTimeToString(this DateTime dateTime)
        {

            if (!dateTime.IsNullDateTime())
            {
                return dateTime.ToString(GlobalSettings.StrDMYHM);
            }

            //return GlobalSettings.NullDateHM;
            return string.Empty;

        }

        /// <summary>
        /// Convert ra chuỗi TO_DATE(ngày, format ngày)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToOracleDateString(this DateTime dateTime)
        {
            return $@"TO_DATE('{dateTime.ToString(GlobalSettings.StrDMYHMS)}', {GlobalSettings.DbStrDMYH24MS})";
        }

        public static DateTime ToDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// Convert ra chuỗi TO_DATE(ngày, format ngày)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToOracleShortDateString(this DateTime dateTime)
        {
            return $@"TO_DATE('{dateTime.ToString(GlobalSettings.StrDMY)}', {GlobalSettings.DbStrDMY})";
        }

        /// <summary>
        /// Chuyển đổi chuỗi thành kiểu ngày
        /// </summary>
        /// <param name="psDateTime"></param>
        /// <returns></returns>
        public static DateTime StringToDate(this string psDateTime)
        {
            try
            {
                var loDTInfo = new DateTimeFormatInfo { ShortDatePattern = GlobalSettings.StrDMY };

                DateTime ldDT = DateTime.Parse(psDateTime, loDTInfo);

                return ldDT;
            }
            catch (Exception)
            {
                return DateTimeUtilities.GetNullDate();

            }

        }

        /// <summary>
        /// Chuyển đổi chuỗi thành kiểu ngày giờ
        /// </summary>
        /// <param name="psDateTime"></param>
        /// <returns></returns>
        public static DateTime StringToDateTime(this string psDateTime)
        {
            DateTime ldDT;
            var loDTInfo = new DateTimeFormatInfo { LongTimePattern = GlobalSettings.StrDMYHMS };

            try
            {
                ldDT = DateTime.ParseExact(psDateTime, GlobalSettings.StrDMYHMS, loDTInfo);

            }
            catch
            {
                try
                {
                    ldDT = DateTime.ParseExact(psDateTime, GlobalSettings.StrDMYHM, loDTInfo);
                }
                catch (Exception)
                {
                    try
                    {
                        ldDT = DateTime.ParseExact(psDateTime, GlobalSettings.StrDMY, loDTInfo);
                    }
                    catch (Exception)
                    {

                        ldDT = DateTimeUtilities.GetNullDate();
                    }

                }
            }

            return ldDT;
        }

        /// <summary>
        /// Kiem tra co phai la gia tri null?
        /// Qui dinh DateTime = {31/12/1900} la gia tri null, empty
        /// </summary>
        /// <param name="poCheck"></param>
        /// <returns></returns>
        /// <history>
        /// Create by thhung, 23/08/2010
        /// </history>
        public static bool IsNullDateTime(this DateTime poCheck)
        {
            return poCheck.Year <= 1900;
        }

        /// <summary>
        /// Kiem tra khong phai la gia tri null?
        /// Qui dinh DateTime = {31/12/1900} la gia tri null, empty
        /// </summary>
        public static bool IsNotNull(this DateTime poCheck)
        {
            return poCheck.Year > 1900;
        }

        /// <summary>
        /// Loại bỏ thông tin gio phut giay trong DataTime
        /// </summary>
        /// <param name="poDateTime"></param>
        /// <returns></returns>
        /// <history>
        /// Create by thhung, 25/05/2011
        /// </history>
        public static DateTime GetDate(this DateTime poDateTime)
        {
            return new DateTime(poDateTime.Year, poDateTime.Month, poDateTime.Day);
        }

        public static DateTime ToBeginDate(this DateTime poDateTime)
        {
            return new DateTime(poDateTime.Year, poDateTime.Month, poDateTime.Day, 0, 0, 0);
        }
        public static DateTime ToEndDate(this DateTime poDateTime)
        {
            return new DateTime(poDateTime.Year, poDateTime.Month, poDateTime.Day, 23, 59, 59);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public static double TimeToNumber(this string timeSpan)
        {
            int pos = timeSpan.IndexOf(":", StringComparison.Ordinal) + 1;
            if (pos > 0)
            {
                return timeSpan.SubstringEx(0, pos - 1).CheckDoubleEx() +
                              timeSpan.SubstringEx(pos).CheckDoubleEx() / 60;
            }

            return 0;
        }

        public static bool IsContainerNo(this string inputStr)
        {
            var input = inputStr.RemoveBlank();
            var first4Str = input.SubstringEx(0, 4);
            var restStr = input.SubstringEx(4);

            if (input.Length >= 11 && input.Length <= 12)
            {
                if ((first4Str.IsAlphabet() || first4Str == "----") && restStr.IsDigit())
                {
                    return true;
                }
            }

            return false;

        }
        //------------------------------------------------------------------------------------------------------------------------------
        public static double TimeToNumber(this TimeSpan timeSpan)
        {
            return timeSpan.TotalHours;
        }

        /// <summary>
        /// Convert input number to string display on screen
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToDisplayString(this double number)
        {
            if (number == GlobalSettings.DoubleDefaultValue || number == 0)
            {
                return "";
            }

            return number.ToString();
        }

        /// <summary>
        /// Convert input number to string display on screen
        /// </summary>
        /// <param name="number"></param>
        /// <param name="suppressIfZero"></param>
        /// <returns></returns>
        public static string NumberToDisplayString(this int number, bool suppressIfZero = true)
        {
            if (number == GlobalSettings.IntDefaultValue)
            {
                return "";
            }

            if (suppressIfZero && number == 0)
            {
                return "";
            }

            return number.ToString();
        }

        /// <summary>
        /// Convert input number to string display time stamp
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToTime(this double number)
        {
            var hrs = (int)number;
            var mins = (number - hrs) * 60;

            return $"{hrs.ToString("00")}:{mins.ToString("00")}";
        }

        /// <summary>
        /// End of day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <history>dvthuan 08/12/2014</history>
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
        /// <summary>
        /// Start Of Day
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <history>dvthuan 08/12/2014</history>
        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        #endregion DATETIME

        #region DATA

        /// <summary>
        /// Kiểm tra DataSet có chứa dữ liệu hay không
        /// </summary>
        /// <param name="poDataSet"></param>
        /// <returns>True: Nếu có dữ liệu, false: không có dữ liệu</returns>
        public static bool IsEmptyData(this DataSet poDataSet)
        {
            bool lbEmpty = true;
            if (poDataSet != null && poDataSet.Tables.Count > 0)
            {
                foreach (DataTable loDT in poDataSet.Tables)
                {
                    if (loDT.Rows.Count > 0)
                    {
                        lbEmpty = false;
                    }

                }
            }
            return lbEmpty;
        }

        /// <summary>
        /// Check if Table container value identify by column name
        /// </summary>
        public static bool TableContainField(this DataTable pData, string pColumn, string pValue)
        {
            DataRow[] dr = pData.Select(pColumn + " = '" + pValue.Trim() + "' ");
            if (dr.Length > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Merge 2 Table into 1 Table by key column
        /// </summary>
        /// <param name="pMainData"></param>
        /// <param name="pGuestData"></param>
        /// <param name="m_KeyValue"></param>
        /// <returns></returns>
        public static DataTable MergeData(this DataTable pMainData, DataTable pGuestData, string m_KeyValue)
        {
            DataTable retData = pMainData.Clone();

            for (int i = 0; i < pGuestData.Columns.Count; i++)
                if (!retData.Columns.Contains(pGuestData.Columns[i].ColumnName))
                    retData.Columns.Add(pGuestData.Columns[i].ColumnName);

            //DataTable onGuestTable = retData.Clone();
            int idx = 0;
            foreach (DataRow dr in pMainData.Rows)
            {
                retData.ImportRow(dr);

                if (!pMainData.Columns.Contains(m_KeyValue) || !pGuestData.Columns.Contains(m_KeyValue))
                {
                    continue;
                }

                for (int i = 0; i < pGuestData.Rows.Count; i++)
                {
                    if (pGuestData.Rows[i][m_KeyValue].TrimEx() == dr[m_KeyValue].TrimEx())
                    {
                        for (int j = 0; j < pGuestData.Columns.Count; j++)
                        {
                            if (pGuestData.Columns[j].ColumnName.TrimEx().ToUpper() != m_KeyValue.Trim().ToUpper())
                                retData.Rows[idx][pGuestData.Columns[j].ColumnName] = pGuestData.Rows[i][j];
                        }

                        break;
                    }
                }
                idx++;
            }

            foreach (DataRow dr in pGuestData.Rows)
            {
                if (!pMainData.Columns.Contains(m_KeyValue) || !pGuestData.Columns.Contains(m_KeyValue))
                {
                    retData.ImportRow(dr);
                }
                else if (pMainData.Select($"{m_KeyValue} = '{dr[m_KeyValue].TrimEx()}'").Length <= 0)
                {
                    retData.ImportRow(dr);
                }
            }

            return retData;

        }
        

        public static DataTable MergeData1(this DataTable pMainData, DataTable pGuestData, string m_KeyValue)
        {
            DataTable retData = pMainData.Clone();

            for (int i = 0; i < pGuestData.Columns.Count; i++)
                if (!retData.Columns.Contains(pGuestData.Columns[i].ColumnName))
                    retData.Columns.Add(pGuestData.Columns[i].ColumnName);

            //DataTable onGuestTable = retData.Clone();
            int idx = 0;
            foreach (DataRow dr in pMainData.Rows)
            {
                retData.ImportRow(dr);

                if (!pMainData.Columns.Contains(m_KeyValue) || !pGuestData.Columns.Contains(m_KeyValue))
                {
                    continue;
                }

                for (int i = 0; i < pGuestData.Rows.Count; i++)
                {
                    if (pGuestData.Rows[i][m_KeyValue].TrimEx() == dr[m_KeyValue].TrimEx())
                    {
                        for (int j = 0; j < pGuestData.Columns.Count; j++)
                        {
                            if (pGuestData.Columns[j].ColumnName.TrimEx().ToUpper() != m_KeyValue.Trim().ToUpper())
                                retData.Rows[idx][pGuestData.Columns[j].ColumnName] = pGuestData.Rows[i][j];
                        }

                        break;
                    }
                }
                idx++;
            }



            return retData;

        }

        /// <summary>
        /// Set current row to pRow, active pColumn
        /// default Column = 0
        /// </summary>
        public static void SetCurrentDGV(this DataGridView DGV, int pRow, int pColumn = 0)
        {
            if (pRow < 0 || pRow >= DGV.Rows.Count)
                return;
            DGV.FirstDisplayedScrollingRowIndex = pRow;

            var colIdx = pColumn <= 0 ? 0 : pColumn;

            if (colIdx >= 0 && colIdx < DGV.Columns.Count && DGV.Columns[colIdx].Visible)
            {
                DGV.CurrentCell = DGV.Rows[pRow].Cells[colIdx];
            }

            DGV.Rows[pRow].Selected = true;
            DGV.Refresh();
        }

        /// <summary>
        /// Set value to blank in grid if date is 31/12/1900
        /// </summary>
        /// <param name="ColFormat"></param>
        public static void SupressNullDate(this DataGridViewCellFormattingEventArgs ColFormat)
        {
            if (ColFormat.Value != null)
            {
                try
                {
                    if (ColFormat.Value.TrimEx().IsDateTime())
                    {
                        ColFormat.Value = ColFormat.Value.CheckDateEx().DateTimeToString();
                    }
                }
                catch (Exception)
                {
                    //Do Nothing
                }
            }
        }
        
        public static void DGVSetReadOnlyByColumn(this DataGridView DGV, int colIdx, bool isReadOnly)
        {
            if (colIdx <= 0 || colIdx >= DGV.ColumnCount)
            {
                return;
            }

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                DGV.Rows[i].Cells[colIdx].ReadOnly = isReadOnly;
            }

        }

        public static List<string> ListColumnHeader(this DataTable data)
        {
            var _excelColumnHeader = new List<string>();

            for (int i = 0; i < data.Columns.Count; i++)
            {
                _excelColumnHeader.Add(data.Columns[i].ColumnName.TrimEx().ToUpper());
            }

            return _excelColumnHeader;
        }
        

        public static bool ExportToExcel(this System.Data.DataSet source, string fileName, bool writeColumnHeader = true, bool isOpenAFterCreated = false)
        {

            System.IO.StreamWriter excelDoc;

            try
            {
                excelDoc = new System.IO.StreamWriter(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            const string startExcelXML = "<xml version>\r\n<Workbook " +
                                            "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                                            " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                                            "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                                            "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                                            "office:spreadsheet\">\r\n <Styles>\r\n " +
                                            "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                                            "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                                            "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                                            "\r\n <Protection/>\r\n </Style>\r\n " +
                                            "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                                            "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                                            "<Style     ss:ID=\"StringLiteral\">\r\n </Style>\r\n <Style " +
                                            "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                                            "ss:Format=\"0.00\"/>\r\n </Style>\r\n " +
                                            "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                                            "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                                            "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                                            "ss:Format=\"dd/MM/yyyy\\ HH:mm\"/>\r\n </Style>\r\n " +
                                            "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;
            bool bRet = false;

            excelDoc.Write(startExcelXML);

            foreach (DataTable table in source.Tables)
            {
                if (table.Rows.Count > 0)
                    bRet = true;
                excelDoc.Write("<Worksheet ss:Name=\"" + table.TableName + sheetCount + "\">");
                excelDoc.Write("<Table>");

                if (writeColumnHeader)
                {
                    excelDoc.Write("<Row>");
                    for (int x = 0; x < table.Columns.Count; x++)
                    {
                        excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                        excelDoc.Write(table.Columns[x].ColumnName);
                        excelDoc.Write("</Data></Cell>");
                    }
                    excelDoc.Write("</Row>");
                }

                foreach (DataRow x in table.Rows)
                {
                    rowCount++;
                    //if the number of rows is > 64000 create a new page to continue output
                    if (rowCount == 64000)
                    {
                        rowCount = 0;
                        sheetCount++;
                        excelDoc.Write("</Table>");
                        excelDoc.Write(" </Worksheet>");
                        excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                        excelDoc.Write("<Table>");
                    }
                    excelDoc.Write("<Row>"); //ID=" + rowCount + "
                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        #region Generate Cell
                        System.Type rowType;
                        rowType = table.Columns[y].DataType;

                        if (rowType.ToString() == "System.Object")
                        {
                            rowType = x[y].GetType();
                        }

                        switch (rowType.ToString())
                        {
                            case "System.String":
                                string XMLstring = x[y].ToString();
                                XMLstring = XMLstring.Trim();
                                XMLstring = XMLstring.Replace("&", "&amp;");
                                XMLstring = XMLstring.Replace(">", "&gt;");
                                XMLstring = XMLstring.Replace("<", "&lt;");
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                               "<Data ss:Type=\"String\">");
                                excelDoc.Write(XMLstring);
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.DateTime":
                                //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                //The Following Code puts the date stored in XMLDate 
                                //to the format above
                                DateTime XMLDate = (DateTime)x[y];
                                string XMLDatetoString = ""; //Excel Converted Date
                                XMLDatetoString = XMLDate.ToString("yyyy-MM-ddTHH:mm:ss.000");
                                excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                             "<Data ss:Type=\"DateTime\">");
                                excelDoc.Write(XMLDatetoString);
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.Boolean":
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                            "<Data ss:Type=\"String\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                        "<Data ss:Type=\"Number\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.Decimal":
                            case "System.Double":
                                excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                      "<Data ss:Type=\"Number\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.DBNull":
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                      "<Data ss:Type=\"String\">");
                                excelDoc.Write("");
                                excelDoc.Write("</Data></Cell>");
                                break;
                            default:
                                string XMLObject = x[y].ToString();
                                XMLstring = XMLObject.Trim();
                                XMLstring = XMLObject.Replace("&", "&amp;");
                                XMLstring = XMLObject.Replace(">", "&gt;");
                                XMLstring = XMLObject.Replace("<", "&lt;");
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                               "<Data ss:Type=\"String\">");
                                excelDoc.Write(XMLstring);
                                excelDoc.Write("</Data></Cell>");
                                break;
                                //throw (new Exception(rowType + " not handled."));
                        }
                        #endregion
                    }
                    excelDoc.Write("</Row>");
                }

                excelDoc.Write("</Table>");
                excelDoc.Write(" </Worksheet>");

                sheetCount++;
            }
            excelDoc.Write(endExcelXML);
            excelDoc.Close();

            if (isOpenAFterCreated)
            {
                System.Diagnostics.Process.Start(fileName);
            }

            return bRet;
        }

        /// <summary>
        /// </summary>
        public static bool ExportToExcel(this DataTable dataTable, string fileName, bool writeColumnHeader = true, bool isOpenAFterCreated = false)
        {
            DataSet loDS = dataTable.DataSet;

            if (loDS == null)
            {
                loDS = new DataSet();
                loDS.Tables.Add(dataTable);
            }

            return loDS.ExportToExcel(fileName, writeColumnHeader, isOpenAFterCreated);
        }

        /// <summary>
        /// Export DGV to excel
        /// If user want to export more details such as vessel header
        /// Then set DGV.Tag = ReportOption object
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="Filename"></param>
        public static void ExportDGVToExcel(this DataGridView DGV, string Filename)
        {
            string[] arrHead;
            int i;
            bool EndRow;
            try
            {
                string lblHeading = "";

                var frm = DGV.FindForm();
                if (frm != null)
                {
                    var headerTextCtl = frm.Controls.Find("LBLDGVHEADING", true);
                    if (headerTextCtl.Length > 0)
                    {
                        lblHeading = headerTextCtl[0].Text;
                    }
                }

                var fs = new StreamWriter(Filename, false);
                fs.WriteLine("<?xml version=\"1.0\"?>");
                fs.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                fs.WriteLine("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                fs.WriteLine("    <ss:Styles>");
                fs.WriteLine("        <ss:Style ss:ID=\"1\">");
                fs.WriteLine("           <ss:Font ss:Bold=\"1\"/>");
                fs.WriteLine("        </ss:Style>");
                fs.WriteLine("    </ss:Styles>");
                fs.WriteLine("    <ss:Worksheet ss:Name=\"Sheet1\">");
                fs.WriteLine("        <ss:Table>");

                //Write header details if it requried

                //Order columns in DGV by display index
                var dgvColumns = from DataGridViewColumn c in DGV.Columns.Cast<DataGridViewColumn>()
                                 orderby c.DisplayIndex
                                 select c;

                //Write header details if it requried
                foreach (DataGridViewColumn column in dgvColumns)
                {
                    if (column.Visible)
                    {
                        fs.WriteLine("            <ss:Column ss:Width=\"{0}\"/>", column.Width);
                    }
                }

                //Header -----------------------------------------------------------

                if (lblHeading != "")
                {
                    arrHead = lblHeading.GetDGVHeading();
                    EndRow = false;
                    for (i = 0; i <= (arrHead.Length - 1); i++)
                    {
                        if (arrHead[i] != null)
                        {
                            if (i % 2 == 0)
                            {
                                fs.WriteLine("            <ss:Row ss:StyleID=\"1\">");
                                fs.WriteLine("                <ss:Cell>");

                                var lineValue =
                                    $"                   <ss:Data ss:Type=\"String\">{arrHead[i].TrimEx()}</ss:Data>";
                                fs.WriteLine(lineValue);
                                fs.WriteLine("                </ss:Cell>");
                                EndRow = false;
                            }
                            else
                            {
                                fs.WriteLine("                <ss:Cell>");

                                var lineValue =
                                    $"                   <ss:Data ss:Type=\"String\">{arrHead[i].TrimEx()}</ss:Data>";

                                fs.WriteLine(lineValue);
                                fs.WriteLine("                </ss:Cell>");
                                fs.WriteLine("            </ss:Row>");
                                EndRow = true;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (!EndRow)
                    {
                        fs.WriteLine("            </ss:Row>");
                    }

                    //Blank Line -------------------------------
                    fs.WriteLine("            <ss:Row ss:StyleID=\"1\">");
                    fs.WriteLine("                <ss:Cell>");
                    fs.WriteLine("                   <ss:Data ss:Type=\"String\"> </ss:Data>");
                    fs.WriteLine("                </ss:Cell>");
                    fs.WriteLine("            </ss:Row>");
                    //----------------------------------------
                }
                //------------------------------------------------------------------

                fs.WriteLine("            <ss:Row ss:StyleID=\"1\">");

                foreach (DataGridViewColumn column in dgvColumns)
                {
                    if (column.Visible)
                    {
                        fs.WriteLine("                <ss:Cell>");

                        var lineValue = $"                   <ss:Data ss:Type=\"String\">{column.HeaderText}</ss:Data>";

                        fs.WriteLine(lineValue);
                        fs.WriteLine("                </ss:Cell>");
                    }
                }

                fs.WriteLine("            </ss:Row>");

                for (int intRow = 0; intRow <= DGV.RowCount - 1; intRow++)
                {
                    //dvduoc 17/04/2014 ignore invisible row
                    if (!DGV.Rows[intRow].Visible)
                    {
                        continue;
                    }

                    var lineValue = $"            <ss:Row ss:Height =\"{DGV.Rows[intRow].Height}\">";
                    fs.WriteLine(lineValue);
                    foreach (DataGridViewColumn column in dgvColumns)
                    {
                        if (column.Visible)
                        {
                            fs.WriteLine("                <ss:Cell>");

                            //NH: 15-02-2012, fixed error cann't open excel file 
                            string lsTextValue = DGV[column.Index, intRow].Value.CheckBlankEx();
                            lsTextValue = lsTextValue.Replace("&", "&amp;");
                            lsTextValue = lsTextValue.Replace(">", "&gt;");
                            lsTextValue = lsTextValue.Replace("<", "&lt;");

                            string lineTextValue =
                                $"                   <ss:Data ss:Type=\"String\">{lsTextValue}</ss:Data>";
                            fs.WriteLine(lineTextValue);
                            fs.WriteLine("                </ss:Cell>");
                        }
                    }
                    fs.WriteLine("            </ss:Row>");
                }

                fs.WriteLine("        </ss:Table>");
                fs.WriteLine("    </ss:Worksheet>");
                fs.WriteLine("</ss:Workbook>");
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string[] GetDGVHeading(this string lblHead)
        {
            int i;
            int Pos;
            int lPos;
            string[] arrHeading = new string[51];


            if (lblHead.IsEmpty())
            {
                return null;
            }

            Pos = lblHead.IndexOf("|") + 1;
            if (Pos == 0)
            {
                arrHeading[0] = lblHead.TrimEx();
                return arrHeading;
            }
            arrHeading[0] = lblHead.SubstringEx(0, Pos - 1);
            lPos = Pos + 1;
            for (i = 1; i <= 20; i++)
            {
                Pos = lblHead.IndexOf("|", Pos + 1 - 1) + 1;
                if (Pos > 0)
                {
                    arrHeading[i] = lblHead.SubstringEx(lPos - 1, Pos - lPos);
                }
                else
                {
                    arrHeading[i] = lblHead.SubstringEx(lPos - 1, lblHead.Length);
                    return arrHeading;
                }
                lPos = Pos + 1;
            }

            return arrHeading;
        }

        public static void ExportToExcelFile(this DataTable dt, string filePath, bool openFile = false)
        {
            StreamWriter wr = new StreamWriter(filePath);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
            }

            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dt.Rows.Count); i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                    }
                    else
                    {
                        wr.Write("\t");
                    }
                }
                //go to next line
                wr.WriteLine();
            }
            //close file
            wr.Close();

            if (openFile)
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }
        

        public static List<T> JoinMemberList<T>(this IEnumerable<IEnumerable<T>> groupData)
        {
            if (groupData == null || !groupData.Any())
            {
                return null;
            }

            var retList = new List<T>();

            foreach (var list in groupData)
            {
                retList.AddRange(list);
            }

            return retList;
        }

        #endregion

        #region OTHER

        public static string GetMd5Hash(this string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(this string input, string hash)
        {
            // Hash the input.
            string hashOfInput = input.GetMd5Hash();

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }

            return false;
        }

        public static int Max(this Enum enumType)
        {
            return Enum.GetValues(enumType.GetType()).Cast<int>().Max();
        }

        /// <summary>
        /// Convert a temperature value to string
        /// </summary>
        /// <returns></returns>
        public static string ConvertTempToString(this object temp)
        {
            try
            {
                if (Convert.ToDouble(temp) == 9999)
                {
                    return string.Empty;
                }

                return temp.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// Convert a string to temperature value
        /// </summary>
        /// <returns></returns>
        public static double ConvertStringToTemp(this string temp)
        {
            if (string.IsNullOrWhiteSpace(temp))
            {
                return 9999;
            }

            return temp.CheckDoubleEx();
        }

        /// <summary>
        /// Convert a number to a string value. if the given value is 0, then return an empty string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNonZeroString(this object value)
        {
            if ((int)value == 0)
            {
                return string.Empty;
            }

            return value.ToStringEx();

        }

        /// <summary>
        ///     So sánh 2 giá trị
        /// </summary>
        /// <param name="rootValue"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static int CompareToGetMark(this string rootValue, string compareValue)
        {
            int mark = 0;

            if (rootValue.TrimEx() == compareValue.TrimEx())
            {
                //ưu tiên 2 điểm
                mark++;
                mark++;
            }
            else
            {
                if (rootValue.TrimEx() == string.Empty)
                {
                    mark++;
                }
                else
                {
                    return 0;
                }
            }

            return mark;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctnrNo"></param>
        /// <returns></returns>
        public static void StandardizeCtnrNo(this Control ctnrNo)
        {


            ctnrNo.Text = ctnrNo.Text.TrimEx();
            ctnrNo.Text = ctnrNo.Text.Replace("'", string.Empty);
        }

        /// <summary>
        /// Convert check state to string (true->"Y", false->"N")
        /// </summary>
        /// <param name="chkCheckBox"></param>
        /// <returns></returns>
        public static string CheckStateEx(this CheckBox chkCheckBox)
        {
            switch (chkCheckBox.CheckState)
            {
                case CheckState.Checked:
                    return "Y";
                case CheckState.Unchecked:
                    return "N";
                case CheckState.Indeterminate:
                    return "";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Convert string to checkbox state
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CheckState CheckStateEx(this string value)
        {
            switch (value)
            {
                case "Y":
                    return CheckState.Checked;
                case "N":
                    return CheckState.Unchecked;
                case "":
                    return CheckState.Indeterminate;
                default:
                    return CheckState.Indeterminate;
            }
        }

        /// <summary>
        /// Chia nhỏ list object
        /// Created by: dvthuan 21/05/2014
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="groupSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetEnumerableOfEnumerables<T>(this IEnumerable<T> enumerable, int groupSize)
        {
            // The list to return.
            var list = new List<T>(groupSize);

            // Cycle through all of the items.
            foreach (T item in enumerable)
            {
                // Add the item.
                list.Add(item);

                // If the list has the number of elements, return that.
                if (list.Count == groupSize)
                {
                    // Return the list.
                    yield return list;

                    // Set the list to a new list.
                    list = new List<T>(groupSize);
                }
            }

            // Return the remainder if there is any,
            if (list.Count != 0)
            {
                // Return the list.
                yield return list;
            }
        }

        /// <summary>
        /// Convert font Unicode to Vni
        /// dvthuan 18/12/2014
        /// </summary>
        /// <param name="vnstr"></param>
        /// <returns></returns>
        public static string UniCodeToVni(this string vnstr)
        {
            var uniCodeToVni = "";
            var temp = "";
            char c;
            for (int i = 0; i < vnstr.Length; i++)
            {
                c = vnstr.SubstringEx(i, 1)[0];

                temp = "";

                switch (c)
                {
                    case (char)97:
                        temp = "a"; break;
                    case (char)(225):
                        temp = "aù"; break;
                    case (char)(224):
                        temp = "aø"; break;
                    case (char)(7843):
                        temp = "aû"; break;
                    case (char)(227):
                        temp = "aõ"; break;
                    case (char)(7841):
                        temp = "aï"; break;
                    case (char)(259):
                        temp = "aê"; break;
                    case (char)(7855):
                        temp = "aé"; break;
                    case (char)(7857):
                        temp = "aè"; break;
                    case (char)(7859):
                        temp = "aú"; break;
                    case (char)(7861):
                        temp = "aü"; break;
                    case (char)(7863):
                        temp = "aë"; break;
                    case (char)(226):
                        temp = "aâ"; break;
                    case (char)(7845):
                        temp = "aá"; break;
                    case (char)(7847):
                        temp = "aà"; break;
                    case (char)(7849):
                        temp = "aå"; break;
                    case (char)(7851):
                        temp = "aã"; break;
                    case (char)(7853):
                        temp = "aä"; break;
                    case (char)(101):
                        temp = "e"; break;
                    case (char)(233):
                        temp = "eù"; break;
                    case (char)(232):
                        temp = "eø"; break;
                    case (char)(7867):
                        temp = "eû"; break;
                    case (char)(7869):
                        temp = "eõ"; break;
                    case (char)(7865):
                        temp = "eï"; break;
                    case (char)(234):
                        temp = "eâ"; break;
                    case (char)(7871):
                        temp = "eá"; break;
                    case (char)(7873):
                        temp = "eà"; break;
                    case (char)(7875):
                        temp = "eå"; break;
                    case (char)(7877):
                        temp = "eã"; break;
                    case (char)(7879):
                        temp = "eä"; break;
                    case (char)(111):
                        temp = "o"; break;
                    case (char)(243):
                        temp = "où"; break;
                    case (char)(242):
                        temp = "oø"; break;
                    case (char)(7887):
                        temp = "oû"; break;
                    case (char)(245):
                        temp = "oõ"; break;
                    case (char)(7885):
                        temp = "oï"; break;
                    case (char)(244):
                        temp = "oâ"; break;
                    case (char)(7889):
                        temp = "oá"; break;
                    case (char)(7891):
                        temp = "oà"; break;
                    case (char)(7893):
                        temp = "oå"; break;
                    case (char)(7895):
                        temp = "oã"; break;
                    case (char)(7897):
                        temp = "oä"; break;
                    case (char)(417):
                        temp = "ô"; break;
                    case (char)(7899):
                        temp = "ôù"; break;
                    case (char)(7901):
                        temp = "ôø"; break;
                    case (char)(7903):
                        temp = "ôû"; break;
                    case (char)(7905):
                        temp = "ôõ"; break;
                    case (char)(7907):
                        temp = "ôï"; break;
                    case (char)(105):
                        temp = "i"; break;
                    case (char)(237):
                        temp = "í"; break;
                    case (char)(236):
                        temp = "ì"; break;
                    case (char)(7881):
                        temp = "æ"; break;
                    case (char)(297):
                        temp = "ó"; break;
                    case (char)(7883):
                        temp = "ò"; break;
                    case (char)(117):
                        temp = "u"; break;
                    case (char)(250):
                        temp = "uù"; break;
                    case (char)(249):
                        temp = "uø"; break;
                    case (char)(7911):
                        temp = "uû"; break;
                    case (char)(361):
                        temp = "uõ"; break;
                    case (char)(7909):
                        temp = "uï"; break;
                    case (char)(432):
                        temp = "ö"; break;
                    case (char)(7913):
                        temp = "öù"; break;
                    case (char)(7915):
                        temp = "uø"; break;
                    case (char)(7917):
                        temp = "öû"; break;
                    case (char)(7919):
                        temp = "öõ"; break;
                    case (char)(7921):
                        temp = "öï"; break;
                    case (char)(121):
                        temp = "y"; break;
                    case (char)(253):
                        temp = "yù"; break;
                    case (char)(7923):
                        temp = "yø"; break;
                    case (char)(7927):
                        temp = "yû"; break;
                    case (char)(7929):
                        temp = "yõ"; break;
                    case (char)(7925):
                        temp = "î"; break;
                    case (char)(273):
                        temp = "ñ"; break;
                    case (char)(65):
                        temp = "A"; break;
                    case (char)(193):
                        temp = "AÙ"; break;
                    case (char)(192):
                        temp = "AØ"; break;
                    case (char)(7842):
                        temp = "AÛ"; break;
                    case (char)(195):
                        temp = "AÕ"; break;
                    case (char)(7840):
                        temp = "AÏ"; break;
                    case (char)(258):
                        temp = "AÊ"; break;
                    case (char)(7854):
                        temp = "AÉ"; break;
                    case (char)(7856):
                        temp = "AÈ"; break;
                    case (char)(7858):
                        temp = "AÚ"; break;
                    case (char)(7860):
                        temp = "AÜ"; break;
                    case (char)(7862):
                        temp = "AË"; break;
                    case (char)(194):
                        temp = "AÂ"; break;
                    case (char)(7844):
                        temp = "AÁ"; break;
                    case (char)(7846):
                        temp = "AÀ"; break;
                    case (char)(7848):
                        temp = "AÅ"; break;
                    case (char)(7850):
                        temp = "AÃ"; break;
                    case (char)(7852):
                        temp = "AÄ"; break;
                    case (char)(69):
                        temp = "E"; break;
                    case (char)(201):
                        temp = "EÙ"; break;
                    case (char)(200):
                        temp = "EØ"; break;
                    case (char)(7866):
                        temp = "EÛ"; break;
                    case (char)(7868):
                        temp = "EÕ"; break;
                    case (char)(7864):
                        temp = "EÏ"; break;
                    case (char)(202):
                        temp = "EÂ"; break;
                    case (char)(7870):
                        temp = "EÁ"; break;
                    case (char)(7872):
                        temp = "EÀ"; break;
                    case (char)(7874):
                        temp = "EÅ"; break;
                    case (char)(7876):
                        temp = "EÃ"; break;
                    case (char)(7878):
                        temp = "EÄ"; break;
                    case (char)(79):
                        temp = "O"; break;
                    case (char)(211):
                        temp = "OÙ"; break;
                    case (char)(210):
                        temp = "OØ"; break;
                    case (char)(7886):
                        temp = "OÛ"; break;
                    case (char)(213):
                        temp = "OÕ"; break;
                    case (char)(7884):
                        temp = "OÏ"; break;
                    case (char)(212):
                        temp = "OÂ"; break;
                    case (char)(7888):
                        temp = "OÁ"; break;
                    case (char)(7890):
                        temp = "OÀ"; break;
                    case (char)(7892):
                        temp = "OÅ"; break;
                    case (char)(7894):
                        temp = "OÃ"; break;
                    case (char)(7896):
                        temp = "OÄ"; break;
                    case (char)(416):
                        temp = "Ô"; break;
                    case (char)(7898):
                        temp = "ÔÙ"; break;
                    case (char)(7900):
                        temp = "ÔØ"; break;
                    case (char)(7902):
                        temp = "ÔÛ"; break;
                    case (char)(7904):
                        temp = "ÔÕ"; break;
                    case (char)(7906):
                        temp = "ÔÏ"; break;
                    case (char)(73):
                        temp = "I"; break;
                    case (char)(205):
                        temp = "Í"; break;
                    case (char)(204):
                        temp = "Ì"; break;
                    case (char)(7880):
                        temp = "Æ"; break;
                    case (char)(296):
                        temp = "Ó"; break;
                    case (char)(7882):
                        temp = "Ò"; break;
                    case (char)(85):
                        temp = "U"; break;
                    case (char)(218):
                        temp = "UÙ"; break;
                    case (char)(217):
                        temp = "UØ"; break;
                    case (char)(7910):
                        temp = "UÛ"; break;
                    case (char)(360):
                        temp = "UÕ"; break;
                    case (char)(7908):
                        temp = "UÏ"; break;
                    case (char)(431):
                        temp = "Ö"; break;
                    case (char)(7912):
                        temp = "ÖÙ"; break;
                    case (char)(7914):
                        temp = "ÖØ"; break;
                    case (char)(7916):
                        temp = "ÖÛ"; break;
                    case (char)(7918):
                        temp = "ÖÕ"; break;
                    case (char)(7920):
                        temp = "ÖÏ"; break;
                    case (char)(89):
                        temp = "Y"; break;
                    case (char)(221):
                        temp = "YÙ"; break;
                    case (char)(7922):
                        temp = "YØ"; break;
                    case (char)(7926):
                        temp = "YÛ"; break;
                    case (char)(7928):
                        temp = "YÕ"; break;
                    case (char)(7924):
                        temp = "Î"; break;
                    case (char)(272):
                        temp = "Ñ"; break;
                    default:
                        temp = c.ToStringEx();
                        break;
                }
                uniCodeToVni = uniCodeToVni + temp;
            }

            return uniCodeToVni;
        }
        /// <summary>
        /// Loại bỏ các ký tự đặc biệt khi tạo file
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <History>dvthuan created 02/02/2015</History>
        //public static string RemoveSpecialCharacters(this string str)
        public static string CheckFileNameValidation(this string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        private static Regex ValidEmailRegex = CreateValidEmailRegex();

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public static bool EmailIsValidMulti(this string emailAddresses)
        {
            var arrEmailDemurage = emailAddresses.Split(',', ';');
            foreach (var emailDemurage in arrEmailDemurage)
            {
                var checkEmail = emailDemurage.TrimEx();
                if (!checkEmail.IsEmpty() && !checkEmail.EmailIsValid())
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EmailIsValid(this string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        public static bool CheckInputIsEirId(this string inputStr)
        {
            var firstStr = inputStr.SubstringEx(0, 1);
            var restStr = inputStr.SubstringEx(1);

            if (inputStr.Length >= 6 && "PDCSERH-".Contains(firstStr) && restStr.IsDigit())
            {
                return true;
            }

            return false;

        }

        public static bool CheckInputIsContainer(this string inputStr)
        {
            var input = inputStr.RemoveBlank();
            var first4Str = input.SubstringEx(0, 4);
            var restStr = input.SubstringEx(4);

            if (input.Length >= 11 && input.Length <= 12)
            {
                if ((first4Str.IsAlphabet() || first4Str == "----") && restStr.IsDigit())
                {
                    return true;
                }
            }

            return false;

        }

        #endregion
        #region Security
        public static string EncodePassword(this string passpwd)
        {
            string returnValue = " ";
            int i;
            int k;
            double strPwd = 0;
            string onechar;
            var ArrPwd = new int[31];

            for (i = 1; i <= passpwd.Length; i++)
            {
                onechar = passpwd.TrimEx().Substring(i - 1, 1);
                if (!Information.IsNumeric(onechar))
                {
                    ArrPwd[i] = Strings.Asc(onechar);
                }
                else
                {
                    ArrPwd[i] = int.Parse(onechar);
                }
            }

            for (k = 1; k <= i - 1; k++)
            {
                strPwd = strPwd + ArrPwd[k];

                strPwd = strPwd * (k + i);
            }

            returnValue = strPwd.ToString();

            return returnValue;
        }
        #endregion
        public static T CheckEnumEx<T>(this object value) where T : new()
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException("T must be an Enum");

            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            catch
            {
                return default(T); // equivalent to (T)0
                                   //return (T)Enum.Parse(typeof(T), "Unknown"));
            }
        }

        #region EXCEPTION

        public static string GetAllErrorMessage(this Exception ex)
        {
            var strError = new StringBuilder();

            var innerEx = ex;

            while (innerEx != null)
            {
                strError.AppendLine("Message:");
                strError.Append(innerEx.Message);
                strError.AppendLine("StackTrace:");
                strError.Append(innerEx.StackTrace);
                strError.AppendLine("");
                innerEx = innerEx.InnerException;
            }

            return strError.ToStringEx();
        }


        #endregion EXCEPTION

        /// <summary>
        /// Helper methods for the lists.
        /// </summary>

        public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }


        /// <summary>
        /// Các phương án móc cáp liên quan tới xuất bãi.
        /// <para> Y-XSLAN </para>
        /// <para> Y_CBNB </para>
        /// <para> Y_DCHUYEN </para>
        /// <para> Y_DXTAU </para>
        /// <para> Y_GNGUYEN </para>
        /// <para> Y_XTAU </para>
        /// <para> Y_HBNB </para>
        /// <para> B_XSLAN </para>
        /// <para> B_XSLAN </para>
        /// <para> V_DXTAU </para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsCableHookMethodDelivery(this string str)
        {
            return (str == "Y_XSLAN" ||
                str == "Y_CBNB" ||
                str == "Y_DCHUYEN" ||
                str == "Y_DXTAU" ||
                str == "Y_GNGUYEN" ||
                str == "Y_XTAU" ||
                str == "Y_HBNB" ||
                str == "B_XSLAN" ||
                str == "B_XSLAN" ||
                str == "V_DXTAU" ||
                str == "V_XTAU");
        }

        public static bool IsCableHookMethodContainsVessel(this string str)
        {
            return (str.Contains("TAU"));
        }

        public static bool IsCableHookMethodContainsBarge(this string str)
        {
            return (str.Contains("SLAN"));
        }
        public static string RemoveBarcodeChar(this string str)
        {
            string result = str;

            if (!result.IsEmpty())
            {
                if (result[0] == '~')
                {
                    result = result.Replace("~", "");
                    result = result.Substring(3);
                }
            }
            return result;
        }
              

        public static string TrimAll(this string s, char character)
        {
            if (s == null || s.IsEmpty())
                return "";

            return s.TrimEnd(character).TrimStart(character);
        }

        public static string RemoveInvalidCharFileName(this string fileName)
        {
            var invalidFileNameChar = Path.GetInvalidFileNameChars();
            foreach (var c in invalidFileNameChar)
            {
                fileName = fileName.Replace(c.ToString(), "");
            }
            return fileName;
        }

        public static double GetFileSize(this string filePath, ref string size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(filePath).Length;
            var order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            size = sizes[order];
            return len;
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek starOfWeek)
        {
            int diff = dt.DayOfWeek - starOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
        public static int GetWeekOfYear(this DateTime dateTime)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            if (dfi != null)
            {
                var cal = dfi.Calendar;

                return cal.GetWeekOfYear(dateTime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            }

            return new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        }
        public static bool IsEmptyDataEx(this DataSet poDataSet)
        {
            bool lbEmpty = true;
            if (poDataSet != null && poDataSet.Tables.Count > 0)
            {
                foreach (DataTable loDT in poDataSet.Tables)
                {
                    if (loDT.Rows.Count > 0)
                    {
                        lbEmpty = false;
                    }

                }
            }
            return lbEmpty;
        }
        public static int InListOf<T>(this T input, List<T> arr)
        {
            int retVal = -1;

            if (arr.Count > 0)
            {
                retVal = arr.FindIndex(i => i.Equals(input));
            }

            return retVal;
        }
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> source) => source != null && source.Any();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();

        /// <summary>
        /// if tháng =4 thì tạo thành 04
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string GenMounth(this object month)
        {
            if (int.Parse(month.ToString()) < 10)
                return "0" + month;
            return month.ToString();
        }

     
        /// <summary>
        ///@@dungnv2: Chuẩn hóa lại MST theo quy tắc:
        ///Đối với các hóa đơn có mst có 13 ký tự, thêm dấu - ở giữa ký tự thứ 10 và 11.Sau đó tích điểm vào KHTT với cấu trúc có – 
        ///Ví dụ: hóa đơn trong hệ thống cảng có mst : 1100598642019 , khi tích hợp qua KHTT thì phải dịch ra là 1100598642 - 019
        /// </summary>
        /// <param name="taxCode">Mã số thuế</param>
        /// <returns></returns>
        public static string ToStandardTaxCode(this string taxCode)
        {
            if (taxCode.IsEmptyEx())
                return "";

            taxCode = taxCode.TrimEx();
            if (taxCode.Length > 10 && !taxCode.Contains("-")) //nếu chiều dài MST > 10 và không chứa dấu gạch
            {
                return $"{taxCode.Substring(0, 10)}-{taxCode.Substring(10)}";
            }

            return taxCode;
        }

        public static string ToEDOCustomerName(this string customerName) => customerName.TrimEx().SubstringEx(0, GlobalSettings.MaxLengthConsignee).DeleteSingleQuote().ToUpper();
        public static string ToEDOSecureCode(this string secureCode) => secureCode.TrimEx().RemoveBlank().DeleteSingleQuote().ToUpper();

        public static bool HasData<T>(this IEnumerable<T> source) => source != null && source.Any();

        //DDThanh add check and replace speccial character 
        //public static string ReplaceSpecialCharacterString(this string str)
        //{
        //    return Regex.Replace(str, @"[^0-9a-zA-Z]", "");
        //}
        /// <summary>
        /// Kiểm tra ký tự lạ có trong số seal?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSpecialCharacterString(this string str, string pattern = "[^a-zA-Z0-9]")
        {
            //return Regex.IsMatch(str, "[^a-zA-Z0-9\\-\\*]");
            return false;
        }

        /// <summary>
        ///     Lấy danh sách các properties của 1 object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> Properties(this object obj)
        {
            Type type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

            return props.ToList();
        }

        /// <summary>
        ///     Set giá trị cho 1 property dynamic
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetObjectProperty(this object obj,
                                             string propertyName,
                                             string value)
        {
            PropertyInfo propertyInfo = obj.GetType()
                                           .GetProperty(propertyName);
            if(propertyInfo != null)
            {
                propertyInfo.SetValue(obj, value, null);
            }
        }

        /// <summary>
        ///     Get giá trị của 1 property dynamic
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static object GetObjectProperty(this object obj,
                                               string propertyName)
        {
            PropertyInfo propertyInfo = obj.GetType()
                                           .GetProperty(propertyName);
            if(propertyInfo != null)
            {
                return propertyInfo.GetValue(obj, null);
            }

            return null;
        }

        /// <summary>
        ///     Tự động thêm khoảng trắng cho object entity framework
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static T FixLength<T>(this T obj,
                                     DbContext context,
                                     string tableName)
        {
            var properties = obj.Properties();
            var oc = ((IObjectContextAdapter) context).ObjectContext;
            foreach (var property in properties)
            {
                var length = oc.MetadataWorkspace.GetItems(DataSpace.CSpace)
                               .OfType<EntityType>()
                               .Where(et => et.Name == tableName)
                               .SelectMany(et => et.Properties.Where(p => p.Name == property.Name))
                               .Select(p => p.MaxLength)
                               .FirstOrDefault();
                if(length >= 0)
                {
                    obj.SetObjectProperty(property.Name, property.GetValue(obj, null)
                                                                 .TrimEx()
                                                                 .PadRight(length.Value));
                }
            }

            return obj;
        }

        /// <summary>
        ///     Xóa khoảng trắng trong object entity framework
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T RemoveWhiteSpace<T>(this T obj)
        {
            var properties = obj.Properties();
            foreach (var property in properties)
            {
                if(property.PropertyType == typeof(string))
                {
                    obj.SetObjectProperty(property.Name, property.GetValue(obj, null)
                                                                 .TrimEx());
                }
            }

            return obj;
        }

        public static List<T> RemoveWhiteSpaceForList<T>(this List<T> obj)
        {
            obj.ForEach(c => c.RemoveWhiteSpace());
            return obj;
        }

        /// <summary>
        ///     Will get the string value for a given enums value, this will
        ///     only work if you assign the StringValue attribute to
        ///     the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs == null ? string.Empty :
                   attribs.Length > 0 ? attribs[0]
                           .StringValue : string.Empty;
        }
    }

}