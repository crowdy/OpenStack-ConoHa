namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using Objects.Dns;
    using Objects;
    using JSIStudios.SimpleRESTServices.Client.Json;


    /// <summary>
    /// Represents a provider for the OpenStack Networking service.
    /// </summary>
    public interface ICloudDnsProvider
    {
        /// <summary>
        /// Gets the version of service provider
        /// </summary>
        DnsServiceVersion GetDnsServiceVersion();

        #region Domains

        /// <summary>
        /// Gets the collection of DNS service details
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-get-servers-hosting-a-domain.html"/>
        IEnumerable<DnsServer> GetDnsServiceDetails(string domainId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the collection of domains
        /// </summary>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-list-domains.html"/>
        IEnumerable<Domain> ListDomains(string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Registers a domain to the DNS service
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="email"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslb"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-create-domain.html"/>
        Domain CreateDomain(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the domain with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-delete-a-domain.html"/>
        bool DeleteDomain(string domainId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the domain details with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-get-a-domain.html"/>
        Domain GetDomain(string domainId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the domain resources
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="domainName"></param>
        /// <param name="email"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslb"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-update-a-domain.html"/>
        Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this is not supported
        /// </summary>
        IEnumerable<Domain> SearchDomain(string domainName, string region = null, CloudIdentity identity = null);

        #endregion

        #region Records

        /// <summary>
        /// Gets the list of DNS records with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-list-records-in-a-domain.html"/>
        IEnumerable<DnsRecord> ListDnsRecords(string domainId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Creates a DNS record
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslbRegion"></param>
        /// <param name="gslbWeight"></param>
        /// <param name="gslbCheck"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-create-record.html"/>
        DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the DNS record with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-delete-a-record.html"/>
        bool DeleteDnsRecord(string domainId, string recordId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the DNS record with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-get-a-record.html"/>
        DnsRecord GetDnsRecord(string domainId, string recordId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the DNS record details
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslbRegion"></param>
        /// <param name="gslbWeight"></param>
        /// <param name="gslbCheck"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-update-a-record.html"/>
        DnsRecord UpdateDnsRecord(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null, CloudIdentity identity = null);

        #endregion

        #region Zone

        /// <summary>
        /// Imports zone data
        /// </summary>
        /// <param name="zoneContent"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-import-zone.html"/>
        Zone ImportZone(string zoneContent, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Exports zone data
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-export-zone.html"/>
        string ExportZone(string zoneId, string region = null, CloudIdentity identity = null);

        #endregion

        /// <summary>
        /// this command is for staff only. 
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool SetGslbSuspend(string domainId, bool enabled, string region = null, CloudIdentity identity = null);

    }


    /// <summary>
    /// <para>The Cloud Networks Provider enable simple access to the ConoHa Cloud Network Services.
    /// Cloud Networks lets you create a virtual Layer 2 network, known as an isolated network,
    /// which gives you greater control and security when you deploy web applications.</para>
    /// <para />
    /// <para>Documentation URL: https://www.google.co.jp/search?q=openstack+</para>
    /// </summary>
    /// <see cref="ICloudDnsProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudDnsProvider : ProviderBase<ICloudDnsProvider>, ICloudDnsProvider
    {
        private readonly HttpStatusCode[] _validResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFilesProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudDnsProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudDnsProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudDnsProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudDnsProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudDnsProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudDnsProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudDnsProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudDnsProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudDnsProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
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
        public CloudDnsProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService, bool isAdminMode)
            : base(identity, defaultRegion, identityProvider, restService, null, isAdminMode)
        { }

        /// <summary>
        /// not implemented
        /// </summary>
        public DnsServiceVersion GetDnsServiceVersion()
        {
            throw new NotImplementedException();
        }


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
            return base.GetPublicServiceEndpoint(identity, "dns", "Dns Service", region ?? base.DefaultRegion ?? "tyo1");
        }

        #endregion


        #region Domains

        /// <inheritdoc/>
        public IEnumerable<DnsServer> GetDnsServiceDetails(string domainId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}/servers", GetServiceEndpoint(identity, region), domainId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<GetDnsServiceDetailsResponse>(identity, urlPath, HttpMethod.GET, settings: defaultSettings);

            if (response == null || response.Data == null || response.Data.DnsServers == null)
                return null;

            return response.Data.DnsServers;
        }

        /// <inheritdoc/>
        public IEnumerable<Domain> ListDomains(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains", GetServiceEndpoint(identity, region)));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<ListDomiansResponse>(identity, urlPath, HttpMethod.GET, settings: defaultSettings);

            if (response == null || response.Data == null || response.Data.Domains == null)
                return null;

            return response.Data.Domains;
        }

        /// <inheritdoc/>
        public Domain CreateDomain(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, string region = null, CloudIdentity identity = null)
        {
            if (domainName == null)
                throw new ArgumentNullException("domainName");
            if (string.IsNullOrEmpty(domainName))
                throw new ArgumentException("domainName cannot be empty");
            if (!domainName.EndsWith("."))
                throw new ArgumentException("domainName must ends with period(.)");
            if (email == null)
                throw new ArgumentNullException("email");
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email cannot be empty");
            if (ttl.HasValue && ttl < 3600)
                throw new ArgumentOutOfRangeException("ttl must be 3600 and more");
            if (gslb.HasValue && (gslb != 0 && gslb != 1))
                throw new ArgumentException("gslb must be 0 or 1");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains", GetServiceEndpoint(identity, region)));

            var parameters = new Dictionary<string, object>()
                {
                    {"name", domainName },
                    {"ttl", ttl },
                    {"email", email },
                    {"description", string.IsNullOrEmpty(description) ? null : description },
                };
            if (gslb != null) parameters.Add("gslb", gslb);

            var response = ExecuteRESTRequest<Domain>(identity, urlPath, HttpMethod.POST, parameters);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public bool DeleteDomain(string domainId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}", GetServiceEndpoint(identity, region), domainId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public Domain GetDomain(string domainId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}", GetServiceEndpoint(identity, region), domainId));

            var response = ExecuteRESTRequest<Domain>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            if (!string.IsNullOrEmpty(domainName) && !domainName.EndsWith("."))
                throw new ArgumentException("domainName must ends with period(.)");
            if (ttl.HasValue && ttl < 3600)
                throw new ArgumentOutOfRangeException("ttl must be 3600 and more");
            if (gslb.HasValue && (gslb != 0 && gslb != 1))
                throw new ArgumentException("gslb must be 0 or 1");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}", GetServiceEndpoint(identity, region), domainId));

            var request = new UpdateDomainRequest(domainName, email, ttl, description, gslb);

            var response = ExecuteRESTRequest<Domain>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data;
        }


        /// <inheritdoc/>
        public IEnumerable<Domain> SearchDomain(string domainName, string region = null, CloudIdentity identity = null)
        {

            if (!string.IsNullOrEmpty(domainName) && !domainName.EndsWith("."))
                throw new ArgumentException("domainName must ends with period(.)");

            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/staff/domains", GetServiceEndpoint(identity, region)));
            var queryParams = new Dictionary<string, string>() { { "name", domainName }, };
            var response = ExecuteRESTRequest<ListDomiansResponse>(identity, urlPath, HttpMethod.GET, null, queryParams);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Domains;
        }

        #endregion


        #region Records

        /// <inheritdoc/>
        public IEnumerable<DnsRecord> ListDnsRecords(string domainId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}/records", GetServiceEndpoint(identity, region), domainId));

            var response = ExecuteRESTRequest<ListDnsRecordsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null || response.Data.DnsRecords == null)
                return null;

            return response.Data.DnsRecords;
        }

        /// <inheritdoc/>
        public DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be empty");
            if (type == null)
                throw new ArgumentNullException("type");
            if (string.IsNullOrEmpty(type))
                throw new ArgumentException("type cannot be empty");
            if (data == null)
                throw new ArgumentNullException("data");
            if (string.IsNullOrEmpty(data))
                throw new ArgumentException("data cannot be empty");
            if (ttl.HasValue && ttl < 3600)
                throw new ArgumentException("ttl must be 3600 and more");
            if (gslbWeight.HasValue && (gslbWeight < 0 || gslbWeight > 255))
                throw new ArgumentException("gslbWeight must be 0~255");
            if (gslbCheck.HasValue && (gslbCheck < 0 || gslbCheck > 65535))
                throw new ArgumentException("gslbWeight must be 0~65535");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}/records", GetServiceEndpoint(identity, region), domainId));

            var request = new CreateDnsRecordRequest(name, type, priority, ttl, data, description, gslbRegion, gslbWeight, gslbCheck);

            var response = ExecuteRESTRequest<DnsRecord>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public bool DeleteDnsRecord(string domainId, string recordId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            if (recordId == null)
                throw new ArgumentNullException("recordId");
            if (string.IsNullOrEmpty(recordId))
                throw new ArgumentException("recordId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}/records/{2}", GetServiceEndpoint(identity, region), domainId, recordId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public DnsRecord GetDnsRecord(string domainId, string recordId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            if (recordId == null)
                throw new ArgumentNullException("recordId");
            if (string.IsNullOrEmpty(recordId))
                throw new ArgumentException("recordId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}/records/{2}", GetServiceEndpoint(identity, region), domainId, recordId));

            var response = ExecuteRESTRequest<DnsRecord>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null || response.Data == null)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public DnsRecord UpdateDnsRecord(string domainId, string recordId, string name = null, string type = null, string data = null, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            if (recordId == null)
                throw new ArgumentNullException("recordId");
            if (string.IsNullOrEmpty(recordId))
                throw new ArgumentException("recordId cannot be empty");
            if (ttl.HasValue && ttl < 3600)
                throw new ArgumentException("ttl must be 3600 and more");
            if (priority.HasValue && (priority < 0 || priority > 65535))
                throw new ArgumentOutOfRangeException("priority must be 0~65535");
            if (gslbWeight.HasValue && (gslbWeight < 0 || gslbWeight > 255))
                throw new ArgumentOutOfRangeException("gslbWeight must be 0~255");
            if (gslbCheck.HasValue && (gslbCheck < 0 || gslbCheck > 65535))
                throw new ArgumentOutOfRangeException("gslbCheck must be 0~65535");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/domains/{1}/records/{2}", GetServiceEndpoint(identity, region), domainId, recordId));

            var request = new CreateDnsRecordRequest(name, type, priority, ttl, data, description, gslbRegion, gslbWeight, gslbCheck);

            var response = ExecuteRESTRequest<DnsRecord>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data;
        }

        #endregion


        #region Zone

        /// <inheritdoc/>
        public Zone ImportZone(string zoneContent, string region = null, CloudIdentity identity = null)
        {
            if (string.IsNullOrEmpty(zoneContent))
                throw new ArgumentException("zoneContent cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/zones", GetServiceEndpoint(identity, region)));

            var response = ExecuteRESTRequest<Zone>(identity, urlPath, HttpMethod.POST, zoneContent, null, new Dictionary<string, string> { { "Content-type", "text/dns" } });

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.Created)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public string ExportZone(string zoneId, string region = null, CloudIdentity identity = null)
        {
            if (zoneId == null)
                throw new ArgumentNullException("zoneId");
            if (string.IsNullOrEmpty(zoneId))
                throw new ArgumentException("zoneId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/zones/{1}", GetServiceEndpoint(identity, region), zoneId));

            var response = ExecuteRESTRequest<string>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data;
        }

        #endregion


        /// <inheritdoc/>
        public bool SetGslbSuspend(string domainId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v1/gslb_suspend/{1}", GetServiceEndpoint(identity, region), domainId));

            var request = new Dictionary<string, string> { { "gslb_suspend", (enabled ? "enable" : "disable") } };
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

    }
}
