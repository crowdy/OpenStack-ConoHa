namespace ConoHaNet.Objects.Billing
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This class models the JSON representation of an Alarm resource in the IMonitoringService.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Alarms</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    public class SimplePayment : ExtensibleJsonObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SimplePayment"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected SimplePayment()
        {
        }

        /// <summary>
        /// Gets the "money_id" property of this information.
        /// </summary>
        [JsonProperty("money_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MoneyId { get; private set; }

        /// <summary>
        /// Gets the "money_type" property of this information.
        /// </summary>
        [JsonProperty("money_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MoneyType { get; private set; }

        /// <summary>
        /// Gets the "received_amount" property of this information.
        /// </summary>
        [JsonProperty("received_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ReceivedAmount { get; private set; }

        /// <summary>
        /// Gets the "unused_amount" property of this information.
        /// </summary>
        [JsonProperty("unused_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int UnusedAmount { get; private set; }

        /// <summary>
        /// Gets the "deposit_amount" property of this information.
        /// </summary>
        [JsonProperty("deposit_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int DepositAmount { get; private set; }

        /// <summary>
        /// Gets the "received_date" property of this information.
        /// </summary>
        [JsonProperty("received_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? ReceivedDate { get; private set; }

        /// <summary>
        /// Gets the "is_locked" property of this information.
        /// </summary>
        [JsonProperty("is_locked", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsLockeced { get; private set; }
    }
}
