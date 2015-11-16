#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Servers
{
    using Networks;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// This models the JSON response used for the List Servers and List Servers with Details requests.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/List_Servers-d1e2078.html">List Servers (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListServersResponse
    {
        /// <summary>
        /// Gets a collection of information about the servers.
        /// </summary>
        [JsonProperty("servers")]
        public Server[] Servers { get; private set; }

        /// <summary>
        /// Gets a collection of links related to the collection of servers.
        /// </summary>
        [JsonProperty("servers_links")]
        public Link[] Links { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Get Server Details, Update Server, and Rebuild Server requests.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Get_Server_Details-d1e2623.html">Get Server Details (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/ServerUpdate.html">Update Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Rebuild_Server-d1e3538.html">Rebuild Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ServerDetailsResponse
    {
        /// <summary>
        /// Gets the detailed information about the server.
        /// </summary>
        [JsonProperty("server")]
        public Server Server { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Update Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/ServerUpdate.html">Update Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateServerRequest
    {
        /// <summary>
        /// Gets additional details about the updated server.
        /// </summary>
        [JsonProperty("server")]
        public ServerUpdateDetails Server { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateServerRequest"/> class
        /// with the specified name and access IP addresses.
        /// </summary>
        /// <param name="name">The new name for the server. If the value is <see langword="null"/>, the server name is not changed.</param>
        /// <param name="accessIPv4">The new IP v4 address for the server, or <see cref="IPAddress.None"/> to remove the configured IP v4 address for the server. If the value is <see langword="null"/>, the server's IP v4 address is not updated.</param>
        /// <param name="accessIPv6">The new IP v6 address for the server, or <see cref="IPAddress.None"/> to remove the configured IP v6 address for the server. If the value is <see langword="null"/>, the server's IP v6 address is not updated.</param>
        /// <exception cref="ArgumentException">
        /// <para>If <paramref name="accessIPv4"/> is not <see cref="IPAddress.None"/> and the <see cref="AddressFamily"/> of <paramref name="accessIPv4"/> is not <see cref="AddressFamily.InterNetwork"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="accessIPv6"/> is not <see cref="IPAddress.None"/> and the <see cref="AddressFamily"/> of <paramref name="accessIPv6"/> is not <see cref="AddressFamily.InterNetworkV6"/>.</para>
        /// </exception>
        public UpdateServerRequest(string name, IPAddress accessIPv4, IPAddress accessIPv6)
        {
            if (accessIPv4 != null && !IPAddress.None.Equals(accessIPv4) && accessIPv4.AddressFamily != AddressFamily.InterNetwork)
                throw new ArgumentException("The specified value for accessIPv4 is not an IP v4 address.", "accessIPv4");
            if (accessIPv6 != null && !IPAddress.None.Equals(accessIPv6) && accessIPv6.AddressFamily != AddressFamily.InterNetworkV6)
                throw new ArgumentException("The specified value for accessIPv6 is not an IP v6 address.", "accessIPv6");

            Server = new ServerUpdateDetails(name, accessIPv4, accessIPv6);
        }

        /// <summary>
        /// This models the JSON body containing details for the Update Server request.
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        [JsonObject(MemberSerialization.OptIn)]
        public class ServerUpdateDetails
        {
            /// <summary>
            /// Gets the new name for the server, or <see langword="null"/> if the server's name should not be changed by the update.
            /// </summary>
            [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
            public string Name { get; private set; }

            /// <summary>
            /// Gets the IP v4 access address for the server, or <see langword="null"/> if the access address should not be changed by the update.
            /// </summary>
            [JsonProperty("accessIPv4", DefaultValueHandling = DefaultValueHandling.Include)]
            [JsonConverter(typeof(IPAddressNoneIsNullSimpleConverter))]
            public IPAddress AccessIPv4 { get; private set; }

            /// <summary>
            /// Gets the IP v6 access address for the server, or <see langword="null"/> if the access address should not be changed by the update.
            /// </summary>
            [JsonProperty("accessIPv6", DefaultValueHandling = DefaultValueHandling.Include)]
            [JsonConverter(typeof(IPAddressNoneIsNullSimpleConverter))]
            public IPAddress AccessIPv6 { get; private set; }

            /// <summary>
            /// Gets the metadata to associate with the server.
            /// </summary>
            [JsonProperty("metadata", DefaultValueHandling = DefaultValueHandling.Include)]
            public Dictionary<string, string> Metadata { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="UpdateServerRequest"/> class
            /// with the specified name and access IP addresses.
            /// </summary>
            /// <param name="name">The new name for the server. If the value is <see langword="null"/>, the server name is not changed.</param>
            /// <param name="accessIPv4">The new IP v4 address for the server, or <see cref="IPAddress.None"/> to remove the configured IP v4 address for the server. If the value is <see langword="null"/>, the server's IP v4 address is not updated.</param>
            /// <param name="accessIPv6">The new IP v6 address for the server, or <see cref="IPAddress.None"/> to remove the configured IP v6 address for the server. If the value is <see langword="null"/>, the server's IP v6 address is not updated.</param>
            /// <exception cref="ArgumentException">
            /// <para>If <paramref name="accessIPv4"/> is not <see cref="IPAddress.None"/> and the <see cref="AddressFamily"/> of <paramref name="accessIPv4"/> is not <see cref="AddressFamily.InterNetwork"/>.</para>
            /// <para>-or-</para>
            /// <para>If <paramref name="accessIPv6"/> is not <see cref="IPAddress.None"/> and the <see cref="AddressFamily"/> of <paramref name="accessIPv6"/> is not <see cref="AddressFamily.InterNetworkV6"/>.</para>
            /// </exception>
            public ServerUpdateDetails(string name, IPAddress accessIPv4, IPAddress accessIPv6)
            {
                if (accessIPv4 != null && !IPAddress.None.Equals(accessIPv4) && accessIPv4.AddressFamily != AddressFamily.InterNetwork)
                    throw new ArgumentException("The specified value for accessIPv4 is not an IP v4 address.", "accessIPv4");
                if (accessIPv6 != null && !IPAddress.None.Equals(accessIPv6) && accessIPv6.AddressFamily != AddressFamily.InterNetworkV6)
                    throw new ArgumentException("The specified value for accessIPv6 is not an IP v6 address.", "accessIPv6");

                Name = name;
                AccessIPv4 = accessIPv4;
                AccessIPv6 = accessIPv6;
            }
        }
    }

    public class RebuildServerRequest
    {
        [JsonProperty("rebuild")]
        public RebuildServerDetails Rebuild { get; set; }

        public RebuildServerRequest(RebuildServerDetails details)
        {
            this.Rebuild = details;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class RebuildServerDetails
    {

        [JsonProperty("imageRef")]
        public string ImageRef { get; set; }

        [JsonProperty("adminPass")]
        public string AdminPass { get; set; }

        [JsonProperty("key_name")]
        public string KeyName { get; set; }

        public RebuildServerDetails(string imageRef, string adminPass, string keyName)
        {
            this.ImageRef = imageRef;
            this.AdminPass = adminPass;
            this.KeyName = keyName;
        }
    }

    /// <summary>
    /// This models the JSON body containing details for the Rebuild Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Rebuild_Server-d1e3538.html">Rebuild Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    [Obsolete("", true)]
    internal class ServerRebuildDetails_OLD
    {
        /// <summary>
        /// Gets the new name for the server.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the image to rebuild the server from. This is specified as an image ID (see <see cref="SimpleServerImage.Id"/>) or a full URL.
        /// </summary>
        [JsonProperty("imageRef")]
        public string ImageName { get; private set; }

        /// <summary>
        /// The new flavor for server. This is obtained from <see cref="Flavor.Id"/>.
        /// </summary>
        [JsonProperty("flavorRef")]
        public string Flavor { get; private set; }

        /// <summary>
        /// The disk configuration. If the value is <see langword="null"/>, the default configuration for the specified image is used.
        /// </summary>
        [JsonProperty("OS-DCF:diskConfig", DefaultValueHandling = DefaultValueHandling.Include)]
        public DiskConfiguration DiskConfig { get; private set; }

        /// <summary>
        /// Gets the new admin password for the server.
        /// </summary>
        [JsonProperty("adminPass")]
        public string AdminPassword { get; private set; }

        /// <summary>
        /// Gets the list of metadata to associate with the server. If the value is <see langword="null"/>, the metadata associated with the server is not changed during the rebuild operation.
        /// </summary>
        [JsonProperty("metadata", DefaultValueHandling = DefaultValueHandling.Include)]
        public Dictionary<string, string> Metadata { get; private set; }

        /// <summary>
        /// The path and contents of a file to inject in the target file system during the rebuild operation. If the value is <see langword="null"/>, no file is injected.
        /// </summary>
        [JsonProperty("personality", DefaultValueHandling = DefaultValueHandling.Include)]
        public Personality Personality { get; private set; }

        /// <summary>
        /// The new IP v4 address for the server. If the value is <see langword="null"/>, the server's IP v4 address is not updated.
        /// </summary>
        [JsonProperty("accessIPv4", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonConverter(typeof(IPAddressNoneIsNullSimpleConverter))]
        public IPAddress AccessIPv4 { get; private set; }

        /// <summary>
        /// The new IP v6 address for the server. If the value is <see langword="null"/>, the server's IP v6 address is not updated.
        /// </summary>
        [JsonProperty("accessIPv6", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonConverter(typeof(IPAddressNoneIsNullSimpleConverter))]
        public IPAddress AccessIPv6 { get; private set; }

    }

    /// <summary>
    /// This models the JSON request used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class CreateServerRequest
    {
        /// <summary>
        /// Gets additional details about the Create Server request.
        /// </summary>
        [JsonProperty("server")]
        public CreateServerDetails Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServerRequest"/> class
        /// with the specified details.
        /// </summary>
        /// <param name="name">Name of the new server.</param>
        /// <param name="imageId">The image to use for the new server instance. This is
        /// specified as an image ID (see <see cref="SimpleServerImage.Id"/>) or a full URL.</param>
        /// <param name="flavorId">The flavor to use for the new server instance. This
        /// is specified as a flavor ID (see <see cref="Flavor.Id"/>) or a full URL.</param>
        /// <param name="adminPass">The root Password </param>
        /// <param name="keyName">The ssh key name</param>
        /// <param name="securityGroupNames">A collection of openstack security group name</param>
        /// <param name="attachVolumeIds">A collection of voiume ids which will be attached to the instance.</param>
        /// <param name="diskConfig">The disk configuration. If the value is <see langword="null"/>, the default configuration for the specified image is used.</param>
        /// <param name="metadata">The metadata to associate with the server.</param>
        /// <param name="personality">A collection of <see cref="Personality"/> objects describing the paths and contents of files to inject in the target file system during the creation process. If the value is <see langword="null"/>, no files are injected.</param>
        /// <param name="accessIPv4">The behavior of this value is unspecified. Do not use.</param>
        /// <param name="accessIPv6">The behavior of this value is unspecified. Do not use.</param>
        ///<param name="networks">A collection of identifiers for networks to initially connect to the server. These are obtained from <see cref="CloudNetwork.Id">CloudNetwork.Id</see></param>
        public CreateServerRequest(string name, string imageId, string flavorId, string adminPass, string keyName, string[] securityGroupNames, string[] attachVolumeIds, DiskConfiguration diskConfig, Dictionary<string, string> metadata, string accessIPv4, string accessIPv6, IEnumerable<string> networks, IEnumerable<Personality> personality)
        {
            Details = new CreateServerDetails(name, imageId, flavorId, adminPass, keyName, securityGroupNames, attachVolumeIds, diskConfig, metadata, accessIPv4, accessIPv6, networks, personality);
        }

        /// <summary>
        /// This models the JSON body containing details for a Create Server request.
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        [JsonObject(MemberSerialization.OptIn)]
        public class CreateServerDetails
        {
            /// <summary>
            /// Gets the name of the new server to create.
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; private set; }

            /// <summary>
            /// Gets the image to use for the new server instance. This is
            /// specified as an image ID (see <see cref="SimpleServerImage.Id"/>) or a full URL.
            /// </summary>
            [JsonProperty("imageRef")]
            public string ImageId { get; private set; }

            /// <summary>
            /// Gets the flavor to use for the new server instance. This
            /// is specified as a flavor ID (see <see cref="Flavor.Id"/>) or a full URL.
            /// </summary>
            [JsonProperty("flavorRef")]
            public string FlavorId { get; private set; }

            /// <summary>
            /// Set the password to use for the new server instance. 
            /// </summary>
            [JsonProperty("adminPass")]
            public string AdminPass { get; private set; }

            /// <summary>
            /// Gets the SSHKeyName to use for the new server instance. This
            /// is specified as a flavor ID (see <see cref="Keypair.Name"/>)
            /// </summary>
            [JsonProperty("key_name")]
            public string KeyName { get; private set; }

            /// <summary>
            /// Gets the security group names to use for the new server instance. This
            /// is specified as a flavor ID (see <see cref="NetworkSecurityGroup"/>)
            /// </summary>
            [JsonProperty("security_groups")]
            public SecurityGroupName[] SecurityGroupNames { get; private set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("block_device_mapping")]
            public VolumeIds[] BlockDeviceMappings { get; private set; }

            /// <summary>
            /// Gets the disk configuration. If the value is <see langword="null"/>, the default configuration for the specified image is used.
            /// </summary>
            [JsonProperty("OS-DCF:diskConfig")]
            public DiskConfiguration DiskConfig { get; private set; }

            /// <summary>
            /// Gets the metadata to associate with the server.
            /// </summary>
            [JsonProperty("metadata", DefaultValueHandling = DefaultValueHandling.Include)]
            public Dictionary<string, string> Metadata { get; set; }

            /// <summary>
            /// The behavior of this value is unspecified. Do not use.
            /// </summary>
            [JsonProperty("accessIPv4", DefaultValueHandling = DefaultValueHandling.Include)]
            public string AccessIPv4 { get; private set; }

            /// <summary>
            /// The behavior of this value is unspecified. Do not use.
            /// </summary>
            [JsonProperty("accessIPv6", DefaultValueHandling = DefaultValueHandling.Include)]
            public string AccessIPv6 { get; private set; }

            /// <summary>
            /// Gets a collection of information about networks to initially connect to the server.
            /// </summary>
            [JsonProperty("networks", DefaultValueHandling = DefaultValueHandling.Include)]
            public NewServerNetwork[] Networks { get; private set; }

            /// <summary>
            /// Gets a collection of <see cref="Personality"/> objects describing the paths and
            /// contents of files to inject in the target file system during the creation process.
            /// If the value is <see langword="null"/>, no files are injected.
            /// </summary>
            [JsonProperty("personality", DefaultValueHandling = DefaultValueHandling.Include)]
            public Personality[] Personality { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateServerDetails"/> class
            /// with the specified details.
            /// </summary>
            /// <param name="name">Name of the new server.</param>
            /// <param name="imageName">The image to use for the new server instance. This is
            /// specified as an image ID (see <see cref="SimpleServerImage.Id"/>) or a full URL.</param>
            /// <param name="flavorId">The flavor to use for the new server instance. This
            /// is specified as a flavor ID (see <see cref="Flavor.Id"/>) or a full URL.</param>
            /// <param name="adminPass">The root Password </param>
            /// <param name="keyName">the ssh keyname to add to server</param>
            /// <param name="securityGroupNames">A collection of openstack security group name</param>
            /// <param name="attachVolumeIds">A collection of voiume ids which will be attached to the instance.</param>
            /// <param name="diskConfig">The disk configuration. If the value is <see langword="null"/>, the default configuration for the specified image is used.</param>
            /// <param name="metadata">The metadata to associate with the server.</param>
            /// <param name="personality">A collection of <see cref="Personality"/> objects describing the paths and contents of files to inject in the target file system during the creation process. If the value is <see langword="null"/>, no files are injected.</param>
            /// <param name="accessIPv4">The behavior of this value is unspecified. Do not use.</param>
            /// <param name="accessIPv6">The behavior of this value is unspecified. Do not use.</param>
            /// <param name="networks">A collection of identifiers for networks to initially connect to the server. These are obtained from <see cref="CloudNetwork.Id">CloudNetwork.Id</see></param>
            public CreateServerDetails(string name, string imageName, string flavorId, string adminPass, string keyName, string[] securityGroupNames, string[] attachVolumeIds, DiskConfiguration diskConfig, Dictionary<string, string> metadata, string accessIPv4, string accessIPv6, IEnumerable<string> networks, IEnumerable<Personality> personality)
            {
                Name = name;
                ImageId = imageName;
                FlavorId = flavorId;
                DiskConfig = diskConfig;
                Metadata = metadata;
                AccessIPv4 = accessIPv4;
                AccessIPv6 = accessIPv6;
                Networks = (networks == null ? null : networks.Select(i => new NewServerNetwork(i)).ToArray());
                Personality = personality != null ? personality.ToArray() : null;
                KeyName = keyName;
                SecurityGroupNames = SecurityGroupName.GetGroupNamesFromStrings(securityGroupNames).ToArray<SecurityGroupName>();
                BlockDeviceMappings = VolumeIds.GetVolumeIdsFromStrings(attachVolumeIds).ToArray<VolumeIds>();
                AdminPass = adminPass;
            }

            /// <summary>
            /// This models the JSON body containing details for a connected network
            /// within the Create Server request.
            /// </summary>
            /// <threadsafety static="true" instance="false"/>
            [JsonObject(MemberSerialization.OptIn)]
            public class NewServerNetwork
            {
                /// <summary>
                /// Gets the ID of the network.
                /// </summary>
                /// <seealso cref="CloudNetwork.Id"/>
                [JsonProperty("uuid")]
                public string NetworkId { get; private set; }

                /// <summary>
                /// Initializes a new instance of the <see cref="NewServerNetwork"/> class
                /// with the specified ID.
                /// </summary>
                /// <param name="networkId">The network ID. This is obtained from <see cref="CloudNetwork.Id">CloudNetwork.Id</see>.</param>
                public NewServerNetwork(string networkId)
                {
                    if (networkId == null)
                        throw new ArgumentNullException("networkId");

                    NetworkId = networkId;
                }
            }

            [JsonObject(MemberSerialization.OptIn)]
            public class SecurityGroupName
            {
                [JsonProperty("name")]

                public string Name { get; set; }

                public static IEnumerable<SecurityGroupName> GetGroupNamesFromStrings(string[] securityGroupNames)
                {
                    if (securityGroupNames == null)
                        securityGroupNames = new string[] { };

                    foreach (var item in securityGroupNames)
                    {
                        yield return new SecurityGroupName() { Name = item };
                    }
                }
            }

            [JsonObject(MemberSerialization.OptIn)]
            public class VolumeIds
            {
                [JsonProperty("volume_id")]
                public string VolumeId { get; set; }

                public static IEnumerable<VolumeIds> GetVolumeIdsFromStrings(string[] attachVolumeIds)
                {
                    if (attachVolumeIds == null)
                        attachVolumeIds = new string[] { };

                    foreach (var item in attachVolumeIds)
                    {
                        yield return new VolumeIds() { VolumeId = item };
                    }
                }
            }
        }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateServerResponse
    {
        /// <summary>
        /// Gets information about the created server.
        /// </summary>
        [JsonProperty("server")]
        public NewServer Server { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member