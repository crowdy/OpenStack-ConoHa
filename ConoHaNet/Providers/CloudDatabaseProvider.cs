namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using Objects.Database;
    using Objects;
    using JSIStudios.SimpleRESTServices.Client.Json;

    /// <summary>
    /// Represents a provider for the OpenStack Networking service.
    /// </summary>
    public interface ICloudDatabaseProvider
    {
        /// <summary>
        /// Gets version of the provider
        /// </summary>
        DatabaseServiceVersion GetVersion();

        /// <summary>
        /// Gets the details of the provider
        /// </summary>
        DatabaseServiceVersion GetVersionDetails();

        #region Services

        /// <summary>
        /// Create a DB service
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-service.html"/>
        DbService CreateDbService(string serviceName, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of DB service
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database-service.html"/>
        IEnumerable<DbService> ListDbServices(int? offset = null, int? limit = null, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the DB service with service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database-service.html"/>
        DbService GetDbService(string serviceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the DB service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-update-database-service.html"/>
        DbService UpdateDbService(string serviceId, string serviceName, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the DB Service with service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-database-service.html"/>
        bool DeleteDbService(string serviceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the value of DB service quota
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database-quotas.html"/>
        DbServiceQuota GetDbServiceQuota(string serviceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Update the value of DB service quota
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="quota"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-update-database-quotas.html"/>
        DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Sets DB service backup 
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-backup.html"/>
        bool SetDbServiceBackup(string databaseId, bool enabled, string region = null, CloudIdentity identity = null);

        #endregion

        #region Databases

        /// <summary>
        /// Creates a database in the DB service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="dbName"></param>
        /// <param name="type"></param>
        /// <param name="charset"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database.html"/>
        Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of database
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database.html"/>
        IEnumerable<Database> ListDatabases(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the database with database id
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database.html"/>
        Database GetDatabase(string databaseId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the database
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-backup.html"/>
        Database UpdateDatabase(string databaseId, string memo = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the database with database id
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-databases.html"/>
        bool DeleteDatabase(string databaseId, string region = null, CloudIdentity identity = null);

        #endregion

        #region DbGrant

        /// <summary>
        /// Create a database grant data
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-grant.html"/>
        DbGrant CreateDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Get the list of a database grant data
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-grant.html"/>
        IEnumerable<DbGrant> ListDbGrant(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the database grant data with userid
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-grant.html"/>
        bool DeleteDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null);

        #endregion

        #region Backups

        /// <summary>
        /// Gets the list of the database backups
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database-backup.html"/>
        IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Restores the database with backup id
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-restore-database-backup.html"/>
        bool RestoreDatabase(string databaseId, string backupId, string region = null, CloudIdentity identity = null);

        #endregion

        #region DbUsers

        /// <summary>
        /// Creates a database user
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hostname"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-account.html"/>
        DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of database user
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database-account.html"/>
        IEnumerable<DbUser> ListDbUsers(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Get the database user with userid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database-account.html"/>
        DbUser GetDbUser(string userId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the database user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-update-database-account.html"/>
        DbUser UpdateDbUser(string userId, string password = null, string memo = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the database user with userid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-database-account.html"/>
        bool DeleteDbUser(string userId, string region = null, CloudIdentity identity = null);

        #endregion

        /// <summary>
        /// command for staff only.
        /// </summary>
        bool SetDbServiceStatus(string serviceId, bool enabled, string region = null, CloudIdentity identity = null);
    }


    /// <summary>
    /// <para>The Cloud Networks Provider enable simple access to the ConoHa Cloud Network Services.
    /// Cloud Networks lets you create a virtual Layer 2 network, known as an isolated network,
    /// which gives you greater control and security when you deploy web applications.</para>
    /// <para />
    /// <para>Documentation URL: https://www.google.co.jp/search?q=openstack+</para>
    /// </summary>
    /// <see cref="ICloudDatabaseProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudDatabaseProvider : ProviderBase<ICloudDatabaseProvider>, ICloudDatabaseProvider
    {
        private readonly HttpStatusCode[] _validResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted, HttpStatusCode.NonAuthoritativeInformation, HttpStatusCode.NoContent };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFilesProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudDatabaseProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudDatabaseProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudDatabaseProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudDatabaseProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudDatabaseProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudDatabaseProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudDatabaseProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDatabaseProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudDatabaseProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, defaultRegion, identityProvider, restService, false)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="defaultRegion"></param>
        /// <param name="identityProvider"></param>
        /// <param name="restService"></param>
        /// <param name="isAdminMode"></param>
        public CloudDatabaseProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService, bool isAdminMode)
            : base(identity, defaultRegion, identityProvider, restService, null, isAdminMode)
        { }


        #endregion


        #region Private methods

        /// <summary>
        /// Gets the public service endpoint to use for Cloud Networks requests for the specified identity and region.
        /// </summary>
        /// <remarks>
        /// This method uses <c>compute</c> for the service type, and <c>cloudServersOpenStack</c> for the preferred service name.
        /// </remarks>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <param name="region">The preferred region for the service. If this value is <see langword="null"/>, the user's default region will be used.</param>
        /// <returns>The public URL for the requested Cloud Networks endpoint.</returns>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// </exception>
        /// <exception cref="net.openstack.Core.Exceptions.NoDefaultRegionSetException">If <paramref name="region"/> is <see langword="null"/> and no default region is available for the identity or provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.UserAuthenticationException">If no service catalog is available for the user.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.UserAuthorizationException">If no endpoint is available for the requested service.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected string GetServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetPublicServiceEndpoint(identity, "databasehosting", "Database Hosting Service", region ?? base.DefaultRegion ?? "tyo1");
        }

        #endregion


        /// <summary>
        /// not implemented
        /// </summary>
        public DatabaseServiceVersion GetVersion()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// not implemented
        /// </summary>
        public DatabaseServiceVersion GetVersionDetails()
        {
            throw new NotImplementedException();
        }


        #region Services

        /// <inheritdoc/>
        public DbService CreateDbService(string serviceName, string region = null, CloudIdentity identity = null)
        {
            if (serviceName == null)
                throw new ArgumentNullException("serviceName");
            if (string.IsNullOrEmpty(serviceName))
                throw new ArgumentException("serviceName cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services", GetServiceEndpoint(identity, region)));

            var request = new Dictionary<string, string>() { { "service_name", serviceName } };
            var response = ExecuteRESTRequest<GetDbServiceResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null || response.Data.Service == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Service;
        }

        /// <inheritdoc/>
        public IEnumerable<DbService> ListDbServices(int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services", GetServiceEndpoint(identity, region)));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<ListDbServicesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null || response.Data.Services == null)
                return null;

            return response.Data.Services;
        }

        /// <inheritdoc/>
        public DbService GetDbService(string serviceId, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}", GetServiceEndpoint(identity, region), serviceId));

            var response = ExecuteRESTRequest<GetDbServiceResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Service;
        }

        /// <inheritdoc/>
        public DbService UpdateDbService(string serviceId, string serviceName, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            if (serviceName == null)
                throw new ArgumentNullException("serviceName");
            if (string.IsNullOrEmpty(serviceName))
                throw new ArgumentException("serviceName cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}", GetServiceEndpoint(identity, region), serviceId));

            var request = new Dictionary<string, string>() { { "service_name", serviceName } };
            var response = ExecuteRESTRequest<GetDbServiceResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Service;
        }

        /// <inheritdoc/>
        public bool DeleteDbService(string serviceId, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}", GetServiceEndpoint(identity, region), serviceId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public DbServiceQuota GetDbServiceQuota(string serviceId, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/quotas", GetServiceEndpoint(identity, region), serviceId));

            var response = ExecuteRESTRequest<GetDbServiceQuotaResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.DbServiceQuota;
        }

        /// <inheritdoc/>
        public DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            if (quota <= 0)
                throw new ArgumentOutOfRangeException("quota");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/quotas", GetServiceEndpoint(identity, region), serviceId));

            var requestJson = new UpdateDbServiceQuotaRequest(quota);
            var response = ExecuteRESTRequest<GetDbServiceQuotaResponse>(identity, urlPath, HttpMethod.PUT, requestJson);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.DbServiceQuota;
        }

        /// <inheritdoc/>
        public bool SetDbServiceBackup(string serviceId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/action", GetServiceEndpoint(identity, region), serviceId));

            var request = new SetDbServiceBackupRequest(enabled ? "enable" : "disable");
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        #endregion


        #region Databases

        /// <inheritdoc/>
        public Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases", GetServiceEndpoint(identity, region)));

            var requestJson = new CreateDatabaseRequest(serviceId, dbName, type, charset, memo);
            var response = ExecuteRESTRequest<GetDatabaseResponse>(identity, urlPath, HttpMethod.POST, requestJson);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Database;
        }

        /// <inheritdoc/>
        public IEnumerable<Database> ListDatabases(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases", GetServiceEndpoint(identity, region)));

            var parameters = new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                };

            if (!string.IsNullOrEmpty(serviceId))
                parameters.Add("service_id", serviceId);

            var response = ExecuteRESTRequest<ListDatabasesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: BuildOptionalParameterList(parameters));

            if (response == null || response.Data == null || response.Data.Databases == null)
                return null;

            return response.Data.Databases;
        }

        /// <inheritdoc/>
        public Database GetDatabase(string databaseId, string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}", GetServiceEndpoint(identity, region), databaseId));

            var response = ExecuteRESTRequest<GetDatabaseResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Database;
        }

        /// <inheritdoc/>
        public Database UpdateDatabase(string databaseId, string memo = null, string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}", GetServiceEndpoint(identity, region), databaseId));

            var request = new Dictionary<string, string>() { { "memo", memo } };
            var response = ExecuteRESTRequest<GetDatabaseResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Database;
        }

        /// <inheritdoc/>
        public bool DeleteDatabase(string databaseId, string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}", GetServiceEndpoint(identity, region), databaseId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        #endregion


        #region Grant

        /// <inheritdoc/>
        public DbGrant CreateDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}/grant", GetServiceEndpoint(identity, region), databaseId));

            var request = new Dictionary<string, string> { { "user_id", userId } };
            var response = ExecuteRESTRequest<CreateDbGrantResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Grant;
        }

        /// <inheritdoc/>
        public IEnumerable<DbGrant> ListDbGrant(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}/grant", GetServiceEndpoint(identity, region), databaseId));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<ListDbGrantResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Grant;
        }

        /// <inheritdoc/>
        public bool DeleteDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}/grant/{2}", GetServiceEndpoint(identity, region), databaseId, userId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        #endregion


        #region Backups

        /// <inheritdoc/>
        public IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}/backup", GetServiceEndpoint(identity, region), databaseId));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<ListDbBackupsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null || response.Data.Backups == null)
                return null;

            return response.Data.Backups;
        }

        /// <inheritdoc/>
        public bool RestoreDatabase(string databaseId, string backupId, string region = null, CloudIdentity identity = null)
        {
            if (databaseId == null)
                throw new ArgumentNullException("databaseId");
            if (string.IsNullOrEmpty(databaseId))
                throw new ArgumentException("databaseId cannot be empty");
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/databases/{1}/action", GetServiceEndpoint(identity, region), databaseId));

            var requestJson = new RestoreDatabaseRequest(backupId);
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.POST, requestJson);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        #endregion


        #region Database_Users

        /// <inheritdoc/>
        public DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            if (username == null)
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            if (hostname == null)
                throw new ArgumentNullException("hostname");
            if (string.IsNullOrEmpty(hostname))
                throw new ArgumentException("hostname cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/users", GetServiceEndpoint(identity, region)));

            var request = new CreateDbUserRequest(serviceId, username, password, hostname, memo);
            var response = ExecuteRESTRequest<GetDbUserResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null || response.Data.User == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.User;
        }

        /// <inheritdoc/>
        public IEnumerable<DbUser> ListDbUsers(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/users", GetServiceEndpoint(identity, region)));

            var parameters = new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                };

            if (!string.IsNullOrEmpty(serviceId))
                parameters.Add("service_id", serviceId);

            var response = ExecuteRESTRequest<ListDbUsersResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: BuildOptionalParameterList(parameters));

            if (response == null || response.Data == null || response.Data.Users == null)
                return null;

            return response.Data.Users;
        }

        /// <inheritdoc/>
        public DbUser GetDbUser(string userId, string region = null, CloudIdentity identity = null)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/users/{1}", GetServiceEndpoint(identity, region), userId));

            var response = ExecuteRESTRequest<GetDbUserResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.User;
        }

        /// <inheritdoc/>
        public DbUser UpdateDbUser(string userId, string password = null, string memo = null, string region = null, CloudIdentity identity = null)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/users/{1}", GetServiceEndpoint(identity, region), userId));

            var requestJson = new UpdateDbUserRequest(password, memo);
            var response = ExecuteRESTRequest<GetDbUserResponse>(identity, urlPath, HttpMethod.PUT, requestJson);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.User;
        }

        /// <inheritdoc/>
        public bool DeleteDbUser(string userId, string region = null, CloudIdentity identity = null)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("userId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/users/{1}", GetServiceEndpoint(identity, region), userId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        #endregion

        /// <inheritdoc/>
        public bool SetDbServiceStatus(string serviceId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/action", GetServiceEndpoint(identity, region), serviceId));

            var requestJson = new SetDbServiceStatusRequest(enabled ? "enable" : "disable");
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, requestJson);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

    }
}