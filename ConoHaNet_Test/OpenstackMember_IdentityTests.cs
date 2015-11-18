namespace ConoHaNet_Test
{
    using ConoHaNet;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

    [TestClass()]
    public class OpenstackMember_IdentityTests : OpenstackMemberTestBase
    {

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
        }

        [TestInitialize()]
        public void Initialize()
        {
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod()]
        public void GetIdentityApiEndPointTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            Assert.IsNotNull(os.IdentityProvider);
        }


        #region "tokens"

        [TestMethod()]
        public void CreateUserAccessTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password);
                var ua = os.CreateUserAccess();
                Assert.IsNotNull(ua);
                Assert.IsNull(ua.Token.Tenant);

                os = new OpenStackMember(m.UserName, m.Password, m.TenantName);
                ua = os.CreateUserAccess();
                Assert.IsNotNull(ua);
                Assert.IsNotNull(ua.Token.Tenant);
                Assert.IsNotNull(ua.Token.Tenant.Id);

                os = new OpenStackMember(m.UserName, m.Password, m.TenantName, m.TenantId);
                ua = os.CreateUserAccess();
                Assert.IsNotNull(ua);
                Assert.IsNotNull(ua.Token.Tenant);

                os = new OpenStackMember(m.UserName, m.Password, m.TenantName, m.TenantId, "tyo1");
                ua = os.CreateUserAccess();
                Assert.IsNotNull(ua);
                Assert.IsNotNull(ua.Token.Tenant);

                os = new OpenStackMember(m.UserName, m.Password, null, m.TenantId, "tyo1");
                ua = os.CreateUserAccess();
                Assert.IsNotNull(ua);
                Assert.IsNotNull(ua.Token.Tenant);
            }
        }

        #endregion

        [TestMethod()]
        public void ListEndpointsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var endpoints = os.ListEndpoints();
            foreach (var ep in endpoints)
            {
                Trace.WriteLine(string.Format("{0} / {1} / {2} / {3}", ep.Name, ep.Region, ep.Type, ep.Url));
            }
        }

    }
}