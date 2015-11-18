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

        [JsonProperty("item_features", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ItemFeaturesType[] itemFeatures { get; private set; }

        [JsonProperty("account_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AccountId { get; private set; }

        [JsonProperty("uu_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; private set; }

        [JsonProperty("service_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ServiceName { get; private set; }

        [JsonProperty("product_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ProductName { get; private set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Status { get; private set; }

        [JsonProperty("unit_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float UnitPrice { get; private set; }

        [JsonProperty("contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; private set; }

        [JsonProperty("service_start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime ServiceStartDate { get; private set; }

        [JsonProperty("bill_start_reserve_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime BillStartReserveDate { get; private set; }

        [JsonProperty("bill_start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime BillStartDate { get; private set; }

        [JsonProperty("cancel_reserve_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CancelReserveDate { get; private set; }

        [JsonProperty("cancel_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CancelDate { get; private set; }

        [JsonProperty("route", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public String Route { get; private set; }

        [JsonProperty("created_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CreatedDate { get; private set; }

        [JsonProperty("created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; private set; }

        [JsonProperty("last_updated_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastUpdatedDate { get; private set; }

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
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member