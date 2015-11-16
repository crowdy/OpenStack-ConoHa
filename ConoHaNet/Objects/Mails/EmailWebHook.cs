#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Mails
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class EmailWebHook : ExtensibleJsonObject
    {
        [JsonProperty("webhook_url")]
        public string Url { get; set; }

        [JsonProperty("webhook_keyword")]
        public string Keyword { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetEmailWebHookResponse
    {
        [JsonProperty("webhook")]
        public EmailWebHook EmailWebHook { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListEmailWebHooksResponse
    {
        [JsonProperty("webhooks")]
        public EmailWebHook[] EmailWebHooks { get; set; }

        [JsonProperty("total_count")]
        public int total_count { get; set; }

        [JsonProperty("current_count")]
        public int current_count { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member