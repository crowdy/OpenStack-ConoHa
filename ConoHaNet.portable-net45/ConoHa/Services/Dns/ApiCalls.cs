namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.Dns;
    using ConoHaNet.Service.Dns;

    // DnsServiceVersion GetDnsServiceVersion();
    // Task<GetDnsServiceVersionApiCall> PrepareGetDnsServiceVersionAsync(CancellationToken cancellationToken);
    public class GetDnsServiceVersionApiCall : DelegatingHttpApiCall<DnsServiceVersion>
    {
        public GetDnsServiceVersionApiCall(IHttpApiCall<DnsServiceVersion> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<DnsServer> GetDnsServiceDetails(string domainId, CloudIdentity identity = null);
    // Task<GetDnsServiceDetailsApiCall> PrepareGetDnsServiceDetailsAsync(string domainId, CancellationToken cancellationToken);
    public class GetDnsServiceDetailsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<DnsServer>>
    {
        public GetDnsServiceDetailsApiCall(IHttpApiCall<ReadOnlyCollectionPage<DnsServer>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<Domain> ListDomains(string region = null, CloudIdentity identity = null);
    // Task<ListDomainsApiCall> PrepareListDomainsAsync(string region = null, CancellationToken cancellationToken);
    public class ListDomainsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Domain>>
    {
        public ListDomainsApiCall(IHttpApiCall<ReadOnlyCollectionPage<Domain>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Domain CreateDomain(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, CloudIdentity identity = null);
    // Task<CreateDomainApiCall> PrepareCreateDomainAsync(string domainName, string email, int? ttl = 3600, string description = null, int? gslb = 0, CancellationToken cancellationToken);
    public class CreateDomainApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Domain>>
    {
        public CreateDomainApiCall(IHttpApiCall<ReadOnlyCollectionPage<Domain>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteDomain(string domainId, CloudIdentity identity = null);
    // Task<ListDeleteDomainApiCall> PrepareDeleteDomainAsync(string domainId, CancellationToken cancellationToken);
    public class ListDeleteDomainApiCall : DelegatingHttpApiCall<bool>
    {
        public ListDeleteDomainApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Domain GetDomain(string domainId, CloudIdentity identity = null);
    // Task<GetDomainApiCall> PrepareGetDomainAsync(string domainId, CancellationToken cancellationToken);
    public class GetDomainApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Domain>>
    {
        public GetDomainApiCall(IHttpApiCall<ReadOnlyCollectionPage<Domain>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, CloudIdentity identity = null);
    // Task<UpdateDomainApiCall> PrepareUpdateDomainAsync(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, CancellationToken cancellationToken);
    public class UpdateDomainApiCall : DelegatingHttpApiCall<Domain>
    {
        public UpdateDomainApiCall(IHttpApiCall<Domain> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<Domain> SearchDomain(string domainName, CloudIdentity identity = null);
    // Task<SearchDomainApiCall> PrepareSearchDomainAsync(string domainName, CancellationToken cancellationToken);
    public class SearchDomainApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Domain>>
    {
        public SearchDomainApiCall(IHttpApiCall<ReadOnlyCollectionPage<Domain>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<DnsRecord> ListDnsRecords(string domainId, CloudIdentity identity = null);
    // Task<ListDnsRecordsApiCall> PrepareListDnsRecordsAsync(string domainId, CancellationToken cancellationToken);
    public class ListDnsRecordsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<DnsRecord>>
    {
        public ListDnsRecordsApiCall(IHttpApiCall<ReadOnlyCollectionPage<DnsRecord>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CloudIdentity identity = null);
    // Task<CreateDnsRecordApiCall> PrepareCreateDnsRecordAsync(string domainId, string name, string type, string data, int? priority = null, int? ttl = 3600, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CancellationToken cancellationToken);
    public class CreateDnsRecordApiCall : DelegatingHttpApiCall<DnsRecord>
    {
        public CreateDnsRecordApiCall(IHttpApiCall<DnsRecord> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteDnsRecord(string domainId, string recordId, CloudIdentity identity = null);
    // Task<DeleteDnsRecordApiCall> PrepareDeleteDnsRecordAsync(string domainId, string recordId, CancellationToken cancellationToken);
    public class DeleteDnsRecordApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteDnsRecordApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // DnsRecord GetDnsRecord(string domainId, string recordId, CloudIdentity identity = null);
    // Task<GetDnsRecordApiCall> PrepareGetDnsRecordAsync(string domainId, string recordId, CancellationToken cancellationToken);
    public class GetDnsRecordApiCall : DelegatingHttpApiCall<DnsRecord>
    {
        public GetDnsRecordApiCall(IHttpApiCall<DnsRecord> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // DnsRecord UpdateDnsRecord(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CloudIdentity identity = null);
    // Task<UpdateDnsRecordApiCall> PrepareUpdateDnsRecordAsync(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, CancellationToken cancellationToken);
    public class UpdateDnsRecordApiCall : DelegatingHttpApiCall<DnsRecord>
    {
        public UpdateDnsRecordApiCall(IHttpApiCall<DnsRecord> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Zone ImportZone(string zoneContent, CloudIdentity identity = null);
    // Task<ImportZoneApiCall> PrepareImportZoneAsync(string zoneContent, CancellationToken cancellationToken);
    public class ImportZoneApiCall : DelegatingHttpApiCall<Zone>
    {
        public ImportZoneApiCall(IHttpApiCall<Zone> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // string ExportZone(string zoneId, CloudIdentity identity = null);
    // Task<ExportZoneApiCall> PrepareExportZoneAsync(string zoneId, CancellationToken cancellationToken);
    public class ExportZoneApiCall : DelegatingHttpApiCall<string>
    {
        public ExportZoneApiCall(IHttpApiCall<string> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetGslbSuspend(string domainId, bool enabled, CloudIdentity identity = null);
    // Task<SetGslbSuspendApiCall> PrepareSetGslbSuspendAsync(string domainId, bool enabled, CancellationToken cancellationToken);
    public class SetGslbSuspendApiCall : DelegatingHttpApiCall<bool>
    {
        public SetGslbSuspendApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }
}
