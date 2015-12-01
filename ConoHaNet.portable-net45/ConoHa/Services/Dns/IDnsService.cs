namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using OpenStack.Services;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IDnsService : IHttpService, IExtensibleService<IDnsService>
    {
        #region ConoHa

        // DnsServiceVersion GetDnsServiceVersion();
        Task<GetDnsServiceVersionApiCall> PrepareGetDnsServiceVersionAsync(CancellationToken cancellationToken);

        // IEnumerable<DnsServer> GetDnsServiceDetails(string domainId, CloudIdentity identity = null);
        Task<GetDnsServiceDetailsApiCall> PrepareGetDnsServiceDetailsAsync(string domainId, CancellationToken cancellationToken);

        // IEnumerable<Domain> ListDomains(string region = null, CloudIdentity identity = null);
        Task<ListDomainsApiCall> PrepareListDomainsAsync(string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // Domain CreateDomain(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, CloudIdentity identity = null);
        Task<CreateDomainApiCall> PrepareCreateDomainAsync(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteDomain(string domainId, CloudIdentity identity = null);
        Task<ListDeleteDomainApiCall> PrepareDeleteDomainAsync(string domainId, CancellationToken cancellationToken);

        // Domain GetDomain(string domainId, CloudIdentity identity = null);
        Task<GetDomainApiCall> PrepareGetDomainAsync(string domainId, CancellationToken cancellationToken);

        // Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, CloudIdentity identity = null);
        Task<UpdateDomainApiCall> PrepareUpdateDomainAsync(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<Domain> SearchDomain(string domainName, CloudIdentity identity = null);
        Task<SearchDomainApiCall> PrepareSearchDomainAsync(string domainName, CancellationToken cancellationToken);

        // IEnumerable<DnsRecord> ListDnsRecords(string domainId, CloudIdentity identity = null);
        Task<ListDnsRecordsApiCall> PrepareListDnsRecordsAsync(string domainId, CancellationToken cancellationToken);

        // DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CloudIdentity identity = null);
        Task<CreateDnsRecordApiCall> PrepareCreateDnsRecordAsync(string domainId, string name, string type, string data, int? priority = null, int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteDnsRecord(string domainId, string recordId, CloudIdentity identity = null);
        Task<DeleteDnsRecordApiCall> PrepareDeleteDnsRecordAsync(string domainId, string recordId, CancellationToken cancellationToken);

        // DnsRecord GetDnsRecord(string domainId, string recordId, CloudIdentity identity = null);
        Task<GetDnsRecordApiCall> PrepareGetDnsRecordAsync(string domainId, string recordId, CancellationToken cancellationToken);

        // DnsRecord UpdateDnsRecord(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CloudIdentity identity = null);
        Task<UpdateDnsRecordApiCall> PrepareUpdateDnsRecordAsync(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CancellationToken cancellationToken = default(CancellationToken));

        // Zone ImportZone(string zoneContent, CloudIdentity identity = null);
        Task<ImportZoneApiCall> PrepareImportZoneAsync(string zoneContent, CancellationToken cancellationToken);

        // string ExportZone(string zoneId, CloudIdentity identity = null);
        Task<ExportZoneApiCall> PrepareExportZoneAsync(string zoneId, CancellationToken cancellationToken);

        // bool SetGslbSuspend(string domainId, bool enabled, CloudIdentity identity = null);
        Task<SetGslbSuspendApiCall> PrepareSetGslbSuspendAsync(string domainId, bool enabled, CancellationToken cancellationToken);

        #endregion
    }
}
