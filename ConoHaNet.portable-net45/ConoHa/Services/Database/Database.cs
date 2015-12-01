#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Database
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    [JsonObject(MemberSerialization.OptIn)]

    public class Database : ExtensibleJsonObject
    {
        [JsonProperty("database_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("internal_hostname")]
        public string InternalHostName { get; set; }

        [JsonProperty("external_hostname")]
        public string ExternalHostName { get; set; }

        [JsonProperty("db_name")]
        public string DbName { get; set; }

        [JsonProperty("db_size")]
        public float DbSize { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("charset")]
        public string Charset { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetDatabaseResponse
    {
        [JsonProperty("database")]
        public Database Database { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListDatabasesResponse
    {
        [JsonProperty("databases")]
        public Database[] Databases { get; set; }

        [JsonProperty("total_count")]
        public string TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateDatabaseRequest
    {
        [JsonProperty("service_id")]
        public string ServiceId { get; private set; }

        [JsonProperty("db_name")]
        public string DbName { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("charset")]
        public string Charset { get; private set; }

        [JsonProperty("memo")]
        public string Memo { get; private set; }

        public CreateDatabaseRequest(string serviceId, string dbName, string type, string charset, string memo = null)
        {
            ServiceId = serviceId;
            DbName = dbName;
            Type = type;
            Charset = Charset;
            Memo = string.IsNullOrEmpty(memo) ? null : memo;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member