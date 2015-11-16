#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Database
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class DatabaseServiceVersionDetailsResponse
    {
        [JsonProperty("version", DefaultValueHandling = DefaultValueHandling.Include)]
        public DatabaseServiceVersion version { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DatabaseServiceVersion : ExtensibleJsonObject
    {
        [JsonProperty("links", DefaultValueHandling = DefaultValueHandling.Include)]
        public Link[] Links { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("mediatypes", DefaultValueHandling = DefaultValueHandling.Include)]
        public MediaTypes[] MediaTypes { get; set; }

        [JsonProperty("updated", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class MediaTypes : ExtensibleJsonObject
    {
        [JsonProperty("_base", DefaultValueHandling = DefaultValueHandling.Include)]
        public string _base { get; set; }
    }

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member