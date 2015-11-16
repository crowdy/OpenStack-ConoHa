#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListSubnetsResponse
    {
        [JsonProperty("subnets", DefaultValueHandling = DefaultValueHandling.Include)]
        public Subnet[] Subnets { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetSubnetResponse
    {
        [JsonProperty("subnet", DefaultValueHandling = DefaultValueHandling.Include)]
        public Subnet Subnet { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateSubnetRequest
    {
        [JsonProperty("subnet", DefaultValueHandling = DefaultValueHandling.Include)]
        public Subnet Subnet { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateSubnetResponse
    {
        [JsonProperty("subnet", DefaultValueHandling = DefaultValueHandling.Include)]
        public Subnet Subnet { get; set; }
    }


    public class Subnet : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("enable_dhcp", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool EnableDhcp { get; set; }

        [JsonProperty("network_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string NetworkId { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("dns_nameservers", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] DnsNameservers { get; set; }

        [JsonProperty("gateway_ip", DefaultValueHandling = DefaultValueHandling.Include)]
        public string GatewayIp { get; set; }

        [JsonProperty("ipv6_ra_mode", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Ipv6RAMode { get; set; }

        [JsonProperty("allocation_pools", DefaultValueHandling = DefaultValueHandling.Include)]
        public Allocation_Pools[] AllocationPools { get; set; }

        [JsonProperty("host_routes", DefaultValueHandling = DefaultValueHandling.Include)]
        public Host_Routes[] HostRoutes { get; set; }

        [JsonProperty("ip_version", DefaultValueHandling = DefaultValueHandling.Include)]
        public int IpVersion { get; set; }

        [JsonProperty("ipv6_address_mode", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Ipv6AddressMode { get; set; }

        [JsonProperty("cidr", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Cidr { get; set; }
    }

    public class Allocation_Pools : ExtensibleJsonObject
    {
        [JsonProperty("start", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Start { get; set; }

        [JsonProperty("end", DefaultValueHandling = DefaultValueHandling.Include)]
        public string End { get; set; }
    }

    public class Host_Routes : ExtensibleJsonObject
    {
        [JsonProperty("nexthop", DefaultValueHandling = DefaultValueHandling.Include)]
        public string NextHop { get; set; }

        [JsonProperty("destination", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Destination { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member