using System;
using System.IO;
using EVE.LogManagement.Logs;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace EVE.LogManagement.Utils
{
    public static class LogUtilExtensions
    {
        private static readonly Logger Serilog = new LoggerConfiguration().WriteTo.File("F:\\log.txt",restrictedToMinimumLevel:LogEventLevel.Debug)
                                                                          .CreateLogger();

        public static void WriteDebugLogBySerilog(this LogDetails obj,
                                                  string path)
        {
            //Serilog?.Information("{@Log}", obj);
            Serilog?.Information(obj.ToJson());
            //File.AppendAllText("serilog.txt", JsonConvert.SerializeObject(obj));

            /// code post object to 
        }

        public static string ToJson(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.None);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return string.Empty;}
    }
}