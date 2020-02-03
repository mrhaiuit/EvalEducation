using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EVE.LogManagement.Logs
{
    /// <summary>
    ///     <para>LogType:</para>
    ///     <para>+ None</para>
    ///     <para>+ Logic: log lỗi logic</para>
    ///     <para>+ Exception: log exception</para>
    ///     <para>+ Trace: log ghi lại cả khi thành công</para>
    /// </summary
    [JsonConverter(typeof(StringEnumConverter))]
    [DataContract]
    [Flags]
    public enum LogTypes
    {
        [EnumMember]
        None = 0,

        /// <summary>
        ///     Lỗi logic
        /// </summary>
        [EnumMember]
        BugLogic,

        /// <summary>
        ///     Lỗi exception
        /// </summary>
        [EnumMember]
        Exception,

        /// <summary>
        ///     Truy vết
        /// </summary>
        [EnumMember]
        Trace
    }
}
