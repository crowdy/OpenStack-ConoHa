#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Servers
{
    using Volumes;
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class GetVncConsoleResponse
    {
        [JsonProperty("console", DefaultValueHandling = DefaultValueHandling.Include)]
        public VncConsole Console { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class VncConsole : ExtensibleJsonObject
    {
        [JsonProperty("url", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Url { get; set; }

        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ConsoleType { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateGlanceImageFromInstanceResponse
    {
        [JsonProperty("os-volume_upload_image")]
        public VolumeUploadImage VolumeUploadImage { get; set; }
    }

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member