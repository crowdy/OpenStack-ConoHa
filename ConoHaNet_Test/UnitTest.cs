using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConoHaNet;
using System.Diagnostics;
using System.Linq;

namespace ConoHaNet_Test
{
    [TestClass]
    public class UnitTest
    {
        string username = "gncu26535051";
        string password = "YourOwnPassword";
        string tenantname = "gnct26535051";
        string tenantid = "8b11719e50dd4dc4932a8930364f60c9";
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
