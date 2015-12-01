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
    using MailService;


    /// <summary>
    /// This class provides a default implementation of <see cref="IContentDeliveryService"/> suitable for connecting to
    /// OpenStack-compatible installations of the Content Delivery Service V1.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public class MailServiceClient : ServiceClient, IMailService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailServiceClient"/> class with the specified
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
        public MailServiceClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IMailService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<ChangeEmailAddressPasswordApiCall> PrepareChangeEmailAddressPasswordAsync(string emailId, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateEmailAddressApiCall> PrepareCreateEmailAddressAsync(string serviceId, string emailAddress, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateEmailForwardingApiCall> PrepareCreateEmailForwardingAsync(string emailId, string toForwardAddress, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateEmailWebHookApiCall> PrepareCreateEmailWebHookAsync(string emailId, string webhookUrl, string keyword, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateMailDomainApiCall> PrepareCreateMailDomainAsync(string serviceId, string domainName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateMailServiceApiCall> PrepareCreateMailServiceAsync(string serviceName, string defaultSubdomain, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateMailServiceApiCall> PrepareCreateMailServiceAsync(int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteEmailAddressApiCall> PrepareDeleteEmailAddressAsync(string emailId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteEmailForwardingApiCall> PrepareDeleteEmailForwardingAsync(string forwardingId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteEmailWebHookApiCall> PrepareDeleteEmailWebHookAsync(string emailId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteMailDomainApiCall> PrepareDeleteMailDomainAsync(string domainId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteMailMessageApiCall> PrepareDeleteMailMessageAsync(string emailId, string messageId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteMailServiceApiCall> PrepareDeleteMailServiceAsync(string serviceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetEmailAddressApiCall> PrepareGetEmailAddressAsync(string emailId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetEmailBlackListApiCall> PrepareGetEmailBlackListAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetEmailForwardingApiCall> PrepareGetEmailForwardingAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetEmailWebHookApiCall> PrepareGetEmailWebHookAsync(string emailId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetEmailWhiteListApiCall> PrepareGetEmailWhiteListAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetMailAttachmentApiCall> PrepareGetMailAttachmentAsync(string emailId, string messageId, string attachmemntId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetMailBoxQuotaApiCall> PrepareGetMailBoxQuotaAsync(string serviceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetMailDomainDedicatedIpApiCall> PrepareGetMailDomainDedicatedIpAsync(string domainId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetMailMessageApiCall> PrepareGetMailMessageAsync(string emailId, string messageId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetMailServiceApiCall> PrepareGetMailServiceAsync(string serviceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetMailServiceVersionApiCall> PrepareGetMailServiceVersionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetMailServiceVersionDetailsApiCall> PrepareGetMailServiceVersionDetailsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListEmailAddressesApiCall> PrepareListEmailAddressesAsync(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListEmailForwardingsApiCall> PrepareListEmailForwardingsAsync(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListMailDomainsApiCall> PrepareListMailDomainsAsync(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListMailMessageHeadersApiCall> PrepareListMailMessageHeadersAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<SetEmailForwardingCopyApiCall> PrepareSetEmailForwardingCopyAsync(string emailId, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetEmailSpamFilterApiCall> PrepareSetEmailSpamFilterAsync(string emailId, bool enabled, string type = "tray", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<SetEmailVirusCheckApiCall> PrepareSetEmailVirusCheckAsync(string emailId, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetMailDomainDedicatedIpStatusApiCall> PrepareSetMailDomainDedicatedIpStatusAsync(string domainId, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetMailServiceBackupApiCall> PrepareSetMailServiceBackupAsync(string serviceId, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetMailServiceStatusApiCall> PrepareSetMailServiceStatusAsync(string serviceId, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateBlackListApiCall> PrepareUpdateBlackListAsync(string emailId, EmailFilterDetails[] targets, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateEmailForwardingApiCall> PrepareUpdateEmailForwardingAsync(string forwardingId, string toForwardAddress, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateEmailWebHookApiCall> PrepareUpdateEmailWebHookAsync(string emailId, string webhookFilter, string keyword, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateMailBoxQuotaApiCall> PrepareUpdateMailBoxQuotaAsync(string serviceId, int quota, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateMailServiceApiCall> PrepareUpdateMailServiceAsync(string serviceId, string serviceName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateWhiteListApiCall> PrepareUpdateWhiteListAsync(string emailId, EmailFilterDetails[] targets, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
