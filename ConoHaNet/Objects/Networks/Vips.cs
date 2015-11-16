#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListVIPsResponse
    {
        [JsonProperty("vips", DefaultValueHandling = DefaultValueHandling.Include)]
        public VIP[] Vips { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetVIPResponse
    {
        [JsonProperty("vip", DefaultValueHandling = DefaultValueHandling.Include)]
        public VIPDetails Vip { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateVIPRequest
    {
        [JsonProperty("vip", DefaultValueHandling = DefaultValueHandling.Include)]
        public VIPDetails Vip { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class UpdateVIPRequest
    {
        [JsonProperty("vip", DefaultValueHandling = DefaultValueHandling.Include)]
        public VIP Vip { get; set; }
    }

    public class VIP : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("protocol", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Protocol { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool AdminStateUp { get; set; }

        [JsonProperty("subnet_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string SubnetId { get; set; }

        [JsonProperty("pool_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PoolId { get; set; }

        [JsonProperty("protocol_port", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ProtocolPort { get; set; }
    }



    public class VIPDetails : VIP
    {
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Description { get; set; }

        [JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Address { get; set; }

        [JsonProperty("status_description", DefaultValueHandling = DefaultValueHandling.Include)]
        public object StatusDescription { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("connection_limit", DefaultValueHandling = DefaultValueHandling.Include)]
        public int? ConnectionLimit { get; set; }

        [JsonProperty("session_persistence", DefaultValueHandling = DefaultValueHandling.Include)]
        public object SessionPersistence { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member