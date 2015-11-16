#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Mails
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class MailBoxQuota : ExtensibleJsonObject
    {
        [JsonProperty("quota")]
        public int Quota { get; set; }

        [JsonProperty("total_usage")]
        public float TotalUsage { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetMailBoxQuotaResponse : ExtensibleJsonObject
    {
        [JsonProperty("quota")]
        public MailBoxQuota MailBoxQuota { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member