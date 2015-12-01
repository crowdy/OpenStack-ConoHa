#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.AccountService
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    /// <summary>
    /// This class models the JSON representation of an resource in the <see cref="Payment"/>.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Alarms</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    public class Payment : ExtensibleJsonObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected Payment()
        {
        }


        /// <summary>
        /// TotalReceivedAmount
        /// </summary>
        [JsonProperty("total_received_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalReceivedAmount { get; private set; }

        /// <summary>
        /// TotalUnusedAmount
        /// </summary>
        [JsonProperty("total_unused_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalUnusedAmount { get; private set; }

        /// <summary>
        /// TotalDepositAmount
        /// </summary>
        [JsonProperty("total_deposit_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalDepositAmount { get; private set; }

        /// <summary>
        /// TotalLockedUnusedAmount
        /// </summary>
        [JsonProperty("total_locked_unused_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalLockedUnusedAmount { get; private set; }
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
    public class ListPaymentHistoryResponse
    {
        [JsonProperty("payment_history", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SimplePayment[] PaymentHistory { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetPaymentSummaryResponse
    {
        [JsonProperty("payment_summary", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PaymentSummary PaymentSummary { get; private set; }
    }

    /// <summary>
    /// This class models the JSON representation of an Alarm resource in the IMonitoringService.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Alarms</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    public class PaymentSummary : ExtensibleJsonObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentSummary"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected PaymentSummary()
        {
        }


        /// <summary>
        /// TotalReceivedAmount
        /// </summary>
        [JsonProperty("total_received_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalReceivedAmount { get; private set; }

        /// <summary>
        /// TotalUnusedAmount
        /// </summary>
        [JsonProperty("total_unused_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalUnusedAmount { get; private set; }

        /// <summary>
        /// TotalDepositAmount
        /// </summary>
        [JsonProperty("total_deposit_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalDepositAmount { get; private set; }

        /// <summary>
        /// TotalLockedUnusedAmount
        /// </summary>
        [JsonProperty("total_locked_unused_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalLockedUnusedAmount { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member