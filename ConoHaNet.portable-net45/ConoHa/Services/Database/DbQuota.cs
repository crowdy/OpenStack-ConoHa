#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Database
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    [JsonObject(MemberSerialization.OptIn)]
    public class DbServiceQuota : ExtensibleJsonObject
    {
        [JsonProperty("quota")]
        public int Quota { get; set; }

        [JsonProperty("total_usage")]
        public float TotalUsage { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetDbServiceQuotaResponse
    {
        [JsonProperty("quota")]
        public DbServiceQuota DbServiceQuota { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class UpdateDbServiceQuotaRequest
    {
        [JsonProperty("quota")]
        public int DatabaseQuota { get; private set; }

        public UpdateDbServiceQuotaRequest(int quota)
        {
            DatabaseQuota = quota;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member