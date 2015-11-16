#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Images
{
    using Newtonsoft.Json;
    using System;

    public class CloudImageTaskResponse : ExtensibleJsonObject
    {
        [JsonProperty("schema", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Schema { get; set; }

        [JsonProperty("tasks", DefaultValueHandling = DefaultValueHandling.Include)]
        public CloudImageTask[] Tasks { get; set; }

        [JsonProperty("first", DefaultValueHandling = DefaultValueHandling.Include)]
        public string First { get; set; }
    }

    public class CloudImageTask : ExtensibleJsonObject
    {
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("created_at", DefaultValueHandling = DefaultValueHandling.Include)]

        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("expires_at", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("owner", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Owner { get; set; }

        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Type { get; set; }

        [JsonProperty("self", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Self { get; set; }

        [JsonProperty("schema", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Schema { get; set; }
    }


    public class CloudImageTaskDetail : CloudImageTask
    {
        [JsonProperty("result", DefaultValueHandling = DefaultValueHandling.Include)]
        public CloudImageTaskResult Result { get; set; }

        [JsonProperty("input", DefaultValueHandling = DefaultValueHandling.Include)]
        public CloudImageTaskInput Input { get; set; }

        [JsonProperty("message", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Message { get; set; }
    }

    public class CloudImageTaskResult
    {
        [JsonProperty("image_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ImageId { get; set; }
    }

    public class CloudImageTaskInput
    {
        [JsonProperty("image_properties", DefaultValueHandling = DefaultValueHandling.Include)]
        public Image_Properties Image_Properties { get; set; }

        [JsonProperty("import_from_format", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Import_From_Format { get; set; }

        [JsonProperty("import_from", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Import_From { get; set; }
    }

    public class Image_Properties
    {
        [JsonProperty("os_type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Os_Type { get; set; }
    }

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member