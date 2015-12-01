#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Database
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    [JsonObject(MemberSerialization.OptIn)]
    public class DbUser : ExtensibleJsonObject
    {
        [JsonProperty("databases")]
        public Database[] Databases { get; set; }

        [JsonProperty("user_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetDbUserResponse
    {
        [JsonProperty("user")]
        public DbUser User { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListDbUsersResponse
    {
        [JsonProperty("users")]
        public DbUser[] Users { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateDbUserRequest
    {
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; private set; }

        [JsonProperty("password")]
        public string Password { get; private set; }

        [JsonProperty("hostname")]
        public string HostName { get; private set; }

        [JsonProperty("memo")]
        public string Memo { get; private set; }

        public CreateDbUserRequest(string serviceId, string userName, string password, string hostname, string memo = null)
        {
            ServiceId = serviceId;
            UserName = userName;
            Password = password;
            HostName = hostname;
            Memo = !string.IsNullOrEmpty(memo) ? memo : null;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateDbUserRequest
    {
        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; private set; }

        [JsonProperty("memo", NullValueHandling = NullValueHandling.Ignore)]
        public string Memo { get; private set; }

        public UpdateDbUserRequest(string password = null, string memo = null)
        {
            Password = password;
            Memo = memo;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member