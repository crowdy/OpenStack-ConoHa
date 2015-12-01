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
    public class DatabaseClient : ServiceClient, IDatabaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseClient"/> class with the specified
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
        public DatabaseClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IDatabaseService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<CreateDatabaseApiCall> PrepareCreateDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateDbGrantApiCall> PrepareCreateDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateDbServiceApiCall> PrepareCreateDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateDbUserApiCall> PrepareCreateDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteDatabaseApiCall> PrepareDeleteDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteDbGrantApiCall> PrepareDeleteDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteDbServiceApiCall> PrepareDeleteDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteDbUserApiCall> PrepareDeleteDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetDatabaseApiCall> PrepareGetDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetDbServiceApiCall> PrepareGetDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetDbServiceQuotaApiCall> PrepareGetDbServiceQuotaAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetDbUserApiCall> PrepareGetDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetVersionApiCall> PrepareGetVersionAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetVersionDetailsApiCall> PrepareGetVersionDetailsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListDatabasesApiCall> PrepareListDatabasesAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListDbBackupsApiCall> PrepareListDbBackupsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListDbGrantApiCall> PrepareListDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListDbServicesApiCall> PrepareListDbServicesAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListDbUsersApiCall> PrepareListDbUsersAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<RestoreDatabaseApiCall> PrepareRestoreDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<SetDbServiceBackupApiCall> PrepareSetDbServiceBackupAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<SetDbServiceStatusApiCall> PrepareSetDbServiceStatusAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDatabaseApiCall> PrepareUpdateDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDbServiceApiCall> PrepareUpdateDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDbServiceQuotaApiCall> PrepareUpdateDbServiceQuotaAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDbUserApiCall> PrepareUpdateDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
