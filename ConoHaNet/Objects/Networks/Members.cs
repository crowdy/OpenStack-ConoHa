#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListLBMembersResponse
    {
        [JsonProperty("members", DefaultValueHandling = DefaultValueHandling.Include)]
        public LBMember[] LBMembers { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetLBMemberResponse
    {
        [JsonProperty("member", DefaultValueHandling = DefaultValueHandling.Include)]
        public LBMember LBMember { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateLBMemberRequest
    {
        [JsonProperty("member", DefaultValueHandling = DefaultValueHandling.Include)]
        public LBMember LBMember { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateLBMemberResponse
    {
        [JsonProperty("member", DefaultValueHandling = DefaultValueHandling.Include)]
        public LBMember LBMember { get; set; }
    }

    public class LBMember : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("weight", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Weight { get; set; }

        [JsonProperty("admin_state_up", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool AdminStateUp { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("pool_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PoolId { get; set; }

        [JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Address { get; set; }

        [JsonProperty("protocol_port", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ProtocolPort { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member