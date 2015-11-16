namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using JSIStudios.SimpleRESTServices.Client;
    using net.openstack.Core;
    using ConoHaNet.Objects;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using CancellationToken = System.Threading.CancellationToken;
    using Objects.Identity;
    using JSIStudios.SimpleRESTServices.Client.Json;

    /// <summary>
    /// Provides an implementation of <see cref="IIdentityProvider"/> and <see cref="IExtendedCloudIdentityProvider"/>
    /// for operating with ConoHa's Cloud Identity product.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/">OpenStack Identity Service API v2.0 Reference</seealso>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">ConoHa Cloud Identity Client Developer Guide - API v2.0</seealso>
    /// <threadsafety static="true" instance="false"/>
    public class CloudIdentityProvider : ProviderBase<IIdentityProvider>, IExtendedCloudIdentityProvider, IIdentityProvider, IIdentityService
    {
        /// <summary>
        /// This is the backing field for the <see cref="TokenCache"/> property.
        /// </summary>
        private readonly net.openstack.Core.Caching.ICache<UserAccess> _userAccessCache;

        /// <summary>
        /// This is the backing field for the <see cref="UrlBase"/> property.
        /// </summary>
        private readonly Uri _urlBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with no default identity, and the default base URL, REST service implementation,
        /// and token cache.
        /// </summary>
        public CloudIdentityProvider() : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with the specified default identity, and the default base URL, REST service
        /// implementation, and token cache.
        /// </summary>
        /// <param name="defaultIdentity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <example>
        /// <para>The following example demonstrates the use of this method to create an identity provider that
        /// authenticates using username and API key credentials.</para>
        /// <code source="..\Samples\CSharpCodeSamples\IdentityProviderExamples.cs" region="CreateProvider" language="cs"/>
        /// <code source="..\Samples\VBCodeSamples\IdentityProviderExamples.vb" region="CreateProvider" language="vbnet"/>
        /// <code source="..\Samples\CPPCodeSamples\IdentityProviderExamples.cpp" region="CreateProvider" language="cpp"/>
        /// <code source="..\Samples\FSharpCodeSamples\IdentityProviderExamples.fs" region="CreateProvider" language="fs"/>
        /// <para>The following example demonstrates the use of this method to create an identity provider that
        /// authenticates using username and password credentials.</para>
        /// <code source="..\Samples\CSharpCodeSamples\IdentityProviderExamples.cs" region="CreateProviderWithPassword" language="cs"/>
        /// <code source="..\Samples\VBCodeSamples\IdentityProviderExamples.vb" region="CreateProviderWithPassword" language="vbnet"/>
        /// <code source="..\Samples\CPPCodeSamples\IdentityProviderExamples.cpp" region="CreateProviderWithPassword" language="cpp"/>
        /// <code source="..\Samples\FSharpCodeSamples\IdentityProviderExamples.fs" region="CreateProviderWithPassword" language="fs"/>
        /// </example>
        public CloudIdentityProvider(CloudIdentity defaultIdentity)
            : this(defaultIdentity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with no default identity, the specified base URL, and the default REST service
        /// implementation and token cache.
        /// </summary>
        /// <param name="urlBase">The base URL for the cloud instance. If this value is <see langword="null"/>, the provider will use <c>https://www.google.co.jp/search?q=openstack+</c>.</param>
        public CloudIdentityProvider(Uri urlBase)
            : this(null, null, null, urlBase)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with the specified default identity and base URL, and the default REST service
        /// implementation and token cache.
        /// </summary>
        /// <param name="defaultIdentity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="urlBase">The base URL for the cloud instance. If this value is <see langword="null"/>, the provider will use <c>https://www.google.co.jp/search?q=openstack+</c>.</param>
        /// <param name="isAdminMode"></param>
        public CloudIdentityProvider(CloudIdentity defaultIdentity, Uri urlBase, bool isAdminMode = false)
            : this(defaultIdentity, null, null, urlBase, isAdminMode)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with no default identity, and the specified base URL, REST service
        /// implementation, and token cache.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        /// <param name="tokenCache">The cache to use for caching user access tokens. If this value is <see langword="null"/>, the provider will use <see cref="UserAccessCache.Instance"/>.</param>
        /// <param name="urlBase">The base URL for the cloud instance. If this value is <see langword="null"/>, the provider will use <c>https://www.google.co.jp/search?q=openstack+</c>.</param>
        public CloudIdentityProvider(IRestService restService, net.openstack.Core.Caching.ICache<UserAccess> tokenCache, Uri urlBase)
            : this(null, restService, tokenCache, urlBase)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with no default identity, the default base URL, the default REST service
        /// implementation, and the specified token cache.
        /// </summary>
        /// <param name="tokenCache">The cache to use for caching user access tokens. If this value is <see langword="null"/>, the provider will use <see cref="UserAccessCache.Instance"/>.</param>
        public CloudIdentityProvider(net.openstack.Core.Caching.ICache<UserAccess> tokenCache)
            : this(null, tokenCache)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with no default identity, the default base URL, the specified REST service
        /// implementation, and the <see cref="UserAccessCache.Instance"/>
        /// token cache.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudIdentityProvider(IRestService restService)
            : this(restService, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// with no default identity, the default base URL, and the specified REST service
        /// implementation and token cache.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        /// <param name="tokenCache">The cache to use for caching user access tokens. If this value is <see langword="null"/>, the provider will use <see cref="UserAccessCache.Instance"/>.</param>
        public CloudIdentityProvider(IRestService restService, net.openstack.Core.Caching.ICache<UserAccess> tokenCache)
            : this(null, restService, tokenCache, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudIdentityProvider"/> class
        /// using the provided values.
        /// </summary>
        /// <param name="defaultIdentity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        /// <param name="tokenCache">The cache to use for caching user access tokens. If this value is <see langword="null"/>, the provider will use <see cref="UserAccessCache.Instance"/>.</param>
        /// <param name="urlBase">The base URL for the cloud instance. If this value is <see langword="null"/>, the provider will use <c>https://www.google.co.jp/search?q=openstack+</c>.</param>
        public CloudIdentityProvider(CloudIdentity defaultIdentity, IRestService restService, net.openstack.Core.Caching.ICache<UserAccess> tokenCache, Uri urlBase)
            : this(null, restService, tokenCache, urlBase, false)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="defaultIdentity"></param>
        /// <param name="restService"></param>
        /// <param name="tokenCache"></param>
        /// <param name="urlBase"></param>
        /// <param name="isAdminMode"></param>
        public CloudIdentityProvider(CloudIdentity defaultIdentity, IRestService restService, net.openstack.Core.Caching.ICache<UserAccess> tokenCache, Uri urlBase, bool isAdminMode)
            : base(defaultIdentity, null, null, restService, null, isAdminMode)
        {
            _userAccessCache = (tokenCache == null ? UserAccessCache.Instance : tokenCache);
            _urlBase = urlBase ?? new Uri("https://identity.tyo1.conoha.io/v2.0");
        }

        /// <summary>
        /// Gets the cache to use for caching user access tokens.
        /// </summary>
        protected internal net.openstack.Core.Caching.ICache<UserAccess> TokenCache
        {
            get
            {
                return _userAccessCache;
            }
        }

        /// <summary>
        /// Gets the base URL for the cloud instance.
        /// </summary>
        protected Uri UrlBase
        {
            get
            {
                return _urlBase;
            }
        }

        #region Roles

        /// <inheritdoc/>
        public virtual IEnumerable<Role> ListRoles(string serviceId = null, int? marker = null, int? limit = null, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"serviceId", serviceId},
                    {"marker", !marker.HasValue ? null : marker.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                });

            var response = ExecuteRESTRequest<RolesResponse>(identity, new Uri(UrlBase, "/v2.0/OS-KSADM/roles"), HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Roles;
        }

        /// <inheritdoc/>
        public virtual bool DeleteRole(string roleId, CloudIdentity identity)
        {
            if (roleId == null)
                throw new ArgumentNullException("roleId");
            if (string.IsNullOrEmpty(roleId))
                throw new ArgumentException("roleId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/OS-KSADM/roles/{0}", roleId);
            var response = ExecuteRESTRequest<Roles>(identity, new Uri(UrlBase, urlPath), HttpMethod.DELETE);

            if (response != null && response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        /// <inheritdoc/>
        public virtual Role AddRole(string name, string description, CloudIdentity identity)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be empty");
            CheckIdentity(identity);

            var response = ExecuteRESTRequest<Roles>(identity, new Uri(UrlBase, "/v2.0/OS-KSADM/roles"), HttpMethod.POST, new AddRoleRequest(new Role(name, description)));

            if (response == null || response.Data == null)
                return null;

            return response.Data.Role;
        }

        /// <inheritdoc/>
        public virtual Role GetRole(string roleId, CloudIdentity identity)
        {
            if (roleId == null)
                throw new ArgumentNullException("roleId");
            if (string.IsNullOrEmpty(roleId))
                throw new ArgumentException("roleId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/OS-KSADM/roles/{0}", roleId);
            var response = ExecuteRESTRequest<Roles>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Role;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<Role> GetRolesByUser(string userId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/users/{0}/roles", userId);
            var response = ExecuteRESTRequest<RolesResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Roles;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<Role> GetRolesByUserTenant(string userId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            // CheckIdentity(identity);

            // check if user has tenant
            User user = IdentityProvider.GetUser(userId);
            if (!user.ExtensionData.ContainsKey("tenantId"))
                throw new InvalidOperationException("user should have tenantId");

            var urlPath = string.Format("/v2.0/tenants/{0}/users/{1}/roles", user.ExtensionData["tenantId"], userId);
            var response = ExecuteRESTRequest<RolesResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Roles;
        }


        /// <inheritdoc/>
        public virtual bool AddRoleToUser(string userId, string roleId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (roleId == null)
                throw new ArgumentNullException("roleId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(roleId))
                throw new ArgumentException("roleId cannot be empty");
            CheckIdentity(identity);

            User user = IdentityProvider.GetUser(userId);
            if (!user.ExtensionData.ContainsKey("tenantId"))
                throw new InvalidOperationException("user should have tenantId");

            var urlPath = string.Format("/v2.0/tenants/{0}/users/{1}/roles/OS-KSADM/{2}", user.ExtensionData["tenantId"], userId, roleId);
            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.PUT);

            // If the response status code is 409, that mean the user is already apart of the role, so we want to return true;
            if (response == null || (response.StatusCode >= HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.Conflict))
                return false;

            return true;
        }

        /// <inheritdoc/>
        public virtual bool DeleteRoleFromUser(string userId, string roleId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (roleId == null)
                throw new ArgumentNullException("roleId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(roleId))
                throw new ArgumentException("roleId cannot be empty");
            CheckIdentity(identity);

            User user = IdentityProvider.GetUser(userId);
            if (!user.ExtensionData.ContainsKey("tenantId"))
                throw new InvalidOperationException("user should have tenantId");

            var urlPath = string.Format("/v2.0/tenants/{0}/users/{1}/roles/OS-KSADM/{2}", user.ExtensionData["tenantId"], userId, roleId);
            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.DELETE);

            if (response != null && response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<User> ListUsersByRole(string roleId, bool? enabled = null, int? marker = null, int? limit = null, CloudIdentity identity = null)
        {
            if (limit < 0 || limit > 1000)
                throw new ArgumentOutOfRangeException("limit");

            CheckIdentity(identity);

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"enabled", !enabled.HasValue ? null : enabled.Value ? "true" : "false"},
                    {"marker", !marker.HasValue ? null : marker.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                });

            var urlPath = string.Format("/v2.0/OS-KSADM/roles/{0}/RAX-AUTH/users", roleId);
            var response = ExecuteRESTRequest<UsersResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;
            // Due to the fact the sometimes the API returns a JSON array of users and sometimes it returns a single JSON user object.
            // Therefore if we get a null data object (which indicates that the deserializer could not parse to an array) we need to try and parse as a single User object.
            if (response.Data.Users == null)
            {
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(response.RawBody);

                if (response == null || response.Data == null)
                    return null;

                return new[] { userResponse.User };
            }

            return response.Data.Users;
        }

        #endregion

        #region Credentials

        /// <inheritdoc/>
        public virtual bool SetUserPassword(string userId, string password, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            CheckIdentity(identity);

            var user = GetUser(userId, identity);

            return SetUserPassword(user, password, identity);
        }

        /// <inheritdoc/>
        public virtual bool SetUserPassword(User user, string password, CloudIdentity identity)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentException("user.Id cannot be null or empty");
            if (string.IsNullOrEmpty(user.Username))
                throw new ArgumentException("user.Username cannot be null or empty");
            CheckIdentity(identity);

            return SetUserPassword(user.Id, user.Username, password, identity);
        }

        /// <inheritdoc/>
        public virtual bool SetUserPassword(string userId, string username, string password, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}/OS-KSADM/credentials", userId);
            var request = new SetPasswordRequest(username, password);
            var response = ExecuteRESTRequest<PasswordCredentialResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.POST, request);

            if (response == null || response.StatusCode != HttpStatusCode.Created || response.Data == null)
                return false;

            return response.Data.PasswordCredential.Password.Equals(password);
        }

        /// <inheritdoc/>
        public virtual bool SetUserPasswordByUpdate(string userId, string password, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}", userId);

            var updateUserRequest = string.Format("{{\"user\": {{\"password\": \"{0}\"}}}}", password);
            var response = ExecuteRESTRequest<UserResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.PUT, updateUserRequest);

            // If the response status code is 409, that mean the user is already apart of the role, so we want to return true;
            if (response == null || response.Data == null || (response.StatusCode >= HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.Conflict))
                return false;

            return true;
        }

        /// <inheritdoc/>
        [Obsolete("currently, ConoHa doesn't use OS-KSADM admin extension. use SetUserPasswordByUpdate instead.", true)]
        public virtual IEnumerable<UserCredential> ListUserCredentials(string userId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}/OS-KSADM/credentials", userId);
            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            if (response == null || string.IsNullOrEmpty(response.RawBody))
                return null;

            var jObject = JObject.Parse(response.RawBody);
            var credsArray = (JArray)jObject["credentials"];
            var creds = new List<UserCredential>();

            foreach (JObject jToken in credsArray)
            {
                foreach (JProperty property in jToken.Properties())
                {
                    var cred = (JObject)property.Value;
                    creds.Add(new UserCredential(property.Name, cred["username"].ToString(), cred["apiKey"].ToString()));
                }

            }

            return creds.ToArray();
        }

        /// <inheritdoc/>
        [Obsolete("currently, ConoHa doesn't use OS-KSADM admin extension. use SetUserPasswordByUpdate instead.")]
        public virtual UserCredential GetUserCredential(string userId, string credentialKey, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (credentialKey == null)
                throw new ArgumentNullException("credentialKey");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(credentialKey))
                throw new ArgumentException("credentialKey cannot be empty");
            CheckIdentity(identity);

            var creds = ListUserCredentials(userId, identity);

            var cred = creds.FirstOrDefault(c => c.Name.Equals(credentialKey, StringComparison.OrdinalIgnoreCase));

            return cred;
        }

        /// <summary>
        /// Reset the API key credentials for a user.
        /// </summary>
        /// <param name="userId">The user ID. This is obtained from <see cref="User.Id"/> or <see cref="NewUser.Id"/>.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the <see cref="DefaultIdentity"/> for the current provider instance will be used.</param>
        /// <returns>A <see cref="UserCredential"/> object containing the new API key for the user.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="userId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="userId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">
        /// <para>If the provider does not support the <see href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/Admin_API_Service_Developer_Operations-d1e1357.html">OS-KSADM Admin Extension</see>.</para>
        /// <para>-or-</para>
        /// <para>If the provider does not support the given <paramref name="identity"/> type.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        /// <example>
        /// <para>The following example demonstrates the use of this method. For more information about creating the
        /// provider, see <see cref="CloudIdentityProvider(CloudIdentity)"/>.</para>
        /// <code source="..\Samples\CSharpCodeSamples\IdentityProviderExamples.cs" region="ResetApiKey" language="cs"/>
        /// <code source="..\Samples\VBCodeSamples\IdentityProviderExamples.vb" region="ResetApiKey" language="vbnet"/>
        /// <code source="..\Samples\CPPCodeSamples\IdentityProviderExamples.cpp" region="ResetApiKey" language="cpp"/>
        /// <code source="..\Samples\FSharpCodeSamples\IdentityProviderExamples.fs" region="ResetApiKey" language="fs"/>
        /// </example>
        /// <seealso href="https://www.google.co.jp/search?q=openstack+">Reset API key credentials (ConoHa Cloud Identity Client Developer Guide - API v2.0)</seealso>
        public virtual UserCredential ResetApiKey(string userId, CloudIdentity identity = null)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}/OS-KSADM/credentials/RAX-KSKEY:apiKeyCredentials/RAX-AUTH/reset", userId);
            var response = ExecuteRESTRequest<UserCredentialResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.POST);
            if (response == null || response.Data == null)
                return null;

            return response.Data.UserCredential;
        }

        /// <inheritdoc/>
        public new virtual CloudIdentity DefaultIdentity { get { return base.DefaultIdentity; } }

        /// <inheritdoc/>
        public virtual UserCredential UpdateUserCredentials(string userId, string apiKey, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("apiKey cannot be empty");
            CheckIdentity(identity);

            var user = GetUser(userId, identity);

            return UpdateUserCredentials(user, apiKey, identity);
        }

        /// <inheritdoc/>
        public virtual UserCredential UpdateUserCredentials(User user, string apiKey, CloudIdentity identity)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("apiKey cannot be empty");
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentException("user.Id cannot be null or empty");
            if (string.IsNullOrEmpty(user.Username))
                throw new ArgumentException("user.Username cannot be null or empty");
            CheckIdentity(identity);

            return UpdateUserCredentials(user.Id, user.Username, apiKey, identity);
        }

        /// <inheritdoc/>
        public virtual UserCredential UpdateUserCredentials(string userId, string username, string apiKey, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (username == null)
                throw new ArgumentNullException("username");
            if (apiKey == null)
                throw new ArgumentNullException("apiKey");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("apiKey cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}/OS-KSADM/credentials/RAX-KSKEY:apiKeyCredentials", userId);
            var request = new UpdateUserCredentialRequest(username, apiKey);
            var response = ExecuteRESTRequest<UserCredentialResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.UserCredential;
        }

        /// <inheritdoc/>
        public virtual bool DeleteUserCredentials(string userId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}/OS-KSADM/credentials/RAX-KSKEY:apiKeyCredentials", userId);
            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.DELETE);

            if (response == null || response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }

        #endregion

        #region Users

        /// <inheritdoc/>
        public virtual IEnumerable<User> ListUsers(CloudIdentity identity)
        {
            CheckIdentity(identity);

            var response = ExecuteRESTRequest<UsersResponse>(identity, new Uri(UrlBase, "/v2.0/users"), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            // Due to the fact the sometimes the API returns a JSON array of users and sometimes it returns a single JSON user object.
            // Therefore if we get a null data object (which indicates that the deserializer could not parse to an array) we need to try and parse as a single User object.
            if (response.Data.Users == null)
            {
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(response.RawBody);

                if (response == null || response.Data == null)
                    return null;

                return new[] { userResponse.User };
            }

            return response.Data.Users;
        }

        /// <inheritdoc/>
        public virtual User GetUserByName(string name, CloudIdentity identity)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/users?name={0}", name);
            var response = ExecuteRESTRequest<UserResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.User;
        }

        /// <summary>
        /// Gets the details for users with the specified email address.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the <see cref="DefaultIdentity"/> for the current provider instance will be used.</param>
        /// <returns>A collection of <see cref="User"/> objects describing the users with the specified email address.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="email"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="email"/> is empty.</exception>
        /// <exception cref="NotSupportedException">If the provider does not support the given <paramref name="identity"/> type.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        /// <seealso href="https://www.google.co.jp/search?q=openstack+">Get User by Email (ConoHa Cloud Identity Client Developer Guide - API v2.0)</seealso>
        [Obsolete("this is not supported in JUNO", true)]
        public virtual IEnumerable<User> GetUsersByEmail(string email, CloudIdentity identity)
        {
            if (email == null)
                throw new ArgumentNullException("email");
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/users/?email={0}", EncodeDecodeProvider.Default.UrlEncode(email));
            var response = ExecuteRESTRequest<UsersResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Users;
        }

        /// <inheritdoc/>
        public virtual User GetUser(string id, CloudIdentity identity)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}", id);

            var response = ExecuteRESTRequest<UserResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.GET);

            return response.Data.User;
        }

        /// <inheritdoc/>
        public virtual NewUser AddUser(NewUser user, CloudIdentity identity)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrEmpty(user.Username))
                throw new ArgumentException("user.Username cannot be null or empty");
            if (user.Id != null)
                throw new InvalidOperationException("user.Id must be null");
            CheckIdentity(identity);

            var response = ExecuteRESTRequest<NewUserResponse>(identity, new Uri(UrlBase, "/v2.0/users"), HttpMethod.POST, new AddUserRequest(user));

            if (response == null || response.Data == null)
                return null;

            /*

            // If the user specifies a password, then the password will not be in the response,
            // so we need to fill it in on the return object.
            if (string.IsNullOrEmpty(response.Data.NewUser.Password))
                response.Data.NewUser.Password = user.Password;

            return response.Data.NewUser;

            */
            if (string.IsNullOrEmpty(response.Data.NewUser.Password))
                typeof(NewUser).GetField("<Password>k__BackingField", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(response.Data.NewUser, user.Password);

            return response.Data.NewUser;
        }

        /// <inheritdoc/>
        public NewUserWithTenantId AddUserWithTenantId(NewUserWithTenantId user, CloudIdentity identity)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (user.Id != null)
                throw new InvalidOperationException("user.Id must be null");
            if (user.TenantId == null)
                throw new ArgumentNullException("tenantId");
            if (string.IsNullOrEmpty(user.Name))
                throw new ArgumentException("user.Name cannot be null or empty");
            if (string.IsNullOrEmpty(user.TenantId))
                throw new ArgumentException("tenantId cannot be null or empty");
            CheckIdentity(identity);

            var response = ExecuteRESTRequest<NewUserWithTenantIdResponse>(identity, new Uri(UrlBase, "/v2.0/users"), HttpMethod.POST, new AddNewUserWithTenantIdRequest(user));

            if (response == null || response.Data == null)
                return null;

            return response.Data.NewUser;
        }


        /// <inheritdoc/>
        public virtual User UpdateUser(User user, CloudIdentity identity)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrEmpty(user.Id))
                throw new ArgumentException("user.Id cannot be null or empty");
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/users/{0}", user.Id);

            var updateUserRequest = new UpdateUserRequest(user);
            var response = ExecuteRESTRequest<UserResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.PUT, updateUserRequest);

            // If the response status code is 409, that mean the user is already apart of the role, so we want to return true;
            if (response == null || response.Data == null || (response.StatusCode >= HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.Conflict))
                return null;

            return response.Data.User;
        }

        /// <inheritdoc/>
        public virtual bool DeleteUser(string userId, CloudIdentity identity)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/users/{0}", userId);
            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.DELETE);

            if (response != null && response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        #endregion

        #region Tenants

        /// <inheritdoc/>
        public virtual IEnumerable<Tenant> ListTenants(CloudIdentity identity)
        {
            CheckIdentity(identity);

            var response = ExecuteRESTRequest<ListTenantsResponse>(identity, new Uri(UrlBase, "v2.0/tenants"), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            //IEnumerable<CloudTenant> tenants = response.Data.Tenants;
            //return tenants.Select(t => t.ToTenant());
            return response.Data.Tenants;
        }

        /// <inheritdoc/>
        public Tenant AddTenant(string name, string description, bool enable, CloudIdentity identity)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be empty");
            CheckIdentity(identity);

            var createTenantRequest = new CreateTenantRequest(name, description, enable);
            var response = ExecuteRESTRequest<CreateTenantResponse>(identity, new Uri(UrlBase, "v2.0/tenants"), HttpMethod.POST, createTenantRequest);

            // If the response status code is 409, that mean the user is already apart of the role, so we want to return true;
            if (response == null || response.Data == null || (response.StatusCode >= HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.Conflict))
                return null;

            return response.Data.Tenant;

        }

        /// <inheritdoc/>
        public Tenant UpdateTenant(string tenantId, string name, string description, bool? enable, CloudIdentity identity)
        {
            CheckIdentity(identity);

            var urlPath = string.Format("v2.0/tenants/{0}", tenantId);

            var updateTenantRequest = new UpdateTenantRequest(name, description, enable);
            var response = ExecuteRESTRequest<UpdateTenantResponse>(identity, new Uri(UrlBase, urlPath), HttpMethod.POST, updateTenantRequest);

            // If the response status code is 409, that mean the user is already apart of the role, so we want to return true;
            if (response == null || response.Data == null || (response.StatusCode >= HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.Conflict))
                return null;

            return response.Data.Tenant;
        }

        /// <inheritdoc/>
        public virtual bool DeleteTenant(string tenantId, CloudIdentity identity)
        {
            if (tenantId == null)
                throw new ArgumentNullException("tenantId");
            if (string.IsNullOrEmpty(tenantId))
                throw new ArgumentException("tenantId cannot be empty");
            CheckIdentity(identity);

            var urlPath = string.Format("/v2.0/tenants/{0}", tenantId);
            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, urlPath), HttpMethod.DELETE);

            if (response != null && response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }



        /// <summary>
        /// Lists the endpoints in a tenant's service catalog.
        /// </summary>
        /// <remarks>
        /// <para>This call is part of the <c>OS-KSCATALOG</c> extension to the OpenStack Identity Service V2.</para>
        /// </remarks>
        /// <param name="tenantId">The tenant ID. This is obtained from <see cref="Tenant.Id"/></param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the <see cref="DefaultIdentity"/> for the current provider instance will be used.</param>
        /// <returns>A collection of <see cref="ExtendedEndpoint"/> objects containing endpoint details.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="tenantId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="tenantId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">If the provider does not support the given <paramref name="identity"/> type.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the authentication request failed or the token does not exist.</exception>
        /// <seealso href="http://developer.openstack.org/api-ref-identity-v2.html#os-kscatalog-ext">OS-KSCATALOG admin extension (Identity API v2.0 - OpenStack Complete API Reference)</seealso>
        /// <preliminary/>
        public virtual ReadOnlyCollection<ExtendedEndpoint> ListServiceCatalogEndpoints(string tenantId, CloudIdentity identity)
        {
            if (tenantId == null)
                throw new ArgumentNullException("tenantId");
            if (string.IsNullOrEmpty(tenantId))
                throw new ArgumentException("tenantId cannot be empty");

            CheckIdentity(identity);

            var response = ExecuteRESTRequest<ListEndpointsResponse>(identity, new Uri(UrlBase, string.Format("/v2.0/tenants/{0}/OS-KSCATALOG/endpoints", tenantId)), HttpMethod.GET);

            if (response == null || response.Data == null || response.Data.Endpoints == null)
                return null;

            return new ReadOnlyCollection<ExtendedEndpoint>(response.Data.Endpoints);
        }

        /// <summary>
        /// Gets an endpoint by ID from the service catalog for a tenant.
        /// </summary>
        /// <remarks>
        /// <para>This call is part of the <c>OS-KSCATALOG</c> extension to the OpenStack Identity Service V2.</para>
        /// </remarks>
        /// <param name="tenantId">The tenant ID. This is obtained from <see cref="Tenant.Id"/></param>
        /// <param name="endpointId">The endpoint ID. This is obtained from <see cref="ExtendedEndpoint.Id"/></param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the <see cref="DefaultIdentity"/> for the current provider instance will be used.</param>
        /// <returns>An <see cref="ExtendedEndpoint"/> object containing the endpoint details.</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="tenantId"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endpointId"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <para>If <paramref name="tenantId"/> is empty.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endpointId"/> is empty.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">If the provider does not support the given <paramref name="identity"/> type.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the authentication request failed or the token does not exist.</exception>
        /// <seealso href="http://developer.openstack.org/api-ref-identity-v2.html#os-kscatalog-ext">OS-KSCATALOG admin extension (Identity API v2.0 - OpenStack Complete API Reference)</seealso>
        /// <preliminary/>
        public virtual ExtendedEndpoint GetServiceCatalogEndpoint(string tenantId, string endpointId, CloudIdentity identity)
        {
            if (tenantId == null)
                throw new ArgumentNullException("tenantId");
            if (endpointId == null)
                throw new ArgumentNullException("endpointId");
            if (string.IsNullOrEmpty(tenantId))
                throw new ArgumentException("tenantId cannot be empty");
            if (string.IsNullOrEmpty(endpointId))
                throw new ArgumentException("endpointId cannot be empty");

            CheckIdentity(identity);

            var response = ExecuteRESTRequest<GetEndpointResponse>(identity, new Uri(UrlBase, string.Format("/v2.0/tenants/{0}/OS-KSCATALOG/endpoints/{1}", tenantId, endpointId)), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Endpoint;
        }

        /// <summary>
        /// Adds an endpoint to the service catalog for a tenant.
        /// </summary>
        /// <remarks>
        /// <para>This call is part of the <c>OS-KSCATALOG</c> extension to the OpenStack Identity Service V2.</para>
        /// </remarks>
        /// <param name="tenantId">The tenant ID. This is obtained from <see cref="Tenant.Id"/></param>
        /// <param name="endpointTemplateId">The endpoint template ID.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the <see cref="DefaultIdentity"/> for the current provider instance will be used.</param>
        /// <returns>An <see cref="ExtendedEndpoint"/> object containing the endpoint details.</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="tenantId"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endpointTemplateId"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="tenantId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">If the provider does not support the given <paramref name="identity"/> type.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the authentication request failed or the token does not exist.</exception>
        /// <seealso href="http://developer.openstack.org/api-ref-identity-v2.html#os-kscatalog-ext">OS-KSCATALOG admin extension (Identity API v2.0 - OpenStack Complete API Reference)</seealso>
        /// <preliminary/>
        public virtual ExtendedEndpoint AddServiceCatalogEndpoint(string tenantId, EndpointTemplateId endpointTemplateId, CloudIdentity identity)
        {
            if (tenantId == null)
                throw new ArgumentNullException("tenantId");
            if (endpointTemplateId == null)
                throw new ArgumentNullException("endpointTemplateId");
            if (string.IsNullOrEmpty(tenantId))
                throw new ArgumentException("tenantId cannot be empty");

            CheckIdentity(identity);

            var request = new AddServiceCatalogEndpointRequest(endpointTemplateId);
            var response = ExecuteRESTRequest<GetEndpointResponse>(identity, new Uri(UrlBase, string.Format("/v2.0/tenants/{0}/OS-KSCATALOG/endpoints", tenantId)), HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Endpoint;
        }

        /// <summary>
        /// Removes an endpoint from the service catalog for a tenant.
        /// </summary>
        /// <remarks>
        /// <para>This call is part of the <c>OS-KSCATALOG</c> extension to the OpenStack Identity Service V2.</para>
        /// </remarks>
        /// <param name="tenantId">The tenant Id. This is obtained from <see cref="Tenant.Id"/></param>
        /// <param name="endpointId">The endpoint Id. This is obtained from <see cref="ExtendedEndpoint.Id"/></param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the <see cref="DefaultIdentity"/> for the current provider instance will be used.</param>
        /// <returns><see langword="true"/> if the endpoint was successfully deleted; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="tenantId"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endpointId"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <para>If <paramref name="tenantId"/> is empty.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endpointId"/> is empty.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">If the provider does not support the given <paramref name="identity"/> type.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the authentication request failed or the token does not exist.</exception>
        /// <seealso href="http://developer.openstack.org/api-ref-identity-v2.html#os-kscatalog-ext">OS-KSCATALOG admin extension (Identity API v2.0 - OpenStack Complete API Reference)</seealso>
        /// <preliminary/>
        public virtual bool DeleteServiceCatalogEndpoint(string tenantId, string endpointId, CloudIdentity identity)
        {
            if (tenantId == null)
                throw new ArgumentNullException("tenantId");
            if (endpointId == null)
                throw new ArgumentNullException("endpointId");
            if (string.IsNullOrEmpty(tenantId))
                throw new ArgumentException("tenantId cannot be empty");
            if (string.IsNullOrEmpty(endpointId))
                throw new ArgumentException("endpointId cannot be empty");

            CheckIdentity(identity);

            var response = ExecuteRESTRequest(identity, new Uri(UrlBase, string.Format("/v2.0/tenants/{0}/OS-KSCATALOG/endpoints/{1}", tenantId, endpointId)), HttpMethod.DELETE);

            if (response == null && response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        #endregion

        #region Token and Authentication

        /// <inheritdoc/>
        public virtual IdentityToken GetToken(CloudIdentity identity, bool forceCacheRefresh = false)
        {
            CheckIdentity(identity);

            var auth = GetUserAccess(identity, forceCacheRefresh);

            if (auth == null || auth.Token == null)
                return null;

            return auth.Token;
        }

        /// <inheritdoc/>
        public virtual Task<IdentityToken> GetTokenAsync(CloudIdentity identity, CancellationToken cancellationToken)
        {
            return GetUserAccessAsync(identity, false, cancellationToken)
                .Select(task => task.Result.Token);
        }

        /// <inheritdoc/>
        public virtual UserAccess Authenticate(CloudIdentity identity)
        {
            CheckIdentity(identity);

            return GetUserAccess(identity, true);
        }

        /// <inheritdoc/>
        public virtual Task<UserAccess> AuthenticateAsync(CloudIdentity identity, CancellationToken cancellationToken)
        {
            CheckIdentity(identity);
            return GetUserAccessAsync(identity, true, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual UserAccess GetUserAccess(CloudIdentity identity, bool forceCacheRefresh = false)
        {
            CheckIdentity(identity);

            if (identity == null)
                identity = DefaultIdentity;

            CloudIdentityWithProject identityWithProject = identity as CloudIdentityWithProject;
            string projectId = (identityWithProject == null) ? string.Empty : identityWithProject.ProjectId.Value;

            var userAccess = TokenCache.Get(string.Format("{0}:{1}/{2}", UrlBase, projectId, identity.Username), () =>
            {
                var auth = new AuthRequest(identity);
                var response = ExecuteRESTRequest<AuthenticationResponse>(identity, new Uri(UrlBase, "/v2.0/tokens"), HttpMethod.POST, auth, isTokenRequest: true);


                if (response == null || response.Data == null || response.Data.UserAccess == null || response.Data.UserAccess.Token == null)
                    return null;

                return response.Data.UserAccess;
            }, forceCacheRefresh);

            return userAccess;

        }

        /// <inheritdoc/>
        public virtual Task<UserAccess> GetUserAccessAsync(CloudIdentity identity, bool forceCacheRefresh, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => GetUserAccess(identity, forceCacheRefresh), cancellationToken);
        }

        /// <summary>
        /// Converts a collection of <see cref="ExtendedEndpoint"/> objects describing service endpoints
        /// for an impersonated identity to a collection of <see cref="ServiceCatalog"/> objects used by
        /// the provider implementations for endpoint resolution.
        /// </summary>
        /// <param name="endpoints">A collection of <see cref="ExtendedEndpoint"/> objects describing the available endpoints.</param>
        /// <returns>A collection of <see cref="ServiceCatalog"/> objects describing the same endpoints as <paramref name="endpoints"/>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="endpoints"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="endpoints"/> contains any <see langword="null"/> values.</exception>
        protected virtual ServiceCatalog[] BuildServiceCatalog(IEnumerable<ExtendedEndpoint> endpoints)
        {
            if (endpoints == null)
                throw new ArgumentNullException("endpoints");
            if (endpoints.Contains(null))
                throw new ArgumentException("endpoints cannot contain any null values", "endpoints");

            var serviceCatalog = new List<ServiceCatalog>();
            var services = endpoints.Select(e => Tuple.Create(e.Type, e.Name)).Distinct();

            foreach (var service in services)
            {
                string type = service.Item1;
                string name = service.Item2;
                IEnumerable<ExtendedEndpoint> serviceEndpoints = endpoints.Where(endpoint => string.Equals(type, endpoint.Type, StringComparison.OrdinalIgnoreCase) && string.Equals(name, endpoint.Name, StringComparison.OrdinalIgnoreCase));
                serviceCatalog.Add(new ServiceCatalog(name, type, serviceEndpoints.ToArray()));
            }

            return serviceCatalog.ToArray();
        }

        /// <inheritdoc/>
        public virtual UserAccess ValidateToken(string token, string tenantId = null, CloudIdentity identity = null)
        {
            if (token == null)
                throw new ArgumentNullException("token");
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("token cannot be empty");

            var queryStringParameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"belongsTo", tenantId}
                });

            var response = ExecuteRESTRequest<AuthenticationResponse>(identity, new Uri(UrlBase, string.Format("/v2.0/tokens/{0}", token)), HttpMethod.GET, queryStringParameter: queryStringParameters);


            if (response == null || response.Data == null || response.Data.UserAccess == null || response.Data.UserAccess.Token == null)
                return null;

            return response.Data.UserAccess;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<ExtendedEndpoint> ListEndpoints(string token, CloudIdentity identity = null)
        {
            if (token == null)
                throw new ArgumentNullException("token");
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("token cannot be empty");

            var response = ExecuteRESTRequest<ListEndpointsResponse>(identity, new Uri(UrlBase, string.Format("/v2.0/tokens/{0}/endpoints", token)), HttpMethod.GET, isTokenRequest: true);


            if (response == null || response.Data == null)
                return null;

            return response.Data.Endpoints;
        }

        /// <summary>
        /// ConoHa only use.
        /// </summary>
        public virtual InternalUser AddInternalUserWithTenantId(string userName, string tenantId, CloudIdentity identity)
        {
            if (userName == null)
                throw new ArgumentNullException("user");
            if (tenantId == null)
                throw new ArgumentNullException("tenantId");
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName cannot be null or empty");
            if (String.IsNullOrEmpty(tenantId))
                throw new InvalidOperationException("tenantId cannot be null or empty");
            CheckIdentity(identity);

            string request = String.Format("{{\"user\": {{\"name\": \"{0}\",\"tenantId\": \"{1}\"}}}}", userName, tenantId);
            var response = ExecuteRESTRequest<InternalUserResponse>(identity, new Uri(UrlBase, "/v2.0/int-users"), HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.User;
        }

        /// <summary>
        /// ConoHa only use.
        /// </summary>
        public virtual UserAccess GetInternalUserAccess(CloudIdentity identity, bool forceCacheRefresh = false)
        {
            CheckIdentity(identity);

            if (identity == null)
                identity = DefaultIdentity;

            CloudIdentityWithProject identityWithProject = identity as CloudIdentityWithProject;
            string projectId = (identityWithProject == null) ? string.Empty : identityWithProject.ProjectId.Value;

            var userAccess = TokenCache.Get(string.Format("{0}:{1}/{2}", UrlBase, projectId, identity.Username), () =>
            {
                if (identity.Password != null) identity.Password = null;
                var auth = new AuthRequest(identity);
                var response = ExecuteRESTRequest<AuthenticationResponse>(identity, new Uri(UrlBase, "/v2.0/int-tokens"), HttpMethod.POST, auth, isTokenRequest: true);


                if (response == null || response.Data == null || response.Data.UserAccess == null || response.Data.UserAccess.Token == null)
                    return null;

                return response.Data.UserAccess;
            }, forceCacheRefresh);

            return userAccess;

        }

        /// <summary>
        /// Constructs the JSON representation used for an impersonation request.
        /// </summary>
        /// <param name="userName">The username of the user to impersonate.</param>
        /// <param name="expirationInSeconds">The time until the impersonation token will expire.</param>
        /// <returns>A <see cref="JObject"/> representing the JSON body of the impersonation request.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="userName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="userName"/> is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="expirationInSeconds"/> is less than or equal to 0.</exception>
        protected virtual JObject BuildImpersonationRequestJson(string userName, int expirationInSeconds)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName cannot be empty");
            if (expirationInSeconds <= 0)
                throw new ArgumentOutOfRangeException("expirationInSeconds");

            return new JObject(
                new JProperty("RAX-AUTH:impersonation", new JObject(
                    new JProperty("user", new JObject(
                        new JProperty("username", userName),
                        new JProperty("expire-in-seconds", expirationInSeconds))))));
        }

        #endregion

        #region

        /// <summary>
        /// Gets the list of same tenant users
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public virtual IEnumerable<User> ListTenantUsers(string tenantId, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var response = ExecuteRESTRequest<UsersResponse>(identity, new Uri(UrlBase, string.Format("/v2.0/tenants/{0}/users", tenantId)), HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            if (response.Data.Users == null)
            {
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(response.RawBody);

                if (response == null || response.Data == null)
                    return null;

                return new[] { userResponse.User };
            }

            return response.Data.Users;
        }

        #endregion

    }
}
