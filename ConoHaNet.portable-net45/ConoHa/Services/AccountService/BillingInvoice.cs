#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.AccountService
{
    using System;
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    /// <summary>
    /// This class models the JSON representation of an Alarm resource in the IMonitoringService.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Alarms</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    public class BillingInvoice : ExtensibleJsonObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingInvoice"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected BillingInvoice()
        {
        }

        /// <summary>
        /// Gets the "items" property of this information.
        /// </summary>
        [JsonProperty("items", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OrderItem[] Items { get; private set; }

        /// <summary>
        /// Gets the "account_id" property of this information.
        /// </summary>
        [JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AccountId { get; private set; }

        /// <summary>
        /// Gets the "brand_id" property of this information.
        /// </summary>
        [JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BrandId { get; private set; }

        /// <summary>
        /// Gets the "invoice_id" property of this information.
        /// </summary>
        [JsonProperty("invoice_id")]
        public int InvoiceId { get; private set; }

        /// <summary>
        /// Gets the "invoice_type" property of this information.
        /// </summary>
        [JsonProperty("invoice_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string InvoiceType { get; private set; }

        /// <summary>
        /// Gets the "payment_method_type" property of this information.
        /// </summary>
        [JsonProperty("payment_method_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PaymentMethodType { get; private set; }

        /// <summary>
        /// Gets the "invoice_date" property of this information.
        /// </summary>
        [JsonProperty("invoice_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? InvoiceDate { get; private set; }

        /// <summary>
        /// Gets the "bill" property of this information.
        /// </summary>
        [JsonProperty("bill", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Bill { get; private set; }

        /// <summary>
        /// Gets the "tax" property of this information.
        /// </summary>
        [JsonProperty("tax", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Tax { get; private set; }

        /// <summary>
        /// Gets the "bill_plas_tax" property of this information.
        /// </summary>
        [JsonProperty("bill_plas_tax", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BillPlasTax { get; private set; }

        /// <summary>
        /// Gets the "balance_bill" property of this information.
        /// </summary>
        [JsonProperty("balance_bill", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BalanceBill { get; private set; }

        /// <summary>
        /// Gets the "balance_bill_plas_tax" property of this information.
        /// </summary>
        [JsonProperty("balance_bill_plas_tax", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int BalanceBillPlasTax { get; private set; }

        /// <summary>
        /// Gets the "currency" property of this information.
        /// </summary>
        [JsonProperty("currency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Currency { get; private set; }

        /// <summary>
        /// Gets the "due_date" property of this information.
        /// </summary>
        [JsonProperty("due_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DueDate { get; private set; }

        /// <summary>
        /// Gets the "receive_type" property of this information.
        /// </summary>
        [JsonProperty("receive_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReceiveType { get; private set; }

        /// <summary>
        /// Gets the "created_date" property of this information.
        /// </summary>
        [JsonProperty("created_date")]
        public DateTimeOffset CreatedDate { get; private set; }

        /// <summary>
        /// Gets the "created_by" property of this information.
        /// </summary>
        [JsonProperty("created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; private set; }

        /// <summary>
        /// Gets the "last_updated_date" property of this information.
        /// </summary>
        [JsonProperty("last_updated_date")]
        public DateTimeOffset LastUpdatedDate { get; private set; }

        /// <summary>
        /// Gets the "last_updated_by" property of this information.
        /// </summary>
        [JsonProperty("last_updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LastUpdatedBy { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <summary>
    /// This models the basic JSON description of a Product.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListBillingInvoicesResponse
    {

        [JsonProperty("billing_invoices", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public BillingInvoice[] BillingInvoices { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetBillingInvoiceResponse
    {
        [JsonProperty("billing_invoice", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public BillingInvoice BillingInvoice { get; private set; }

    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member