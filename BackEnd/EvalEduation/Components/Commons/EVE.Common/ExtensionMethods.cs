
using System;
using System.Globalization;
using System.Data;
using System.Windows.Forms;
using EVE.Commons;
using Microsoft.VisualBasic;
/*
* Class contain extension methods to existing types.
* User can define new methods for any type
* 
*/

namespace ExtensionMethods
{
    public static class ExtensionClass
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public static string MySubstring(this string str, int startIndex, int length)
        {
            try
            {               
                if (str == null)
                    return "";
                if (startIndex + length <= str.Length)
                     
                    return str.Substring(startIndex, length);
                return str.Substring(startIndex);
            }
            catch
            {
                return "";
            }                                               
        }
        

        //------------------------------------------------------------------------------------------------------------------------------
        
        public static string MyTrim(this string str)
        {
            if (str == null)                                    //Hao, 19/11/2010
                return "";

            return str.Trim();

            //str = Strings.Trim(str);
            //return str;
        }

        //------------------------------------------------------------------------------------------------------------------------------

        public static string MyTrim(this object str)
        {
            if (str == null)                                        //Hao, 19/11/2010
                return "";

            return Convert.ToString(str).Trim();
            //return Strings.Trim(str.ToString());
        }

        /// <summary>
        /// Return string value, if object is null return empty string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MyToString(this object str)
        {

            if (str == null)
                return "";

            return str.ToString();
        }
        //------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Check if string is null or empty then return space
        /// otherwise return trim of itself        
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckBlank(this object  str)
        {

            if (str == null)
                return " ";
            string returnVal = str.MyTrim();

            if (returnVal == "")
                return " ";

            return returnVal;
        }

        /// <summary>
        /// Convert object to decimal value
        /// if can not, return 0.0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CheckInt(this object str)
        {
            if (str == null)                 
                return 0;
            int value;
            if (!int.TryParse(str.ToStringEx(), out value))
                value = 0;
            return value;
        }


        /// <summary>
        /// Convert object to int value
        /// if can not, return 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal CheckDecimal(this object  str)
        {
            if (str == null)                
                return 0M;
            decimal value;
            if (!decimal.TryParse(str.ToStringEx(), out value))
                value = 0M;
            return value;
        }

        /// <summary>
        /// convert object to double value
        /// if can not return 0.0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double CheckDouble(this object str)
        {
            if (str == null)                 
                return 0.0;
            double value;
            if (!double.TryParse(str.ToStringEx(), out value))
                value = 0.0;
            return value;
        }

        /// <summary>
        /// convert object to long value
        /// if can not reuturn 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long CheckLong(this object str)
        {
            if (str == null)              
                return 0;
            long value;
            if (!long.TryParse(str.ToStringEx(), out value))
                value = 0;
            return value;
        }

        /// <summary>
        /// convert object to string DateTime
        /// if can not reuturn 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime CheckDate(this object str)
        {
            if (str == null)
                return DateTime.Parse(mGlobal.NullDateHMS);
            if (str.ToString().MyTrim() == "")
                return DateTime.Parse(mGlobal.NullDateHMS);
            if (!Information.IsDate(str.ToString()))
                return DateTime.Parse(mGlobal.NullDateHMS);
            return DateTime.Parse(str.ToString());
        }

        /// <summary>
        /// This function will return string number having single quote at front and back Ex: '98,78'
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringNum(this object str)
        {

           string output = str.MyTrim();
           return "'" + output + "'";
            
        }
        /// <summary>
        /// Find findVal in the InString whole word only, if found return true,
        /// false otherwise
        /// </summary>
        /// <param name="InString"></param>
        /// <param name="findVal"></param>
        /// <returns></returns>
        public static Boolean MyContains(this string InString, string findVal)
        {
            string[] list;
            list = InString.ToUpper().Split(',');
            findVal = findVal.ToUpper().MyTrim();
            for (int i = 0; i < list.Length; i++)
                if (list[i].MyTrim() == findVal)
                    return true;
            return false;
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
                strTmp = pStrInput.MySubstring(i, 1);
                if (strTmp != "\'")
                {
                    strOutput = strOutput + strTmp;
                }
                else
                {
                    strOutput = strOutput + "\'\'";
                }
            }
            return strOutput.MyTrim();
        }

        /// <summary>
        /// <para> DataGridView to DataTable with visible columns </para> 
        /// <para> Requirement: DGV column name must be assigned </para>
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this DataGridView dataGridView, string tableName = "Table")
        {
            DataGridView dgv = dataGridView;
            DataTable table = new DataTable(tableName);

            // Crea las columnas 
            for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
            {
                if (dgv.Columns[iCol].Visible == true)
                    table.Columns.Add(dgv.Columns[iCol].Name);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {

                DataRow datarw = table.NewRow();
                int j = 0;

                for (int iCol = 0; iCol < dgv.Columns.Count; iCol++)
                {
                    if (dgv.Columns[iCol].Visible == true)
                    {
                        datarw[j] = row.Cells[iCol].Value;
                        j++;
                    }
                }

                table.Rows.Add(datarw);
            }

            return table;
        }
    }        
        
}
