#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Dns
{
    using Newtonsoft.Json;
    using System;


    [JsonObject(MemberSerialization.OptIn)]
    public class Zone : ExtensibleJsonObject
    {
        [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Include)]

        public string EmailAddress { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("links", DefaultValueHandling = DefaultValueHandling.Include)]
        public Links Links { get; set; }

        [JsonProperty("passwordCredentials", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("pool_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PoolId { get; set; }

        [JsonProperty("project_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ProjectId { get; set; }

        [JsonProperty("serial", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Serial { get; set; }

        [JsonProperty("ttl", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TTL { get; set; }

        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("version", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Version { get; set; }
    }

    public class Links
    {
        [JsonProperty("self", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Self { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ZoneImportREsponse
    {
        [JsonProperty("zone", DefaultValueHandling = DefaultValueHandling.Include)]
        public Zone Zone { get; set; }
    }

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member