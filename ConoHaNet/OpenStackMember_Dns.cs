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
        public IEnumerable<DnsServer> GetDnsServiceDetails(string domainId, string region = null)
        {
            return DnsProvider.GetDnsServiceDetails(domainId, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Domain> ListDomains(string region = null)
        {
            return DnsProvider.ListDomains(region, Identity);
        }

        /// <inheritdoc/>
        public Domain CreateDomain(string domainName, string email, int? ttl = null, string description = null, int? gslb = null, string region = null)
        {
            return DnsProvider.CreateDomain(domainName, email, ttl, description, gslb, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDomain(string domainId, string region = null)
        {
            return DnsProvider.DeleteDomain(domainId, region, Identity);
        }

        /// <inheritdoc/>
        public Domain GetDomain(string domainId, string region = null)
        {
            return DnsProvider.GetDomain(domainId, region);
        }

        /// <inheritdoc/>
        public Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, string region = null)
        {
            return DnsProvider.UpdateDomain(domainId, domainName, email, ttl, description, gslb, region, Identity);
        }

        #endregion


        #region Records

        /// <inheritdoc/>
        public IEnumerable<DnsRecord> ListDnsRecords(string domainId, string region = null)
        {
            return DnsProvider.ListDnsRecords(domainId, region, Identity);
        }

        /// <inheritdoc/>
        public DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null)
        {
            return DnsProvider.CreateDnsRecord(domainId, name, type, data, priority, ttl, description, gslbRegion, gslbWeight, gslbCheck, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDnsRecord(string domainId, string recordId, string region = null)
        {
            return DnsProvider.DeleteDnsRecord(domainId, recordId, region, Identity);
        }

        /// <inheritdoc/>
        public DnsRecord GetDnsRecord(string domainId, string recordId, string region = null)
        {
            return DnsProvider.GetDnsRecord(domainId, recordId, region, Identity);
        }

        /// <inheritdoc/>
        public DnsRecord UpdateDnsRecord(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null)
        {
            return DnsProvider.UpdateDnsRecord(domainId, recordId, name, type, data, priority, ttl, description, gslbRegion, gslbWeight, gslbCheck, region, Identity);
        }

        #endregion


        #region Zone

        /// <inheritdoc/>
        public Zone ImportZone(string zoneContent, string region = null)
        {
            return DnsProvider.ImportZone(zoneContent, region, Identity);
        }

        /// <inheritdoc/>
        public string ExportZone(string zoneId, string region = null)
        {
            return DnsProvider.ExportZone(zoneId, region, Identity);
        }

        #endregion

    }
}