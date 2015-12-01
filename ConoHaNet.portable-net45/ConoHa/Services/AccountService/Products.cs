#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.AccountService
{
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListProductsResponse
    {
        [JsonProperty("product_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ProdctBase[] ProductItems { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member