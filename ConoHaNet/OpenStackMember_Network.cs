namespace ConoHaNet
{
    using Providers;
    using Objects.Networks;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudNetworksProvider _NetworksProvider = null;

        /// <summary>
        /// Represents the instance of NetworkProvider
        /// </summary>
        public CloudNetworksProvider NetworksProvider
        {
            get
            {
                if (_NetworksProvider == null)
                {
                    _NetworksProvider = new CloudNetworksProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudNetworksProvider created.");

                }
                return _NetworksProvider;
            }
        }


        #region "networks"

        /// <inheritdoc/>
        public IEnumerable<Network> ListNetworks()
        {
            return NetworksProvider.ListNuetronNetworks(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Network GetNetwork(string networkId)
        {
            return NetworksProvider.GetNuetronNetwork(networkId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Network CreateNetwork(string name, bool adminStateUp = true, string networkType = "vxlan", string segmentationId = null)
        {
            return NetworksProvider.CreateNuetronNetwork(name, adminStateUp, networkType, segmentationId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteNetwork(string networkId)
        {
            return NetworksProvider.DeleteNuetronNetwork(networkId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "ports"

        /// <inheritdoc/>
        public IEnumerable<Port> ListPorts()
        {
            return NetworksProvider.ListPorts(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Port GetPort(string portId)
        {
            return NetworksProvider.GetPort(portId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Port CreatePort(string networkId, FixedIp[] fixedIps = null, Dictionary<string, string> allowedAddressPairs = null, string tenantId = null, string[] securityGroups = null, string status = null)
        {
            return NetworksProvider.CreatePort(networkId, fixedIps, allowedAddressPairs, tenantId, securityGroups, status, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Port UpdatePort(string portId, bool? adminStateUp = null, string[] securityGroups = null, FixedIp[] fixedIps = null, AllowedAddressPair[] allowedAddressPairs = null)
        {
            return NetworksProvider.UpdatePort(portId, adminStateUp, securityGroups, fixedIps, allowedAddressPairs, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeletePort(string portId)
        {
            return NetworksProvider.DeletePort(portId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "subnets (VIP)"

        /// <inheritdoc/>
        public IEnumerable<Subnet> ListSubnets()
        {
            return NetworksProvider.ListSubnets(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Subnet GetSubnet(string subnetId)
        {
            return NetworksProvider.GetSubnet(subnetId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Subnet CreateSubnet(string name, string networkId, int ipVersion, string cidr)
        {
            return NetworksProvider.CreateSubnet(name, networkId, ipVersion, cidr, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Subnet UpdateSubnet(string subnetId, string name)
        {
            return NetworksProvider.UpdateSubnet(subnetId, name, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteSubnet(string subnetId)
        {
            return NetworksProvider.DeleteSubnet(subnetId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "network pool"

        /// <inheritdoc/>
        public IEnumerable<Pool> ListPools()
        {
            return NetworksProvider.ListPools(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Pool GetPool(string poolId)
        {
            return NetworksProvider.GetPool(poolId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Pool CreatePool(string name, string subnetId, string lbMethod = "ROUND_ROBIN", string protocol = "TCP")
        {
            return NetworksProvider.CreatePool(name, subnetId, lbMethod, protocol, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Pool UpdatePool(string poolId, string name = null, string lbMethod = null)
        {
            return NetworksProvider.UpdatePool(poolId, name, lbMethod, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeletePool(string poolId)
        {
            return NetworksProvider.DeletePool(poolId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "vips"

        /// <inheritdoc/>
        public IEnumerable<VIP> ListVIPs()
        {
            return NetworksProvider.ListVIPs(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VIP GetVIP(string vipId)
        {
            return NetworksProvider.GetVIP(vipId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VIP CreateVIP(string name, string protocol, string protocolPort, string poolId, string subnetId, string address, bool adminStateUp, string description = null, string sessionPpersistence = null, int? connectionLimit = null)
        {
            return NetworksProvider.CreateVIP(name, protocol, protocolPort, poolId, subnetId, address, adminStateUp, description, sessionPpersistence, connectionLimit, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VIP UpdateVIP()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool DeleteVIP(string vipId)
        {
            return NetworksProvider.DeleteVIP(vipId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "members (LB)"

        /// <inheritdoc/>
        public IEnumerable<LBMember> ListLBMembers(string subnetId = null, string poolId = null, string protocolPort = null)
        {
            return NetworksProvider.ListLBMembers(subnetId, poolId, protocolPort, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public LBMember GetLBMember(string memberId)
        {
            return NetworksProvider.GetLBMember(memberId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public LBMember CreateLBMember(string poolId, string address, string protocolPort, int weight = 1)
        {
            return NetworksProvider.CreateLBMember(poolId, address, protocolPort, weight, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public LBMember UpdateLBMember(string memberId, int weight)
        {
            return NetworksProvider.UpdateLBMember(memberId, weight, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteLBMember(string memberId)
        {
            return NetworksProvider.DeleteLBMember(memberId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "health_monitors"

        /// <inheritdoc/>
        public IEnumerable<HealthMonitor> ListHealthMonitors()
        {
            return NetworksProvider.ListHealthMonitors(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public HealthMonitor GetHealthMonitor(string monitorId)
        {
            return NetworksProvider.GetHealthMonitor(monitorId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public HealthMonitor CreateHealthMonitor(string monitorType, int delay, int maxRetries, string urlPath = null, string expectedCodes = null)
        {
            return NetworksProvider.CreateHealthMonitor(monitorType, delay, maxRetries, urlPath, expectedCodes, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public HealthMonitor UpdateHealthMonitor(string monitorId, int delay, int maxRetries, string urlPath)
        {
            return NetworksProvider.UpdateHealthMonitor(monitorId, delay, maxRetries, urlPath, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteHealthMonitor(string monitorId)
        {
            return NetworksProvider.DeleteHealthMonitor(monitorId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool AssociateHealthMonitor(string monitorId, string poolId)
        {
            return NetworksProvider.AssociateHealthMonitor(monitorId, poolId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DisassociateHealthMonitor(string monitorId, string poolId)
        {
            return NetworksProvider.DisassociateHealthMonitor(monitorId, poolId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "security-groups"

        /// <inheritdoc/>
        public IEnumerable<NetworkSecurityGroup> ListNetworkSecurityGroups()
        {
            return NetworksProvider.ListSecurityGroups(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroup GetNetworkSecurityGroup(string groupId)
        {
            return NetworksProvider.GetSecurityGroup(groupId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroup CreateNetworkSecurityGroup(string name, string description)
        {
            return NetworksProvider.CreatSecurityGroup(name, description, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteNetworkSecurityGroup(string networkSecurityGroupId)
        {
            return NetworksProvider.DeleteSecurityGroup(networkSecurityGroupId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "security-group-rules"

        /// <inheritdoc/>
        public IEnumerable<NetworkSecurityGroupRule> ListNetworkSecurityGroupRules()
        {
            return NetworksProvider.ListSecurityGroupRules(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroupRule GetNetworkSecurityGroupRule(string ruleId)
        {
            return NetworksProvider.GetSecurityGroupRule(ruleId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroupRule CreateNetworkSecurityGroupRule(string securityGroupId, string direction, string etherType, string portRangeMin = null, string portRangeMax = null, string protocol = null, string remoteGroupId = null, string remoteIpPrefix = null)
        {
            return NetworksProvider.CreatSecurityGroupRule(securityGroupId, direction, etherType, portRangeMin, portRangeMax, protocol, remoteGroupId, remoteIpPrefix, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteNetworkSecurityGroupRule(string networkSecurityRuleId)
        {
            return NetworksProvider.DeleteSecurityRule(networkSecurityRuleId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "ConoHa"

        /// <inheritdoc/>
        public Subnet AddSubnetForAdditionalIp(int bitmask)
        {
            return NetworksProvider.AddSubnetForAdditionalIp(bitmask, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Subnet AddSubnetForLb()
        {
            return NetworksProvider.AddSubnetForLb(this.DefaultRegion, this.Identity);
        }

        #endregion

    }
}
