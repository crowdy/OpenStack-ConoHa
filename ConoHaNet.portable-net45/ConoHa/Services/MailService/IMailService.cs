namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using MailService;
    using OpenStack.Services;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IMailService : IHttpService, IExtensibleService<IMailService>
    {
        #region ConoHa


        // MailServiceVersion GetMailServiceVersion();
        Task<GetMailServiceVersionApiCall> PrepareGetMailServiceVersionAsync(CancellationToken cancellationToken);

        // MailServiceVersion GetMailServiceVersionDetails();
        Task<GetMailServiceVersionDetailsApiCall> PrepareGetMailServiceVersionDetailsAsync(CancellationToken cancellationToken);

        // MailService CreateMailService(string serviceName, string defaultSubdomain, CloudIdentity identity = null);
        Task<CreateMailServiceApiCall> PrepareCreateMailServiceAsync(string serviceName, string defaultSubdomain, CancellationToken cancellationToken);

        // IEnumerable<MailService> CreateMailService(int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
        Task<CreateMailServiceApiCall> PrepareCreateMailServiceAsync(int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // MailService GetMailService(string serviceId, CloudIdentity identity = null);
        Task<GetMailServiceApiCall> PrepareGetMailServiceAsync(string serviceId, CancellationToken cancellationToken);

        // MailService UpdateMailService(string serviceId, string serviceName, CloudIdentity identity = null);
        Task<UpdateMailServiceApiCall> PrepareUpdateMailServiceAsync(string serviceId, string serviceName, CancellationToken cancellationToken);

        // bool SetMailServiceBackup(string serviceId, bool enabled, CloudIdentity identity = null);
        Task<SetMailServiceBackupApiCall> PrepareSetMailServiceBackupAsync(string serviceId, bool enabled, CancellationToken cancellationToken);

        // bool DeleteMailService(string serviceId, CloudIdentity identity = null);
        Task<DeleteMailServiceApiCall> PrepareDeleteMailServiceAsync(string serviceId, CancellationToken cancellationToken);

        // MailBoxQuota GetMailBoxQuota(string serviceId, CloudIdentity identity = null);
        Task<GetMailBoxQuotaApiCall> PrepareGetMailBoxQuotaAsync(string serviceId, CancellationToken cancellationToken);

        // MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota, CloudIdentity identity = null);
        Task<UpdateMailBoxQuotaApiCall> PrepareUpdateMailBoxQuotaAsync(string serviceId, int quota, CancellationToken cancellationToken);

        // MailDomain CreateMailDomain(string serviceId, string domainName, CloudIdentity identity = null);
        Task<CreateMailDomainApiCall> PrepareCreateMailDomainAsync(string serviceId, string domainName, CancellationToken cancellationToken);

        // IEnumerable<MailDomain> ListMailDomains(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
        Task<ListMailDomainsApiCall> PrepareListMailDomainsAsync(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteMailDomain(string domainId, CloudIdentity identity = null);
        Task<DeleteMailDomainApiCall> PrepareDeleteMailDomainAsync(string domainId, CancellationToken cancellationToken);

        // string GetMailDomainDedicatedIp(string domainId, CloudIdentity identity = null);
        Task<GetMailDomainDedicatedIpApiCall> PrepareGetMailDomainDedicatedIpAsync(string domainId, CancellationToken cancellationToken);

        // string SetMailDomainDedicatedIpStatus(string domainId, bool enabled, CloudIdentity identity = null);
        Task<SetMailDomainDedicatedIpStatusApiCall> PrepareSetMailDomainDedicatedIpStatusAsync(string domainId, bool enabled, CancellationToken cancellationToken);

        // Email CreateEmailAddress(string serviceId, string emailAddress, string password, CloudIdentity identity = null);
        Task<CreateEmailAddressApiCall> PrepareCreateEmailAddressAsync(string serviceId, string emailAddress, string password, CancellationToken cancellationToken);

        // IEnumerable<Email> ListEmailAddresses(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
        Task<ListEmailAddressesApiCall> PrepareListEmailAddressesAsync(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // Email GetEmailAddress(string emailId, CloudIdentity identity = null);
        Task<GetEmailAddressApiCall> PrepareGetEmailAddressAsync(string emailId, CancellationToken cancellationToken);

        // bool DeleteEmailAddress(string emailId, CloudIdentity identity = null);
        Task<DeleteEmailAddressApiCall> PrepareDeleteEmailAddressAsync(string emailId, CancellationToken cancellationToken);

        // bool ChangeEmailAddressPassword(string emailId, string password, CloudIdentity identity = null);
        Task<ChangeEmailAddressPasswordApiCall> PrepareChangeEmailAddressPasswordAsync(string emailId, string password, CancellationToken cancellationToken);

        // bool SetEmailSpamFilter(string emailId, bool enabled, string type = "tray", CloudIdentity identity = null);
        Task<SetEmailSpamFilterApiCall> PrepareSetEmailSpamFilterAsync(string emailId, bool enabled, string type = "tray", CancellationToken cancellationToken = default(CancellationToken));

        // bool SetEmailVirusCheck(string emailId, bool enabled, CloudIdentity identity = null);
        Task<SetEmailVirusCheckApiCall> PrepareSetEmailVirusCheckAsync(string emailId, bool enabled, CancellationToken cancellationToken);

        // bool SetEmailForwardingCopy(string emailId, bool enabled, CloudIdentity identity = null);
        Task<SetEmailForwardingCopyApiCall> PrepareSetEmailForwardingCopyAsync(string emailId, bool enabled, CancellationToken cancellationToken);

        // IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", CloudIdentity identity = null);
        Task<ListMailMessageHeadersApiCall> PrepareListMailMessageHeadersAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // MailMessage GetMailMessage(string emailId, string messageId, CloudIdentity identity = null);
        Task<GetMailMessageApiCall> PrepareGetMailMessageAsync(string emailId, string messageId, CancellationToken cancellationToken);

        // Attachment GetMailAttachment(string emailId, string messageId, string attachmemntId, CloudIdentity identity = null);
        Task<GetMailAttachmentApiCall> PrepareGetMailAttachmentAsync(string emailId, string messageId, string attachmemntId, CancellationToken cancellationToken);

        // bool DeleteMailMessage(string emailId, string messageId, CloudIdentity identity = null);
        Task<DeleteMailMessageApiCall> PrepareDeleteMailMessageAsync(string emailId, string messageId, CancellationToken cancellationToken);

        // EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword, CloudIdentity identity = null);
        Task<CreateEmailWebHookApiCall> PrepareCreateEmailWebHookAsync(string emailId, string webhookUrl, string keyword, CancellationToken cancellationToken);

        // EmailWebHook GetEmailWebHook(string emailId, CloudIdentity identity = null);
        Task<GetEmailWebHookApiCall> PrepareGetEmailWebHookAsync(string emailId, CancellationToken cancellationToken);

        // EmailWebHook UpdateEmailWebHook(string emailId, string webhookFilter, string keyword, CloudIdentity identity = null);
        Task<UpdateEmailWebHookApiCall> PrepareUpdateEmailWebHookAsync(string emailId, string webhookFilter, string keyword, CancellationToken cancellationToken);

        // bool DeleteEmailWebHook(string emailId, CloudIdentity identity = null);
        Task<DeleteEmailWebHookApiCall> PrepareDeleteEmailWebHookAsync(string emailId, CancellationToken cancellationToken);

        // IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CloudIdentity identity = null);
        Task<GetEmailWhiteListApiCall> PrepareGetEmailWhiteListAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets, CloudIdentity identity = null);
        Task<UpdateWhiteListApiCall> PrepareUpdateWhiteListAsync(string emailId, EmailFilterDetails[] targets, CancellationToken cancellationToken);

        // IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CloudIdentity identity = null);
        Task<GetEmailBlackListApiCall> PrepareGetEmailBlackListAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets, CloudIdentity identity = null);
        Task<UpdateBlackListApiCall> PrepareUpdateBlackListAsync(string emailId, EmailFilterDetails[] targets, CancellationToken cancellationToken);

        // EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress, CloudIdentity identity = null);
        Task<CreateEmailForwardingApiCall> PrepareCreateEmailForwardingAsync(string emailId, string toForwardAddress, CancellationToken cancellationToken);

        // IEnumerable<EmailForwarding> ListEmailForwardings(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
        Task<ListEmailForwardingsApiCall> PrepareListEmailForwardingsAsync(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken = default(CancellationToken));

        // EmailForwarding GetEmailForwarding(string forwardingId, CloudIdentity identity = null);
        Task<GetEmailForwardingApiCall> PrepareGetEmailForwardingAsync(CancellationToken cancellationToken);

        // EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress, CloudIdentity identity = null);
        Task<UpdateEmailForwardingApiCall> PrepareUpdateEmailForwardingAsync(string forwardingId, string toForwardAddress, CancellationToken cancellationToken);

        // bool DeleteEmailForwarding(string forwardingId, CloudIdentity identity = null);
        Task<DeleteEmailForwardingApiCall> PrepareDeleteEmailForwardingAsync(string forwardingId, CancellationToken cancellationToken);

        // bool SetMailServiceStatus(string serviceId, bool enabled, CloudIdentity identity = null);
        Task<SetMailServiceStatusApiCall> PrepareSetMailServiceStatusAsync(string serviceId, bool enabled, CancellationToken cancellationToken);

        #endregion
    }
}
