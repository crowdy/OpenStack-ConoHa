#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Database
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class DbService : ExtensibleJsonObject
    {
        [JsonProperty("service_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("service_name")]
        public string Name { get; set; }

        [JsonProperty("create_date")]
        public DateTimeOffset CreateDate { get; set; }

        [JsonProperty("quota")]
        public int Quota { get; set; }

        [JsonProperty("total_usage")]
        public float TotalUsage { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("backup")]
        public string Backup { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetDbServiceResponse
    {
        [JsonProperty("service")]
        public DbService Service { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListDbServicesResponse
    {
        [JsonProperty("services")]
        public DbService[] Services { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class SetDbServiceStatusRequest
    {
        [JsonProperty("service")]
        public SetDbServiceStatusDetails Details { get; private set; }

        public SetDbServiceStatusRequest(string status)
        {
            Details = new SetDbServiceStatusDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SetDbServiceStatusDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public SetDbServiceStatusDetails(string status)
            {
                Status = status;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member