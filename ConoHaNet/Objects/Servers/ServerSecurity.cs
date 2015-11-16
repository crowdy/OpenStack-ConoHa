#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Servers
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListServerSecurityGroupsResponse
    {
        [JsonProperty("security_groups", DefaultValueHandling = DefaultValueHandling.Include)]
        public ServerSecurityGroup[] SecurityGroups { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ServerSecurityGroup : ExtensibleJsonObject
    {
        [JsonProperty("rules", DefaultValueHandling = DefaultValueHandling.Include)]
        public ServerSecurityRule[] Rules { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Description { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ServerSecurityRule : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("from_port", DefaultValueHandling = DefaultValueHandling.Include)]
        public object FromPort { get; set; }

        [JsonProperty("group", DefaultValueHandling = DefaultValueHandling.Include)]
        public Group Group { get; set; }

        [JsonProperty("ip_protocol", DefaultValueHandling = DefaultValueHandling.Include)]
        public object IpProtocol { get; set; }

        [JsonProperty("to_port", DefaultValueHandling = DefaultValueHandling.Include)]
        public object ToPort { get; set; }

        [JsonProperty("parent_group_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string ParentGroupId { get; set; }

        [JsonProperty("ip_range", DefaultValueHandling = DefaultValueHandling.Include)]
        public object IpRange { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Group : ExtensibleJsonObject
    {
        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }
    }

}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member