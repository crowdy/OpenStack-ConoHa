namespace ConoHaNet.Objects.Identity
{
    using System;
    using Newtonsoft.Json;
    using Providers;

    /// <summary>
    /// This models the JSON response used for the List Users request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_listUsers_v2.0_users_.html">List Users (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UsersResponse
    {
        /// <summary>
        /// Gets a collection of information about the users.
        /// </summary>
        [JsonProperty("users")]
        public User[] Users { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Get User Information by Name, Get User Information by ID, and Update User requests.
    /// </summary>
    /// <remarks>
    /// In certain situations with certain vendors, the List Users request is known to result
    /// in a response that resembles this model. When such a situation is detected, this
    /// response model is also used for the List Users response.
    /// </remarks>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_getUserByName_v2.0_users__User_Operations.html">Get User Information by Name (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_getUserById_v2.0_users__user_id__User_Operations.html">Get User Information by ID (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUser_v2.0_users__userId__.html">Update User (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_listUsers_v2.0_users_.html">List Users (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UserResponse
    {
        /// <summary>
        /// Gets information about the user.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Add User request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_addUser_v2.0_users_.html">Add User (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class NewUserResponse
    {
        /// <summary>
        /// Gets the information about the newly created user, including the generated
        /// <see cref="NewUser.Password"/> if no password was specified in the request.
        /// </summary>
        [JsonProperty("user")]
        public NewUser NewUser { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Add User request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_addUser_v2.0_users_.html">Add User (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AddUserRequest
    {
        /// <summary>
        /// Gets additional information about the user to add.
        /// </summary>
        [JsonProperty("user")]
        public NewUser User { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserRequest"/> class for the
        /// specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="user"/> is <see langword="null"/>.</exception>
        public AddUserRequest(NewUser user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            User = user;
        }
    }

    /// <summary>
    /// Represents the JSON result of an Add User operation.
    /// </summary>
    /// <seealso cref="IIdentityProvider.AddUser"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_addUser_v2.0_users_.html">Add User (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class NewUserWithTenantId : ExtensibleJsonObject
    {
        /// <summary>
        /// Gets the password for the new user.
        /// </summary>
        /// <value>The generated password for the new user, or <see langword="null"/> if the Add User request included a password.</value>
        [JsonProperty("password")]
        public string Password { get; internal set; }

        /// <summary>
        /// Gets the ID for the new user.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include, Required = Required.Always)]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the new user.
        /// <note type="warning">
        /// The value of this property in the underlying JSON representation differs between
        /// name and username
        /// </note>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the username of the new user.
        /// <note type="warning">
        /// The value of this property in the underlying JSON representation differs between
        /// name and username
        /// </note>
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// Gets the email address of the new user.
        /// </summary>
        /// <value>
        /// The email address of the user.
        /// <para>-or-</para>
        /// <para><see langword="null"/> if the response from the server did not include the underlying property.</para>
        /// </value>
        [JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not the user is enabled.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the user is enabled; otherwise, <see langword="false"/>.
        /// </value>
        [JsonProperty("enabled")]
        public bool Enabled { get; private set; }

        /// <summary>
        /// Gets the tenant id of the new user.
        /// </summary>
        /// <value>
        /// The tenant id of the user.
        /// <para>-or-</para>
        /// <para><see langword="null"/> if the response from the server did not include the underlying property.</para>
        /// </value>
        [JsonProperty("tenantId")]
        public string TenantId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewUserWithTenantId"/> class with the specified
        /// username, email address, password, and value indicating whether or not the user
        /// is initially enabled.
        /// </summary>
        /// <param name="name">The username of the new user (see <see cref="Username"/>).</param>
        /// <param name="email">The email address of the new user (see <see cref="Email"/>).</param>
        /// <param name="password">The password for the new user (see <see cref="Password"/>).</param>
        /// <param name="enabled"><see langword="true"/> if the user is initially enabled; otherwise, <see langword="false"/> (see <see cref="Enabled"/>).</param>
        /// <param name="tenantId">The TenantId for user</param>
        public NewUserWithTenantId(string name, string email, string password = null, bool enabled = true, string tenantId = null)
        {
            Name = name;
            Email = email;
            Password = password;
            Enabled = enabled;
            TenantId = tenantId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewUser"/> class with the specified
        /// username, email address, password, and value indicating whether or not the user
        /// is initially enabled.
        /// </summary>
        /// <param name="user">the new user instanace (see <see cref="NewUser"/>).</param>
        /// <param name="tenantId">The TenantId for user</param>
        public NewUserWithTenantId(NewUser user, string tenantId)
        {
            Name = user.Username;
            Username = user.Username;
            Email = user.Email;
            Password = user.Password;
            Enabled = user.Enabled;
            TenantId = tenantId;
        }

        /// <summary>
        /// Initializes a new instance of the NewUserWithTenantId class.
        /// </summary>
        public NewUserWithTenantId()
        {
        }
    }

    /// <summary>
    /// This models the JSON request used for the Update NewUserWithTenantId request.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AddNewUserWithTenantIdRequest
    {
        /// <summary>
        /// Gets additional information about the user to add.
        /// </summary>
        [JsonProperty("user")]
        public NewUserWithTenantId User { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserRequest"/> class for the
        /// specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="user"/> is <see langword="null"/>.</exception>
        public AddNewUserWithTenantIdRequest(NewUserWithTenantId user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            User = user;
        }
    }

    /// <summary>
    /// This models the JSON request used for the Update NewUserWithTenantId response.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class NewUserWithTenantIdResponse
    {
        /// <summary>
        /// Gets the information about the newly created user, including the generated
        /// <see cref="NewUser.Password"/> if no password was specified in the request.
        /// </summary>
        [JsonProperty("user")]
        public NewUserWithTenantId NewUser { get; private set; }
    }


    /// <summary>
    /// This models the JSON request used for the Update User request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_updateUser_v2.0_users__userId__.html">Update User (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateUserRequest
    {
        /// <summary>
        /// Gets the updated user information for the request.
        /// </summary>
        [JsonProperty("user")]
        public User User { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserRequest"/> class
        /// with the specified user.
        /// </summary>
        /// <param name="user">A <see cref="User"/> instance containing the updated details for the user.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="user"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="user"/>.<see cref="User.Id"/> is <see langword="null"/> or empty.</exception>
        public UpdateUserRequest(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentException("user.Id cannot be null or empty");

            User = user;
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    [JsonObject(MemberSerialization.OptIn)]
    public class InternalUserResponse
    {
        [JsonProperty("user")]

        public InternalUser User { get; set; }
    }

    public class InternalUser : ExtensibleJsonObject
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member