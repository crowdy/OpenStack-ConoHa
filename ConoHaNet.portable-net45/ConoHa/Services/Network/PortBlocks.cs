#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.Network
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;
    using System.Collections.Generic;

    [JsonObject(MemberSerialization.OptIn)]
    public class PortBlockResponse
    {
        [JsonProperty("ports", DefaultValueHandling = DefaultValueHandling.Include)]
        public PortBlock[] PortBlocks { get; set; }
    }

    public class PortBlock : ExtensibleJsonObject
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("tenant_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }

        [JsonProperty("mac_address", DefaultValueHandling = DefaultValueHandling.Include)]
        public string MacAddress { get; set; }

        [JsonProperty("device_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string DeviceId { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Status { get; set; }

        [JsonProperty("bw_usage", DefaultValueHandling = DefaultValueHandling.Include)]
        public BandWidthUsage BandWidthUsage { get; set; }

        [JsonProperty("port_blocks", DefaultValueHandling = DefaultValueHandling.Include)]
        public Port_Block[] Port_Blocks { get; set; }


        public PortBlock(int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictionary)
        {
            this.BandWidthUsage = new BandWidthUsage();
            this.BandWidthUsage.BandWidthIn = bandWidthIn;
            this.BandWidthUsage.BandWidthOut = bandWidthOut;

            if (dictionary != null && dictionary.Count > 0)
            {
                var ports = new List<Port_Block>();
                foreach (var key in dictionary.Keys)
                {
                    ports.Add(new Port_Block()
                    {
                        BlockedPort = key,
                        Protocol = dictionary[key]
                    });
                }
                this.Port_Blocks = ports.ToArray();
            }
        }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BandWidthUsage : ExtensibleJsonObject
    {
        [JsonProperty("bw_in", DefaultValueHandling = DefaultValueHandling.Include)]
        public int BandWidthIn { get; set; }

        [JsonProperty("bw_out", DefaultValueHandling = DefaultValueHandling.Include)]
        public int BandWidthOut { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Port_Block : ExtensibleJsonObject
    {
        [JsonProperty("blocked_port", DefaultValueHandling = DefaultValueHandling.Include)]
        public int BlockedPort { get; set; }

        [JsonProperty("protocol", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Protocol { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class PortBlockRequest
    {
        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Include)]
        public PortBlock PortBlock { get; set; }

        public PortBlockRequest(PortBlock portBlock)
        {
            this.PortBlock = portBlock;
        }
    }


}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member