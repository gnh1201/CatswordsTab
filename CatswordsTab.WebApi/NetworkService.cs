using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CatswordsTab.WebApi
{
    class NetworkService
    {
        public static string GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "";
        }

        public static string GetLocalMAC()
        {
            var macAddrs = new List<string>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress().ToString();
                }
            }

            return "";
        }
    }
}
