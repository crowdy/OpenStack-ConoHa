#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Glance
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListImagesResponse
    {
        [JsonProperty("images", DefaultValueHandling = DefaultValueHandling.Include)]
        public CloudImage[] Images { get; set; }

        [JsonProperty("schema", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Schema { get; set; }

        [JsonProperty("first", DefaultValueHandling = DefaultValueHandling.Include)]
        public string First { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class UpdateImageResponse
    {
        [JsonProperty("image", DefaultValueHandling = DefaultValueHandling.Include)]
        public CloudImage Image { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CloudImage : ExtensibleJsonObject
    {
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Include)]
        public string[] Tags { get; set; }

        [JsonProperty("container_format", DefaultValueHandling = DefaultValueHandling.Include)]

        public string ContainerFormat { get; set; }

        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("disk_format", DefaultValueHandling = DefaultValueHandling.Include)]
        public string DiskFormat { get; set; }

        [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("visibility", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Visibility { get; set; }

        [JsonProperty("self", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Self { get; set; }

        [JsonProperty("min_disk", DefaultValueHandling = DefaultValueHandling.Include)]
        public int MinDisk { get; set; }

        [JsonProperty("_protected", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool _protected { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("file", DefaultValueHandling = DefaultValueHandling.Include)]
        public string File { get; set; }

        [JsonProperty("checksum", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Checkum { get; set; }

        [JsonProperty("owner", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Owner { get; set; }

        [JsonProperty("size", DefaultValueHandling = DefaultValueHandling.Include)]
        public long Size { get; set; }

        [JsonProperty("min_ram", DefaultValueHandling = DefaultValueHandling.Include)]
        public int MinRam { get; set; }

        [JsonProperty("schema", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Schema { get; set; }

        [JsonProperty("webshare", DefaultValueHandling = DefaultValueHandling.Include)]
        public string WebShare { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member