namespace ConoHaNet
{
    using Objects.Mails;
    using Providers;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudMailServiceProvider _MailServiceProvider = null;

        /// <summary>
        /// defines CloudMailServiceProvider instance
        /// </summary>
        public CloudMailServiceProvider MailServiceProvider
        {
            get
            {
                if (_MailServiceProvider == null)
                {
                    _MailServiceProvider = new CloudMailServiceProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudMailServiceProvider created.");

                }
                return _MailServiceProvider;
            }
        }


        #region Services

        /// <inheritdoc/>
        public MailService CreateMailService(string serviceName, string defaultSubdomain, string region = null)
        {
            return MailServiceProvider.CreateMailService(serviceName, defaultSubdomain, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<MailService> ListMailServices(int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.ListMailServices(offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public MailService GetMailService(string serviceId, string region = null)
        {
            return MailServiceProvider.GetMailService(serviceId, region, Identity);
        }

        /// <inheritdoc/>
        public MailService UpdateMailService(string serviceId, string serviceName, string region = null)
        {
            return MailServiceProvider.UpdateMailService(serviceId, serviceName, region, Identity);
        }

        /// <inheritdoc/>
        public bool SetMailServiceBackup(string serviceId, bool enabled, string region = null)
        {
            return MailServiceProvider.SetMailServiceBackup(serviceId, enabled, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteMailService(string serviceId, string region = null)
        {
            return MailServiceProvider.DeleteMailService(serviceId, region, Identity);
        }

        /// <inheritdoc/>
        public MailBoxQuota GetMailBoxQuota(string serviceId, string region = null)
        {
            return MailServiceProvider.GetMailBoxQuota(serviceId, region, Identity);
        }

        /// <inheritdoc/>
        public MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota, string region = null)
        {
            return MailServiceProvider.UpdateMailBoxQuota(serviceId, quota, region, Identity);
        }

        #endregion


        #region Domains

        /// <inheritdoc/>
        public MailDomain CreateMailDomain(string serviceId, string domainName, string region = null)
        {
            return MailServiceProvider.CreateMailDomain(serviceId, domainName, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<MailDomain> ListMailDomains(string serviceId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.ListMailDomains(serviceId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteMailDomain(string domainId, string region = null)
        {
            return MailServiceProvider.DeleteMailDomain(domainId, region, Identity);
        }

        /// <inheritdoc/>
        public string GetMailDomainDedicatedIp(string domainId, string region = null)
        {
            return MailServiceProvider.GetMailDomainDedicatedIp(domainId, region, Identity);
        }

        /// <inheritdoc/>
        public string SetMailDomainDedicatedIpStatus(string domainId, bool enabled, string region = null)
        {
            return MailServiceProvider.SetMailDomainDedicatedIpStatus(domainId, enabled, region, Identity);
        }

        #endregion


        #region MailAddresses

        /// <inheritdoc/>
        public Email CreateEmailAddress(string domainId, string emailAddress, string password, string region = null)
        {
            return MailServiceProvider.CreateEmailAddress(domainId, emailAddress, password, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Email> ListEmailAddresses(string domainId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.ListEmailAddresses(domainId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public Email GetEmailAddress(string emailId, string region = null)
        {
            return MailServiceProvider.GetEmailAddress(emailId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteEmailAddress(string emailId, string region = null)
        {
            return MailServiceProvider.DeleteEmailAddress(emailId, region, Identity);
        }

        /// <inheritdoc/>
        public bool ChangeEmailAddressPassword(string emailId, string password, string region = null)
        {
            return MailServiceProvider.ChangeEmailAddressPassword(emailId, password, region, Identity);
        }

        /// <inheritdoc/>
        public bool SetEmailSpamFilter(string emailId, bool enabled, string type = null, string region = null)
        {
            return MailServiceProvider.SetEmailSpamFilter(emailId, enabled, type, region, Identity);
        }

        /// <inheritdoc/>
        public bool SetEmailVirusCheck(string emailId, bool enabled, string region = null)
        {
            return MailServiceProvider.SetEmailVirusCheck(emailId, enabled, region, Identity);
        }

        /// <inheritdoc/>
        public bool SetEmailForwardingCopy(string emailId, bool enabled, string region = null)
        {
            return MailServiceProvider.SetEmailForwardingCopy(emailId, enabled, region, Identity);
        }

        #endregion


        #region Messages

        /// <inheritdoc/>
        public IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.ListMailMessageHeaders(emailId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public MailMessage GetMailMessage(string emailId, string messageId, string region = null)
        {
            return MailServiceProvider.GetMailMessage(emailId, messageId, region, Identity);
        }

        /// <inheritdoc/>
        public Attachment GetMailAttachment(string emailId, string messageId, string attachmentId, string region = null)
        {
            return MailServiceProvider.GetMailAttachment(emailId, messageId, attachmentId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteMailMessage(string emailId, string messageId, string region = null)
        {
            return MailServiceProvider.DeleteMailMessage(emailId, messageId, region, Identity);
        }

        #endregion


        #region WebHooks

        /// <inheritdoc/>
        public EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null)
        {
            return MailServiceProvider.CreateEmailWebHook(emailId, webhookUrl, keyword, region, Identity);
        }

        /// <inheritdoc/>
        public EmailWebHook GetEmailWebHook(string emailId, string region = null)
        {
            return MailServiceProvider.GetEmailWebHook(emailId, region, Identity);
        }

        /// <inheritdoc/>
        public EmailWebHook UpdateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null)
        {
            return MailServiceProvider.UpdateEmailWebHook(emailId, webhookUrl, keyword, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteEmailWebHook(string emailId, string region = null)
        {
            return MailServiceProvider.DeleteEmailWebHook(emailId, region, Identity);
        }

        #endregion


        #region Filtering

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.GetEmailWhiteList(emailId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets, string region = null)
        {
            return MailServiceProvider.UpdateWhiteList(emailId, targets, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.GetEmailBlackList(emailId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets, string region = null)
        {
            return MailServiceProvider.UpdateBlackList(emailId, targets, region, Identity);
        }

        #endregion


        #region Forwardings

        /// <inheritdoc/>
        public EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress, string region = null)
        {
            return MailServiceProvider.CreateEmailForwarding(emailId, toForwardAddress, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailForwarding> ListEmailForwardings(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return MailServiceProvider.ListEmailForwardings(emailId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public EmailForwarding GetEmailForwarding(string forwardingId, string region = null)
        {
            return MailServiceProvider.GetEmailForwarding(forwardingId, region, Identity);
        }

        /// <inheritdoc/>
        public EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress, string region = null)
        {
            return MailServiceProvider.UpdateEmailForwarding(forwardingId, toForwardAddress, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteEmailForwarding(string forwardingId, string region = null)
        {
            return MailServiceProvider.DeleteEmailForwarding(forwardingId, region, Identity);
        }

        #endregion
    }
}
