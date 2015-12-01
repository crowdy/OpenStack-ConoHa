namespace ConoHaNet.Services.AccountService
{
    using System;
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;

    /// <summary>
    /// This class models the JSON representation of an order item resource in the <see cref="IAccountServiceProvider"/>.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Alarms</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleOrderItem : ExtensibleJsonObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected SimpleOrderItem()
        {
        }

        /// <summary>
        /// Gets the "item_id" property of this information.
        /// </summary>
        [JsonProperty("uu_id", Required = Required.Always)]
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the "service_name" property of this information.
        /// </summary>
        [JsonProperty("service_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ServiceName { get; internal set; }

        /// <summary>
        /// Gets the "service_start_date" property of this information.
        /// </summary>
        [JsonProperty("service_start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? ServiceStartDate { get; internal set; }

        /// <summary>
        /// Gets the "item_status" property of this information.
        /// </summary>
        [JsonProperty("item_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ItemStatus { get; internal set; }

    }
}
