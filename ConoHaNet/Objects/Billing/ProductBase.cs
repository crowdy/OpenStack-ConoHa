#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Billing
{
    using Newtonsoft.Json;

    public class ProdctBase : ExtensibleJsonObject
    {

        [JsonProperty("products", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SimpleProduct[] Products;

        [JsonProperty("service_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ServiceName;
    }

    public class SimpleProduct : ExtensibleJsonObject
    {
        [JsonProperty("product_code", DefaultValueHandling = DefaultValueHandling.Ignore)]

        public string ProductCode { get; set; }

        [JsonProperty("product_price_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ProductPriceId { get; set; }

        [JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ProductId { get; set; }

        [JsonProperty("mnemonic", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Mnemonic { get; set; }

        [JsonProperty("product_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ProductName { get; set; }

        [JsonProperty("product_unit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ProductUnit { get; set; }

        [JsonProperty("product_unit_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ProductUnitName { get; set; }

        [JsonProperty("unit_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float UnitPrice { get; set; }

        [JsonProperty("unit_currency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UnitCurrency { get; set; }

        [JsonProperty("start_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public System.DateTime StartDate { get; set; }

        [JsonProperty("end_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object EndDate { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member