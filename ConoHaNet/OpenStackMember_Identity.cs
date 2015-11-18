namespace ConoHaNet
{
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Objects.Identity;
    using Objects;

    public partial class OpenStackMember : IOpenStackMember
    {
        /// <inheritdoc/>
        public CloudIdentity Identity { get; set; }

        /// <inheritdoc/>
        public UserAccess UA { get; set; }

        private CloudIdentityProvider _IdentityProvider = null;

        /// <inheritdoc/>
        public CloudIdentityProvider IdentityProvider
        {
            get
            {
                if (_IdentityProvider == null)
                {
                    _IdentityProvider = new CloudIdentityProvider(this.Identity, DefaultPublicEndPointUri, this.IsAdminMode);
                    Trace.WriteLine("CloudIdentityProvider created.");

                }
                return _IdentityProvider;
            }
            set
            {
                _IdentityProvider = value;
            }
        }

        /// <inheritdoc/>
        public UserAccess CreateUserAccess()
        {
            if (this.UA == null)
                this.UA = this.IdentityProvider.GetUserAccess(Identity);
            return this.UA;
        }

        /// <inheritdoc/>
        public UserAccess CreateUserAccess(string username, string password, string tenantName = null, string tenantId = null)
        {
            CloudIdentity identity = null;
            if (tenantId == null)
            {
                identity = new CloudIdentity()
                {
                    Username = username,
                    Password = password
                };

            }
            else
            {
                identity = new CloudIdentityWithProject()
                {
                    ProjectId = (new ProjectId(tenantId ?? tenantName)),
                    ProjectName = tenantName,
                    Username = username,
                    Password = password
                };

            }

            CloudIdentityProvider identityProvider = new CloudIdentityProvider(identity, DefaultPublicEndPointUri);
            UserAccess ua = identityProvider.GetUserAccess(identity);
            this.UA = ua;
            return ua;
        }

        /// <summary>
        /// Gets the list of endpoint
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegionEndpoint> ListEndpoints()
        {
            if (this.UA == null)
                this.UA = IdentityProvider.GetUserAccess(Identity);
                // this.UA = IdentityProvider.GetInternalUserAccess(Identity);

            // region dictionary
            IDictionary<string, IDictionary<string, string>> regionEndpoints = new Dictionary<string, IDictionary<string, string>>();
            foreach (var catalog in this.UA.ServiceCatalog)
                foreach (var endpoint in catalog.Endpoints)
                    yield return new RegionEndpoint(catalog.Name, endpoint.Region, catalog.Type, endpoint.PublicURL);
        }

        #region

        /// <summary>
        /// Get Tenant Users
        /// </summary>
        public IEnumerable<User> ListTenantUsers(string tenantId = null)
        {
            return IdentityProvider.ListTenantUsers(tenantId ?? this.TenantId, this.Identity);
        }

        #endregion

    }
}
