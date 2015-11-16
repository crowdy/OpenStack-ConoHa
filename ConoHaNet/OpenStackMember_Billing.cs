namespace ConoHaNet
{
    using Objects.Billing;
    using Providers;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudAccountServiceProvider _AccountServiceProvider = null;

        /// <inheritdoc/>
        public CloudAccountServiceProvider AccountServiceProvider
        {
            get
            {
                if (_AccountServiceProvider == null)
                {
                    _AccountServiceProvider = new CloudAccountServiceProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null);
                    Trace.WriteLine("CloudAccountServiceProvider created.");
                }

                return _AccountServiceProvider;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<SimpleOrderItem> ListOrderItems()
        {
            return AccountServiceProvider.ListOrderItems(Identity);
        }

        /// <inheritdoc/>
        public OrderItem GetOrderItem(int itemid)
        {
            return AccountServiceProvider.GetOrderItem(itemid, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ProdctBase> ListProducts()
        {
            return AccountServiceProvider.ListProducts(Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<SimplePayment> ListPaymentHistory()
        {
            return AccountServiceProvider.ListPaymentHistory(Identity);
        }

        /// <inheritdoc/>
        public PaymentSummary GetPaymentSummary()
        {
            return AccountServiceProvider.GetPaymentSummary(Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000)
        {
            return AccountServiceProvider.ListBillingInvoices(offset, limit, Identity);
        }

        /// <inheritdoc/>
        public BillingInvoice GetBillingInvoice(int invoiceId)
        {
            return AccountServiceProvider.GetBillingInvoice(invoiceId, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000)
        {
            return AccountServiceProvider.ListNotifications(lang, offset, limit, Identity);
        }

        /// <inheritdoc/>
        public Notification GetNotification(int notificationCode, string lang = "en")
        {
            return AccountServiceProvider.GetNotification(notificationCode, lang, Identity);
        }

        /// <inheritdoc/>
        public Notification SetNotification(int notificationCode, string status)
        {
            return AccountServiceProvider.SetNotification(notificationCode, status, Identity);
        }

    }
}
