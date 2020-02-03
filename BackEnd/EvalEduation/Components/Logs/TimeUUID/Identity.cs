using System;

namespace TimeUUID
{
    public class Identity
    {
        private static ulong _identity;

        public static string Next()
        {
            var dt = DateTime.UtcNow;
            if(_identity == 0)
            {
                _identity = ulong.Parse(dt.ToString("hhmmssffff")) + 1;
            }
            else
            {
                _identity++;
            }

            return dt.ToString("yyyyMMddhhmmssffff") + _identity;
        }
    }
}
