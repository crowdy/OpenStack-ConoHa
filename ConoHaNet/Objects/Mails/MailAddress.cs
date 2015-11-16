#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Mails
{
    using Newtonsoft.Json;

    public class ListMailAddressesResponse
    {
        [JsonProperty("emails")]
        public Email[] Emails { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetEmailResponse
    {
        [JsonProperty("email")]
        public Email Email { get; set; }
    }

    public class Email
    {
        [JsonProperty("email_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("total_usage")]
        public float TotalUsage { get; set; }

        [JsonProperty("virus_check")]
        public bool VirusCheckEnabled { get; set; }

        [JsonProperty("spam_filter")]
        public bool SpamFilterEnabled { get; set; }

        [JsonProperty("spam_filter_type")]
        public string SpamFilterType { get; set; }

        [JsonProperty("forwarding_copy")]
        public bool ForwardingCopyEnabled { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member