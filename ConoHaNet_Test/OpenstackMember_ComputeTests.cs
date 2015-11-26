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
    using net.openstack.Core.Exceptions.Response;

    [TestClass()]
    public class OpenstackMember_ComputeTests : OpenstackMemberTestBase
    {
        protected const string InvalidId = "12345678-abcd-1234-abcd-1234abcd5678";
        protected const string InvalidItemName = "InvalidItemName for Test";

        private string TemporaryServerName { get { return "changeme_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss_fff"); } }

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
        public void GetComputeApiEndPointTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName);
            Assert.IsNotNull(os.ServersProvider);
        }

        #region "flavors"

        [TestMethod()]
        public void ListFlavorsTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password); // without tenant, can not get endpoints.
                IEnumerable<Flavor> flavors = null;
                try
                {
                    flavors = os.ListFlavors();
                }
                catch (net.openstack.Core.Exceptions.UserAuthorizationException uae)
                {
                    Assert.IsTrue(uae.Message.Equals("The user does not have access to the requested service or region."));
                }

                os = new OpenStackMember(m.UserName, m.Password, m.TenantName); // with tenant
                flavors = os.ListFlavors();
                Assert.IsNotNull(flavors);
                foreach (var f in flavors)
                {
                    Assert.IsNotNull(f.Id);
                    Assert.IsNotNull(f.Name);
                    Assert.IsNotNull(f.Links);
                }
            }
        }

        [TestMethod()]
        public void ListFlavorsDetailsTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password, m.TenantName); // without tenant, can not get endpoints.
                IEnumerable<Flavor> flavors = null;
                try
                {
                    flavors = os.ListFlavors();
                }
                catch (net.openstack.Core.Exceptions.UserAuthorizationException uae)
                {
                    Assert.IsTrue(uae.Message.Equals("The user does not have access to the requested service or region."));
                    return;
                }

                os = new OpenStackMember(m.UserName, m.Password, m.TenantName); // with tenant
                flavors = os.ListFlavorsDetails();
                Assert.IsNotNull(flavors);
                foreach (var f in flavors)
                {
                    Assert.IsNotNull(f.Id);
                    Assert.IsNotNull(f.Name);
                    Assert.IsNotNull(f.Links);
                }
            }
        }

        [TestMethod()]
        public void GetFlavorTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var flavor = GetFlavorByName("g-2gb");
            var f = os.GetFlavor(flavor.Id);
            Assert.IsNotNull(f);
            Assert.IsNotNull(f.Id == flavor.Id);
            Assert.IsNotNull(f.Name == flavor.Id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void GetFlavorTest_Get_Flavor_Invalid()
        {
            var os = new OpenStackMember(UserName, Password, TenantName);

            // expect ItemNotFoundException
            var f = os.GetFlavor(InvalidId);
        }

        #endregion


        #region "servers"

        [TestMethod()]
        public void ListServersTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password, m.TenantName);
                IEnumerable<SimpleServer> servers = os.ListServers();
                Assert.IsNotNull(servers);
                foreach (var s in servers)
                {
                    Trace.WriteLine(string.Format("serverid : {0}, servername : {1}", s.Id, s.Name));
                }
            }
        }

        [TestMethod()]
        public void ListServersDetailsTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password, m.TenantName);
                IEnumerable<Server> servers = os.ListServersDetails();
                Assert.IsNotNull(servers);
                foreach (var s in servers)
                {
                    Trace.WriteLine(string.Format("serverid : {0}, servername : {1}", s.Id, s.Name));
                    foreach (var n in s.ListAddresses())
                    {
                        Trace.WriteLine(String.Format("\tAddresses key : {0}", n.Key));
                        Trace.WriteLine(String.Format("\tAddresses key : {0}", n.Value));
                    }
                }
            }
        }

        [TestMethod()]
        public void GetServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName); // with tenant
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            Server server = osm.GetServer(ss.Id);
            Assert.IsTrue(server.Id == ss.Id);
            Assert.IsTrue(osm.DeleteServer(ss.Id));
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void GetServerTest_VM_Invalid()
        {
            var os = new OpenStackMember(UserName, Password, TenantName);

            // expect ItemNotFoundException
            Server server = os.GetServer(InvalidId);
        }

        [TestMethod()]
        public void CreateServerTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            var image = os.ListImages().First();

            // decide server name which is not duplicated.
            IEnumerable<SimpleServer> servers = os.ListServers();
            var names = servers.GroupBy(s => s.Name, (key, g) => key);
            string[] data = Enumerable.Range(1, 100).Select(i => string.Format("{0}_{1}", TesterName, i)).ToArray<string>();
            string serverName = (from b in data where !names.Contains<string>(b) select b).First();

            // create server
            // the name tag must not contain space
            NewServer server = os.CreateServer(serverName, image.Id, GetFlavorByName("g-1gb").Id, "S5df!Afdas%'Zt", keyname: null, nametag: "test_nametag", networks: null);
            Trace.WriteLine(String.Format("server creation transferred : {0}", DateTime.Now));
            Assert.IsNotNull(server);
            Assert.IsNotNull(server.AdminPassword);
            Trace.WriteLine(string.Format("ServerName : {0}", serverName));
            Trace.WriteLine(string.Format("AdminPassword : {0}", server.AdminPassword));

            // wait for activate
            os.ServersProvider.WaitForServerActive(server.Id);
            Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));

            bool bDelete = os.DeleteServer(server.Id);
            Assert.IsTrue(bDelete);
            Trace.WriteLine(String.Format("server deletion transferred : {0}", DateTime.Now));

            // wait for delete
            os.ServersProvider.WaitForServerDeleted(server.Id);
            Trace.WriteLine(String.Format("server deleted : {0}", DateTime.Now));
        }

        [TestMethod(), Ignore]
        public void CreateServerTest_5times()
        {
            OpenStackMember os = null;
            NewServer server = null;
            var serverIds = new List<string>();
            try
            {
                os = new OpenStackMember(UserName, Password, TenantName, TenantId);
                var image = os.ListImages().First();
                for (int cnt = 1; cnt <= 15; cnt++)
                {
                    IEnumerable<SimpleServer> servers = os.ListServers();
                    var names = servers.GroupBy(s => s.Name, (key, g) => key);
                    string[] data = Enumerable.Range(1, 100).Select(i => string.Format("{0}_{1}", TesterName, i)).ToArray<string>();
                    string serverName = (from b in data where !names.Contains<string>(b) select b).First();
                    server = os.CreateServer(serverName, image.Id, GetFlavorByName("g-1gb").Id, "D$fjhg5422mnM-");
                    serverIds.Add(server.Id);
                    Trace.WriteLine(String.Format("server creation transferred : {0}", DateTime.Now));
                    Assert.IsNotNull(server);
                    Assert.IsNotNull(server.AdminPassword);
                    Trace.WriteLine(string.Format("ServerName : {0}", serverName));
                    Trace.WriteLine(string.Format("AdminPassword : {0}", server.AdminPassword));
                }
            }
            finally
            {
                foreach (var serverId in serverIds)
                {
                    bool bDelete = os.DeleteServer(serverId);
                    Assert.IsTrue(bDelete);
                    Trace.WriteLine(String.Format("server deletion transferred : {0}", DateTime.Now));
                    os.ServersProvider.WaitForServerDeleted(serverId);
                    Trace.WriteLine(String.Format("server deleted : {0}", DateTime.Now));
                }
            }
        }

        [TestMethod()]
        public void DeleteServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                bool b = osm.DeleteServer(ss.Id);
                Assert.IsTrue(b);
                Trace.WriteLine(String.Format("server deleted : {0}", DateTime.Now));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void DeleteServerTest_Delete_Server_Not_Exist()
        {
            var os = new OpenStackMember(UserName, Password, TenantName);

            // expect ItemNotFoundException
            bool b = os.DeleteServer(InvalidId);
        }

        [TestMethod()]
        public void StartServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            Server server = osm.GetServer(ss.Id);

            // check server status
            if (server.Status == ServerState.Active && server.VMState == VirtualMachineState.Active)
            {
                osm.StopServer(server.Id);
                // wait for stop
                WaitForVMState(server.Id, new[] { VirtualMachineState.Stopped }, new[] { VirtualMachineState.Error });
                Trace.WriteLine(String.Format("server stopped : {0}", DateTime.Now));

                // start server
                bool b = osm.StartServer(server.Id);
                Assert.IsTrue(b);
                Trace.WriteLine(string.Format("server started : {0}", DateTime.Now));
            }
            else
            {
                Trace.WriteLine(string.Format("server.Status : {0}", server.Status));
                Trace.WriteLine(string.Format("server.VMState : {0}", server.VMState));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void StartServerTest_Start_VM_Not_Exist()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // expect ItemNotFoundException
            bool b = os.StartServer(InvalidId);
        }

        [TestMethod()]
        public void RestartServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            Server server = osm.GetServer(ss.Id);

            // check server status
            if (server.Status != ServerState.Active)
            {
                if (server.Status != ServerState.Reboot)
                    osm.StartServer(server.Id);
                // wait for activate
                osm.ServersProvider.WaitForServerActive(server.Id);
                Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
            }

            bool b = server.SoftReboot();
            Assert.IsTrue(b);
            Trace.WriteLine(string.Format("server restarted : {0}", DateTime.Now));
        }

        [TestMethod()]
        public void StopServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            Server server = osm.GetServer(ss.Id);

            // check server status
            if (server.VMState == VirtualMachineState.Stopped)
            {
                if (server.Status != ServerState.Reboot)
                    osm.StartServer(server.Id);
                // wait for activate
                osm.ServersProvider.WaitForServerActive(server.Id);
                Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));

                // stop server
                bool b = osm.StopServer(server.Id);
                Assert.IsTrue(b);
                var vmState = server.VMState;
                Trace.WriteLine(string.Format("server stopped : {0}", DateTime.Now));
            }
            else
            {
                Trace.WriteLine(string.Format("server.Status : {0}", server.Status));
                Trace.WriteLine(string.Format("server.VMState : {0}", server.VMState));
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void StopServerTest_Stop_VM_Not_Exist()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // expect ItemNotFoundException
            bool b = os.StopServer(InvalidId);
        }

        [TestMethod(), Ignore]
        public void RebuildServerTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = GetServerByNameOrCreate(TesterName);
            Server s = os.GetServer(ss.Id);
            Assert.IsNotNull(s);

            try
            {
                var rebuiltServer = os.RebuildServer(s.Id, s.Image.Id, "newPassword");
                Assert.IsNotNull(rebuiltServer);
                Trace.WriteLine(string.Format("server rebuilt : {0}", DateTime.Now));

                s = os.ServersProvider.WaitForServerActive(s.Id, 100);
            }
            catch (ServiceConflictException sce)
            {
                if (sce.Message.Equals("Cannot 'rebuild' while instance is in task_state reboot_started"))
                {
                    // no error for this is what expected.
                    Trace.WriteLine(string.Format("s.Status : {0}", s.Status));
                    Trace.WriteLine(string.Format("s.VMState : {0}", s.VMState));
                    return;
                }

                // in other cases,
                throw;
            }
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void RebuildServerTest_ServerId_Invalid()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            Server server = osm.GetServer(ss.Id);

            // expect ItemNotFoundException
            Server rebuiltserver = osm.RebuildServer(InvalidId, server.Image.Id, "newPassword");
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(BadServiceRequestException))]
        public void RebuildServerTest_ImageId_Invalid()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = GetServerByNameOrCreate(TesterName);
            Server s = os.GetServer(ss.Id);

            // expect BadServiceRequestException
            Server rebuiltserver = os.RebuildServer(s.Id, InvalidId, "newPassword");
        }

        [TestMethod(), Ignore]
        public void RebuildServerTest_FlavorId_Invalid()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = GetServerByNameOrCreate(TesterName);
            Server s = os.GetServer(ss.Id);

            try
            {
                Server rebuiltserver = os.RebuildServer(s.Id, s.Image.Id, "newPassword");
            }
            catch (ServiceConflictException sce)
            {
                if (sce.Message.Equals("Cannot 'rebuild' while instance is in task_state reboot_started"))
                {
                    // no error for this is what expected.
                    Trace.WriteLine(string.Format("s.Status : {0}", s.Status));
                    Trace.WriteLine(string.Format("s.VMState : {0}", s.VMState));
                    return;
                }

                // in other cases,
                throw;
            }

            s = os.ServersProvider.WaitForServerActive(s.Id, 100);
        }

        [TestMethod(), Ignore]
        public void ResizeServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            Server server = osm.GetServer(ss.Id);
            if (server != null)
            {

                if (server.Status == ServerState.VerifyResize)
                {
                    osm.RevertResizeServer(server.Id);
                    Trace.WriteLine(String.Format("server reverted a resizing : {0}", DateTime.Now));
                    // wait for activate
                    server = osm.ServersProvider.WaitForServerActive(server.Id);
                    Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
                }
                IEnumerable<Flavor> flavors = osm.ListFlavors();
                Flavor flavor1g = flavors.Where<Flavor>(x => x.Name == "g-1gb").First<Flavor>();
                Flavor flavor2g = flavors.Where<Flavor>(x => x.Name == "g-2gb").First<Flavor>();
                bool b;
                try
                {
                    b = osm.ResizeServer(server.Id, (server.Flavor.Id == flavor1g.Id ? flavor2g.Id : flavor1g.Id), DiskConfiguration.FromName("AUTO"));
                    Assert.IsTrue(b);

                    Trace.WriteLine(String.Format("server requested a resizing : {0}", DateTime.Now));
                    Trace.WriteLine(String.Format("FlavorId : {0}", server.Flavor.Id));

                    // wait for request
                    server = osm.ServersProvider.WaitForServerState(server.Id, ServerState.VerifyResize, new[] { ServerState.Error, ServerState.Unknown, ServerState.Suspended });
                    Trace.WriteLine(String.Format("server status changed to {0} : {1}", server.Status, DateTime.Now));

                }
                catch (ServiceConflictException sce)
                {
                    // throwing ServiceConflictException when server is locked is designed.
                    Assert.IsTrue(sce.Message.Contains("locked"));
                }
            }
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(ServiceConflictException))]
        public void ResizeServerTest_Resize_2Times()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                Server s = osm.GetServer(ss.Id);
                IEnumerable<Flavor> flavors = osm.ListFlavors();
                if (s.Status != ServerState.VerifyResize)
                {
                    Flavor flavor4g = flavors.Where<Flavor>(x => x.Name == "4g").First<Flavor>();
                    osm.ResizeServer(s.Id, flavor4g.Id, DiskConfiguration.FromName("AUTO"));
                    Trace.WriteLine(String.Format("server requested a resizing : {0}", DateTime.Now));
                    Trace.WriteLine(String.Format("FlavorId : {0}", s.Flavor.Id));
                    // wait for request
                    s = osm.ServersProvider.WaitForServerState(s.Id, ServerState.VerifyResize, new[] { ServerState.Error, ServerState.Unknown, ServerState.Suspended });
                    Trace.WriteLine(String.Format("server status changed to {0} : {1}", s.Status, DateTime.Now));
                }
                Flavor flavor1g = flavors.Where<Flavor>(x => x.Name == "g-1gb").First<Flavor>();
                Flavor flavor2g = flavors.Where<Flavor>(x => x.Name == "g-2gb").First<Flavor>();

                // expect ServiceConflictException
                bool b = osm.ResizeServer(s.Id, (s.Flavor.Id == flavor1g.Id ? flavor2g.Id : flavor1g.Id), DiskConfiguration.FromName("AUTO"));
            }
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(BadServiceRequestException))]
        public void ResizeServerTest_same_flavorid()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                Server s = osm.GetServer(ss.Id);
                if (s.Status == ServerState.VerifyResize)
                {
                    osm.RevertResizeServer(s.Id);
                    Trace.WriteLine(String.Format("server reverted a resizing : {0}", DateTime.Now));
                    // wait for activate
                    s = osm.ServersProvider.WaitForServerActive(s.Id);
                    Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
                }

                // expect BadServiceRequestException
                bool b = osm.ResizeServer(s.Id, s.Flavor.Id, DiskConfiguration.FromName("AUTO"));
                Assert.IsTrue(b);
            }
        }

        [TestMethod(), Ignore]
        public void ConfirmServerResizedTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                Server s = osm.GetServer(ss.Id);
                if (s.Status != ServerState.VerifyResize)
                {
                    IEnumerable<Flavor> flavors = osm.ListFlavors();
                    Flavor flavor1g = flavors.Where<Flavor>(x => x.Name == "g-1gb").First<Flavor>();
                    Flavor flavor2g = flavors.Where<Flavor>(x => x.Name == "g-2gb").First<Flavor>();
                    osm.ResizeServer(s.Id, (s.Flavor.Id == flavor1g.Id ? flavor2g.Id : flavor1g.Id), DiskConfiguration.FromName("AUTO"));
                    Trace.WriteLine(String.Format("server requested a resizing : {0}", DateTime.Now));
                    Trace.WriteLine(String.Format("FlavorId : {0}", s.Flavor.Id));

                    // wait for request
                    s = osm.ServersProvider.WaitForServerState(s.Id, ServerState.VerifyResize, new[] { ServerState.Error, ServerState.Unknown, ServerState.Suspended });
                    Trace.WriteLine(String.Format("server status changed to {0} : {1}", s.Status, DateTime.Now));
                }
                bool b = osm.ConfirmServerResized(s.Id);
                Assert.IsTrue(b);
                Trace.WriteLine(String.Format("server confirmed a resizing : {0}", DateTime.Now));

                // wait for activate
                s = osm.ServersProvider.WaitForServerActive(s.Id);
                Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
            }
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(ServiceConflictException))]
        public void ConfirmServerResizedTest_Confirm_Without_Resize()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            Trace.Flush();
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                Server s = osm.GetServer(ss.Id);
                if (s.Status == ServerState.VerifyResize)
                {
                    osm.RevertResizeServer(s.Id);
                    Trace.WriteLine(String.Format("server reverted a resizing : {0}", DateTime.Now));
                    // wait for activate
                    s = osm.ServersProvider.WaitForServerActive(s.Id);
                    Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
                }

                // expect ServiceConflictException
                bool b = osm.ConfirmServerResized(s.Id);
            }
        }

        [TestMethod(), Ignore]
        public void RevertResizeServerTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                Server s = osm.GetServer(ss.Id);
                //if (s.Status.Name != "SHUTOFF")
                //    os.StopServer(s.Id);

                if (s.Status != ServerState.VerifyResize)
                {
                    IEnumerable<Flavor> flavors = osm.ListFlavors();
                    Flavor flavor1g = flavors.Where<Flavor>(x => x.Name == "g-1gb").First<Flavor>();
                    Flavor flavor2g = flavors.Where<Flavor>(x => x.Name == "g-2gb").First<Flavor>();
                    osm.ResizeServer(s.Id, (s.Flavor.Id == flavor1g.Id ? flavor2g.Id : flavor1g.Id), DiskConfiguration.FromName("AUTO"));
                    Trace.WriteLine(String.Format("server requested a resizing : {0}", DateTime.Now));
                    Trace.WriteLine(String.Format("FlavorId : {0}", s.Flavor.Id));
                    // wait for request
                    s = osm.ServersProvider.WaitForServerState(s.Id, ServerState.VerifyResize, new[] { ServerState.Error, ServerState.Unknown, ServerState.Suspended });
                    Trace.WriteLine(String.Format("server status changed to {0} : {1}", s.Status, DateTime.Now));
                }

                // resize
                bool b = osm.RevertResizeServer(s.Id);
                Assert.IsTrue(b);
                Trace.WriteLine(String.Format("server reverted a resizing : {0}", DateTime.Now));

                // wait for activate
                s = osm.ServersProvider.WaitForServerActive(s.Id);
                Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
            }
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(ServiceConflictException))]
        public void ConfirmServerResizedTest_Revert_Without_Resize()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);
            if (ss != null)
            {
                Server s = osm.GetServer(ss.Id);
                if (s.Status == ServerState.VerifyResize)
                {
                    osm.RevertResizeServer(s.Id);
                    Trace.WriteLine(String.Format("server reverted a resizing : {0}", DateTime.Now));
                    // wait for activate
                    s = osm.ServersProvider.WaitForServerActive(s.Id);
                    Trace.WriteLine(String.Format("server activated : {0}", DateTime.Now));
                }

                // expect ServiceConflictException
                bool b = osm.RevertResizeServer(s.Id);
            }
        }

        [TestMethod()]
        public void GetVncConsoleTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            VncConsole v = osm.GetVncConsole(ss.Id);
            Assert.IsNotNull(v);
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void GetVncConsoleTest_VM_Invalid()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // expect ItemNotFoundException
            VncConsole v = os.GetVncConsole(InvalidId);
        }

        [TestMethod()]
        public void ListServerSecurityGroupTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            IEnumerable<ServerSecurityGroup> groups = osm.ListServerSecurityGroups(ss.Id);
            Assert.IsNotNull(groups);
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void ListServerSecurityGroupTest_InvalidId()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // expect ItemNotFoundException
            IEnumerable<ServerSecurityGroup> groups = os.ListServerSecurityGroups(InvalidId);
        }

        #endregion


        #region "os-keypairs"

        [TestMethod()]
        public void ListKeypairsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            IEnumerable<KeypairData> keypairs = os.ListKeypairs();
            Assert.IsNotNull(keypairs);
            foreach (var kp in keypairs)
            {
                Assert.IsNotNull(kp.KeyPair.Name);
                Trace.WriteLine(kp.KeyPair.Name);

                Assert.IsNotNull(kp.KeyPair.PublicKey);
                Trace.WriteLine(kp.KeyPair.PublicKey);
            }
        }

        [TestMethod()]
        public void GetKeypairTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            string keypairName = string.Format("keypair-key-{0}", TesterName);
            KeypairData[] keypairs = os.ListKeypairs().ToArray<KeypairData>();
            string name = (from b in keypairs where b.KeyPair.Name == keypairName select b.KeyPair.Name).FirstOrDefault();
            if (string.IsNullOrEmpty(name))
            {
                // add keypair
                Keypair kp = os.AddKeypair(keypairName);
                Assert.IsNotNull(kp);
                Assert.IsNotNull(kp.PublicKey);
                Assert.IsNotNull(kp.FingerPrint);
                Assert.IsNotNull(kp.UserId);
                Trace.WriteLine(String.Format("keypair added : {0}", DateTime.Now));
                Trace.WriteLine(String.Format("KeypairName : {0}", kp.Name));
            }

            Keypair k = os.GetKeypair(keypairName);
            Assert.IsNotNull(k);
            Assert.IsNotNull(k.Name);
            Trace.WriteLine(k.Name);
            Assert.IsNotNull(k.PublicKey);
            Trace.WriteLine(k.PublicKey);
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void GetKeypairTest_Invalid()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // expect ItemNotFoundException
            os.GetKeypair(InvalidItemName);
        }

        [TestMethod()]
        public void AddKeypairTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            // decide keypair name which is not duplicated.
            IEnumerable<KeypairData> keypairs = os.ListKeypairs();
            IEnumerable<string> names = keypairs.GroupBy(s => s.KeyPair.Name, (key, g) => key);
            string[] data = Enumerable.Range(1, 100).Select(i => string.Format("keypair-key-{0}_{1}", TesterName, i)).ToArray<string>();
            string keypairName = (from b in data where !names.Contains<string>(b) select b).First();

            Keypair kp = os.AddKeypair(keypairName);
            Assert.IsNotNull(kp);
            Assert.IsNotNull(kp.PublicKey);
            Assert.IsNotNull(kp.FingerPrint);
            Assert.IsNotNull(kp.UserId);
            Trace.WriteLine(String.Format("keypair added : {0}", DateTime.Now));
            Trace.WriteLine(String.Format("KeypairName : {0}", kp.Name));

            // delete keypair
            Assert.IsTrue(os.DeleteKeypair(keypairName));
            Trace.WriteLine(String.Format("keypair deleted : {0}", DateTime.Now));
        }

        [TestMethod()]
        [ExpectedException(typeof(ServiceConflictException))]
        public void AddKeypairTest_Add_Same_Name()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            string keypairName = string.Format("keypair-key-{0}", TesterName);
            KeypairData[] keypairs = os.ListKeypairs().ToArray<KeypairData>();
            string name = (from b in keypairs where b.KeyPair.Name == keypairName select b.KeyPair.Name).FirstOrDefault();
            if (string.IsNullOrEmpty(name))
            {
                // add keypair
                Keypair kp = os.AddKeypair(keypairName);
                Assert.IsNotNull(kp);
                Assert.IsNotNull(kp.PublicKey);
                Assert.IsNotNull(kp.FingerPrint);
                Assert.IsNotNull(kp.UserId);
                Trace.WriteLine(String.Format("keypair added : {0}", DateTime.Now));
                Trace.WriteLine(String.Format("KeypairName : {0}", kp.Name));
            }

            // expect ServiceConflictException
            os.AddKeypair(keypairName);
        }

        [TestMethod(), Ignore]
        public void DeleteKeypairTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            string keypairName = string.Format("keypair-key-{0}", TesterName);

            Assert.IsTrue(os.DeleteKeypair(keypairName));
            Trace.WriteLine(String.Format("keypair deleted : {0}", DateTime.Now));
        }

        [TestMethod()]
        [ExpectedException(typeof(ItemNotFoundException))]
        public void DeleteKeypairTest_Delete_Keypair_Not_Exist()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // expect ItemNotFoundException
            os.DeleteKeypair(InvalidItemName);
        }

        #endregion


        #region "images"

        [TestMethod()]
        public void ListImagesTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password, m.TenantName);
                var images = os.ListImages();
                Assert.IsNotNull(images);
                foreach (var i in images)
                {
                    Assert.IsNotNull(i.Id);
                    Assert.IsNotNull(i.Name);
                    Assert.IsNotNull(i.Links);
                    Trace.WriteLine(String.Format("imageid : {0}, name : {1}, links : {2}", i.Id, i.Name, i.Links));
                    Assert.IsNotNull(i.ExtensionData);
                }
            }
        }

        [TestMethod()]
        public void ListImagesDetailsTest()
        {
            foreach (var m in TestEnvMembers.Members)
            {
                var os = new OpenStackMember(m.UserName, m.Password, m.TenantName);
                var images = os.ListImagesDetails();
                Assert.IsNotNull(images);
                foreach (var i in images)
                {
                    Assert.IsNotNull(i.Id);
                    Assert.IsNotNull(i.Links);
                    Assert.IsNotNull(i.Name);
                    Assert.IsNotNull(i.ExtensionData);
                }
            }
        }

        [TestMethod()]
        public void GetImageTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName);
            var image = os.ListImages().First();
            var i = os.GetImage(image.Id);
            Assert.IsNotNull(i);
            Trace.WriteLine(String.Format("imageid : {0}", i.Id));
            Assert.IsTrue(image.Id == i.Id);
            Assert.IsTrue(image.Name == i.Name);
        }

        #endregion


        #region "os-volume_attachments"

        [TestMethod()]
        public void ListServerVolumesTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            IEnumerable<ServerVolume> servervolumes = osm.ListServerVolumes(ss.Id);
            Server server = osm.GetServer(ss.Id);
            Trace.WriteLine(string.Format("Server Status : {0}", server.Status.Name));
            //if (s.Status.Name != "SHUTOFF")
            //    os.StopServer(s.Id);

            Assert.IsNotNull(servervolumes);
            Trace.WriteLine(String.Format("servervolumes count : {0}", servervolumes.Count()));
            foreach (var v in servervolumes)
            {
                Assert.IsNotNull(v);
                Trace.WriteLine(String.Format("server volume id : {0}", v.Id));
            }
        }

        [TestMethod()]
        public void GetServerVolumeTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            IEnumerable<ServerVolume> servervolumes = osm.ListServerVolumes(ss.Id);
            //if (s.Status.Name != "SHUTOFF")
            //    os.StopServer(s.Id);

            Assert.IsNotNull(servervolumes);
            Trace.WriteLine(String.Format("servervolumes count : {0}", servervolumes.Count()));
            foreach (var v in servervolumes)
            {
                Trace.WriteLine(String.Format("server volume id : {0}", v.Id));
                ServerVolume volume = osm.GetServerVolume(ss.Id, v.Id);
                Assert.IsNotNull(volume);
            }
        }

        #endregion


        #region "os-interface"

        [TestMethod(), Ignore]
        public void ListInterfaceAttachmentsTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);

            IEnumerable<InterfaceAttachment> interfaces = osm.ListInterfaceAttachments(ss.Id);
            Assert.IsNotNull(interfaces);
            Trace.WriteLine(string.Format("InterfaceAttachments count : {0}", interfaces.Count()));

            if (interfaces.Count() == 0)
                osm.AddInterfaceAttachment(ss.Id, GetInterfaceAttachmentIdByTesterName());

            foreach (var i in interfaces)
            {
                Trace.WriteLine(string.Format("PortId : {0}, NetId : {1}, MacAddress : {2}, PortState : {3}", i.PortId, i.NetId, i.MacAddr, i.PortState));
            }
        }

        [TestMethod()]
        public void GetInterfaceAttachmentTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);

            IEnumerable<InterfaceAttachment> interfaces = osm.ListInterfaceAttachments(ss.Id);
            Assert.IsNotNull(interfaces);
            Trace.WriteLine(string.Format("InterfaceAttachments count : {0}", interfaces.Count()));

            if (interfaces.Count() == 0)
                osm.AddInterfaceAttachment(ss.Id, GetInterfaceAttachmentIdByTesterName());

            foreach (var _i in interfaces)
            {
                InterfaceAttachment i = osm.GetInterfaceAttachment(ss.Id, _i.PortId);
                Assert.IsNotNull(i);
                Assert.IsNotNull(i.PortId);
                Assert.IsNotNull(i.NetId);
                Assert.IsNotNull(i.MacAddr);
                Assert.IsNotNull(i.PortState);

                Trace.WriteLine(string.Format("PortId : {0}, NetId : {1}, MacAddress : {2}, PortState : {3}", i.PortId, i.NetId, i.MacAddr, i.PortState));
            }
        }

        [TestMethod(), Ignore]
        public void GetInterfaceAttachmentTest_Get_PortId_Not_Exist()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);

            InterfaceAttachment i = osm.GetInterfaceAttachment(ss.Id, InvalidId);
        }

        [TestMethod(), Ignore]
        public void AddInterfaceAttachmentTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            Server server = osm.GetServer(ss.Id);
            Trace.WriteLine(string.Format("s.Status : {0}", server.Status));
            Trace.WriteLine(string.Format("s.VMState : {0}", server.VMState));

            // detach all port
            foreach (var _i in osm.ListInterfaceAttachments(ss.Id))
                Assert.IsTrue(osm.DeleteInterfaceAttachment(ss.Id, _i.PortId));

            // add interface
            var portId = GetInterfaceAttachmentIdByTesterName();
            InterfaceAttachment i = osm.AddInterfaceAttachment(ss.Id, portId);

            try
            {
                Trace.WriteLine(string.Format("interface attachment added : {0}", DateTime.Now));
                Trace.WriteLine(string.Format("PortId : {0}, NetId : {1}, MacAddress : {2}, PortState : {3}", i.PortId, i.NetId, i.MacAddr, i.PortState));
                Assert.IsNotNull(i);
                Assert.IsNotNull(i.PortId);
                Assert.IsNotNull(i.NetId);
                Assert.IsNotNull(i.MacAddr);
                Assert.IsNotNull(i.PortState);
            }
            finally
            {
                // delete interface
                Assert.IsTrue(osm.DeleteInterfaceAttachment(ss.Id, i.PortId));
            }
        }

        [TestMethod(), Ignore]
        [ExpectedException(typeof(BadServiceRequestException))]
        public void AddInterfaceAttachmentTest_PortId_Invalid()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);

            // expect BadServiceRequestException
            InterfaceAttachment i = osm.AddInterfaceAttachment(ss.Id, InvalidId);
        }

        [TestMethod()]
        public void AddInterfaceAttachmentTest_2Times_Sequencely()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);

            if (ss != null)
            {
                Server server = osm.GetServer(ss.Id);
                Trace.WriteLine(string.Format("s.Status : {0}", server.Status));
                Trace.WriteLine(string.Format("s.VMState : {0}", server.VMState));

                string portId = GetInterfaceAttachmentIdByTesterName();

                // the first time
                InterfaceAttachment i = osm.AddInterfaceAttachment(ss.Id, portId);
                Assert.IsNotNull(i);
                Assert.IsNotNull(i.PortId);
                Assert.IsNotNull(i.NetId);
                Assert.IsNotNull(i.MacAddr);
                Assert.IsNotNull(i.PortState);
                Trace.WriteLine(string.Format("interface attachment added : {0}", DateTime.Now));
                Trace.WriteLine(string.Format("PortId : {0}, NetId : {1}, MacAddress : {2}, PortState : {3}", i.PortId, i.NetId, i.MacAddr, i.PortState));

                // the second time, expected BadServiceRequestException but ItemNotFundException occurs
                AssertCatch<BadServiceRequestException>(() => i = osm.AddInterfaceAttachment(ss.Id, portId));

                // delete interface
                Assert.IsTrue(osm.DeleteInterfaceAttachment(ss.Id, i.PortId));
            }
        }

        [TestMethod()]
        public void DeleteInterfaceAttachmentTest()
        {
            AddInterfaceAttachmentTest();
        }

        [TestMethod()]
        public void DeleteInterfaceAttachmentTest_InvalidId()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.ShutOff);

            bool b = osm.DeleteInterfaceAttachment(ss.Id, InvalidId);
            // 成功が返ります。（202 Accepted）
        }

        [TestMethod(), Ignore]
        public void DeleteInterfaceAttachmentTest_2Times_Sequencely()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);
            string attachmentId = GetInterfaceAttachmentIdByTesterName();

            bool b = osm.DeleteInterfaceAttachment(ss.Id, attachmentId);
            Assert.IsTrue(b);
            Trace.WriteLine(string.Format("interface attachment deleted : {0}", DateTime.Now));

            b = osm.DeleteInterfaceAttachment(ss.Id, attachmentId);
        }


        #endregion

        private Server WaitForVMState(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null)
        {
            refreshDelay = refreshDelay ?? TimeSpan.FromMilliseconds(2400);

            var os = new OpenStackMember(UserName, Password, TenantName);
            Server serverDetails = os.GetServer(serverId);

            Func<bool> exitCondition = () => serverDetails.TaskState == null && (expectedVMStates.Contains(serverDetails.VMState) || errorVMStates.Contains(serverDetails.VMState));
            int count = 0;
            int exitCount = exitCondition() ? 1 : 0;
            while (exitCount < 3 && count < refreshCount)
            {
                System.Threading.Thread.Sleep(refreshDelay ?? TimeSpan.FromMilliseconds(2400));
                serverDetails = os.GetServer(serverId);
                count++;
                if (exitCondition())
                    exitCount++;
                else
                    exitCount = 0;
            }

            if (errorVMStates.Contains(serverDetails.VMState))
                throw new ServerEnteredErrorStateException(serverDetails.Status);

            return serverDetails;
        }

        private string GetInterfaceAttachmentIdByTesterName(string testerName = null)
        {
            testerName = testerName ?? TesterName;

            var os = new OpenStackMember(UserName, Password, TenantName);

            IEnumerable<Network> networks = os.ListNetworks();
            Network n = networks.Where<Network>(x => x.Name == testerName).FirstOrDefault<Network>();
            if (n == null)
            {
                try
                {
                    n = os.CreateNetwork(testerName);
                    Trace.WriteLine(string.Format("network added : {0}", DateTime.Now));
                    Trace.WriteLine(string.Format("NetworkId : {0}, Name : {1}", n.Id, n.Name));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            IEnumerable<Port> ports = os.ListPorts();
            Port p = ports.Where<Port>(x => x.Name == testerName).FirstOrDefault<Port>();
            if (p == null)
            {
                try
                {
                    p = os.CreatePort(n.Id);
                    Trace.WriteLine(string.Format("port added : {0}", DateTime.Now));
                    Trace.WriteLine(string.Format("PortId : {0}, Name : {1}", p.Id, p.Name));
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return p.Id;
        }


    }
}