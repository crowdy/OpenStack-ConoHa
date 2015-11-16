#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet
{
    using Objects;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class EmailForwarding : ExtensibleJsonObject
    {
        [JsonProperty("forwarding_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("email_id")]
        public string EmailId { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetEmailForwardingResponse
    {
        [JsonProperty("forwarding")]
        public EmailForwarding Forwarding { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListEmailForwardingsResponse : ExtensibleJsonObject
    {
        [JsonProperty("forwarding")]
        public EmailForwarding[] Forwardings { get; set; }

        [JsonProperty("total_count")]
        public int total_count { get; set; }

        [JsonProperty("current_count")]
        public int current_count { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class EmailForwardingCopyActionRequest
    {
        [JsonProperty("forwarding_copy")]
        public EmailForwardingCopyActionRequestDetails Details { get; private set; }

        public EmailForwardingCopyActionRequest(string status)
        {
            Details = new EmailForwardingCopyActionRequestDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class EmailForwardingCopyActionRequestDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public EmailForwardingCopyActionRequestDetails(string status)
            {
                Status = status;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member