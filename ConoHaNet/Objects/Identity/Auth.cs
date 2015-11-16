namespace ConoHaNet.Objects.Identity
{
    using System;
    using Newtonsoft.Json;
    using Providers;

    /// <summary>
    /// Represents the credentials data for an Authenticate request to the ConoHa
    /// Identity Service.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Authenticate</seealso>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Sample Authentication Request and Response</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class Credentials
    {
        /// <summary>
        /// Gets or sets the username to use for authentication.
        /// </summary>
        [JsonProperty("username", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Username { get; private set; }

        /// <summary>
        /// Gets or sets the password to use for authentication.
        /// </summary>
        [JsonProperty("password", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Password { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class using the specified
        /// username, password, and API key.
        /// </summary>
        /// <param name="username">The username to use for authentication.</param>
        /// <param name="password">The password to use for authentication.</param>
        /// <param name="apiKey">ConoHa does not support this by design.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="username"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="username"/> is empty.
        /// <para>-or-</para>
        /// <para>If <paramref name="password"/> and <paramref name="apiKey"/> are both <see langword="null"/> or empty.</para>
        /// </exception>
        public Credentials(string username, string password, string apiKey = null)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");

            // for GetOpenStackCPMember(), no password validation 
            //if (string.IsNullOrEmpty(password))
            //    throw new ArgumentException("password cannot both be null or empty");

            Username = username;
            Password = password;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class AuthDetails
    {
        [JsonProperty("passwordCredentials", DefaultValueHandling = DefaultValueHandling.Include)]
        public Credentials PasswordCredentials { get; set; }

        [JsonProperty("tenantName", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantName { get; set; }

        [JsonProperty("tenantId", DefaultValueHandling = DefaultValueHandling.Include)]
        public string TenantId { get; set; }
    }


    /// <summary>
    /// This models the JSON request used for the Authenticate request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_authenticate_v2.0_tokens_.html">Authenticate (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AuthRequest
    {
        /// <summary>
        /// Gets additional information about the credentials to authenticate.
        /// </summary>
        [JsonProperty("auth")]
        public AuthDetails Credentials { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRequest"/> class with the
        /// given identity.
        /// </summary>
        /// <param name="identity">The identity of the user to authenticate.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="identity"/> is <see langword="null"/>.</exception>
        /// <exception cref="NotSupportedException">If given <paramref name="identity"/> type is not supported.</exception>
        public AuthRequest(CloudIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("identity");

            var credentials = new AuthDetails();

            credentials.PasswordCredentials = new Credentials(identity.Username, identity.Password, null);

            CloudIdentityWithProject p = identity as CloudIdentityWithProject;
            if (p is CloudIdentityWithProject)
            {
                if (p != null && !string.IsNullOrEmpty(p.ProjectName))
                    credentials.TenantName = p.ProjectName;

                if (p != null && p.ProjectId != null)
                    credentials.TenantId = p.ProjectId.Value;
            }

            Credentials = credentials;
        }
    }

    /// <summary>
    /// This models the JSON response used for the Authenticate request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_authenticate_v2.0_tokens_.html">Authenticate (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AuthenticationResponse
    {
        /// <summary>
        /// Gets additional information about the authenticated user.
        /// </summary>
        /// <seealso cref="UserAccess"/>
        [JsonProperty("access")]
        public UserAccess UserAccess { get; private set; }
    }

}
