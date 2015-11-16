#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Billing
{
    using System;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class OrderItem : ExtensibleJsonObject
    {

        public class ItemFeaturesType
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected OrderItem()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("item_features", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ItemFeaturesType[] itemFeatures { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AccountId { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("uu_id", Required = Required.Always)]
        public int Id { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("service_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ServiceName { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("product_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ProductName { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Status { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("unit_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float UnitPrice { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("service_start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime ServiceStartDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bill_start_reserve_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime BillStartReserveDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bill_start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime BillStartDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("cancel_reserve_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CancelReserveDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("cancel_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CancelDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("route", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public String Route { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("created_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("last_updated_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastUpdatedDate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [JsonProperty("last_updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LastUpdatedBy { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server</seealso>
    /// <threadsafety static="true" instance="false"/>

    [JsonObject(MemberSerialization.OptIn)]
    public class GetOrderItemResponse
    {
        [JsonProperty("order_item", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OrderItem OrderItem { get; set; }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListOrderItemsResponse
    {
        [JsonProperty("order_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SimpleOrderItem[] OrderItems { get; internal set; }

        [JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int AccountId { get; internal set; }

    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member