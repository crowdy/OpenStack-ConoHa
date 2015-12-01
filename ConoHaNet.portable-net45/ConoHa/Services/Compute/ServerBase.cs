namespace ConoHaNet.Objects.Servers
{
    using Newtonsoft.Json;
    using OpenStack.Services.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides basic information about a server.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Servers-d1e2073.html">Servers (OpenStack Compute API v2 and Extensions Reference - API v2)</seealso>
    /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/Servers-d1e2073.html">Servers (Rackspace Next Generation Cloud Servers Developer Guide  - API v2)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class ServerBase
    {
        /// <summary>
        /// Gets the unique identifier for the server.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Id { get; private set; }

        /// <summary>
        /// Gets a collection of links related to the current server.
        /// </summary>
        /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/LinksReferences.html">Links and References (OpenStack Compute API v2 and Extensions Reference - API v2)</seealso>
        [JsonProperty]
        public Link[] Links { get; private set; }
    }
}
