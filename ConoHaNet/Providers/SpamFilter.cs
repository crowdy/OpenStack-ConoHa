#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Providers
{
    using Objects;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class SpamFilter : ExtensibleJsonObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class SpamFilterActionResponse
    {
        [JsonProperty("spams")]
        public SpamFilter SpamFilter { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class SpamFilterActionRequest
    {
        [JsonProperty("spam")]
        public SpamFilterActionRequestDetails Details { get; private set; }

        public SpamFilterActionRequest(string status, string type)
        {
            Details = new SpamFilterActionRequestDetails(status, type);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SpamFilterActionRequestDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            [JsonProperty("type")]
            public string Type { get; private set; }

            public SpamFilterActionRequestDetails(string status, string type)
            {
                Status = status;
                Type = type;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member