#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Networks
{
    using Newtonsoft.Json;
    using System;


    [JsonObject(MemberSerialization.OptIn)]
    public class ListInterfaceAttachmentsResponse
    {
        [JsonProperty("interfaceAttachments", DefaultValueHandling = DefaultValueHandling.Include)]
        public InterfaceAttachment[] interfaceAttachments { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetInterfaceAttachmentResponse
    {
        [JsonProperty("interfaceAttachment", DefaultValueHandling = DefaultValueHandling.Include)]
        public InterfaceAttachment interfaceAttachment { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class InterfaceAttachment : ExtensibleJsonObject
    {
        [JsonProperty("port_state", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PortState { get; internal set; }

        [JsonProperty("fixed_ips", DefaultValueHandling = DefaultValueHandling.Include)]
        public FixedIp[] FixedIPs { get; internal set; }

        [JsonProperty("port_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string PortId { get; internal set; }

        [JsonProperty("net_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string NetId { get; internal set; }

        [JsonProperty("mac_addr", DefaultValueHandling = DefaultValueHandling.Include)]
        public string MacAddr { get; internal set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member