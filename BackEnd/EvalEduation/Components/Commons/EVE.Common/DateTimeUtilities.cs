
using System;
using System.Globalization;
using Microsoft.VisualBasic;

namespace EVE.Commons
{
    public static class DateTimeUtilities
    {
        /// <summary>
        /// Check to see if the given object is null date (value of year is 1900)
        /// </summary>
        /// <param name="dateValue"></param>
        /// <returns></returns>
        static public bool IsNullDate(object dateValue)
        {
            bool returnValue = false;
            DateTime date = new DateTime();
            try
            {
                if (dateValue.GetType().Name == "DateTime")
                {
                    date = (DateTime)(dateValue);
                }
                else if (dateValue.GetType().Name == "String")
                {

                    if (string.IsNullOrWhiteSpace(dateValue.ToStringEx()))
                    {
                        return true;
                    }

                    bool isValid = DateTime.TryParse((string)dateValue, out date);
                    if (!isValid)
                    {
                        date = Convert.ToDateTime((string)dateValue, GlobalSettings.DateTimeFormat);
                    }

                }
                else
                {
                    return false;
                }

                //Check to see if value of year is 1900
                if (date.Year == 1900)
                {
                    returnValue = true;
                }
                else
                {
                    returnValue = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;

        }

        public static TimeSpan DiffDBTimeSpan = new TimeSpan(0,0,0,0);
        

        /// <summary>
        /// Format date string to sFormat provided, follow vn cultural
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="sFormat"></param>
        /// <returns></returns>
        public static string FormatDateTime(string pDateTime, string sFormat)
        {

            string ReturnVal = " ";

            if (pDateTime.Trim() == "")
            {

                return ReturnVal;

            }

            if (pDateTime.IndexOf("1900") > -1)
            {

                return ReturnVal;

            }

            DateTime dt;

            if (Information.IsDate(pDateTime) == false)
                return " ";


            if (DateTime.TryParse(pDateTime, out dt) == false)
                return " ";


            ReturnVal = String.Format("{0:" + sFormat + "}", dt);   //String.Format("{0:dd/MM/yyyy HH:mm:ss}", dt);

            string seperator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            if (ReturnVal.IndexOf("-") >= 0)
            {
                ReturnVal = ReturnVal.Replace(seperator, "/");

            }


            return ReturnVal;

        }

        /// <summary>
        /// This function will check the value passin is date type value or not,
        /// If it is valid date type value. then this function return string in format dmyhm. Otherwise, if it can not parse to
        /// date type object, it will return null date string 31/12/1900
        /// </summary>
        /// <returns></returns>
        public  static string CheckDate(string dateTime)
        {
            if (dateTime == null)
                return GlobalSettings.NullDateHM;
            else if (dateTime.TrimEx() == string.Empty)
                return GlobalSettings.NullDateHM;
            else if (!Information.IsDate(dateTime))
                return GlobalSettings.NullDateHM;
            else
                return Convert.ToDateTime(dateTime).ToString(GlobalSettings.StrDMYHM);
        }

        /// <summary>
        /// The function returns a date that is considered as default null date in TOPO project (31/12/1900 00:00:00)
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNullDate()
        {
            DateTime nullDate = DateTime.ParseExact(GlobalSettings.NullDateHMS, GlobalSettings.StrDMYHMS, CultureInfo.InvariantCulture);
            return nullDate;
        }
        
        /// <summary>
        /// The function returns a string that can be used in SQL queries to determine whether a value is null date or not (in TOPO)
        /// </summary>
        /// <returns>TO_DATE('31/12/1900', 'dd/mm/yyyy')</returns>
        public static string GetDbStringNullDate()
        {
            return
                $"TO_DATE('{DateTimeUtilities.GetNullDate().ToString(GlobalSettings.StrDMY)}', {GlobalSettings.DbStrDMY} )";
        }

        public static DateTime GetLastDayOfMonthEx(this object str)
        {
            var lastDayOfMonth = CheckDateEx(str);
            return new DateTime(lastDayOfMonth.Year, lastDayOfMonth.Month, DateTime.DaysInMonth(lastDayOfMonth.Year, lastDayOfMonth.Month), 23, 59, 59);
        }
        public static DateTime GetBeginDayOfMonthEx(this object str)
        {
            var lastDayOfMonth = CheckDateEx(str);
            return new DateTime(lastDayOfMonth.Year, lastDayOfMonth.Month,01, 00, 00, 00);
        }

        /// <summary>
        /// convert object to string DateTime
        /// if can not reuturn 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime CheckDateEx(this object str)
        {
            DateTime nullDate = DateTimeUtilities.GetNullDate();
            DateTime date = new DateTime();

            if (str == null)
            {
                return nullDate;
            }

            if (str.ToString().TrimEx() == "")
            {
                return nullDate;
            }

            if (str.GetType() == typeof(DateTime))
            {
                return (DateTime)str;
            }

            if (str.ToString().Contains("1900"))
            {
                return nullDate;
            }

            if (DateTime.TryParseExact(str.ToString().SubstringEx(0, GlobalSettings.StrDMYHMS.Length), GlobalSettings.StrDMYHMS, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return date;
            }
            else if (DateTime.TryParseExact(str.ToString().SubstringEx(0, GlobalSettings.StrDMYHM.Length), GlobalSettings.StrDMYHM, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return date;
            }
            else if (DateTime.TryParseExact(str.ToString().SubstringEx(0, GlobalSettings.StrDMY.Length), GlobalSettings.StrDMY, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return date;
            }
            else if (DateTime.TryParse(str.ToString(), out date))
            {
                return date;
            }
            else
            {
                return nullDate;
            }
        }

        /// <summary>
        /// 2014.03.17 pxtung: Get begin date (ex: 01/01/2014 00:00:00)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime GetBeginDate(this object str)
        {
            DateTime nullDate = DateTimeUtilities.GetNullDate();
            DateTime date = new DateTime();

            if (str == null)
            {
                return nullDate;
            }
            if (str.ToString().TrimEx() == "")
            {
                return nullDate;
            }
            if (str.ToString().Contains("1900"))
            {
                return nullDate;
            }

            
            if (DateTime.TryParseExact(str.ToString().SubstringEx(0, GlobalSettings.StrDMY.Length) + "00:00:00", GlobalSettings.StrDMYHMS, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return date;
            }
            return nullDate;
        }

        /// <summary>
        /// 2014.03.17 pxtung: Get end date (Ex: 31/12/2014 23:59:59)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime GetEndDate(this object str)
        {
            DateTime nullDate = DateTimeUtilities.GetNullDate();
            DateTime date = new DateTime();

            if (str == null)
            {
                return nullDate;
            }
            if (str.ToString().TrimEx() == "")
            {
                return nullDate;
            }
            if (str.ToString().Contains("1900"))
            {
                return nullDate;
            }

            if (DateTime.TryParseExact(str.ToString().SubstringEx(0, GlobalSettings.StrDMY.Length) + "23:59:59", GlobalSettings.StrDMYHMS, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return date;
            }
            if (DateTime.TryParse(str.ToString(), out date))
            {
                return date.Date;
            }
            return nullDate;
        }
        /// <summary>
        /// Check to see if the given string is correct format as it's defined in GlobalSettings, or least, a valid date time as defined in local machine
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str)
        {
            DateTime date;

            if (DateTime.TryParseExact(str.FixString(GlobalSettings.StrDMY.Length), GlobalSettings.StrDMY, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return true;
            }
            else if (DateTime.TryParseExact(str.FixString(GlobalSettings.StrDMYHM.Length), GlobalSettings.StrDMYHM, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return true;
            }
            else if (DateTime.TryParseExact(str.FixString(GlobalSettings.StrDMYHMS.Length), GlobalSettings.StrDMYHMS, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out date))
            {
                return true;
            }
            else if (DateTime.TryParse(str, out date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns></returns>
        public static DateTime TruncateSecond(this DateTime dateTimeValue)
        {
            return new DateTime(dateTimeValue.Year, dateTimeValue.Month, dateTimeValue.Day, dateTimeValue.Hour, dateTimeValue.Minute, 0);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns></returns>
        public static DateTime TruncateTime(this DateTime dateTimeValue)
        {
            return new DateTime(dateTimeValue.Year, dateTimeValue.Month, dateTimeValue.Day, 0, 0, 0);
        }
    }
}
