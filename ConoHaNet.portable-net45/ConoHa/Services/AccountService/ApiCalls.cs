namespace ConoHaNet.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using AccountService;

    // IEnumerable<SimpleOrderItem> ListOrderItems(CloudIdentity identity = null);
    // Task<ListOrderItemsApiCall> PrepareListOrderItemsAsync(CancellationToken cancellationToken);
    public class ListOrderItemsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public ListOrderItemsApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // OrderItem GetOrderItem(int itemid, CloudIdentity identity = null);
    // Task<GetOrderItemApiCall> PrepareGetOrderItemAsync(int itemid, CancellationToken cancellationToken);
    public class GetOrderItemApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public GetOrderItemApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<ProdctBase> ListProducts(CloudIdentity identity = null);
    // Task<ListProductsApiCall> PrepareListProductsAsync(CancellationToken cancellationToken);
    public class ListProductsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public ListProductsApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<SimplePayment> ListPaymentHistory(CloudIdentity identity = null);
    // Task<ListPaymentHistoryApiCall> PrepareListPaymentHistoryAsync(CancellationToken cancellationToken);
    public class ListPaymentHistoryApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public ListPaymentHistoryApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // PaymentSummary GetPaymentSummary(CloudIdentity identity = null);
    // Task<GetPaymentSummaryApiCall> PrepareGetPaymentSummaryAsync(CancellationToken cancellationToken);
    public class GetPaymentSummaryApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public GetPaymentSummaryApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000, CloudIdentity identity = null);
    // Task<ListBillingInvoicesApiCall> PrepareListBillingInvoicesAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken);
    public class ListBillingInvoicesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public ListBillingInvoicesApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // BillingInvoice GetBillingInvoice(int invoiceId, CloudIdentity identity = null);
    // Task<GetBillingInvoiceApiCall> PrepareGetBillingInvoiceAsync(int invoiceId, CancellationToken cancellationToken);
    public class GetBillingInvoiceApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public GetBillingInvoiceApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000, CloudIdentity identity = null);
    // Task<ListNotificationsApiCall> PrepareListNotificationsAsync(string lang = "en", int offset = 0, int limit = 1000, CancellationToken cancellationToken);
    public class ListNotificationsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public ListNotificationsApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Notification GetNotification(int notificationCode, string lang = "en", CloudIdentity identity = null);
    // Task<GetNotificationApiCall> PrepareGetNotificationAsync(int notificationCode, string lang = "en", CancellationToken cancellationToken);
    public class GetNotificationApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public GetNotificationApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Notification SetNotification(int notificationCode, string status, CloudIdentity identity = null);
    // Task<SetNotificationApiCall> PrepareSetNotificationAsync(int notificationCode, string status, CancellationToken cancellationToken);
    public class SetNotificationApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>>
    {
        public SetNotificationApiCall(IHttpApiCall<ReadOnlyCollectionPage<SimpleOrderItem>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

}
