#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListNetworksResponse
    {
        [JsonProperty("networks", DefaultValueHandling = DefaultValueHandling.Include)]
        public Network[] Networks { get; set; }
    }

    public class Network : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("subnets", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Subnets { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool AdminStateUp { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("routerexternal", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool RouterExternal { get; set; }

        [JsonProperty("shared", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool Shared { get; set; }

        [JsonProperty("provider:physical_network", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PhysicalNetwork { get; set; }

        [JsonProperty("provider:network_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string NetworkType { get; set; }

        [JsonProperty("provider:segmentation_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int SegmentationId { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetNetworkResponse
    {
        [JsonProperty("network", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Network Network { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateNetworkRequest
    {
        [JsonProperty("network", DefaultValueHandling = DefaultValueHandling.Include)]
        public Network Network { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateNetworkResponse
    {
        [JsonProperty("network", DefaultValueHandling = DefaultValueHandling.Include)]
        public Network Network { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member