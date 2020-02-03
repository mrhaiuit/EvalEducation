using System;

namespace EVE.Commons
{
    public static class ConvertUtils
    {
        public static int TryConvertToInt32(object obj,
                                            int defaultValue = 0)
        {
            try
            {
                int.TryParse(obj.ToString(), out defaultValue);
            }
            catch (Exception exception)
            {
                defaultValue = 0;
            }

            return defaultValue;
        }
    }
}
