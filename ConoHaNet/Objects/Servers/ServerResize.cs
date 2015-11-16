namespace ConoHaNet.Objects.Servers
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON body containing details for the Resize Server request.
    /// </summary>
    /// <seealso cref="ServerResizeRequest"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Resize_Server-d1e3707.html">Resize Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ServerResizeDetails
    {
        /// <summary>
        /// Gets the new name for the resized server.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the ID of the new flavor.
        /// </summary>
        /// <seealso cref="Flavor.Id"/>
        [JsonProperty("flavorRef")]
        public string Flavor { get; private set; }

        /// <summary>
        /// The disk configuration. If the value is <see langword="null"/>, the default configuration for the image is used.
        /// </summary>
        [JsonProperty("OS-DCF:diskConfig", DefaultValueHandling = DefaultValueHandling.Include)]
        public DiskConfiguration DiskConfig { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerResizeDetails"/> class with the specified details.
        /// </summary>
        /// <param name="flavor">The new flavor. This is obtained from <see cref="Flavor.Id">Flavor.Id</see>.</param>
        /// <param name="diskConfig">The disk configuration. If the value is <see langword="null"/>, the default configuration for the specified image is used.</param>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="flavor"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <para>If <paramref name="flavor"/> is empty.</para>
        /// </exception>
        public ServerResizeDetails(string flavor, DiskConfiguration diskConfig)
        {
            if (flavor == null)
                throw new ArgumentNullException("flavor");
            if (string.IsNullOrEmpty(flavor))
                throw new ArgumentException("flavor cannot be empty");

            Flavor = flavor;
            DiskConfig = diskConfig;
        }
    }

    /// <summary>
    /// This models the JSON request used for the Resize Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Resize_Server-d1e3707.html">Resize Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ServerResizeRequest
    {
        /// <summary>
        /// Gets additional information about the Resize Server request.
        /// </summary>
        [JsonProperty("resize")]
        public ServerResizeDetails Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerResizeRequest"/>
        /// class with the specified details.
        /// </summary>
        /// <param name="details">The details of the request.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="details"/> is <see langword="null"/>.</exception>
        public ServerResizeRequest(ServerResizeDetails details)
        {
            if (details == null)
                throw new ArgumentNullException("details");

            Details = details;
        }
    }

    /// <summary>
    /// This models the JSON request used for the Revert Resized Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Revert_Resized_Server-d1e4024.html">Revert Resized Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class RevertServerResizeRequest
    {
#pragma warning disable 414 // The field 'fieldName' is assigned but its value is never used
        [JsonProperty("revertResize")]
        private string _command = "none";
#pragma warning restore 414
    }

    /// <summary>
    /// This models the JSON request used for the Confirm Resized Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Confirm_Resized_Server-d1e3868.html">Confirm Resized Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ConfirmServerResizeRequest
    {
#pragma warning disable 414 // The field 'fieldName' is assigned but its value is never used
        [JsonProperty("confirmResize")]
        private string _command = "none";
#pragma warning restore 414
    }

}
