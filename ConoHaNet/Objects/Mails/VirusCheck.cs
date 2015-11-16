namespace ConoHaNet.Objects.Mails
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateVirusCheckStatusRequest
    {
        [JsonProperty("virus")]
        public UpdateVirusCheckStatusRequestDetails Details { get; private set; }

        public UpdateVirusCheckStatusRequest(string status)
        {
            Details = new UpdateVirusCheckStatusRequestDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class UpdateVirusCheckStatusRequestDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public UpdateVirusCheckStatusRequestDetails(string status)
            {
                Status = status;
            }
        }
    }
}
