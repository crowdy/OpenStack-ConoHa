using ConoHaNet;
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
            string username = "gncu26535051";
            string password = "YourOwnPassword";
            string tenantname = "gnct26535051";
            string tenantid = "8b11719e50dd4dc4932a8930364f60c9";
            string region = "tyo1";

            var osm = new OpenStackMember(
               username,
               password,
               tenantname,
               tenantid,
               defaultregion: region,
               bLazyProviderSetting: false
               );

            var servers = osm.ListServers(region: region);
            Console.WriteLine(servers.Count());

            var console = osm.GetVncConsole("3531f17f-3ffa-4938-8b82-9f4f58ef2a0e");
            Console.WriteLine(console.Url);
            System.Diagnostics.Process.Start(console.Url);
        }
    }
}
