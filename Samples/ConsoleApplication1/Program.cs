using ConoHaNet;
using ConoHaNet.Objects.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = ""; // input your user name like gncu12345678
            string password = ""; // input your own password
            string tenantname = ""; // input your own tenant name like gnct12345678
            string tenantid = ""; // input your tenant id, which is 32 characters
            string region = "tyo1";

            var osm = new OpenStackMember(
               username,
               password,
               tenantname,
               tenantid,
               defaultregion: region,
               bLazyProviderSetting: false
               );

            var activeServer = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            if (activeServer != null)
            {
                Console.WriteLine(String.Format("{0} is active.", activeServer.Id));
                var console = osm.GetVncConsole(activeServer.Id);
                Console.WriteLine(console.Url);
                System.Diagnostics.Process.Start(console.Url);
            }
            else
            {
                Console.WriteLine("there is no active servers.");
            }
        }
    }
}
