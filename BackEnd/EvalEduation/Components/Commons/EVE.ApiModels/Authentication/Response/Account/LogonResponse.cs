using System;

namespace EVE.ApiModels.Authentication.Response
{
    public class LogonResponse
    {
        public LogonResponse()
        {
            
        }

        public string USER_ID { get; set; }

        public string IP_ADDRESS { get; set; }

        public string USER_NAME { get; set; }

        public DateTime LOGON_DATE { get; set; }

        public DateTime UPD_TS { get; set; }
    }
}
