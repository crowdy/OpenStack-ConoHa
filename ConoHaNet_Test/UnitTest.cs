using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConoHaNet;
using System.Diagnostics;
using System.Linq;

namespace ConoHaNet_Test
{
    [TestClass]
    public class UnitTest
    {
        string username = ""; // input your user name like gncu12345678
        string password = ""; // input your own password
        string tenantname = ""; // input your own tenant name like gnct12345678
        string tenantid = ""; // input your tenant id, which is 32 characters
        string region = "tyo1";

        [TestMethod]
        public void TestMethod1()
        {
            var osm = new OpenStackMember(
            username,
            password,
            tenantname,
            tenantid,
            defaultregion: region,
            bLazyProviderSetting: false
            );

            var servers = osm.ListServers(region: region);
            Trace.WriteLine(servers.Count());

            var console = osm.GetVncConsole("3531f17f-3ffa-4938-8b82-9f4f58ef2a0e");
            Trace.WriteLine(console.Url);
        }
    }
}
