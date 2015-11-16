namespace ConoHaNet.Objects.Servers
{
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON response used for the List Flavors request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/List_Flavors-d1e4188.html">List Flavors (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListFlavorsResponse
    {
        /// <summary>
        /// Gets a collection of basic information about the available flavors.
        /// </summary>
        [JsonProperty("flavors")]
        public Flavor[] Flavors { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the List Flavors with Details request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/List_Flavors-d1e4188.html">List Flavors (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListFlavorDetailsResponse
    {
        /// <summary>
        /// Gets a collection of detailed information about the flavors.
        /// </summary>
        [JsonProperty("flavors")]
        public FlavorDetails[] Flavors { get; private set; }

    }

    /// <summary>
    /// This models the JSON response used for the Get Flavor Details request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Get_Flavor_Details-d1e4317.html">Get Flavor Details (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class FlavorDetailsResponse
    {
        /// <summary>
        /// Gets detailed information about the flavor.
        /// </summary>
        [JsonProperty("flavor")]
        public FlavorDetails Flavor { get; private set; }
    }
}
