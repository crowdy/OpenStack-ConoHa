namespace ConoHaNet.Objects.Identity
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON request used for the Update User Credentials request
    /// when used with password credentials.
    /// this uses OS-KSEC2 admin extension.
    /// </summary>
    /// <seealso cref="PasswordCredential"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUserCredential_v2.0_users__userId__OS-KSADM_credentials__credential-type__.html">Update User Credentials (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class SetPasswordRequest
    {
        /// <summary>
        /// Gets the password credentials to use for the Update User Credentials request.
        /// </summary>
        [JsonProperty("passwordCredentials")]
        public PasswordCredential PasswordCredential { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPasswordRequest"/> class
        /// with the specified username and password.
        /// </summary>
        /// <param name="username">The new username.</param>
        /// <param name="password">The new password.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="username"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="password"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="username"/> is empty.
        /// <para>-or-</para>
        /// <para>If <paramref name="password"/> is empty.</para>
        /// </exception>
        public SetPasswordRequest(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");

            PasswordCredential = new PasswordCredential(username, password);
        }
    }


    /// <summary>
    /// This models the JSON response used for the Update User Credentials request
    /// when used with password credentials.
    /// this uses OS-KSEC2 admin extension.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUserCredential_v2.0_users__userId__OS-KSADM_credentials__credential-type__.html">Update User Credentials (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class PasswordCredentialResponse
    {
        /// <summary>
        /// Gets the password credentials used for the Update User Credentials request.
        /// </summary>
        [JsonProperty("passwordCredentials")]
        public PasswordCredential PasswordCredential { get; private set; }
    }

    /// <summary>
    /// This models the JSON representation of password credentials.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUserCredential_v2.0_users__userId__OS-KSADM_credentials__credential-type__.html">Update User Credentials (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class PasswordCredential
    {
        /// <summary>
        /// Gets the username for the credentials.
        /// </summary>
        [JsonProperty("username")]
        public string Username
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the password for the credentials.
        /// </summary>
        [JsonProperty("password")]
        public string Password
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordCredential"/> class
        /// with the specified username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="username"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="password"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="username"/> is empty.
        /// <para>-or-</para>
        /// <para>If <paramref name="password"/> is empty.</para>
        /// </exception>
        public PasswordCredential(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");

            Username = username;
            Password = password;
        }
    }

    /// <summary>
    /// This models the JSON response used for the Update User Credentials request
    /// when used with API Key credentials.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUserCredential_v2.0_users__userId__OS-KSADM_credentials__credential-type__.html">Update User Credentials (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UserCredentialResponse
    {
        /// <summary>
        /// Gets the API key credentials sent with the Update User Credentials request.
        /// </summary>
        [JsonProperty("RAX-KSKEY:apiKeyCredentials")]
        public UserCredential UserCredential { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Update User Credentials request
    /// when used with API Key credentials.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUserCredential_v2.0_users__userId__OS-KSADM_credentials__credential-type__.html">Update User Credentials (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateUserCredentialRequest
    {
        /// <summary>
        /// Gets the API Key credentials to use for the Update User Credentials request.
        /// </summary>
        [JsonProperty("RAX-KSKEY:apiKeyCredentials")]
        public UserCredential UserCredential { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCredentialRequest"/>
        /// class with the specified API Key credentials.
        /// </summary>
        /// <param name="username">The new username.</param>
        /// <param name="apiKey">The new API key.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="username"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="apiKey"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="username"/> is empty.
        /// <para>-or-</para>
        /// <para>If <paramref name="apiKey"/> is empty.</para>
        /// </exception>
        public UpdateUserCredentialRequest(string username, string apiKey)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("apiKey cannot be empty");

            UserCredential = new UserCredential(null, username, apiKey);
        }
    }
}
