#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.MailService
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    [JsonObject(MemberSerialization.OptIn)]
    public class MailDomain : ExtensibleJsonObject
    {
        [JsonProperty("domain_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("domain_name")]
        public string Name { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListMailDomainsResponse : ExtensibleJsonObject
    {
        [JsonProperty("domains")]
        public MailDomain[] MailDomains { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetMailDomainResponse : ExtensibleJsonObject
    {
        [JsonProperty("domain")]
        public MailDomain MailDomain { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class SetMailDomainDedicatedIpStatusRequest
    {
        [JsonProperty("dedicatedip")]
        public SetMailDomainDedicatedIpStatusRequestDetails Details { get; private set; }

        public SetMailDomainDedicatedIpStatusRequest(string status)
        {
            Details = new SetMailDomainDedicatedIpStatusRequestDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SetMailDomainDedicatedIpStatusRequestDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public SetMailDomainDedicatedIpStatusRequestDetails(string status)
            {
                Status = status;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member