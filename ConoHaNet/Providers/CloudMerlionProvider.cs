namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using Objects.Billing;
    using Objects;
    using Objects.Servers;
    using JSIStudios.SimpleRESTServices.Client.Json;


    /// <summary>
    /// Represents a provider for the OpenStack Compute service.
    /// </summary>
    public interface IMerlionProvider
    {
        /// <summary>
        /// Gets a collection of order itmes
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-order-item-list.html"/>
        IEnumerable<SimpleOrderItem> ListOrderItems(CloudIdentity identity = null);

        /// <summary>
        /// Gets an order itedm
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-order-item-detail-specified.html"/>
        OrderItem GetOrderItem(int itemid, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of product
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-products.html"/>
        IEnumerable<ProdctBase> ListProducts(CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of payment history
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-payment-histories.html"/>
        IEnumerable<SimplePayment> ListPaymentHistory(CloudIdentity identity = null);

        /// <summary>
        /// Gets the information of payment summary
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-payment-summary.html"/>
        PaymentSummary GetPaymentSummary(CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of billing invoice
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-billing-invoices-list.html"/>
        IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000, CloudIdentity identity = null);

        /// <summary>
        /// Gets the billing invoice with invoice id
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-billing-invoices-detail-specified.html"/>
        BillingInvoice GetBillingInvoice(int invoiceId, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of notification
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-informations-list.html"/>
        IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000, CloudIdentity identity = null);

        /// <summary>
        /// Gets the notification with id
        /// </summary>
        /// <param name="notificationCode"></param>
        /// <param name="lang"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-informations-detail-specified.html"/>
        Notification GetNotification(int notificationCode, string lang = "en", CloudIdentity identity = null);

        /// <summary>
        /// Updates the notification status
        /// </summary>
        /// <param name="notificationCode"></param>
        /// <param name="status"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-informations-marking.html"/>
        Notification SetNotification(int notificationCode, string status, CloudIdentity identity = null);
    }

    /// <summary>
    /// <para>The Cloud Servers Provider enables simple access go the ConoHa next generation Cloud Servers powered by OpenStack.
    /// The next generation service is a fast, reliable, and scalable cloud compute solution without the risk of proprietary lock-in.
    /// It provides the core features of the OpenStack Compute API v2 and also deploys certain extensions as permitted by the OpenStack Compute API contract.
    /// Some of these extensions are generally available through OpenStack while others implement ConoHa-specific features
    /// to meet customers�f expectations and for operational compatibility. The OpenStack Compute API and the ConoHa extensions are
    /// known collectively as API v2.</para>
    /// <para />
    /// <para>Documentation URL: https://www.google.co.jp/search?q=openstack+</para>
    /// </summary>
    /// <see cref="IComputeProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudMerlionProvider : ProviderBase<IMerlionProvider>, IMerlionProvider
    {
        private readonly HttpStatusCode[] _validServerActionResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Accepted, HttpStatusCode.NonAuthoritativeInformation, HttpStatusCode.NoContent };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudMerlionProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudMerlionProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudMerlionProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudMerlionProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudMerlionProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudMerlionProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudMerlionProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudMerlionProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
            : base(identity, defaultRegion, identityProvider, restService)
        { }

        #endregion

        #region billings

        /// <inheritdoc />
        public IEnumerable<SimpleOrderItem> ListOrderItems(CloudIdentity identity = null)
        {
            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/order-items", GetServiceEndpoint(identity)));

            var response = ExecuteRESTRequest<ListOrderItemsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.OrderItems;
        }

        /// <inheritdoc />
        /// /v1/{tenant_id}/order-items/{item_id}
        public OrderItem GetOrderItem(int itemid, CloudIdentity identity = null)
        {
            if (itemid < 0)
                throw new ArgumentOutOfRangeException("itemid");

            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/order-items/{1}", GetServiceEndpoint(identity), itemid));

            var response = ExecuteRESTRequest<GetOrderItemResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.OrderItem;
        }

        /// <inheritdoc />
        /// /v1/{tenant_id}/order-items/{item_id}
        public IEnumerable<ProdctBase> ListProducts(CloudIdentity identity = null)
        {
            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/product-items", GetServiceEndpoint(identity)));

            var response = ExecuteRESTRequest<ListProductsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.ProductItems;
        }


        /// <inheritdoc />
        /// /v1/{tenant_id}/order-items/{item_id}
        public IEnumerable<SimplePayment> ListPaymentHistory(CloudIdentity identity = null)
        {

            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/payment-history", GetServiceEndpoint(identity)));

            var response = ExecuteRESTRequest<ListPaymentHistoryResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.PaymentHistory;
        }

        /// <inheritdoc />
        /// /v1/{tenant_id}/order-items/{item_id}
        public PaymentSummary GetPaymentSummary(CloudIdentity identity = null)
        {
            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/payment-summary", GetServiceEndpoint(identity)));

            var response = ExecuteRESTRequest<GetPaymentSummaryResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.PaymentSummary;
        }

        /// <inheritdoc />
        public IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");

            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/billing-invoices", GetServiceEndpoint(identity)));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", offset.ToString()},
                    {"limit", limit.ToString()}
                });
            var response = ExecuteRESTRequest<ListBillingInvoicesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.BillingInvoices;
        }




        /// <inheritdoc />
        public BillingInvoice GetBillingInvoice(int invoiceId, CloudIdentity identity = null)
        {
            if (invoiceId < 0)
                throw new ArgumentOutOfRangeException("invoiceid");

            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/billing-invoices/{1}", GetServiceEndpoint(identity), invoiceId));
            var response = ExecuteRESTRequest<GetBillingInvoiceResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.BillingInvoice;
        }

        /// <inheritdoc />
        public IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");

            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/notifications", GetServiceEndpoint(identity)));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"lang", lang},
                    {"offset", offset.ToString()},
                    {"limit", limit.ToString()}
                });

            var response = ExecuteRESTRequest<ListNotificationsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Notifications;
        }

        
        /// <inheritdoc />
        public Notification GetNotification(int notificationCode, string lang = "en", CloudIdentity identity = null)
        {
            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/notifications/{1}", GetServiceEndpoint(identity), notificationCode.ToString()));

            var response = ExecuteRESTRequest<GetNotificationResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Notification;
        }

        /// <inheritdoc />
        public Notification SetNotification(int notificationCode, string status, CloudIdentity identity = null)
        {
            CheckIdentity(identity);
            var urlPath = new Uri(string.Format("{0}/notifications/{1}", GetServiceEndpoint(identity), notificationCode.ToString()));
            var request = String.Format("{{ \"notification\": {{ \"read_status\": \"{0}\" }} }}", status.ToString());
            var response = ExecuteRESTRequest<GetNotificationResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.RawBody == null)
                return null;

            return response.Data.Notification;
        }

        /// <summary>
        /// Execute a Cloud Servers action which returns a strongly-typed value in the body of the response.
        /// </summary>
        /// <remarks>
        /// This method executes actions using a <see cref="HttpMethod.POST"/> request to the URI
        /// <strong>servers/{serverId}/action</strong>.
        /// </remarks>
        /// <typeparam name="T">The type modeling the JSON representation of the result of executing the action.</typeparam>
        /// <param name="serverId">The server ID. This is obtained from <see cref="ServerBase.Id"/>.</param>
        /// <param name="body">The body of the action.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>The result of the web request, as an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="serverId"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="body"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="serverId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <see langword="null"/> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected T ExecuteServerAction<T>(string serverId, object body, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (body == null)
                throw new ArgumentNullException("body");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<T>(identity, urlPath, HttpMethod.POST, body);

            if (response == null || response.Data == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return default(T);

            return response.Data;
        }

        /// <summary>
        /// Execute a Cloud Servers action which does not return a response.
        /// </summary>
        /// <remarks>
        /// This method executes actions using a <see cref="HttpMethod.POST"/> request to the URI
        /// <strong>servers/{serverId}/action</strong>.
        /// </remarks>
        /// <param name="serverId">The server ID. This is obtained from <see cref="ServerBase.Id"/>.</param>
        /// <param name="body">The body of the action.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns><see langword="true"/> if the <see cref="HttpMethod.POST"/> request is executed successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="serverId"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="body"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="serverId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <see langword="null"/> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected bool ExecuteServerAction(string serverId, object body, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (body == null)
                throw new ArgumentNullException("body");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, body);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false;

            return true;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Gets the public service endpoint to use for Cloud Servers requests for the specified identity and region.
        /// </summary>
        /// <remarks>
        /// This method uses <c>compute</c> for the service type, and <c>cloudServersOpenStack</c> for the preferred service name.
        /// </remarks>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <param name="region">The preferred region for the service. If this value is <see langword="null"/>, the user's default region will be used.</param>
        /// <returns>The public URL for the requested Cloud Servers endpoint.</returns>
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
        protected string GetServiceEndpoint(CloudIdentity identity, string region = "tyo1")
        {
            // return base.GetPublicServiceEndpoint(identity, "compute", "cloudServersOpenStack", region);
            return base.GetPublicServiceEndpoint(identity, "account", "Account Service", region ?? "tyo1");
        }

        #endregion
    }
}
