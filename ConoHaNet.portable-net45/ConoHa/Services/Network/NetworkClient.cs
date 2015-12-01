namespace ConoHaNet.Services
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenStack.Collections;
    using OpenStack.Net;
    using OpenStack.ObjectModel.JsonHome;
    using OpenStack.Security.Authentication;
    using OpenStack.Services.Identity;
    using Rackspace.Net;
    using Rackspace.Threading;

    using System.Diagnostics;
    using OpenStack.Services;
    using ConoHa.Services;


    /// <summary>
    /// This class provides a default implementation of <see cref="IContentDeliveryService"/> suitable for connecting to
    /// OpenStack-compatible installations of the Content Delivery Service V1.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public class NetworkClient : ServiceClient, INetworkService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComputeClient"/> class with the specified
        /// authentication service, default region, and value indicating whether an internal or public endpoint should
        /// be used for communicating with the service.
        /// </summary>
        /// <param name="authenticationService">The authentication service to use for authenticating requests made to
        /// this service.</param>
        /// <param name="defaultRegion">The preferred region for the service. Unless otherwise specified for a specific
        /// client, derived service clients will not use a default region if this value is <see langword="null"/> (i.e.
        /// only region-less or "global" service endpoints will be considered acceptable).</param>
        /// <param name="internalUrl"><see langword="true"/> to access the service over a local network; otherwise,
        /// <see langword="false"/> to access the service over a public network (the Internet).</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="authenticationService"/> is <see langword="null"/>.
        /// </exception>
        public NetworkClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<INetworkService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<AssociateHealthMonitorApiCall> PrepareAssociateHealthMonitorAsync(string monitorId, string poolId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateNetworkApiCall> PrepareCreateNetworkAsync(string cidr, string label, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteNetworkApiCall> PrepareDeleteNetworkAsync(string networkId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetPortBlocksApiCall> PrepareGetPortBlocksAsync(string tenantId, string portId = null, string serverId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListNetworksApiCall> PrepareListNetworksAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetPortBlocksApiCall> PrepareSetPortBlocksAsync(string portId, int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictPortProtocol, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ShowNetworkApiCall> PrepareShowNetworkAsync(string networkId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
