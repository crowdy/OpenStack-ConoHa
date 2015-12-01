#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.MailService
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    [JsonObject(MemberSerialization.OptIn)]
    public class EmailFilter : ExtensibleJsonObject
    {
        [JsonProperty("targets")]
        public EmailFilterDetails[] Targets { get; set; }

        [JsonProperty("total_count")]
        public int total_count { get; set; }

        [JsonProperty("current_count")]
        public int current_count { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class EmailFilterDetails : ExtensibleJsonObject
    {
        [JsonProperty("target")]
        public string TargetAddress { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member