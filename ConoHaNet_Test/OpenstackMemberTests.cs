namespace ConoHaNet_Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using ConoHaNet;
    using ConoHaNet.Objects;
    using ConoHaNet.Objects.Servers;
    using ConoHaNet.Objects.Networks;

    public sealed class MemberCredentials
    {
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public string TenantName { get; internal set; }
        public string TenantId { get; internal set; }
        public string TokenId { get; internal set; }
    }

    public sealed class TestEnvMembers
    {
        public static MemberCredentials Member = new MemberCredentials
        {
            TenantName = "",
            TenantId = "",
            UserName = "",
            Password = "",
            TokenId = null
        };

        public readonly static List<MemberCredentials> Members = new List<MemberCredentials>
        {
            Member,
        };
    }


    public class OpenstackMemberTestBase
    {
        protected string UserName = ""; // input your user name like gncu12345678
        protected string Password = ""; // input your own password yksole1L1234-
        protected string TenantName = ""; // input your own tenant name like gnct12345678
        protected string TenantId = ""; // input your tenant id, which is 32 characters

        protected static string _TesterName = null;
        public string TesterName
        {
            get
            {
                if (_TesterName == null)
                    _TesterName = GetTesterNameByEnv();
                return _TesterName;
            }
        }

        public TException AssertCatch<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException exception)
            {
                return exception;
            }
            string msg = "Expected exception of type " + typeof(TException) + " was not thrown";
            Trace.WriteLine("===================================");
            Trace.WriteLine(msg);
            throw new AssertFailedException(msg);
        }

        protected string GetTesterNameByEnv()
        {
            return UserName;
        }


        protected SimpleServer GetServerByNameOrCreate(string serverName, bool forceCreateServer = true)
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var servers = os.ListServersDetails().Where<Server>(x =>
            {
                var metadata = x.GetMetadata();
                if (!metadata.ContainsKey("loginname"))
                    return false;
                return metadata["loginname"] == serverName;
            });
            if (servers != null && servers.Count() > 0)
                return servers.First<Server>();
            else
            {
                if (!forceCreateServer) throw new ArgumentException("no item found");

                // create server
                var image = os.ListImages().First();
                var network = os.ListNetworks().Where<Network>(x => x.Name.Contains("ext_")).First<Network>();
                NewServer server = os.CreateServer(serverName, image.Id, GetFlavorByName("g-1gb").Id, "YKJkd2-GF%x1O", keyname: null, nametag: "test nametag", networks: (new String[] { network.Id }));
                Trace.WriteLine(String.Format("server creation transferred : {0}", DateTime.Now));
                Assert.IsNotNull(server);
                Assert.IsNotNull(server.AdminPassword);
                Trace.WriteLine(string.Format("ServerName : {0}", serverName));
                Trace.WriteLine(string.Format("AdminPassword : {0}", server.AdminPassword));

                // wait for activate
                os.ServersProvider.WaitForServerActive(server.Id);
                Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));

                servers = os.ListServersDetails().Where<Server>(x =>
                {
                    var metadata = x.GetMetadata();
                    if (!metadata.ContainsKey("loginname"))
                        return false;
                    return metadata["loginname"] == serverName;
                });
                if (servers != null && servers.Count() > 0)
                    return servers.First<SimpleServer>();
                else
                    throw new ArgumentException("server creation faild");
            }
        }

        /// <summary>
        /// Tests getting flavor by name
        /// </summary>
        /// <param name="flavorName"></param>
        /// <returns></returns>
        protected Flavor GetFlavorByName(string flavorName)
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            return os.ListFlavors().Where<Flavor>(x => x.Name == flavorName).First<Flavor>();
        }


    }

    [TestClass()]
    public class OpenstackMemberTests : OpenstackMemberTestBase
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
        public void OpenstackMemberTest()
        {
            var os = new OpenStackMember(UserName, Password);
            Assert.IsNotNull(os);

            os = new OpenStackMember(UserName, Password, null, null);
            Assert.IsNotNull(os);

            os = new OpenStackMember(UserName, Password, TenantName);
            Assert.IsNotNull(os);

            os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            Assert.IsNotNull(os);

            os = new OpenStackMember(UserName, Password, TenantName, TenantId, "tyo1");
            Assert.IsTrue(os.DefaultRegion == "tyo1");

            os = new OpenStackMember(UserName, Password, null, TenantId, "tyo1");
            Assert.IsTrue(os.DefaultRegion == "tyo1");
        }

        [TestMethod()]
        public void OpenstackMemberTest_ShouldFail()
        {
            IOpenStackMember os = null;

            // it should throw ArgumentNullException when UserName and Password are null.
            AssertCatch<ArgumentNullException>(() => os = new OpenStackMember(null, null));

            // it should throw ArgumentNullException when UserName is null.
            AssertCatch<ArgumentNullException>(() => os = new OpenStackMember(null, Password));

            // it should throw ArgumentNullException when password is null.
            AssertCatch<ArgumentNullException>(() => os = new OpenStackMember(UserName, null));

            // os.UserId should be null when UserName or Password doesn't match.
            AssertCatch<ArgumentException>(() => os = new OpenStackMember(UserName, string.Empty));

            // what if os.UserId will be? when tenantId is not match.
            AssertCatch<ArgumentException>(() => os = new OpenStackMember(UserName, Password, null, string.Empty));

        }

    }

}