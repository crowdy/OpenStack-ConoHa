#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Database
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class DbGrant : ExtensibleJsonObject
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateDbGrantResponse
    {
        [JsonProperty("grant")]
        public DbGrant Grant { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListDbGrantResponse
    {
        [JsonProperty("grant")]
        public DbGrant[] Grant { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member