#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Servers
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// This models the JSON response used for the List Addresses request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/List_Addresses-d1e3014.html">List Addresses (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListAddressesResponse
    {
        /// <summary>
        /// Gets the IP address details.
        /// </summary>
        [JsonProperty("addresses")]
        public ServerAddresses Addresses { get; private set; }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
    public class ServerIps : Dictionary<string, IEnumerable<ServerIpAddress>> { }

    [JsonObject(MemberSerialization.OptIn)]
    public class ServerIpAddress : ExtensibleJsonObject
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("addr")]
        public string Address { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListServerIpsResponse
    {
        [JsonProperty("addresses")]
        public ServerIps ServerIps { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member