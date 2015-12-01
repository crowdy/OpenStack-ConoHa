namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.MailService;

    // MailServiceVersion GetMailServiceVersion();
    // Task<GetMailServiceVersionApiCall> PrepareGetMailServiceVersionAsync(CancellationToken cancellationToken);
    public class GetMailServiceVersionApiCall : DelegatingHttpApiCall<MailServiceVersion>
    {
        public GetMailServiceVersionApiCall(IHttpApiCall<MailServiceVersion> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailServiceVersion GetMailServiceVersionDetails();
    // Task<GetMailServiceVersionDetailsApiCall> PrepareGetMailServiceVersionDetailsAsync(CancellationToken cancellationToken);
    public class GetMailServiceVersionDetailsApiCall : DelegatingHttpApiCall<MailServiceVersion>
    {
        public GetMailServiceVersionDetailsApiCall(IHttpApiCall<MailServiceVersion> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailService CreateMailService(string serviceName, string defaultSubdomain, CloudIdentity identity = null);
    // Task<CreateMailServiceApiCall> PrepareCreateMailServiceAsync(string serviceName, string defaultSubdomain, CancellationToken cancellationToken);
    public class CreateMailServiceApiCall : DelegatingHttpApiCall<MailService>
    {
        public CreateMailServiceApiCall(IHttpApiCall<MailService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailService GetMailService(string serviceId, CloudIdentity identity = null);
    // Task<GetMailServiceApiCall> PrepareGetMailServiceAsync(string serviceId, CancellationToken cancellationToken);
    public class GetMailServiceApiCall : DelegatingHttpApiCall<MailService>
    {
        public GetMailServiceApiCall(IHttpApiCall<MailService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailService UpdateMailService(string serviceId, string serviceName, CloudIdentity identity = null);
    // Task<UpdateMailServiceApiCall> PrepareUpdateMailServiceAsync(string serviceId, string serviceName, CancellationToken cancellationToken);
    public class UpdateMailServiceApiCall : DelegatingHttpApiCall<MailService>
    {
        public UpdateMailServiceApiCall(IHttpApiCall<MailService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetMailServiceBackup(string serviceId, bool enabled, CloudIdentity identity = null);
    // Task<SetMailServiceBackupApiCall> PrepareSetMailServiceBackupAsync(string serviceId, bool enabled, CancellationToken cancellationToken);
    public class SetMailServiceBackupApiCall : DelegatingHttpApiCall<bool>
    {
        public SetMailServiceBackupApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteMailService(string serviceId, CloudIdentity identity = null);
    // Task<DeleteMailServiceApiCall> PrepareDeleteMailServiceAsync(string serviceId, CancellationToken cancellationToken);
    public class DeleteMailServiceApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteMailServiceApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailBoxQuota GetMailBoxQuota(string serviceId, CloudIdentity identity = null);
    // Task<GetMailBoxQuotaApiCall> PrepareGetMailBoxQuotaAsync(string serviceId, CancellationToken cancellationToken);
    public class GetMailBoxQuotaApiCall : DelegatingHttpApiCall<MailBoxQuota>
    {
        public GetMailBoxQuotaApiCall(IHttpApiCall<MailBoxQuota> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota, CloudIdentity identity = null);
    // Task<UpdateMailBoxQuotaApiCall> PrepareUpdateMailBoxQuotaAsync(string serviceId, int quota, CancellationToken cancellationToken);
    public class UpdateMailBoxQuotaApiCall : DelegatingHttpApiCall<MailBoxQuota>
    {
        public UpdateMailBoxQuotaApiCall(IHttpApiCall<MailBoxQuota> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailDomain CreateMailDomain(string serviceId, string domainName, CloudIdentity identity = null);
    // Task<CreateMailDomainApiCall> PrepareCreateMailDomainAsync(string serviceId, string domainName, CancellationToken cancellationToken);
    public class CreateMailDomainApiCall : DelegatingHttpApiCall<MailDomain>
    {
        public CreateMailDomainApiCall(IHttpApiCall<MailDomain> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<MailDomain> ListMailDomains(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
    // Task<ListMailDomainsApiCall> PrepareListMailDomainsAsync(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken);
    public class ListMailDomainsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<MailDomain>>
    {
        public ListMailDomainsApiCall(IHttpApiCall<ReadOnlyCollectionPage<MailDomain>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteMailDomain(string domainId, CloudIdentity identity = null);
    // Task<DeleteMailDomainApiCall> PrepareDeleteMailDomainAsync(string domainId, CancellationToken cancellationToken);
    public class DeleteMailDomainApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteMailDomainApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // string GetMailDomainDedicatedIp(string domainId, CloudIdentity identity = null);
    // Task<GetMailDomainDedicatedIpApiCall> PrepareGetMailDomainDedicatedIpAsync(string domainId, CancellationToken cancellationToken);
    public class GetMailDomainDedicatedIpApiCall : DelegatingHttpApiCall<String>
    {
        public GetMailDomainDedicatedIpApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // string SetMailDomainDedicatedIpStatus(string domainId, bool enabled, CloudIdentity identity = null);
    // Task<SetMailDomainDedicatedIpStatusApiCall> PrepareSetMailDomainDedicatedIpStatusAsync(string domainId, bool enabled, CancellationToken cancellationToken);
    public class SetMailDomainDedicatedIpStatusApiCall : DelegatingHttpApiCall<String>
    {
        public SetMailDomainDedicatedIpStatusApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Email CreateEmailAddress(string serviceId, string emailAddress, string password, CloudIdentity identity = null);
    // Task<CreateEmailAddressApiCall> PrepareCreateEmailAddressAsync(string serviceId, string emailAddress, string password, CancellationToken cancellationToken);
    public class CreateEmailAddressApiCall : DelegatingHttpApiCall<Email>
    {
        public CreateEmailAddressApiCall(IHttpApiCall<Email> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<Email> ListEmailAddresses(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
    // Task<ListEmailAddressesApiCall> PrepareListEmailAddressesAsync(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken);
    public class ListEmailAddressesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Email>>
    {
        public ListEmailAddressesApiCall(IHttpApiCall<ReadOnlyCollectionPage<Email>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Email GetEmailAddress(string emailId, CloudIdentity identity = null);
    // Task<GetEmailAddressApiCall> PrepareGetEmailAddressAsync(string emailId, CancellationToken cancellationToken);
    public class GetEmailAddressApiCall : DelegatingHttpApiCall<Email>
    {
        public GetEmailAddressApiCall(IHttpApiCall<Email> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteEmailAddress(string emailId, CloudIdentity identity = null);
    // Task<DeleteEmailAddressApiCall> PrepareDeleteEmailAddressAsync(string emailId, CancellationToken cancellationToken);
    public class DeleteEmailAddressApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteEmailAddressApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool ChangeEmailAddressPassword(string emailId, string password, CloudIdentity identity = null);
    // Task<ChangeEmailAddressPasswordApiCall> PrepareChangeEmailAddressPasswordAsync(string emailId, string password, CancellationToken cancellationToken);
    public class ChangeEmailAddressPasswordApiCall : DelegatingHttpApiCall<bool>
    {
        public ChangeEmailAddressPasswordApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetEmailSpamFilter(string emailId, bool enabled, string type = "tray", CloudIdentity identity = null);
    // Task<SetEmailSpamFilterApiCall> PrepareSetEmailSpamFilterAsync(string emailId, bool enabled, string type = "tray", CancellationToken cancellationToken);
    public class SetEmailSpamFilterApiCall : DelegatingHttpApiCall<bool>
    {
        public SetEmailSpamFilterApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetEmailVirusCheck(string emailId, bool enabled, CloudIdentity identity = null);
    // Task<SetEmailVirusCheckApiCall> PrepareSetEmailVirusCheckAsync(string emailId, bool enabled, CancellationToken cancellationToken);
    public class SetEmailVirusCheckApiCall : DelegatingHttpApiCall<bool>
    {
        public SetEmailVirusCheckApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetEmailForwardingCopy(string emailId, bool enabled, CloudIdentity identity = null);
    // Task<SetEmailForwardingCopyApiCall> PrepareSetEmailForwardingCopyAsync(string emailId, bool enabled, CancellationToken cancellationToken);
    public class SetEmailForwardingCopyApiCall : DelegatingHttpApiCall<bool>
    {
        public SetEmailForwardingCopyApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", CloudIdentity identity = null);
    // Task<ListMailMessageHeadersApiCall> PrepareListMailMessageHeadersAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", CancellationToken cancellationToken);
    public class ListMailMessageHeadersApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<MailMessageHeader>>
    {
        public ListMailMessageHeadersApiCall(IHttpApiCall<ReadOnlyCollectionPage<MailMessageHeader>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // MailMessage GetMailMessage(string emailId, string messageId, CloudIdentity identity = null);
    // Task<GetMailMessageApiCall> PrepareGetMailMessageAsync(string emailId, string messageId, CancellationToken cancellationToken);
    public class GetMailMessageApiCall : DelegatingHttpApiCall<MailMessage>
    {
        public GetMailMessageApiCall(IHttpApiCall<MailMessage> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Attachment GetMailAttachment(string emailId, string messageId, string attachmemntId, CloudIdentity identity = null);
    // Task<GetMailAttachmentApiCall> PrepareGetMailAttachmentAsync(string emailId, string messageId, string attachmemntId, CancellationToken cancellationToken);
    public class GetMailAttachmentApiCall : DelegatingHttpApiCall<Attachment>
    {
        public GetMailAttachmentApiCall(IHttpApiCall<Attachment> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteMailMessage(string emailId, string messageId, CloudIdentity identity = null);
    // Task<DeleteMailMessageApiCall> PrepareDeleteMailMessageAsync(string emailId, string messageId, CancellationToken cancellationToken);
    public class DeleteMailMessageApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteMailMessageApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword, CloudIdentity identity = null);
    // Task<CreateEmailWebHookApiCall> PrepareCreateEmailWebHookAsync(string emailId, string webhookUrl, string keyword, CancellationToken cancellationToken);
    public class CreateEmailWebHookApiCall : DelegatingHttpApiCall<EmailWebHook>
    {
        public CreateEmailWebHookApiCall(IHttpApiCall<EmailWebHook> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // EmailWebHook GetEmailWebHook(string emailId, CloudIdentity identity = null);
    // Task<GetEmailWebHookApiCall> PrepareGetEmailWebHookAsync(string emailId, CancellationToken cancellationToken);
    public class GetEmailWebHookApiCall : DelegatingHttpApiCall<EmailWebHook>
    {
        public GetEmailWebHookApiCall(IHttpApiCall<EmailWebHook> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // EmailWebHook UpdateEmailWebHook(string emailId, string webhookFilter, string keyword, CloudIdentity identity = null);
    // Task<UpdateEmailWebHookApiCall> PrepareUpdateEmailWebHookAsync(string emailId, string webhookFilter, string keyword, CancellationToken cancellationToken);
    public class UpdateEmailWebHookApiCall : DelegatingHttpApiCall<EmailWebHook>
    {
        public UpdateEmailWebHookApiCall(IHttpApiCall<EmailWebHook> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteEmailWebHook(string emailId, CloudIdentity identity = null);
    // Task<DeleteEmailWebHookApiCall> PrepareDeleteEmailWebHookAsync(string emailId, CancellationToken cancellationToken);
    public class DeleteEmailWebHookApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteEmailWebHookApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CloudIdentity identity = null);
    // Task<GetEmailWhiteListApiCall> PrepareGetEmailWhiteListAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CancellationToken cancellationToken);
    public class GetEmailWhiteListApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>>
    {
        public GetEmailWhiteListApiCall(IHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets, CloudIdentity identity = null);
    // Task<UpdateWhiteListApiCall> PrepareUpdateWhiteListAsync(string emailId, EmailFilterDetails[] targets, CancellationToken cancellationToken);
    public class UpdateWhiteListApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>>
    {
        public UpdateWhiteListApiCall(IHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CloudIdentity identity = null);
    // Task<GetEmailBlackListApiCall> PrepareGetEmailBlackListAsync(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", CancellationToken cancellationToken);
    public class GetEmailBlackListApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>>
    {
        public GetEmailBlackListApiCall(IHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets, CloudIdentity identity = null);
    // Task<UpdateBlackListApiCall> PrepareUpdateBlackListAsync(string emailId, EmailFilterDetails[] targets, CancellationToken cancellationToken);
    public class UpdateBlackListApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>>
    {
        public UpdateBlackListApiCall(IHttpApiCall<ReadOnlyCollectionPage<EmailFilterDetails>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress, CloudIdentity identity = null);
    // Task<CreateEmailForwardingApiCall> PrepareCreateEmailForwardingAsync(string emailId, string toForwardAddress, CancellationToken cancellationToken);
    public class CreateEmailForwardingApiCall : DelegatingHttpApiCall<EmailForwarding>
    {
        public CreateEmailForwardingApiCall(IHttpApiCall<EmailForwarding> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<EmailForwarding> ListEmailForwardings(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CloudIdentity identity = null);
    // Task<ListEmailForwardingsApiCall> PrepareListEmailForwardingsAsync(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", CancellationToken cancellationToken);
    public class ListEmailForwardingsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<EmailForwarding>>
    {
        public ListEmailForwardingsApiCall(IHttpApiCall<ReadOnlyCollectionPage<EmailForwarding>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // EmailForwarding GetEmailForwarding(string forwardingId, CloudIdentity identity = null);
    // Task<GetEmailForwardingApiCall> PrepareGetEmailForwardingAsync(CancellationToken cancellationToken);
    public class GetEmailForwardingApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<EmailForwarding>>
    {
        public GetEmailForwardingApiCall(IHttpApiCall<ReadOnlyCollectionPage<EmailForwarding>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress, CloudIdentity identity = null);
    // Task<UpdateEmailForwardingApiCall> PrepareUpdateEmailForwardingAsync(string forwardingId, string toForwardAddress, CancellationToken cancellationToken);
    public class UpdateEmailForwardingApiCall : DelegatingHttpApiCall<EmailForwarding>
    {
        public UpdateEmailForwardingApiCall(IHttpApiCall<EmailForwarding> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteEmailForwarding(string forwardingId, CloudIdentity identity = null);
    // Task<DeleteEmailForwardingApiCall> PrepareDeleteEmailForwardingAsync(string forwardingId, CancellationToken cancellationToken);
    public class DeleteEmailForwardingApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteEmailForwardingApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetMailServiceStatus(string serviceId, bool enabled, CloudIdentity identity = null);
    // Task<SetMailServiceStatusApiCall> PrepareSetMailServiceStatusAsync(string serviceId, bool enabled, CancellationToken cancellationToken);
    public class SetMailServiceStatusApiCall : DelegatingHttpApiCall<bool>
    {
        public SetMailServiceStatusApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

}
