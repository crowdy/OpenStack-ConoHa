namespace ConoHaNet
{
    using Objects.Dns;
    using Providers;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {
        private CloudDnsProvider _DnsProvider = null;

        /// <inheritdoc/>
        public CloudDnsProvider DnsProvider
        {
            get
            {
                if (_DnsProvider == null)
                {
                    _DnsProvider = new CloudDnsProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudDnsProvider created.");

                }
                return _DnsProvider;
            }
        }

        #region Domains

        /// <inheritdoc/>
        public IEnumerable<DnsServer> GetDnsServiceDetails(string domainId)
        {
            return DnsProvider.GetDnsServiceDetails(domainId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Domain> ListDomains()
        {
            return DnsProvider.ListDomains(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Domain CreateDomain(string domainName, string email, int? ttl = null, string description = null, int? gslb = null)
        {
            return DnsProvider.CreateDomain(domainName, email, ttl, description, gslb, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDomain(string domainId)
        {
            return DnsProvider.DeleteDomain(domainId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Domain GetDomain(string domainId)
        {
            return DnsProvider.GetDomain(domainId, this.DefaultRegion);
        }

        /// <inheritdoc/>
        public Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null)
        {
            return DnsProvider.UpdateDomain(domainId, domainName, email, ttl, description, gslb, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Records

        /// <inheritdoc/>
        public IEnumerable<DnsRecord> ListDnsRecords(string domainId)
        {
            return DnsProvider.ListDnsRecords(domainId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null)
        {
            return DnsProvider.CreateDnsRecord(domainId, name, type, data, priority, ttl, description, gslbRegion, gslbWeight, gslbCheck, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDnsRecord(string domainId, string recordId)
        {
            return DnsProvider.DeleteDnsRecord(domainId, recordId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DnsRecord GetDnsRecord(string domainId, string recordId)
        {
            return DnsProvider.GetDnsRecord(domainId, recordId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DnsRecord UpdateDnsRecord(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null)
        {
            return DnsProvider.UpdateDnsRecord(domainId, recordId, name, type, data, priority, ttl, description, gslbRegion, gslbWeight, gslbCheck, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Zone

        /// <inheritdoc/>
        public Zone ImportZone(string zoneContent)
        {
            return DnsProvider.ImportZone(zoneContent, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string ExportZone(string zoneId)
        {
            return DnsProvider.ExportZone(zoneId, this.DefaultRegion, this.Identity);
        }

        #endregion

    }
}