#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Dns
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class DnsServer : ExtensibleJsonObject
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetDnsServiceDetailsResponse
    {
        [JsonProperty("servers")]
        public DnsServer[] DnsServers { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member