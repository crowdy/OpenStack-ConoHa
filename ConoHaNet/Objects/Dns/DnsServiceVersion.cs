#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Dns
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class DnsServiceVersion : ExtensibleJsonObject
    {
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("updated", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("links", DefaultValueHandling = DefaultValueHandling.Include)]
        public Link[] Links { get; set; }
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class DnsServiceVersionResponse
    {
        [JsonProperty("versions", DefaultValueHandling = DefaultValueHandling.Include)]

        public Version[] versions { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DnsServiceVersionDetailsResponse
    {
        [JsonProperty("versions", DefaultValueHandling = DefaultValueHandling.Include)]
        public Version[] versions { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member