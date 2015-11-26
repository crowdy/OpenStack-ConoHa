namespace ConoHaNet_Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Diagnostics;
    using ConoHaNet.Objects.Networks;
    using ConoHaNet;
    using ConoHaNet.Objects.Servers;

    [TestClass()]
    public class OpenstackMember_NetWorkTests : OpenstackMemberTestBase
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

        public Network GetNetworkByName(string name, ref OpenStackMember os)
        {
            var networks = (os ?? new OpenStackMember(UserName, Password, TenantName, TenantId))
                .ListNetworks().Where<Network>(n => n.Name == name);
            if (networks != null && networks.Count() > 0)
                return networks.First<Network>();
            else
                throw new ArgumentException("no network found");
        }

        public Subnet GetSubnetByName(string name, ref IOpenStackMember os)
        {
            var subnets = (os ?? new OpenStackMember(UserName, Password, TenantName, TenantId))
                .ListSubnets().Where<Subnet>(n => n.Name == name);
            if (subnets != null && subnets.Count() > 0)
                return subnets.First<Subnet>();
            else
                throw new ArgumentException("no subnet found");
        }

        public Pool GetPoolByName(string name, ref OpenStackMember os)
        {
            var pools = (os ?? new OpenStackMember(UserName, Password, TenantName, TenantId))
                .ListPools().Where<Pool>(n => n.Name == name);
            if (pools != null && pools.Count() > 0)
                return pools.First<Pool>();
            else
                throw new ArgumentException("no pool found");

        }

        public string GetSubnetIdByRegion(string region = null)
        {
            if (region == null || region == "tyo1")
                return "20f429bb-472c-403d-b9ec-e637475f1602";

            throw new NotImplementedException("other region's global subnetid is not defined yet");
        }


        [TestMethod()]
        public void GetNetworkApiEndPointTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            Assert.IsNotNull(os.NetworksProvider);
        }

        #region "networks"

        [TestMethod()]
        public void ListNetworksTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var networks = os.ListNetworks();
            Assert.IsNotNull(networks);
            foreach (var n in networks)
            {
                Trace.WriteLine(string.Format("networkid : {0}, name : {1}", n.Id, n.Name));
            }
        }

        [TestMethod()]
        public void GetNetworkTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var networks = os.ListNetworks();
            Assert.IsNotNull(networks);
            foreach (var n in networks)
            {
                var network = os.GetNetwork(n.Id);
                Assert.IsNotNull(network);
            }
        }

        [TestMethod()]
        public void CreateNetworkTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            string name = GetTesterNameByEnv();
            bool adminStateUp = true;
            string networkType = "vxlan";
            string segmentationId = null;

            var n = os.CreateNetwork(name, adminStateUp, networkType, segmentationId);
            Assert.IsNotNull(n);

            os.DeleteNetwork(n.Id);
        }

        [TestMethod()]
        public void DeleteNetworkTest()
        {
            CreateNetworkTest();
        }

        [TestMethod(), Ignore]
        public void DeleteNetworkTest_havingSubnet()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region "ports"

        [TestMethod()]
        public void ListPortsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var ports = os.ListPorts();
            Assert.IsNotNull(ports);
            foreach (var p in ports)
            {
                Trace.WriteLine(string.Format("portId : {0}", p.Id));
                Trace.WriteLine(string.Format("portName : {0}", p.Name));
                Trace.WriteLine(string.Format("portMacAddress : {0}", p.MacAddress));
                Trace.WriteLine(string.Format("portnetworkId : {0}", p.NetworkId));
                Trace.WriteLine(string.Format("portTenantId : {0}", p.TenantId));
                Trace.WriteLine(string.Format("portStatus : {0}", p.Status));
                Trace.WriteLine(string.Format("portSecurityGroups : {0}", string.Join(",", p.SecurityGroups)));
            }
        }

        [TestMethod()]
        public void GetPortTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var ports = os.ListPorts();
            Assert.IsNotNull(ports);
            foreach (var p in ports)
            {
                var port = os.GetPort(p.Id);
                Assert.IsNotNull(port);
                Trace.WriteLine(string.Format("portId : {0}", port.Id));
                Trace.WriteLine(string.Format("portName : {0}", port.Name));
                Trace.WriteLine(string.Format("portMacAddress : {0}", port.MacAddress));
                Trace.WriteLine(string.Format("portnetworkId : {0}", port.NetworkId));
                Trace.WriteLine(string.Format("portTenantId : {0}", port.TenantId));
                Trace.WriteLine(string.Format("portStatus : {0}", port.Status));
                Trace.WriteLine(string.Format("portSecurityGroups : {0}", string.Join(",", port.SecurityGroups)));
            }
        }

        [TestMethod()]
        public void CreatePortTest()
        {

            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            // string tenantId = os.IdentityProvider.GetToken(os.Identity).Tenant.Id;

            // create network
            //string network_name = GetTesterNameByEnv();
            // string network_name = @"\u65e5\u672c\u8a9e"; // "日本語" = "\u65e5\u672c\u8a9e"
            string network_name = "日本語"; // "日本語" = "\u65e5\u672c\u8a9e"

            bool adminStateUp = true;
            string networkType = "vxlan";
            string segmentationId = null;
            var n = os.CreateNetwork(network_name, adminStateUp, networkType, segmentationId);
            Assert.IsNotNull(n);

            Trace.WriteLine(string.Format("network id : {0}", n.Id));
            Trace.WriteLine(string.Format("network name : {0}", n.Name));

            try
            {
                // create port
                //string port_name = GetTesterNameByEnv();
                //string port_name = @"\u65e5\u672c\u8a9e"; // "日本語" = "\u65e5\u672c\u8a9e"
                string networkId = n.Id;
                var port = os.CreatePort(networkId, tenantId: TenantId);
                Assert.IsNotNull(port);
                Trace.WriteLine(string.Format("portId : {0}", port.Id));
                Trace.WriteLine(string.Format("portName : {0}", port.Name));
                Trace.WriteLine(string.Format("portMacAddress : {0}", port.MacAddress));
                Trace.WriteLine(string.Format("portnetworkId : {0}", port.NetworkId));
                Trace.WriteLine(string.Format("portTenantId : {0}", port.TenantId));
                Trace.WriteLine(string.Format("portStatus : {0}", port.Status));
                Trace.WriteLine(string.Format("portSecurityGroups : {0}", string.Join(",", port.SecurityGroups)));

                Assert.IsTrue(os.DeletePort(port.Id));

            }
            finally
            {
                Assert.IsTrue(os.DeleteNetwork(n.Id));
            }

        }

        [TestMethod(), Ignore]
        public void UpdatePortTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            // string tenantId = os.IdentityProvider.GetToken(os.Identity).Tenant.Id;

            // create network
            string network_name = GetTesterNameByEnv();
            bool adminStateUp = true;
            string networkType = "vxlan";
            string segmentationId = null;
            var n = os.CreateNetwork(network_name, adminStateUp, networkType, segmentationId);
            Assert.IsNotNull(n);

            try
            {
                // create port
                string port_name = GetTesterNameByEnv();
                string networkId = n.Id;
                var port = os.CreatePort(networkId, tenantId: TenantId);
                Assert.IsNotNull(port);

                Trace.WriteLine(string.Format("portStatus : {0}", port.Status));
                Assert.AreEqual(port.Status, "DOWN");

                try
                {
                    // update port
                    string newName = "new-name";
                    port = os.UpdatePort(port.Id, adminStateUp);
                    Assert.IsNotNull(port);
                    Assert.AreEqual(port.Name, newName);

                    newName = "日本語";
                    port = os.UpdatePort(port.Id, adminStateUp);
                    //Assert.IsNotNull(port);
                    //Assert.AreEqual(port.Name, newName);

                    Trace.WriteLine(string.Format("portId : {0}", port.Id));
                    Trace.WriteLine(string.Format("portName : {0}", port.Name));
                    Trace.WriteLine(string.Format("portMacAddress : {0}", port.MacAddress));
                    Trace.WriteLine(string.Format("portnetworkId : {0}", port.NetworkId));
                    Trace.WriteLine(string.Format("portTenantId : {0}", port.TenantId));
                    Trace.WriteLine(string.Format("portStatus : {0}", port.Status));
                    Trace.WriteLine(string.Format("portSecurityGroups : {0}", string.Join(",", port.SecurityGroups)));

                }
                finally
                {
                    Assert.IsTrue(os.DeletePort(port.Id));
                }
            }
            finally
            {
                Assert.IsTrue(os.DeleteNetwork(n.Id));
            }
        }

        [TestMethod()]
        public void DeletePortTest()
        {
            CreatePortTest();
        }

        #endregion


        #region "subnets (VIP)"

        [TestMethod()]
        public void ListSubnetsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var subnets = os.ListSubnets();
            Assert.IsNotNull(subnets);
            foreach (var s in subnets)
            {
                Trace.WriteLine("===============================================");
                Trace.WriteLine(string.Format("subnet Id : {0}", s.Id));
                Trace.WriteLine(string.Format("subnet Name : {0}", s.Name));
                Trace.WriteLine(string.Format("subnet TenantId : {0}", s.TenantId));
                Trace.WriteLine(string.Format("subnet NetworkId : {0}", s.NetworkId));
                Trace.WriteLine(string.Format("subnet Cidr : {0}", s.Cidr));
                Trace.WriteLine(string.Format("subnet GatewayIp : {0}", s.GatewayIp));
            }
        }

        [TestMethod()]
        public void GetSubnetTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var subnets = os.ListSubnets();
            Assert.IsNotNull(subnets);
            foreach (var s in subnets)
            {
                var subnet = os.GetSubnet(s.Id);
                Assert.IsNotNull(subnet);
            }
        }

        [TestMethod()]
        public void CreateSubnetTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // create network
            string network_name = GetTesterNameByEnv();
            bool adminStateUp = true;
            string networkType = "vxlan";
            string segmentationId = null;
            var n = os.CreateNetwork(network_name, adminStateUp, networkType, segmentationId);
            Assert.IsNotNull(n);

            try
            {
                // create subnet
                string subnet_name = GetTesterNameByEnv();
                int ipVersion = 4;
                string cidr = "192.168.2.0/24";

                var s = os.CreateSubnet(subnet_name, n.Id, ipVersion, cidr);
                Assert.IsNotNull(s);
                Trace.WriteLine(string.Format("subnet Id : {0}", s.Id));
                Trace.WriteLine(string.Format("subnet Name : {0}", s.Name));
                Trace.WriteLine(string.Format("subnet TenantId : {0}", s.TenantId));
                Trace.WriteLine(string.Format("subnet NetworkId : {0}", s.NetworkId));
                Trace.WriteLine(string.Format("subnet Cidr : {0}", s.Cidr));
                Trace.WriteLine(string.Format("subnet GatewayIp : {0}", s.GatewayIp));
                Trace.WriteLine(string.Format("subnet IpVersion : {0}", s.IpVersion));

                Assert.IsTrue(os.DeleteSubnet(s.Id));
            }
            finally
            {
                Assert.IsTrue(os.DeleteNetwork(n.Id));
            }
        }

        [TestMethod(), Ignore]
        public void UpdateSubnetTest()
        {

            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // create network
            string network_name = GetTesterNameByEnv();
            bool adminStateUp = true;
            string networkType = "vxlan";
            string segmentationId = null;
            var n = os.CreateNetwork(network_name, adminStateUp, networkType, segmentationId);
            Assert.IsNotNull(n);

            try
            {
                string subnet_name = GetTesterNameByEnv();
                int ipVersion = 4;
                string cidr = "192.168.2.0/24";

                // create subnet
                var s = os.CreateSubnet(subnet_name, n.Id, ipVersion, cidr);
                Assert.IsNotNull(s);
                Trace.WriteLine(string.Format("subnet IpVersion : {0}", s.IpVersion));

                try
                {
                    // update subnet
                    var subnet = os.UpdateSubnet(s.Id, "new value");
                    Assert.IsNotNull(subnet);
                    Trace.WriteLine(string.Format("subnet name : {0}", subnet.Name));

                    // this fails
                    //subnet = os.UpdateSubnet(s.Id, "日本語");
                    //subnet = os.UpdateSubnet(s.Id, "new value\\\"");

                }
                finally
                {
                    Assert.IsTrue(os.DeleteSubnet(s.Id));
                }
            }
            finally
            {
                Assert.IsTrue(os.DeleteNetwork(n.Id));
            }
        }

        [TestMethod(), Ignore]
        public void DeleteSubnetTest()
        {
            CreateSubnetTest();
        }

        #endregion


        #region "pools"

        [TestMethod()]
        public void ListPoolsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var pools = os.ListPools();
            Assert.IsNotNull(pools);
            Trace.WriteLine(string.Format("pools Count : {0}", pools.Count()));
            foreach (Pool pool in pools)
            {
                Assert.IsNotNull(pool);
                Trace.WriteLine("-------------------");
                Trace.WriteLine(string.Format("pool Name : {0}", pool.Name));
                Trace.WriteLine(string.Format("pool Id : {0}", pool.Id));
                Trace.WriteLine(string.Format("pool Protocol : {0}", pool.Protocol));
                Trace.WriteLine(string.Format("pool TenantId : {0}", pool.TenantId));
                Trace.WriteLine(string.Format("pool Description : {0}", pool.Description));
            }
        }

        [TestMethod()]
        public void GetPoolTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var pools = os.ListPools();
            Assert.IsNotNull(pools);
            Trace.WriteLine(string.Format("pools Count : {0}", pools.Count()));
            foreach (var p in pools)
            {
                var pool = os.GetPool(p.Id);
                Assert.IsNotNull(pool);
                Trace.WriteLine("-------------------");
                Trace.WriteLine(string.Format("pool Name : {0}", pool.Name));
                Trace.WriteLine(string.Format("pool Id : {0}", pool.Id));
                Trace.WriteLine(string.Format("pool Protocol : {0}", pool.Protocol));
                Trace.WriteLine(string.Format("pool TenantId : {0}", pool.TenantId));
                Trace.WriteLine(string.Format("pool Description : {0}", pool.Description));
            }
        }

        [TestMethod(), Ignore]
        public void CreatePoolTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // create pool
            string pool_name = GetTesterNameByEnv();
            string TokyoLBaas_subnetId = GetSubnetIdByRegion(region: null);
            string[] lbMethods = { "ROUND_ROBIN", "LEAST_CONNECTIONS" };
            string protocol = "TCP";

            foreach (var lbMethod in lbMethods)
            {
                var p = osm.CreatePool(pool_name, TokyoLBaas_subnetId, lbMethod, protocol);
                try
                {
                    Assert.IsNotNull(p);
                    Trace.WriteLine(string.Format("pool Name : {0}", p.Name));
                    Trace.WriteLine(string.Format("pool Id : {0}", p.Id));
                    Trace.WriteLine(string.Format("pool Protocol : {0}", p.Protocol));
                    Trace.WriteLine(string.Format("pool Description : {0}", p.Description));
                    Trace.WriteLine(string.Format("pool LbMethod : {0}", p.LbMethod));
                    Trace.WriteLine(string.Format("pool HealthMonitors : {0}", string.Join(",", p.HealthMonitors)));
                    Trace.WriteLine(string.Format("pool Members : {0}", string.Join(",", p.Members)));
                }
                finally
                {
                    Assert.IsTrue(osm.DeletePool(p.Id));
                }
            }
        }

        [TestMethod(), Ignore]
        public void CreatePoolTest_ShouldFail_OverQuata()
        {
            // by 10

            throw new NotImplementedException();
        }

        [TestMethod(), Ignore]
        public void UpdatePoolTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            // string tenantId = os.IdentityProvider.GetToken(os.Identity).Tenant.Id;

            // create pool
            string pool_name = GetTesterNameByEnv();
            string TokyoLBaas_subnetId = GetSubnetIdByRegion(region: null);
            string[] lbMethods = { "ROUND_ROBIN", "LEAST_CONNECTIONS" };
            string protocol = "TCP";

            foreach (var lbMethod in lbMethods)
            {
                var p = os.CreatePool(pool_name, TokyoLBaas_subnetId, lbMethod, protocol);
                Trace.WriteLine(string.Format("pool Status : {0}", p.Status));
                System.Threading.Thread.Sleep(1000 * 10);
                Trace.WriteLine(string.Format("pool Status : {0}", p.Status));
                try
                {
                    foreach (var newLbMethod in lbMethods)
                    {
                        os.UpdatePool(p.Id, "newName", newLbMethod);

                        // not tested yet.
                        //os.UpdatePool(p.Id, "日本語", lbMethod);
                        //os.UpdatePool(p.Id, "//", lbMethod);
                    }
                }
                finally
                {
                    Assert.IsTrue(os.DeletePool(p.Id));
                }
            }
        }

        [TestMethod(), Ignore]
        public void DeletePoolTest()
        {
            CreatePoolTest();
        }

        #endregion


        #region "vips"
        [TestMethod()]
        public void ListVIPsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var vips = os.ListVIPs();
            Assert.IsNotNull(vips);
            Trace.WriteLine(string.Format("vips count : {0}", vips.Count()));

            foreach (var v in vips)
            {
                Trace.WriteLine(string.Format("vip Name : {0}", v.Name));
                Trace.WriteLine(string.Format("vip Id : {0}", v.Id));
                Trace.WriteLine(string.Format("vip PoolId : {0}", v.PoolId));
                Trace.WriteLine(string.Format("vip SubnetId : {0}", v.SubnetId));
                Trace.WriteLine(string.Format("vip Protocol : {0}", v.Protocol));
                Trace.WriteLine(string.Format("vip ProtocolPort : {0}", v.ProtocolPort));
            }
        }

        [TestMethod()]
        public void GetVIPTest()
        {

            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var vips = os.ListVIPs();
            Assert.IsNotNull(vips);
            foreach (var v in vips)
            {
                var vip = os.GetVIP(v.Id);
                Assert.IsNotNull(vip);

                Trace.WriteLine(string.Format("vip Name : {0}", vip.Name));
                Trace.WriteLine(string.Format("vip Id : {0}", vip.Id));
                Trace.WriteLine(string.Format("vip PoolId : {0}", vip.PoolId));
                Trace.WriteLine(string.Format("vip SubnetId : {0}", vip.SubnetId));
                Trace.WriteLine(string.Format("vip Protocol : {0}", vip.Protocol));
                Trace.WriteLine(string.Format("vip ProtocolPort : {0}", vip.ProtocolPort));

            }
        }

        [TestMethod(), Ignore]
        public void CreateVIPTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // Get Pool
            Pool pool;
            try { pool = GetPoolByName(TesterName, ref os); }
            catch (ArgumentException pae)
            {
                if (pae.Message.Equals("no pool found"))
                {
                    // Get Subnet
                    Subnet subnet;
                    try
                    {
                        // subnet = GetSubnetByName(TesterName, ref os);
                        subnet = os.GetSubnet("20f429bb-472c-403d-b9ec-e637475f1602"); // fixed tyo1　subnet
                    }
                    catch (ArgumentException sae)
                    {
                        if (sae.Message.Equals("no subnet found"))
                        {
                            // Get Network
                            Network network;
                            try { network = GetNetworkByName(TesterName, ref os); }
                            catch (ArgumentException nae)
                            {
                                if (nae.Message.Equals("no network found"))
                                {
                                    // var tenantId = os.IdentityProvider.GetToken(os.Identity).Tenant.Id;
                                    network = os.CreateNetwork(TesterName);
                                    Assert.IsNotNull(network);
                                }
                                else
                                    throw;
                            }
                            subnet = os.CreateSubnet(TesterName, network.Id, ipVersion: 4, cidr: "192.168.2.0/24");
                            Assert.IsNotNull(subnet);

                        }
                        else
                            throw;
                    }

                    var subnetId = GetSubnetIdByRegion(region: null);

                    pool = os.CreatePool(TesterName, TenantId, subnetId);
                    Assert.IsNotNull(pool);
                }
                else
                    throw;
            }

            string name = GetTesterNameByEnv(); ;
            string protocol = "TCP"; // TCP Only
            string protocolPort = "80"; // A valid value is from 0 to 65535.
            string poolId = GetPoolByName(TesterName, ref os).Id;
            string TokyoLBaas_subnetId = GetSubnetIdByRegion(region: null);
            string address = "157.7.81.200"; // cidr of (subnetid=20f429bb-472c-403d-b9ec-e637475f1602) is "157.7.81.128/27"
            bool adminStateUp = true;
            string description = null;
            string sessionPpersistence = null;
            int? connectionLimit = null;

            var vip = os.CreateVIP(name, protocol, protocolPort, poolId, TokyoLBaas_subnetId, address, adminStateUp, description, sessionPpersistence, connectionLimit);
            Assert.IsNotNull(vip);
        }

        [TestMethod(), Ignore]
        public VIP UpdateVIPTest(string region = null)
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            throw new NotImplementedException();
        }

        [TestMethod(), Ignore]
        public void DeleteVIPTest()
        {
            string vipId = string.Empty;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            bool b = os.DeleteVIP(vipId);
            Assert.IsTrue(b);
        }

        #endregion


        #region "members (LB)"

        [TestMethod()]
        public void ListLBMembersTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var members = os.ListLBMembers();
            Assert.IsNotNull(members);
        }

        [TestMethod()]
        public void GetLBMemberTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var members = os.ListLBMembers();
            Assert.IsNotNull(members);
            foreach (var m in members)
            {
                var member = os.GetLBMember(m.Id);
                Assert.IsNotNull(member);
                Trace.WriteLine(string.Format("member.Id : {0}", member.Id));
                Trace.WriteLine(string.Format("member.PoolId : {0}", member.PoolId));
                Trace.WriteLine(string.Format("member.Status : {0}", member.Status));
                Trace.WriteLine(string.Format("member.ProtocolPort : {0}", member.ProtocolPort));
                Trace.WriteLine(string.Format("member.Address : {0}", member.Address));
            }
        }

        [TestMethod(), Ignore]
        public void CreateLBMemberTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // get server
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);

            // get ipv4
            ServerAddresses addresses = ss.GetDetails().ListAddresses();
            Assert.IsNotNull(addresses["default_global"]);
            Assert.IsTrue(addresses["default_global"].Count() > 0);

            var ip = addresses["default_global"].
                Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .First<System.Net.IPAddress>();

            // create pool
            string pool_name = GetTesterNameByEnv();
            string TokyoLBaas_subnetId = GetSubnetIdByRegion(region: null);
            int weight = 1;
            string[] lbMethods = { "ROUND_ROBIN", "LEAST_CONNECTIONS" };
            string protocol = "TCP";

            foreach (var lbMethod in lbMethods)
            {
                var p = osm.CreatePool(pool_name, TokyoLBaas_subnetId, lbMethod, protocol);
                try
                {
                    string address = ip.ToString(); // ip address virtual machine is having. ?
                    string protocolPort = "80"; // a valid value is from 0 to 65535.
                    var member = osm.CreateLBMember(p.Id, address, protocolPort, weight);
                    Assert.IsNotNull(member);
                }
                finally
                {
                    // Assert.IsTrue(os.DeletePool(p.Id));
                }
            }
        }

        [TestMethod(), Ignore]
        public void UpdateLBMemberTest()
        {
            var osm = new OpenStackMember(UserName, Password, TenantName, TenantId);

            // get server
            SimpleServer ss = osm.ListServers().FirstOrDefault(s => s.GetDetails().Status == ServerState.Active);

            // get ipv4, sometimes server does not have network interface.
            ServerAddresses addresses = ss.GetDetails().ListAddresses();
            Assert.IsNotNull(addresses["default_global"]);
            Assert.IsTrue(addresses["default_global"].Count() > 0);

            var ip = addresses["default_global"].
                Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .First<System.Net.IPAddress>();

            // create pool
            string pool_name = GetTesterNameByEnv();
            string TokyoLBaas_subnetId = GetSubnetIdByRegion(region: null);
            int weight = 1;
            string[] lbMethods = { "ROUND_ROBIN", "LEAST_CONNECTIONS" };
            string protocol = "TCP";

            foreach (var lbMethod in lbMethods)
            {
                // create pool
                var p = osm.CreatePool(pool_name, TokyoLBaas_subnetId, lbMethod, protocol);
                try
                {
                    // create member
                    string address = ip.ToString(); // ip address virtual machine is having. ?
                    string protocolPort = "80"; // a valid value is from 0 to 65535.
                    var member = osm.CreateLBMember(p.Id, address, protocolPort, weight);
                    Assert.IsNotNull(member);

                    try
                    {
                        // update member(toggle adminStateUp)
                        var updatedMember = osm.UpdateLBMember(member.Id, (weight == 1 ? 0 : 1));
                        Assert.IsNotNull(updatedMember);
                        Assert.IsTrue(updatedMember.Weight != (weight == 1 ? 0 : 1));
                    }
                    finally
                    {
                        // delete member
                        Assert.IsTrue(osm.DeleteLBMember(member.Id));
                    }
                }
                finally
                {
                    // Assert.IsTrue(os.DeletePool(p.Id));
                }
            }
        }

        [TestMethod(), Ignore]
        public void DeleteLBMemberTest()
        {
            // hard to write code briefly. but deleted surely.

            string memberId = string.Empty;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            bool b = os.DeleteLBMember(memberId);
            Assert.IsTrue(b);
        }

        #endregion


        #region "health_monitors"

        [TestMethod()]
        public void ListHealthMonitorsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var monitors = os.ListHealthMonitors();
            Assert.IsNotNull(monitors);
            foreach (var m in monitors)
            {
                Assert.IsNotNull(m);
                Trace.WriteLine(string.Format("monitor.Id : {0}", m.Id));
                Trace.WriteLine(string.Format("monitor.MaxRetries : {0}", m.MaxRetries));
                Trace.WriteLine(string.Format("monitor.HttpMethod : {0}", m.HttpMethod));
                Trace.WriteLine(string.Format("monitor.Timeout : {0}", m.Timeout));
                Trace.WriteLine(string.Format("monitor.Type : {0}", m.Type));
                Trace.WriteLine(string.Format("monitor.UrlPath : {0}", m.UrlPath));
            }
        }

        [TestMethod()]
        public void GetHealthMonitorTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var monitors = os.ListHealthMonitors();
            Assert.IsNotNull(monitors);
            foreach (var m in monitors)
            {
                var monitor = os.GetHealthMonitor(m.Id);
                Assert.IsNotNull(monitor);
                Trace.WriteLine(string.Format("monitor.Id : {0}", monitor.Id));
                Trace.WriteLine(string.Format("monitor.MaxRetries : {0}", monitor.MaxRetries));
                Trace.WriteLine(string.Format("monitor.HttpMethod : {0}", monitor.HttpMethod));
                Trace.WriteLine(string.Format("monitor.Timeout : {0}", monitor.Timeout));
                Trace.WriteLine(string.Format("monitor.Type : {0}", monitor.Type));
                Trace.WriteLine(string.Format("monitor.UrlPath : {0}", monitor.UrlPath));
            }
        }

        [TestMethod()]
        public void CreateHealthMonitorTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            string monitorType = "TCP"; // PING or TCP or HTTP
            int delay = 10; // 5-10
            int maxRetries = 1; // 1-5
            string urlPath = null;
            string expectedCodes = null;

            var monitor = os.CreateHealthMonitor(monitorType, delay, maxRetries, urlPath, expectedCodes);
            Assert.IsNotNull(monitor);

            Assert.IsTrue(os.DeleteHealthMonitor(monitor.Id));
        }

        [TestMethod(), Ignore]
        public void UpdateHealthMonitorTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);

            string monitorType = "TCP"; // PING or TCP or HTTP
            int delay = 5; // 5-10
            int maxRetries = 1; // 1-5
            string urlPath = null;
            string expectedCodes = null;

            // create
            var monitor = os.CreateHealthMonitor(monitorType, delay, maxRetries, urlPath, expectedCodes);

            try
            {
                // update
                int newDelay = 6;
                int newMaxRetries = 3;
                string newUrlPath = "http://www.google.com";
                monitor = os.UpdateHealthMonitor(monitor.Id, newDelay, newMaxRetries, newUrlPath);

                Assert.IsNotNull(monitor);
            }
            finally
            {
                Assert.IsTrue(os.DeleteHealthMonitor(monitor.Id));
            }
        }

        #endregion


        #region "security-groups"

        [TestMethod()]
        public void ListNetworkSecurityGroupsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var groups = os.ListNetworkSecurityGroups();
            Assert.IsNotNull(groups);
        }

        [TestMethod(), Ignore]
        public void GetNetworkSecurityGroupTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var groups = os.ListNetworkSecurityGroups();
            Assert.IsNotNull(groups);
            foreach (var g in groups)
            {
                var group = os.GetNetworkSecurityGroup(g.Id);
                Assert.IsNotNull(group);
            }
        }

        [TestMethod()]
        public void CreateNetworkSecurityGroupTest()
        {
            string name = "test_security_group";
            string description = string.Empty;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var group = os.CreateNetworkSecurityGroup(name, description);
            Assert.IsNotNull(group);
        }

        [TestMethod(), Ignore]
        public void DeleteNetworkSecurityGroupTest()
        {
            string name = "test_security_group";
            string description = null;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var group = os.CreateNetworkSecurityGroup(name, description);
            Assert.IsNotNull(group);

            bool b = os.DeleteNetworkSecurityGroup(group.Id);
            Assert.IsTrue(b);
        }

        #endregion


        #region "security-group-rules"

        [TestMethod()]
        public void ListNetworkSecurityRulesTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var rules = os.ListNetworkSecurityGroupRules();
            Assert.IsNotNull(rules);
        }

        [TestMethod(), Ignore]
        public void GetNetworkSecurityRuleTest()
        {
            string name = TesterName;
            string description = null;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var group = os.CreateNetworkSecurityGroup(name, description);
            Assert.IsNotNull(group);
            try
            {
                string direction = "ingress"; // "ingress" or "egress"
                string etherType = "IPv4"; // "IPv4" or "IPv6"
                string portRangeMin = null;
                string portRangeMax = null;
                string protocol = null;
                string remoteGroupId = null;
                string remoteIpPrefix = null;

                var rule = os.CreateNetworkSecurityGroupRule(group.Id, direction, etherType, portRangeMin, portRangeMax, protocol, remoteGroupId, remoteIpPrefix);
                Assert.IsNotNull(rule);

                rule = os.GetNetworkSecurityGroupRule(rule.Id);
                Trace.WriteLine(string.Format("rule id : {0}", rule.Id));
                Trace.WriteLine(string.Format("rule EtherType : {0}", rule.EtherType));
                Trace.WriteLine(string.Format("rule PortRangeMin : {0}", rule.PortRangeMin));
                Trace.WriteLine(string.Format("rule PortRangeMax : {0}", rule.PortRangeMax));
                Trace.WriteLine(string.Format("rule Protocol : {0}", rule.Protocol));
                Trace.WriteLine(string.Format("rule RemoteIpPrefix : {0}", rule.RemoteIpPrefix));
                Trace.WriteLine(string.Format("rule SecurityGroupId : {0}", rule.SecurityGroupId));
                Trace.WriteLine(string.Format("rule RemoteGroupId : {0}", rule.RemoteGroupId));

                Assert.IsTrue(os.DeleteNetworkSecurityGroupRule(rule.Id));
            }
            finally
            {
                Assert.IsTrue(os.DeleteNetworkSecurityGroup(group.Id));
            }
        }

        [TestMethod(), Ignore]
        public void CreateNetworkSecurityRuleTest()
        {

            string name = TesterName;
            string description = null;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var group = os.CreateNetworkSecurityGroup(name, description);
            Assert.IsNotNull(group);
            try
            {
                string direction = "ingress"; // "ingress" or "egress"
                string etherType = "IPv4"; // "IPv4" or "IPv6"
                string portRangeMin = null;
                string portRangeMax = null;
                string protocol = null;
                string remoteGroupId = null;
                string remoteIpPrefix = null;

                var rule = os.CreateNetworkSecurityGroupRule(group.Id, direction, etherType, portRangeMin, portRangeMax, protocol, remoteGroupId, remoteIpPrefix);
                Assert.IsNotNull(rule);

                Assert.IsTrue(os.DeleteNetworkSecurityGroupRule(rule.Id));
            }
            finally
            {
                Assert.IsTrue(os.DeleteNetworkSecurityGroup(group.Id));
            }
        }

        [TestMethod(), Ignore]
        public void DeleteNetworkSecurityRuleTest()
        {
            CreateNetworkSecurityRuleTest();
        }

        #endregion


        #region "GMO"

        [TestMethod()]
        public void AddSubnetForAdditionalIpTest()
        {
            int bitmask = 28;
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var subnet = os.AddSubnetForAdditionalIp(bitmask);
            Assert.IsNotNull(subnet);
        }

        [TestMethod()]
        public void AddSubnetForLbTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName, TenantId);
            var subnet = os.AddSubnetForLb();
            Assert.IsNotNull(subnet);
        }

        #endregion

    }
}