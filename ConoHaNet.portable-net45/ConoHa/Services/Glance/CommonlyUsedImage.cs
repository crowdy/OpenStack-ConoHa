#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Glance
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;


    [JsonObject(MemberSerialization.OptIn)]
    public class CommonlyUsedImageResponse
    {
        [JsonProperty("used_images", DefaultValueHandling = DefaultValueHandling.Include)]
        public CommonlyUsedImage[] CommonlyUsedImages { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CommonlyUsedImage : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("size", DefaultValueHandling = DefaultValueHandling.Include)]
        public long Size { get; set; }

        [JsonProperty("used_count", DefaultValueHandling = DefaultValueHandling.Include)]

        public int UsedCount { get; set; }

        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("min_disk", DefaultValueHandling = DefaultValueHandling.Include)]
        public int MinDisk { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member