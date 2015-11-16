#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects
{
    using Providers;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the basic JSON description of a tenant.
    /// </summary>
    /// <seealso cref="IIdentityProvider.ListTenants"/>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class Tenant : ExtensibleJsonObject
    {
        /// <summary>
        /// Gets the unique identifier for the tenant.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the "name" property for the tenant.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("description ", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Description { get; set; }

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        [JsonProperty("domain_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DomainId { get; set; }

        public Tenant(string name, string description, bool? enable)
        {
            Name = name;
            Description = description;
            Enabled = enable;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member