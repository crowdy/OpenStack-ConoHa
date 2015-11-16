#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Identity
{
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON response used for the List Tenants request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_listTenants_v2.0_tenants_Tenant_Operations.html">List Tenants (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListTenantsResponse
    {
        /// <summary>
        /// Gets a collection of information about the tenants.
        /// </summary>
        [JsonProperty("tenants")]
        public Tenant[] Tenants { get; set; }

        /// <summary>
        /// Gets a collection of information about the tenant links.
        /// </summary>
        [JsonProperty("tenants_links")]
        public string[] TenantsLinks { get; set; }
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class CreateTenantRequest
    {
        [JsonProperty("tenant", DefaultValueHandling = DefaultValueHandling.Include)]
        public Tenant Tenant { get; set; }

        public CreateTenantRequest(string name, string description, bool enable)
        {
            Tenant = new Tenant(name, description, enable);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateTenantResponse
    {
        [JsonProperty("tenant", DefaultValueHandling = DefaultValueHandling.Include)]
        public Tenant Tenant { get; set; }
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class UpdateTenantRequest
    {
        [JsonProperty("tenant", DefaultValueHandling = DefaultValueHandling.Include)]
        public Tenant Tenant { get; set; }

        public UpdateTenantRequest(string name, string description, bool? enable)
        {
            Tenant = new Tenant(name, description, enable);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class UpdateTenantResponse
    {
        [JsonProperty("tenant", DefaultValueHandling = DefaultValueHandling.Include)]
        public Tenant Tenant { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member