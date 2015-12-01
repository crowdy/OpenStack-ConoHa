#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Glance
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class CloudImageMember : ExtensibleJsonObject
    {
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("created_at ", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("image_id", DefaultValueHandling = DefaultValueHandling.Include)]

        public string ImageId { get; set; }

        [JsonProperty("member_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string MemberId { get; set; }

        [JsonProperty("schema", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Schema { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member