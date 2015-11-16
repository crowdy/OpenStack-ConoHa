#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Dns
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class Domain : ExtensibleJsonObject
    {
        [JsonProperty("id", Required = Required.Always)]

        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ttl")]
        public int TTL { get; set; }

        [JsonProperty("serial")]
        public int Serial { get; set; }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("gslb")]
        public int GSLB { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListDomiansResponse
    {
        [JsonProperty("domains")]
        public Domain[] Domains { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateDomainRequest
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; private set; }

        [JsonProperty("ttl", NullValueHandling = NullValueHandling.Ignore)]
        public int? TTL { get; private set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; private set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; private set; }

        [JsonProperty("gslb", NullValueHandling = NullValueHandling.Ignore)]
        public int? GSLB { get; set; }

        public UpdateDomainRequest(string name = null, string email = null, int? ttl = null, string description = null, int? gslb = null)
        {
            Name = name;
            EmailAddress = email;
            TTL = ttl;
            Description = description;
            GSLB = gslb;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member