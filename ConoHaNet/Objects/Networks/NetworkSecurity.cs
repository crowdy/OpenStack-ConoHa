#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class ListNetworkSecurityGroupsResponse
    {
        [JsonProperty("security_groups", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroup[] NetworkSecurityGroups { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetNetworkSecurityGroupResponse
    {
        [JsonProperty("security_group", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroup NetworkSecurityGroup { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateNetworkSecurityGroupRequest
    {
        [JsonProperty("security_group", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroup NetworkSecurityGroup { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateNetworkSecurityGroupResponse
    {
        [JsonProperty("security_group", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroup NetworkSecurityGroup { get; set; }
    }

    public class NetworkSecurityGroup : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Description { get; set; }

        [JsonProperty("security_group_rules", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroupRule[] SecurityRules { get; set; }
    }

    public class NetworkSecurityGroupRule : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("remote_group_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string RemoteGroupId { get; set; }

        [JsonProperty("direction", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Direction { get; set; }

        [JsonProperty("remote_ip_prefix", DefaultValueHandling = DefaultValueHandling.Include)]
        public object RemoteIpPrefix { get; set; }

        [JsonProperty("protocol", DefaultValueHandling = DefaultValueHandling.Include)]
        public object Protocol { get; set; }

        [JsonProperty("ethertype", DefaultValueHandling = DefaultValueHandling.Include)]
        public string EtherType { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("port_range_max", DefaultValueHandling = DefaultValueHandling.Include)]
        public object PortRangeMax { get; set; }

        [JsonProperty("port_range_min", DefaultValueHandling = DefaultValueHandling.Include)]
        public object PortRangeMin { get; set; }

        [JsonProperty("security_group_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string SecurityGroupId { get; set; }
    }




    [JsonObject(MemberSerialization.OptIn)]
    public class ListNetworkSecurityGroupRulesResponse
    {
        [JsonProperty("security_group_rules", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroupRule[] SecurityGroupRules { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetNetworkSecurityGroupRuleResponse
    {
        [JsonProperty("security_group_rule", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroupRule SecurityGroupRule { get; set; }
    }

    public class CreateNetworkSecurityGroupRuleRequest
    {
        [JsonProperty("security_group_rule", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroupRule NetworkSecurityGroupRule { get; set; }
    }

    public class CreateNetworkSecurityGroupRuleResponse
    {
        [JsonProperty("security_group_rule", DefaultValueHandling = DefaultValueHandling.Include)]
        public NetworkSecurityGroupRule NetworkSecurityGroupRule { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member