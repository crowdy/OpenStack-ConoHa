#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListHealthMonitorsResponse
    {
        [JsonProperty("health_monitors", DefaultValueHandling = DefaultValueHandling.Include)]
        public HealthMonitor[] HealthMonitors { get; set; }
    }

    public class GetHealthMonitorResponse
    {
        [JsonProperty("health_monitor", DefaultValueHandling = DefaultValueHandling.Include)]
        public HealthMonitor HealthMonitor { get; set; }
    }

    public class CreateHealthMonitorRequest
    {
        [JsonProperty("health_monitor", DefaultValueHandling = DefaultValueHandling.Include)]
        public HealthMonitor HealthMonitor { get; set; }
    }

    public class CreateHealthMonitorResponse
    {
        [JsonProperty("health_monitor", DefaultValueHandling = DefaultValueHandling.Include)]
        public HealthMonitor HealthMonitor { get; set; }
    }

    public class UpdateHealthMonitorRequest
    {
        [JsonProperty("health_monitor", DefaultValueHandling = DefaultValueHandling.Include)]
        public HealthMonitorUpdate HealthMonitor { get; set; }
    }

    public class HealthMonitorUpdate : ExtensibleJsonObject
    {
        [JsonProperty("delay", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Delay { get; set; }

        [JsonProperty("max_retries", DefaultValueHandling = DefaultValueHandling.Include)]
        public int MaxRetries { get; set; }

        [JsonProperty("url_path", DefaultValueHandling = DefaultValueHandling.Include)]
        public string UrlPath { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool AdminStateUp { get; set; }
    }

    public class HealthMonitor : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool AdminStateUp { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("delay", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Delay { get; set; }

        [JsonProperty("max_retries", DefaultValueHandling = DefaultValueHandling.Include)]
        public int MaxRetries { get; set; }

        [JsonProperty("timeout", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Timeout { get; set; }

        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Type { get; set; }

        [JsonProperty("expected_codes", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ExpectedCodes { get; set; }

        [JsonProperty("http_method", DefaultValueHandling = DefaultValueHandling.Include)]
        public string HttpMethod { get; set; }

        [JsonProperty("url_path", DefaultValueHandling = DefaultValueHandling.Include)]
        public string UrlPath { get; set; }

        [JsonProperty("pools", DefaultValueHandling = DefaultValueHandling.Include)]
        public AssociatedPool[] AssociatedPools { get; set; }
    }

    public class AssociatedPool : ExtensibleJsonObject
    {
        [JsonProperty("pool_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PoolId { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("status_description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string StatusDescription { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member