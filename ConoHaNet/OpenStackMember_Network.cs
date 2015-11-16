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
        public IEnumerable<Network> ListNetworks(string region = null)
        {
            return NetworksProvider.ListNuetronNetworks(region, Identity);
        }

        /// <inheritdoc/>
        public Network GetNetwork(string networkId, string region = null)
        {
            return NetworksProvider.GetNuetronNetwork(networkId, region, Identity);
        }

        /// <inheritdoc/>
        public Network CreateNetwork(string name, bool adminStateUp = true, string networkType = "vxlan", string segmentationId = null, string region = null)
        {
            return NetworksProvider.CreateNuetronNetwork(name, adminStateUp, networkType, segmentationId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteNetwork(string networkId, string region = null)
        {
            return NetworksProvider.DeleteNuetronNetwork(networkId, region, Identity);
        }

        #endregion


        #region "ports"

        /// <inheritdoc/>
        public IEnumerable<Port> ListPorts(string region = null)
        {
            return NetworksProvider.ListPorts(region, Identity);
        }

        /// <inheritdoc/>
        public Port GetPort(string portId, string region = null)
        {
            return NetworksProvider.GetPort(portId, region, Identity);
        }

        /// <inheritdoc/>
        public Port CreatePort(string networkId, FixedIp[] fixedIps = null, Dictionary<string, string> allowedAddressPairs = null, string tenantId = null, string[] securityGroups = null, string status = null, string region = null)
        {
            return NetworksProvider.CreatePort(networkId, fixedIps, allowedAddressPairs, tenantId, securityGroups, status, region, Identity);
        }

        /// <inheritdoc/>
        public Port UpdatePort(string portId, bool? adminStateUp = null, string[] securityGroups = null, FixedIp[] fixedIps = null, AllowedAddressPair[] allowedAddressPairs = null, string region = null)
        {
            return NetworksProvider.UpdatePort(portId, adminStateUp, securityGroups, fixedIps, allowedAddressPairs, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeletePort(string portId, string region = null)
        {
            return NetworksProvider.DeletePort(portId, region, Identity);
        }

        #endregion


        #region "subnets (VIP)"

        /// <inheritdoc/>
        public IEnumerable<Subnet> ListSubnets(string region = null)
        {
            return NetworksProvider.ListSubnets(region, Identity);
        }

        /// <inheritdoc/>
        public Subnet GetSubnet(string subnetId, string region = null)
        {
            return NetworksProvider.GetSubnet(subnetId, region, Identity);
        }

        /// <inheritdoc/>
        public Subnet CreateSubnet(string name, string networkId, int ipVersion, string cidr, string region = null)
        {
            return NetworksProvider.CreateSubnet(name, networkId, ipVersion, cidr, region, Identity);
        }

        /// <inheritdoc/>
        public Subnet UpdateSubnet(string subnetId, string name, string region = null)
        {
            return NetworksProvider.UpdateSubnet(subnetId, name, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteSubnet(string subnetId, string region = null)
        {
            return NetworksProvider.DeleteSubnet(subnetId, region, Identity);
        }

        #endregion


        #region "network pool"

        /// <inheritdoc/>
        public IEnumerable<Pool> ListPools(string region = null)
        {
            return NetworksProvider.ListPools(region, Identity);
        }

        /// <inheritdoc/>
        public Pool GetPool(string poolId, string region = null)
        {
            return NetworksProvider.GetPool(poolId, region, Identity);
        }

        /// <inheritdoc/>
        public Pool CreatePool(string name, string subnetId, string lbMethod = "ROUND_ROBIN", string protocol = "TCP", string region = null)
        {
            return NetworksProvider.CreatePool(name, subnetId, lbMethod, protocol, region, Identity);
        }

        /// <inheritdoc/>
        public Pool UpdatePool(string poolId, string name = null, string lbMethod = null, string region = null)
        {
            return NetworksProvider.UpdatePool(poolId, name, lbMethod, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeletePool(string poolId, string region = null)
        {
            return NetworksProvider.DeletePool(poolId, region, Identity);
        }

        #endregion


        #region "vips"

        /// <inheritdoc/>
        public IEnumerable<VIP> ListVIPs(string region = null)
        {
            return NetworksProvider.ListVIPs(region, Identity);
        }

        /// <inheritdoc/>
        public VIP GetVIP(string vipId, string region = null)
        {
            return NetworksProvider.GetVIP(vipId, region, Identity);
        }

        /// <inheritdoc/>
        public VIP CreateVIP(string name, string protocol, string protocolPort, string poolId, string subnetId, string address, bool adminStateUp, string description = null, string sessionPpersistence = null, int? connectionLimit = null, string region = null)
        {
            return NetworksProvider.CreateVIP(name, protocol, protocolPort, poolId, subnetId, address, adminStateUp, description, sessionPpersistence, connectionLimit, region, Identity);
        }

        /// <inheritdoc/>
        public VIP UpdateVIP(string region = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool DeleteVIP(string vipId, string region = null)
        {
            return NetworksProvider.DeleteVIP(vipId, region, Identity);
        }

        #endregion


        #region "members (LB)"

        /// <inheritdoc/>
        public IEnumerable<LBMember> ListLBMembers(string subnetId = null, string poolId = null, string protocolPort = null, string region = null)
        {
            return NetworksProvider.ListLBMembers(subnetId, poolId, protocolPort, region, Identity);
        }

        /// <inheritdoc/>
        public LBMember GetLBMember(string memberId, string region = null)
        {
            return NetworksProvider.GetLBMember(memberId, region, Identity);
        }

        /// <inheritdoc/>
        public LBMember CreateLBMember(string poolId, string address, string protocolPort, int weight = 1, string region = null)
        {
            return NetworksProvider.CreateLBMember(poolId, address, protocolPort, weight, region, Identity);
        }

        /// <inheritdoc/>
        public LBMember UpdateLBMember(string memberId, int weight, string region = null)
        {
            return NetworksProvider.UpdateLBMember(memberId, weight, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteLBMember(string memberId, string region = null)
        {
            return NetworksProvider.DeleteLBMember(memberId, region, Identity);
        }

        #endregion


        #region "health_monitors"

        /// <inheritdoc/>
        public IEnumerable<HealthMonitor> ListHealthMonitors(string region = null)
        {
            return NetworksProvider.ListHealthMonitors(region, Identity);
        }

        /// <inheritdoc/>
        public HealthMonitor GetHealthMonitor(string monitorId, string region = null)
        {
            return NetworksProvider.GetHealthMonitor(monitorId, region, Identity);
        }

        /// <inheritdoc/>
        public HealthMonitor CreateHealthMonitor(string monitorType, int delay, int maxRetries, string urlPath = null, string expectedCodes = null, string region = null)
        {
            return NetworksProvider.CreateHealthMonitor(monitorType, delay, maxRetries, urlPath, expectedCodes, region, Identity);
        }

        /// <inheritdoc/>
        public HealthMonitor UpdateHealthMonitor(string monitorId, int delay, int maxRetries, string urlPath, string region = null)
        {
            return NetworksProvider.UpdateHealthMonitor(monitorId, delay, maxRetries, urlPath, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteHealthMonitor(string monitorId, string region = null)
        {
            return NetworksProvider.DeleteHealthMonitor(monitorId, region, Identity);
        }

        /// <inheritdoc/>
        public bool AssociateHealthMonitor(string monitorId, string poolId, string region = null)
        {
            return NetworksProvider.AssociateHealthMonitor(monitorId, poolId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DisassociateHealthMonitor(string monitorId, string poolId, string region = null)
        {
            return NetworksProvider.DisassociateHealthMonitor(monitorId, poolId, region, Identity);
        }

        #endregion


        #region "security-groups"

        /// <inheritdoc/>
        public IEnumerable<NetworkSecurityGroup> ListNetworkSecurityGroups(string region = null)
        {
            return NetworksProvider.ListSecurityGroups(region, Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroup GetNetworkSecurityGroup(string groupId, string region = null)
        {
            return NetworksProvider.GetSecurityGroup(groupId, region, Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroup CreateNetworkSecurityGroup(string name, string description, string region = null)
        {
            return NetworksProvider.CreatSecurityGroup(name, description, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteNetworkSecurityGroup(string networkSecurityGroupId, string region = null)
        {
            return NetworksProvider.DeleteSecurityGroup(networkSecurityGroupId, region, Identity);
        }

        #endregion


        #region "security-group-rules"

        /// <inheritdoc/>
        public IEnumerable<NetworkSecurityGroupRule> ListNetworkSecurityGroupRules(string region = null)
        {
            return NetworksProvider.ListSecurityGroupRules(region, Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroupRule GetNetworkSecurityGroupRule(string ruleId, string region = null)
        {
            return NetworksProvider.GetSecurityGroupRule(ruleId, region, Identity);
        }

        /// <inheritdoc/>
        public NetworkSecurityGroupRule CreateNetworkSecurityGroupRule(string securityGroupId, string direction, string etherType, string portRangeMin = null, string portRangeMax = null, string protocol = null, string remoteGroupId = null, string remoteIpPrefix = null, string region = null)
        {
            return NetworksProvider.CreatSecurityGroupRule(securityGroupId, direction, etherType, portRangeMin, portRangeMax, protocol, remoteGroupId, remoteIpPrefix, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteNetworkSecurityGroupRule(string networkSecurityRuleId, string region = null)
        {
            return NetworksProvider.DeleteSecurityRule(networkSecurityRuleId, region, Identity);
        }

        #endregion


        #region "ConoHa"

        /// <inheritdoc/>
        public Subnet AddSubnetForAdditionalIp(int bitmask, string region = null)
        {
            return NetworksProvider.AddSubnetForAdditionalIp(bitmask, region, Identity);
        }

        /// <inheritdoc/>
        public Subnet AddSubnetForLb(string region = null)
        {
            return NetworksProvider.AddSubnetForLb(region, Identity);
        }

        #endregion

    }
}
