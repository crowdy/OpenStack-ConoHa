#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListPoolsResponse
    {
        [JsonProperty("pools", DefaultValueHandling = DefaultValueHandling.Include)]
        public Pool[] Pools { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreatePoolRequest
    {
        [JsonProperty("pool", DefaultValueHandling = DefaultValueHandling.Include)]
        public Pool Pool { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreatePoolResponse
    {
        [JsonProperty("pool", DefaultValueHandling = DefaultValueHandling.Include)]
        public Pool Pool { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetPoolResponse
    {
        [JsonProperty("pool", DefaultValueHandling = DefaultValueHandling.Include)]
        public Pool Pool { get; set; }
    }

    public class Pool : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("lb_method", DefaultValueHandling = DefaultValueHandling.Include)]
        public string LbMethod { get; set; }

        [JsonProperty("protocol", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Protocol { get; set; }

        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Description { get; set; }

        [JsonProperty("health_monitors", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] HealthMonitors { get; set; }

        [JsonProperty("members", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Members { get; set; }

        [JsonProperty("status_description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string StatusDescription { get; set; }

        [JsonProperty("vip_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string VipId { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool? AdminStateUp { get; set; }

        [JsonProperty("subnet_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string SubnetId { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("health_monitors_status", DefaultValueHandling = DefaultValueHandling.Include)]
        public HealthMonitorsStatus[] HealthMonitors_status { get; set; }

        [JsonProperty("provider", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Provider { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class HealthMonitorsStatus
    {
        [JsonProperty("monitor_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string MonitorId { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("status_description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string StatusDescription { get; set; }
    }

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member