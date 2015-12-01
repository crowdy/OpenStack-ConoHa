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
    public class DnsClient : ServiceClient, IDnsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsClient"/> class with the specified
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
        public DnsClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IDnsService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<CreateDnsRecordApiCall> PrepareCreateDnsRecordAsync(string domainId, string name, string type, string data, int? priority = default(int?), int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = default(int?), int? gslbCheck = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateDomainApiCall> PrepareCreateDomainAsync(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteDnsRecordApiCall> PrepareDeleteDnsRecordAsync(string domainId, string recordId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListDeleteDomainApiCall> PrepareDeleteDomainAsync(string domainId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ExportZoneApiCall> PrepareExportZoneAsync(string zoneId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetDnsRecordApiCall> PrepareGetDnsRecordAsync(string domainId, string recordId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetDnsServiceDetailsApiCall> PrepareGetDnsServiceDetailsAsync(string domainId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetDnsServiceVersionApiCall> PrepareGetDnsServiceVersionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetDomainApiCall> PrepareGetDomainAsync(string domainId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImportZoneApiCall> PrepareImportZoneAsync(string zoneContent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListDnsRecordsApiCall> PrepareListDnsRecordsAsync(string domainId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListDomainsApiCall> PrepareListDomainsAsync(string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<SearchDomainApiCall> PrepareSearchDomainAsync(string domainName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetGslbSuspendApiCall> PrepareSetGslbSuspendAsync(string domainId, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDnsRecordApiCall> PrepareUpdateDnsRecordAsync(string domainId, string recordId, string name, string type, string data, int? priority = default(int?), int? ttl = default(int?), string description = null, string gslbRegion = null, int? gslbWeight = default(int?), int? gslbCheck = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDomainApiCall> PrepareUpdateDomainAsync(string domainId, string domainName = null, string email = null, int? ttl = default(int?), string description = null, int? gslb = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
