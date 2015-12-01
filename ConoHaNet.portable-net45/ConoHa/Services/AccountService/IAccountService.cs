namespace ConoHaNet.Services
{
    using OpenStack.Services;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IAccountService : IHttpService, IExtensibleService<IAccountService>
    {
        #region ConoHa

        // IEnumerable<SimpleOrderItem> ListOrderItems(CloudIdentity identity = null);
        Task<ListOrderItemsApiCall> PrepareListOrderItemsAsync(CancellationToken cancellationToken);

        // OrderItem GetOrderItem(int itemid, CloudIdentity identity = null);
        Task<GetOrderItemApiCall> PrepareGetOrderItemAsync(int itemid, CancellationToken cancellationToken);
        
        // IEnumerable<ProdctBase> ListProducts(CloudIdentity identity = null);
        Task<ListProductsApiCall> PrepareListProductsAsync(CancellationToken cancellationToken);
        
        // IEnumerable<SimplePayment> ListPaymentHistory(CloudIdentity identity = null);
        Task<ListPaymentHistoryApiCall> PrepareListPaymentHistoryAsync(CancellationToken cancellationToken);
        
        // PaymentSummary GetPaymentSummary(CloudIdentity identity = null);
        Task<GetPaymentSummaryApiCall> PrepareGetPaymentSummaryAsync(CancellationToken cancellationToken);
        
        // IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000, CloudIdentity identity = null);
        Task<ListBillingInvoicesApiCall> PrepareListBillingInvoicesAsync(int offset = 0, int limit = 1000, CancellationToken cancellationToken = default(CancellationToken));
        
        // BillingInvoice GetBillingInvoice(int invoiceId, CloudIdentity identity = null);
        Task<GetBillingInvoiceApiCall> PrepareGetBillingInvoiceAsync(int invoiceId, CancellationToken cancellationToken);
        
        // IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000, CloudIdentity identity = null);
        Task<ListNotificationsApiCall> PrepareListNotificationsAsync(string lang = "en", int offset = 0, int limit = 1000, CancellationToken cancellationToken = default(CancellationToken));
        
        // Notification GetNotification(int notificationCode, string lang = "en", CloudIdentity identity = null);
        Task<GetNotificationApiCall> PrepareGetNotificationAsync(int notificationCode, string lang = "en", CancellationToken cancellationToken = default(CancellationToken));
        
        // Notification SetNotification(int notificationCode, string status, CloudIdentity identity = null);
        Task<SetNotificationApiCall> PrepareSetNotificationAsync(int notificationCode, string status, CancellationToken cancellationToken);

        #endregion
    }
}
