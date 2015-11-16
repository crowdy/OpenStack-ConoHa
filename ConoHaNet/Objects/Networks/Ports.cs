#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListPortsResponse
    {
        [JsonProperty("ports", DefaultValueHandling = DefaultValueHandling.Include)]
        public Port[] Ports { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Port : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("bindinghost_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string BindinghostId { get; set; }

        [JsonProperty("allowed_address_pairs", DefaultValueHandling = DefaultValueHandling.Include)]
        public AllowedAddressPair[] AllowedAddressPairs { get; set; }

        [JsonProperty("extra_dhcp_opts", DefaultValueHandling = DefaultValueHandling.Include)]
        public object[] ExtraDhcpOpts { get; set; }

        [JsonProperty("device_owner", DefaultValueHandling = DefaultValueHandling.Include)]
        public string DeviceOwner { get; set; }

        [JsonProperty("bindingprofile", DefaultValueHandling = DefaultValueHandling.Include)]
        public object[] BindingProfile { get; set; }

        [JsonProperty("fixed_ips", DefaultValueHandling = DefaultValueHandling.Include)]
        public FixedIp[] FixedIPs { get; set; }

        [JsonProperty("security_groups", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] SecurityGroups { get; set; }

        [JsonProperty("device_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string DeviceId { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool? AdminStateUp { get; set; }

        [JsonProperty("network_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string NetworkId { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("bindingvif_details", DefaultValueHandling = DefaultValueHandling.Include)]
        public BindingVIFDetails BindingVIFDetails { get; set; }

        [JsonProperty("bindingvnic_type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string BindingVINCType { get; set; }

        [JsonProperty("bindingvif_type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string BindingVIFType { get; set; }

        [JsonProperty("mac_address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string MacAddress { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BindingVIFDetails
    {
        [JsonProperty("port_filter", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool PortFilter { get; set; }

        [JsonProperty("ovs_hybrid_plug", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool OvsHybridPlug { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class AllowedAddressPair : ExtensibleJsonObject
    {
        [JsonProperty("ip_address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string IpAddress { get; set; }

        [JsonProperty("mac_address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string MacAddress { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class FixedIp : ExtensibleJsonObject
    {
        [JsonProperty("subnet_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string SubnetId { get; set; }

        [JsonProperty("ip_address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string IpAddress { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreatePortRequest
    {
        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Include)]
        public NewPort Port { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class NewPort : ExtensibleJsonObject
    {
        [JsonProperty("network_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string NetworkId { get; set; }

        [JsonProperty("fixed_ips", DefaultValueHandling = DefaultValueHandling.Include)]
        public FixedIp[] FixedIPs { get; set; }

        [JsonProperty("allowed_address_pairs", DefaultValueHandling = DefaultValueHandling.Include)]
        public Dictionary<string, string> AllowedAddressPairs { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("security_groups", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] SecurityGroups { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }


        public NewPort(string networkId, FixedIp[] fixedIps = null, Dictionary<string, string> allowedAddressPairs = null, string tenantId = null, string[] securityGroups = null, string status = null)
        {
            this.NetworkId = networkId;
            this.FixedIPs = fixedIps;
            this.AllowedAddressPairs = allowedAddressPairs;
            this.TenantId = tenantId;
            this.SecurityGroups = securityGroups;
            this.Status = status;
        }
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class UpdatePortRequest
    {
        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Include)]
        public Port Port { get; set; }

        public UpdatePortRequest(string portId, bool? adminStateUp = null, string[] securityGroups = null, FixedIp[] fixedIps = null, AllowedAddressPair[] allowedAddressPairs = null)
        {
            this.Port = new Port()
            {
                AdminStateUp = adminStateUp,
                SecurityGroups = securityGroups,
                FixedIPs = fixedIps,
                AllowedAddressPairs = allowedAddressPairs
            };
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetPortResponse
    {
        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Include)]
        public Port Port { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreatePortResponse
    {
        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Include)]
        public Port Port { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member