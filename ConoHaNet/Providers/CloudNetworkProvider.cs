namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using net.openstack.Core.Exceptions;
    using net.openstack.Core.Exceptions.Response;
    using Objects.Networks;
    using Objects;
    using JSIStudios.SimpleRESTServices.Client.Json;

    /// <summary>
    /// <para>The Cloud Networks Provider enable simple access to the ConoHa Cloud Network Services.
    /// Cloud Networks lets you create a virtual Layer 2 network, known as an isolated network,
    /// which gives you greater control and security when you deploy web applications.</para>
    /// <para />
    /// <para>Documentation URL: https://www.google.co.jp/search?q=openstack+</para>
    /// </summary>
    /// <see cref="INetworksProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudNetworksProvider : ProviderBase<INetworksProvider>, INetworksProvider
    {
        private readonly HttpStatusCode[] _validResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFilesProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudNetworksProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudNetworksProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudNetworksProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudNetworksProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudNetworksProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudNetworksProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudNetworksProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudNetworksProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
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
        public CloudNetworksProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService, bool isAdminMode)
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
        /// <exception cref="NoDefaultRegionSetException">If <paramref name="region"/> is <see langword="null"/> and no default region is available for the identity or provider.</exception>
        /// <exception cref="UserAuthenticationException">If no service catalog is available for the user.</exception>
        /// <exception cref="UserAuthorizationException">If no endpoint is available for the requested service.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected string GetServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetPublicServiceEndpoint(identity, "network", "Network Service", region ?? "tyo1");
        }

        /// <summary>
        /// not used
        /// </summary>
        protected string GetAdminServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetAdminServiceEndpoint(identity, "network", "Network Service", region ?? "tyo1");
        }

        /// <summary>
        /// not used
        /// </summary>
        protected string GetInternalServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetInternalServiceEndpoint(identity, "network", "Network Service", region ?? "tyo1");
        }

        #endregion


        /// <summary>
        /// not used.
        /// </summary>
        [Obsolete("Ignore ListNetworks using os-networksv2 plugin of Compute API", true)]
        public IEnumerable<CloudNetwork> ListNetworks(string region = null, CloudIdentity identity = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// not used.
        /// </summary>
        [Obsolete("Ignore ListNetworks using os-networksv2 plugin of Compute API", true)]
        public CloudNetwork ShowNetwork(string networkId, string region = null, CloudIdentity identity = null)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// not used.
        /// </summary>
        [Obsolete("Ignore ListNetworks using os-networksv2 plugin of Compute API", true)]
        public CloudNetwork CreateNetwork(string cidr, string label, string region = null, CloudIdentity identity = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// not used.
        /// </summary>
        [Obsolete("Ignore ListNetworks using os-networksv2 plugin of Compute API", true)]
        public bool DeleteNetwork(string networkId, string region = null, CloudIdentity identity = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IEnumerable<Network> ListNuetronNetworks(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/networks", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListNetworksResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Networks;
        }

        /// <inheritdoc />
        public Network CreateNuetronNetwork(string name, bool admin_state_up = true, string networkType = "vxlan", string segmentationId = null, string region = null, CloudIdentity identity = null)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be empty");
            CheckIdentity(identity);

            string requestTemplate = @"{{""network"": {{""name"": ""{0}""}} }}";
            string request = String.Format(requestTemplate, name);
            var urlPath = new Uri(string.Format("{0}/v2.0/networks", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreateNetworkResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Network;
        }

        /// <inheritdoc />
        public bool DeleteNuetronNetwork(string networkId, string region = null, CloudIdentity identity = null)
        {
            if (networkId == null)
                throw new ArgumentNullException("networkId");
            if (string.IsNullOrEmpty(networkId))
                throw new ArgumentException("networkId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/networks/{1}", GetServiceEndpoint(identity, region), networkId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete network. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public Network GetNuetronNetwork(string networkId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/networks/{1}", GetServiceEndpoint(identity, region), networkId));
            var response = ExecuteRESTRequest<GetNetworkResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Network;

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IEnumerable<Port> ListPorts(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/ports", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListPortsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Ports;
        }

        /// <inheritdoc />
        public Port GetPort(string portId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/ports/{1}", GetServiceEndpoint(identity, region), portId));
            var response = ExecuteRESTRequest<GetPortResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Port;
        }

        /// <inheritdoc />
        public Port CreatePort(string networkId, FixedIp[] fixedIps = null, Dictionary<string, string> allowedAddressPairs = null, string tenantId = null, string[] securityGroups = null, string status = null, string region = null, CloudIdentity identity = null)
        {
            if (networkId == null)
                throw new ArgumentNullException("networkId");
            if (string.IsNullOrEmpty(networkId))
                throw new ArgumentException("networkId cannot be empty");
            CheckIdentity(identity);

            var newPort = new NewPort(networkId, fixedIps, allowedAddressPairs, tenantId, securityGroups, status);
            var request = new CreatePortRequest() { Port = newPort };
            var urlPath = new Uri(string.Format("{0}/v2.0/ports", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreatePortResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Port;
        }

        /// <inheritdoc />
        public Port UpdatePort(string portId, bool? adminStateUp = null, string[] securityGroups = null, FixedIp[] fixedIps = null, AllowedAddressPair[] allowedAddressPairs = null, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var request = new UpdatePortRequest(portId, adminStateUp, securityGroups, fixedIps, allowedAddressPairs);
            var urlPath = new Uri(string.Format("{0}/v2.0/ports/{1}", GetServiceEndpoint(identity, region), portId));
            var response = ExecuteRESTRequest<CreatePortResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Port;
        }

        /// <inheritdoc />
        public bool DeletePort(string portId, string region = null, CloudIdentity identity = null)
        {
            if (portId == null)
                throw new ArgumentNullException("portId");
            if (string.IsNullOrEmpty(portId))
                throw new ArgumentException("portId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/ports/{1}", GetServiceEndpoint(identity, region), portId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete port. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public IEnumerable<Subnet> ListSubnets(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/subnets", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListSubnetsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Subnets;
        }

        /// <inheritdoc />
        public Subnet GetSubnet(string subnetId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/subnets/{1}", GetServiceEndpoint(identity, region), subnetId));
            var response = ExecuteRESTRequest<GetSubnetResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Subnet;
        }

        /// <inheritdoc />
        public Subnet CreateSubnet(string name, string networkId, int ipVersion, string cidr, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/subnets", GetServiceEndpoint(identity, region)));
            var subnet = new Subnet()
            {
                Name = name,
                NetworkId = networkId,
                IpVersion = ipVersion,
                Cidr = cidr
            };
            var request = new CreateSubnetRequest() { Subnet = subnet };
            var response = ExecuteRESTRequest<CreateSubnetResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Subnet;
        }

        /// <inheritdoc />
        public Subnet UpdateSubnet(string subnetId, string name, string region = null, CloudIdentity identity = null)
        {
            if (subnetId == null)
                throw new ArgumentNullException("subnetId");
            if (string.IsNullOrEmpty(subnetId))
                throw new ArgumentException("subnetId cannot be empty");
            CheckIdentity(identity);

            var request = String.Format("{{ \"subnet\": {{ \"name\": \"{0}\" }} }}", name);
            var urlPath = new Uri(string.Format("{0}/v2.0/subnets/{1}", GetServiceEndpoint(identity, region), subnetId));
            var response = ExecuteRESTRequest<GetSubnetResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Subnet;
        }

        /// <inheritdoc />
        public bool DeleteSubnet(string subnetId, string region = null, CloudIdentity identity = null)
        {
            if (subnetId == null)
                throw new ArgumentNullException("subnetId");
            if (string.IsNullOrEmpty(subnetId))
                throw new ArgumentException("subnetId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/subnets/{1}", GetServiceEndpoint(identity, region), subnetId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);

        }

        /// <inheritdoc />
        public IEnumerable<VIP> ListVIPs(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/vips", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListVIPsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Vips;
        }

        /// <inheritdoc />
        public VIPDetails GetVIP(string vipId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/vips/{1}", GetServiceEndpoint(identity, region), vipId));
            var response = ExecuteRESTRequest<GetVIPResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Vip;
        }

        /// <inheritdoc />
        public VIPDetails CreateVIP(string name, string protocol, string protocolPort, string poolId, string subnetId, string address, bool adminStateUp, string description = null, string sessionPpersistence = null, int? connectionLimit = null, string region = null, CloudIdentity identity = null)
        {
            //if (name == null)
            //    throw new ArgumentNullException("name");
            if (protocol == null)
                throw new ArgumentNullException("protocol");
            if (protocolPort == null)
                throw new ArgumentNullException("protocolPort");
            if (poolId == null)
                throw new ArgumentNullException("poolId");
            if (subnetId == null)
                throw new ArgumentNullException("subnetId");
            if (address == null)
                throw new ArgumentNullException("address");
            //if (string.IsNullOrEmpty(name))
            //    throw new ArgumentException("name cannot be empty");
            if (string.IsNullOrEmpty(protocol))
                throw new ArgumentException("protocol cannot be empty");
            if (string.IsNullOrEmpty(protocolPort))
                throw new ArgumentException("protocolPort cannot be empty");
            if (string.IsNullOrEmpty(poolId))
                throw new ArgumentException("poolId cannot be empty");
            if (string.IsNullOrEmpty(subnetId))
                throw new ArgumentException("subnetId cannot be empty");
            if (string.IsNullOrEmpty(subnetId))
                throw new ArgumentException("subnetId cannot be empty");
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException("address cannot be empty");
            CheckIdentity(identity);

            var v = new VIPDetails()
            {
                Name = name,
                Protocol = protocol,
                ProtocolPort = protocolPort,
                PoolId = poolId,
                SubnetId = subnetId,
                Address = address,
                AdminStateUp = adminStateUp,
                ConnectionLimit = connectionLimit
            };
            var request = new CreateVIPRequest() { Vip = v };
            var urlPath = new Uri(string.Format("{0}/v2.0/lb/vips", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreateVIPRequest>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Vip;
        }

        /// <inheritdoc />
        public VIP UpdateVip(string vipId, string region = null, CloudIdentity identity = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool DeleteVIP(string vipId, string region = null, CloudIdentity identity = null)
        {
            if (vipId == null)
                throw new ArgumentNullException("vipId");
            if (string.IsNullOrEmpty(vipId))
                throw new ArgumentException("vipId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/vips/{1}", GetServiceEndpoint(identity, region), vipId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public IEnumerable<Pool> ListPools(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListPoolsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Pools;
        }

        /// <inheritdoc />
        public Pool GetPool(string poolId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools/{1}", GetServiceEndpoint(identity, region), poolId));
            var response = ExecuteRESTRequest<GetPoolResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Pool;
        }

        /// <inheritdoc />
        public Pool CreatePool(string name, string subnetId, string lbMethod = "ROUND_ROBIN", string protocol = "TCP", string region = null, CloudIdentity identity = null)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (subnetId == null)
                throw new ArgumentNullException("subnetId");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be empty");
            if (string.IsNullOrEmpty(subnetId))
                throw new ArgumentException("subnetId cannot be empty");
            CheckIdentity(identity);

            var pool = new Pool()
            {
                Name = name,
                SubnetId = subnetId,
                LbMethod = lbMethod,
                Protocol = protocol
            };
            var request = new CreatePoolRequest() { Pool = pool };
            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools/", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreatePoolResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Pool;
        }

        /// <inheritdoc />
        public Pool UpdatePool(string poolId, string name = null, string lbMethod = null, string region = null, CloudIdentity identity = null)
        {
            if (poolId == null)
                throw new ArgumentNullException("poolId");
            if (string.IsNullOrEmpty(poolId))
                throw new ArgumentException("poolId cannot be empty");
            CheckIdentity(identity);

            var request = String.Format("{{ \"pool\": {{ \"name\": \"{0}\", \"lb_method\": \"{1}\" }} }}", name, lbMethod);
            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools/{1}", GetServiceEndpoint(identity, region), poolId));
            var response = ExecuteRESTRequest<GetPoolResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Pool;
        }

        /// <inheritdoc />
        public bool DeletePool(string poolId, string region = null, CloudIdentity identity = null)
        {
            if (poolId == null)
                throw new ArgumentNullException("poolId");
            if (string.IsNullOrEmpty(poolId))
                throw new ArgumentException("poolId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools/{1}", GetServiceEndpoint(identity, region), poolId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public IEnumerable<HealthMonitor> ListHealthMonitors(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/health_monitors", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListHealthMonitorsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.HealthMonitors;
        }

        /// <inheritdoc />
        public HealthMonitor GetHealthMonitor(string monitorId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/health_monitors/{1}", GetServiceEndpoint(identity, region), monitorId));
            var response = ExecuteRESTRequest<GetHealthMonitorResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.HealthMonitor;
        }

        /// <inheritdoc />
        public HealthMonitor CreateHealthMonitor(string monitorType, int delay, int maxRetries, string urlPath = null, string expectedCodes = null, string region = null, CloudIdentity identity = null)
        {
            if (monitorType == null)
                throw new ArgumentNullException("monitorType");
            if (string.IsNullOrEmpty(monitorType))
                throw new ArgumentException("monitorType cannot be empty");
            CheckIdentity(identity);

            var monitor = new HealthMonitor()
            {
                Type = monitorType,
                Delay = delay,
                MaxRetries = maxRetries,
                UrlPath = urlPath,
                ExpectedCodes = expectedCodes
            };
            var request = new CreateHealthMonitorRequest() { HealthMonitor = monitor };
            var requestUrlPath = new Uri(string.Format("{0}/v2.0/lb/health_monitors/", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreateHealthMonitorResponse>(identity, requestUrlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.HealthMonitor;
        }

        /// <inheritdoc />
        public HealthMonitor UpdateHealthMonitor(string monitorId, int delay, int maxRetries, string urlPath, string region = null, CloudIdentity identity = null)
        {
            if (monitorId == null)
                throw new ArgumentNullException("monitorId");
            if (string.IsNullOrEmpty(monitorId))
                throw new ArgumentException("monitorId cannot be empty");
            CheckIdentity(identity);

            var request = new UpdateHealthMonitorRequest()
            {
                HealthMonitor = new HealthMonitorUpdate()
                {
                    Delay = delay,
                    MaxRetries = maxRetries,
                    UrlPath = urlPath
                }
            };

            var requestUrlPath = new Uri(string.Format("{0}/v2.0/lb/health_monitors/{1}", GetServiceEndpoint(identity, region), monitorId));
            var response = ExecuteRESTRequest<GetHealthMonitorResponse>(identity, requestUrlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.HealthMonitor;
        }

        /// <inheritdoc />
        public bool DeleteHealthMonitor(string monitorId, string region = null, CloudIdentity identity = null)
        {
            if (monitorId == null)
                throw new ArgumentNullException("monitorId");
            if (string.IsNullOrEmpty(monitorId))
                throw new ArgumentException("monitorId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/health_monitors/{1}", GetServiceEndpoint(identity, region), monitorId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public bool AssociateHealthMonitor(string monitorId, string poolId, string region = null, CloudIdentity identity = null)
        {
            if (monitorId == null)
                throw new ArgumentNullException("monitorId");
            if (string.IsNullOrEmpty(monitorId))
                throw new ArgumentException("monitorId cannot be empty");
            if (poolId == null)
                throw new ArgumentNullException("poolId");
            if (string.IsNullOrEmpty(poolId))
                throw new ArgumentException("poolId cannot be empty");

            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools/{1}/health_monitors", GetServiceEndpoint(identity, region), poolId));

            var request = String.Format("{{ \"health_monitor\": {{ \"id\": \"{0}\" }} }}", monitorId);
            var response = ExecuteRESTRequest<GetPoolResponse>(identity, urlPath, HttpMethod.POST, request);

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public bool DisassociateHealthMonitor(string monitorId, string poolId, string region = null, CloudIdentity identity = null)
        {
            if (monitorId == null)
                throw new ArgumentNullException("monitorId");
            if (string.IsNullOrEmpty(monitorId))
                throw new ArgumentException("monitorId cannot be empty");
            if (poolId == null)
                throw new ArgumentNullException("poolId");
            if (string.IsNullOrEmpty(poolId))
                throw new ArgumentException("poolId cannot be empty");

            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/pools/{1}/health_monitors/{2}", GetServiceEndpoint(identity, region), poolId, monitorId));

            var response = ExecuteRESTRequest<GetPoolResponse>(identity, urlPath, HttpMethod.DELETE);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        /// <inheritdoc />
        public IEnumerable<LBMember> ListLBMembers(string subnetId = null, string poolId = null, string protocolPort = null, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/members", GetServiceEndpoint(identity, region)));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"subnet_id", subnetId},
                    {"pool_id", poolId},
                    {"protocol_port", protocolPort}
                });

            var response = ExecuteRESTRequest<ListLBMembersResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.LBMembers;
        }

        /// <inheritdoc />
        public LBMember GetLBMember(string memberId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/members/{1}", GetServiceEndpoint(identity, region), memberId));
            var response = ExecuteRESTRequest<GetLBMemberResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.LBMember;
        }

        /// <inheritdoc />
        public LBMember CreateLBMember(string poolId, string address, string protocolPort, int weight = 1, string region = null, CloudIdentity identity = null)
        {
            if (poolId == null)
                throw new ArgumentNullException("poolId");
            if (address == null)
                throw new ArgumentNullException("address");
            if (protocolPort == null)
                throw new ArgumentNullException("protocolPort");
            if (string.IsNullOrEmpty(poolId))
                throw new ArgumentException("poolId cannot be empty");
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException("address cannot be empty");
            if (string.IsNullOrEmpty(protocolPort))
                throw new ArgumentException("protocolPort cannot be empty");
            CheckIdentity(identity);

            var m = new LBMember()
            {
                PoolId = poolId,
                Address = address,
                ProtocolPort = protocolPort,
                Weight = weight,
            };
            var request = new CreateLBMemberRequest() { LBMember = m };
            var urlPath = new Uri(string.Format("{0}/v2.0/lb/members/", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreateLBMemberResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.LBMember;
        }

        /// <inheritdoc />
        public LBMember UpdateLBMember(string memberId, int weight, string region = null, CloudIdentity identity = null)
        {
            if (memberId == null)
                throw new ArgumentNullException("memberId");
            if (string.IsNullOrEmpty(memberId))
                throw new ArgumentException("memberId cannot be empty");
            if (weight < 0 || weight > 255) { throw new ArgumentNullException("weight"); }
            CheckIdentity(identity);

            var request = String.Format("{{ \"member\": {{ \"weight\": {0} }} }}", weight);
            var urlPath = new Uri(string.Format("{0}/v2.0/lb/members/{1}", GetServiceEndpoint(identity, region), memberId));
            var response = ExecuteRESTRequest<CreateLBMemberResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.LBMember;
        }

        /// <inheritdoc />
        public bool DeleteLBMember(string memberId, string region = null, CloudIdentity identity = null)
        {
            if (memberId == null)
                throw new ArgumentNullException("memberId");
            if (string.IsNullOrEmpty(memberId))
                throw new ArgumentException("memberId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/members/{1}", GetServiceEndpoint(identity, region), memberId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public IEnumerable<NetworkSecurityGroup> ListSecurityGroups(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/security-groups", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListNetworkSecurityGroupsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.NetworkSecurityGroups;
        }

        /// <inheritdoc />
        public NetworkSecurityGroup GetSecurityGroup(string securityGroupId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/security-groups/{1}", GetServiceEndpoint(identity, region), securityGroupId));
            var response = ExecuteRESTRequest<GetNetworkSecurityGroupResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.NetworkSecurityGroup;
        }

        /// <inheritdoc />
        public NetworkSecurityGroup CreatSecurityGroup(string name, string description, string region = null, CloudIdentity identity = null)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            CheckIdentity(identity);

            var group = new NetworkSecurityGroup()
            {
                Name = name,
                Description = description
            };
            var request = new CreateNetworkSecurityGroupRequest() { NetworkSecurityGroup = group };
            var urlPath = new Uri(string.Format("{0}/v2.0/security-groups", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreateNetworkSecurityGroupResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.NetworkSecurityGroup;
        }

        /// <inheritdoc />
        public bool DeleteSecurityGroup(string securityGroupId, string region = null, CloudIdentity identity = null)
        {
            if (securityGroupId == null)
                throw new ArgumentNullException("securityGroupId");
            if (string.IsNullOrEmpty(securityGroupId))
                throw new ArgumentException("securityGroupId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/security-groups/{1}", GetServiceEndpoint(identity, region), securityGroupId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public IEnumerable<NetworkSecurityGroupRule> ListSecurityGroupRules(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/security-group-rules", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListNetworkSecurityGroupRulesResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.SecurityGroupRules;
        }

        /// <inheritdoc />
        public NetworkSecurityGroupRule GetSecurityGroupRule(string securityRuleId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/security-group-rules/{1}", GetServiceEndpoint(identity, region), securityRuleId));
            var response = ExecuteRESTRequest<GetNetworkSecurityGroupRuleResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.SecurityGroupRule;
        }

        /// <inheritdoc />
        public NetworkSecurityGroupRule CreatSecurityGroupRule(string securityGroupId, string direction, string etherType,
            string portRangeMin = null, string portRangeMax = null, string protocol = null, string remoteGroupId = null, string remoteIpPrefix = null, string region = null, CloudIdentity identity = null)
        {
            if (securityGroupId == null)
                throw new ArgumentNullException("securityGroupId");
            if (direction == null)
                throw new ArgumentNullException("direction");
            if (etherType == null)
                throw new ArgumentNullException("etherType");
            if (string.IsNullOrEmpty(securityGroupId))
                throw new ArgumentException("securityGroupId cannot be empty");
            if (string.IsNullOrEmpty(direction))
                throw new ArgumentException("direction cannot be empty");
            if (string.IsNullOrEmpty(etherType))
                throw new ArgumentException("etherType cannot be empty");
            CheckIdentity(identity);

            var rule = new NetworkSecurityGroupRule()
            {
                SecurityGroupId = securityGroupId,
                Direction = direction,
                EtherType = etherType,
                PortRangeMin = portRangeMin,
                PortRangeMax = portRangeMax,
                Protocol = protocol,
                RemoteGroupId = remoteGroupId,
                RemoteIpPrefix = remoteIpPrefix

            };
            var request = new CreateNetworkSecurityGroupRuleRequest() { NetworkSecurityGroupRule = rule };
            var urlPath = new Uri(string.Format("{0}/v2.0/security-group-rules/", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<CreateNetworkSecurityGroupRuleResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.NetworkSecurityGroupRule;
        }

        /// <inheritdoc />
        public bool DeleteSecurityRule(string securityRuleId, string region = null, CloudIdentity identity = null)
        {
            if (securityRuleId == null)
                throw new ArgumentNullException("securityRuleId");
            if (string.IsNullOrEmpty(securityRuleId))
                throw new ArgumentException("securityRuleId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/security-group-rules/{1}", GetServiceEndpoint(identity, region), securityRuleId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete subnet. Ensure that all servers are removed from this network first.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc />
        public Subnet AddSubnetForAdditionalIp(int bitmask, string region = null, CloudIdentity identity = null)
        {
            if (bitmask < 28 || bitmask > 32)
                throw new ArgumentException("bitmask must be 28~32");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/allocateips", GetServiceEndpoint(identity, region)));

            var request = String.Format("{{ \"allocateip\": {{ \"bitmask\": \"{0}\" }} }}", bitmask);
            var response = ExecuteRESTRequest<CreateSubnetResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null || response.Data.Subnet == null)
                return null;

            return response.Data.Subnet;
        }

        /// <inheritdoc />
        public Subnet AddSubnetForLb(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/lb/subnets", GetServiceEndpoint(identity, region)));

            var response = ExecuteRESTRequest<CreateSubnetResponse>(identity, urlPath, HttpMethod.POST);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Subnet;
        }


        /// <inheritdoc />
        public IEnumerable<PortBlock> GetPortBlocks(string tenantId, string portId = null, string serverId = null, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/public-ports", GetServiceEndpoint(identity, region)));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"tenant_id", tenantId},
                    {"id", portId},
                    {"device_id", serverId}
                });

            var response = ExecuteRESTRequest<PortBlockResponse>(identity, urlPath, HttpMethod.GET, null, parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.PortBlocks;
        }

        /// <inheritdoc />
        public IEnumerable<PortBlock> SetPortBlocks(string portId, int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictPortProtocol, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2.0/port-limit/{1}", GetServiceEndpoint(identity, region), portId));
            var request = new PortBlockRequest(new PortBlock(bandWidthIn, bandWidthOut, dictPortProtocol));

            var response = ExecuteRESTRequest<PortBlockResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.PortBlocks;
        }
    }

}
