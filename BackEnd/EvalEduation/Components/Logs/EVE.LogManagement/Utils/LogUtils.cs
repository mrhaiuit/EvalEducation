﻿using System;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EVE.LogManagement.Utils
{
    public class LogUtils
    {
        /// <summary>
        ///     Get Ip address client
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            var context = OperationContext.Current;
            if(context == null)
                return "";

            var prop = context.IncomingMessageProperties;
            var endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            if(endpoint == null)
                return "";
            return endpoint.Address;
        }

        /// <summary>
        ///     AddressFamily.InterNetwork
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <returns></returns>
        public static string GetLocalIPAddress(AddressFamily addressFamily)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if(ip.AddressFamily == addressFamily)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        //public static Dictionary<string, object> RetrievalParameter(MethodExecutionArgs args)
        //{
        //    var m_args = new Dictionary<string, object>();
        //    var name = string.Empty;
        //    object obj = null;
        //    for (int i = 0; i < args.Arguments.Count(); i++)
        //    {
        //        name = args.Method.GetParameters()[i].Name;
        //        obj = args.Arguments.GetArgument(i);

        //        m_args.Add(name, obj);
        //    }
        //    return m_args;
        //}
    }
}
