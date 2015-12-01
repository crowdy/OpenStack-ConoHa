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

    using OpenStack.Services;


    /// <summary>
    /// This class provides a default implementation of <see cref="IContentDeliveryService"/> suitable for connecting to
    /// OpenStack-compatible installations of the Content Delivery Service V1.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public class AccountServiceClient : ServiceClient, IAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountServiceClient"/> class with the specified
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
        public AccountServiceClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IAccountService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<GetBillingInvoiceApiCall> PrepareGetBillingInvoiceAsync(int invoiceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetNotificationApiCall> PrepareGetNotificationAsync(int notificationCode, string lang = "en", CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetOrderItemApiCall> PrepareGetOrderItemAsync(int itemid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetPaymentSummaryApiCall> PrepareGetPaymentSummaryAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListBillingInvoicesApiCall> PrepareListBillingInvoicesAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListNotificationsApiCall> PrepareListNotificationsAsync(string lang = "en", int offset = 0, int limit = 1000, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListOrderItemsApiCall> PrepareListOrderItemsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPaymentHistoryApiCall> PrepareListPaymentHistoryAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListProductsApiCall> PrepareListProductsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SetNotificationApiCall> PrepareSetNotificationAsync(int notificationCode, string status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
