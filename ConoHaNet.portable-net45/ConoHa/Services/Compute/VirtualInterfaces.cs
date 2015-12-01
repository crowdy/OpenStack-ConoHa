namespace ConoHaNet.Services.Compute
{
    using System.Net.NetworkInformation;
    using Newtonsoft.Json;
    using System.Net;
    using System;
    using System.Collections.Generic;
    using OpenStack.ObjectModel;
    using OpenStack.Net;

    /// <summary>
    /// Represents the IP address of a virtual interface on a specific network.
    /// </summary>
    /// <remarks>
    /// <note>
    /// Virtual network interfaces are a Rackspace-specific extension to the OpenStack Networking Service.
    /// </note>
    /// </remarks>
    /// <seealso href="http://docs.rackspace.com/networks/api/v2/cn-devguide/content/list_virt_interfaces.html">List Virtual Interfaces (Rackspace Cloud Networks Developer Guide - OpenStack Networking API v2)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class VirtualInterfaceAddress : ExtensibleJsonObject
    {
        /// <summary>
        /// Gets the IP address of the virtual interface.
        /// </summary>
        /// <seealso href="http://docs.rackspace.com/networks/api/v2/cn-devguide/content/list_virt_interfaces.html">List Virtual Interfaces (Rackspace Cloud Networks Developer Guide - OpenStack Networking API v2)</seealso>
        [JsonProperty("address")]
        [JsonConverter(typeof(IPAddressSimpleConverter))]
        public IPAddress Address
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ID of the network this virtual interface is connected to.
        /// </summary>
        /// <seealso cref="CloudNetwork.Id"/>
        /// <seealso href="http://docs.rackspace.com/networks/api/v2/cn-devguide/content/list_virt_interfaces.html">List Virtual Interfaces (Rackspace Cloud Networks Developer Guide - OpenStack Networking API v2)</seealso>
        [JsonProperty("network_id")]
        public string NetworkId { get; private set; }

        /// <summary>
        /// Gets the label of the network this virtual interface is connected to.
        /// </summary>
        /// <seealso cref="CloudNetwork.Label"/>
        /// <seealso href="http://docs.rackspace.com/networks/api/v2/cn-devguide/content/list_virt_interfaces.html">List Virtual Interfaces (Rackspace Cloud Networks Developer Guide - OpenStack Networking API v2)</seealso>
        [JsonProperty("network_label")]
        public string NetworkLabel { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Create Virtual Interface request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/GET_os-virtual-interfaces-v2_getVirtualInterfaces_v2__tenant_id__servers__server_id__os-virtual-interfaces_ext-os-virtual-interfaces.html">Create Virtual Interface</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateVirtualInterfaceRequest
    {
        /// <summary>
        /// Gets additional details about the virtual interface to create.
        /// </summary>
        [JsonProperty("virtual_interface")]
        public CreateVirtualInterface VirtualInterface { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVirtualInterfaceRequest"/>
        /// class with the specified network ID.
        /// </summary>
        /// <param name="networkId">The network ID. This is obtained from <see cref="CloudNetwork.Id">CloudNetwork.Id</see>.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="networkId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="networkId"/> is empty.</exception>
        public CreateVirtualInterfaceRequest(string networkId)
        {
            if (networkId == null)
                throw new ArgumentNullException("networkId");
            if (string.IsNullOrEmpty(networkId))
                throw new ArgumentException("networkId cannot be empty");

            VirtualInterface = new CreateVirtualInterface(networkId);
        }

        /// <summary>
        /// This models the JSON body containing details for a Create Virtual Interface request.
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        [JsonObject(MemberSerialization.OptIn)]
        internal class CreateVirtualInterface
        {
            /// <summary>
            /// Gets the network ID.
            /// </summary>
            /// <seealso cref="CloudNetwork.Id"/>
            [JsonProperty("network_id")]
            public string NetworkId { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateVirtualInterface"/>
            /// class with the specified network ID.
            /// </summary>
            /// <param name="networkId">The network ID. This is obtained from <see cref="CloudNetwork.Id">CloudNetwork.Id</see>.</param>
            /// <exception cref="ArgumentNullException">If <paramref name="networkId"/> is <see langword="null"/>.</exception>
            /// <exception cref="ArgumentException">If <paramref name="networkId"/> is empty.</exception>
            public CreateVirtualInterface(string networkId)
            {
                if (networkId == null)
                    throw new ArgumentNullException("networkId");
                if (string.IsNullOrEmpty(networkId))
                    throw new ArgumentException("networkId cannot be empty");

                NetworkId = networkId;
            }
        }
    }


    /// <summary>
    /// This models the JSON response used for the Create Virtual Interface and List Virtual Interfaces requests.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Create Virtual Interface</seealso>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">List Virtual Interfaces</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListVirtualInterfacesResponse
    {
        /// <summary>
        /// Gets a collection of information about the virtual interfaces.
        /// </summary>
        [JsonProperty("virtual_interfaces")]
        public IEnumerable<VirtualInterface> VirtualInterfaces { get; private set; }
    }
}
