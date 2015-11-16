namespace ConoHaNet
{
    using Objects.Billing;
    using Providers;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudMerlionProvider _MerlionProvider = null;

        /// <inheritdoc/>
        public CloudMerlionProvider MerlionProvider
        {
            get
            {
                if (_MerlionProvider == null)
                {
                    _MerlionProvider = new CloudMerlionProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null);
                    Trace.WriteLine("CloudMerlionProvider created.");
                }

                return _MerlionProvider;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<SimpleOrderItem> ListOrderItems()
        {
            return MerlionProvider.ListOrderItems(Identity);
        }

        /// <inheritdoc/>
        public OrderItem GetOrderItem(int itemid)
        {
            return MerlionProvider.GetOrderItem(itemid, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ProdctBase> ListProducts()
        {
            return MerlionProvider.ListProducts(Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<SimplePayment> ListPaymentHistory()
        {
            return MerlionProvider.ListPaymentHistory(Identity);
        }

        /// <inheritdoc/>
        public PaymentSummary GetPaymentSummary()
        {
            return MerlionProvider.GetPaymentSummary(Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000)
        {
            return MerlionProvider.ListBillingInvoices(offset, limit, Identity);
        }

        /// <inheritdoc/>
        public BillingInvoice GetBillingInvoice(int invoiceId)
        {
            return MerlionProvider.GetBillingInvoice(invoiceId, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000)
        {
            return MerlionProvider.ListNotifications(lang, offset, limit, Identity);
        }

        /// <inheritdoc/>
        public Notification GetNotification(int notificationCode, string lang = "en")
        {
            return MerlionProvider.GetNotification(notificationCode, lang, Identity);
        }

        /// <inheritdoc/>
        public Notification SetNotification(int notificationCode, string status)
        {
            return MerlionProvider.SetNotification(notificationCode, status, Identity);
        }

    }
}
