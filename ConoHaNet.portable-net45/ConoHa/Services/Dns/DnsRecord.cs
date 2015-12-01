#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Service.Dns
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class DnsRecord : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Type { get; set; }

        [JsonProperty("priority", DefaultValueHandling = DefaultValueHandling.Include)]
        public int? Priority { get; set; }

        [JsonProperty("ttl", DefaultValueHandling = DefaultValueHandling.Include)]
        public int TTL { get; set; }

        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("data", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Data { get; set; }

        [JsonProperty("domain_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string DomainId { get; set; }

        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Description { get; set; }

        [JsonProperty("gslb_region", DefaultValueHandling = DefaultValueHandling.Include)]
        public string GSLBRegion { get; set; }

        [JsonProperty("gslb_weight", DefaultValueHandling = DefaultValueHandling.Include)]
        public int? GSLBWeight { get; set; }

        [JsonProperty("gslb_check", DefaultValueHandling = DefaultValueHandling.Include)]
        public int? GSLBCheck { get; set; }
    }

    public class ListDnsRecordsResponse
    {
        [JsonProperty("records", DefaultValueHandling = DefaultValueHandling.Include)]
        public DnsRecord[] DnsRecords { get; set; }

        [JsonProperty("total_count", DefaultValueHandling = DefaultValueHandling.Include)]
        public int TotalCount { get; set; }

        [JsonProperty("current_count", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateDnsRecordRequest
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public int? Priority { get; set; }

        [JsonProperty("ttl", NullValueHandling = NullValueHandling.Ignore)]
        public int? TTL { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("gslb_region", NullValueHandling = NullValueHandling.Ignore)]
        public string GSLBRegion { get; set; }

        [JsonProperty("gslb_weight", NullValueHandling = NullValueHandling.Ignore)]
        public int? GSLBWeight { get; set; }

        [JsonProperty("gslb_check", NullValueHandling = NullValueHandling.Ignore)]
        public int? GSLBCheck { get; set; }

        public CreateDnsRecordRequest(string name = null, string type = null, int? priority = null, int? ttl = null, string data = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null)
        {
            Name = name;
            Type = type;
            Priority = priority;
            TTL = ttl;
            Data = data;
            Description = description;
            GSLBRegion = gslbRegion;
            GSLBWeight = gslbWeight;
            GSLBCheck = gslbCheck;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member