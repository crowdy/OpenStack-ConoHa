namespace ConoHaNet.Objects.Servers
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON request used for the Change Administrator Password request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Change_Password-d1e3234.html">Change Administrator Password (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ChangeServerAdminPasswordRequest
    {
        /// <summary>
        /// Gets additional information about the new password to assign to the server.
        /// </summary>
        [JsonProperty("changePassword")]
        public ChangeAdminPasswordDetails Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeServerAdminPasswordRequest"/>
        /// class with the given password.
        /// </summary>
        /// <param name="password">The new password to use on the server.</param>
        public ChangeServerAdminPasswordRequest(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");

            Details = new ChangeAdminPasswordDetails(password);
        }

        /// <summary>
        /// This models the JSON body containing the details of the Change Administrator Password request.
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        [JsonObject(MemberSerialization.OptIn)]
        internal class ChangeAdminPasswordDetails
        {
            /// <summary>
            /// Gets the new password to assign to the server.
            /// </summary>
            [JsonProperty("adminPass")]
            public string AdminPassword { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ChangeAdminPasswordDetails"/>
            /// class with the given password.
            /// </summary>
            /// <param name="password">The new password to use on the server.</param>
            public ChangeAdminPasswordDetails(string password)
            {
                if (password == null)
                    throw new ArgumentNullException("password");
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentException("password cannot be empty");

                AdminPassword = password;
            }
        }
    }

    /// <summary>
    /// This models the JSON request used for the Reboot Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Reboot_Server-d1e3371.html">Reboot Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ServerRebootRequest
    {
        /// <summary>
        /// Gets additional details about the Reboot Server request.
        /// </summary>
        [JsonProperty("reboot")]
        public ServerRebootDetails Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRebootRequest"/>
        /// class with the specified details.
        /// </summary>
        /// <param name="details">The details of the request.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="details"/> is <see langword="null"/>.</exception>
        public ServerRebootRequest(ServerRebootDetails details)
        {
            if (details == null)
                throw new ArgumentNullException("details");

            Details = details;
        }
    }

    /// <summary>
    /// This models the JSON body containing details for the Reboot Server request.
    /// </summary>
    /// <seealso cref="ServerRebootRequest"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Reboot_Server-d1e3371.html">Reboot Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ServerRebootDetails
    {
        /// <summary>
        /// Gets the type of reboot to perform.
        /// </summary>
        [JsonProperty("type")]
        public RebootType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerRebootDetails"/>
        /// class with the specified reboot type.
        /// </summary>
        /// <param name="type">The type of reboot to perform. See <see cref="RebootType"/> for predefined values.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="type"/> is <see langword="null"/>.</exception>
        public ServerRebootDetails(RebootType type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            Type = type;
        }
    }


    /// <summary>
    /// This models the JSON request used for the Rescue Server request.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Rescue Server</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class RescueServerRequest
    {
#pragma warning disable 414 // The field 'fieldName' is assigned but its value is never used
        [JsonProperty("rescue")]
        private string _command = "none";
#pragma warning restore 414
    }

    /// <summary>
    /// This models the JSON response used for the Rescue Server request.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Rescue Server</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class RescueServerResponse
    {
        /// <summary>
        /// Gets the temporary administrator password assigned for use while the server
        /// is in rescue mode.
        /// </summary>
        [JsonProperty("adminPass")]
        public string AdminPassword { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Unrescue Server request.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Unrescue Server</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UnrescueServerRequest
    {
#pragma warning disable 414 // The field 'fieldName' is assigned but its value is never used
        [JsonProperty("unrescue")]
        private string _command = "none";
#pragma warning restore 414
    }

}
