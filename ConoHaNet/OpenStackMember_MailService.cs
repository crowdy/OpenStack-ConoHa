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
        public MailService CreateMailService(string serviceName, string defaultSubdomain)
        {
            return MailServiceProvider.CreateMailService(serviceName, defaultSubdomain, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<MailService> ListMailServices(int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.ListMailServices(offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public MailService GetMailService(string serviceId)
        {
            return MailServiceProvider.GetMailService(serviceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public MailService UpdateMailService(string serviceId, string serviceName)
        {
            return MailServiceProvider.UpdateMailService(serviceId, serviceName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool SetMailServiceBackup(string serviceId, bool enabled)
        {
            return MailServiceProvider.SetMailServiceBackup(serviceId, enabled, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteMailService(string serviceId)
        {
            return MailServiceProvider.DeleteMailService(serviceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public MailBoxQuota GetMailBoxQuota(string serviceId)
        {
            return MailServiceProvider.GetMailBoxQuota(serviceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota)
        {
            return MailServiceProvider.UpdateMailBoxQuota(serviceId, quota, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Domains

        /// <inheritdoc/>
        public MailDomain CreateMailDomain(string serviceId, string domainName)
        {
            return MailServiceProvider.CreateMailDomain(serviceId, domainName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<MailDomain> ListMailDomains(string serviceId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.ListMailDomains(serviceId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteMailDomain(string domainId)
        {
            return MailServiceProvider.DeleteMailDomain(domainId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string GetMailDomainDedicatedIp(string domainId)
        {
            return MailServiceProvider.GetMailDomainDedicatedIp(domainId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string SetMailDomainDedicatedIpStatus(string domainId, bool enabled)
        {
            return MailServiceProvider.SetMailDomainDedicatedIpStatus(domainId, enabled, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region MailAddresses

        /// <inheritdoc/>
        public Email CreateEmailAddress(string domainId, string emailAddress, string password)
        {
            return MailServiceProvider.CreateEmailAddress(domainId, emailAddress, password, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Email> ListEmailAddresses(string domainId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.ListEmailAddresses(domainId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Email GetEmailAddress(string emailId)
        {
            return MailServiceProvider.GetEmailAddress(emailId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteEmailAddress(string emailId)
        {
            return MailServiceProvider.DeleteEmailAddress(emailId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ChangeEmailAddressPassword(string emailId, string password)
        {
            return MailServiceProvider.ChangeEmailAddressPassword(emailId, password, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool SetEmailSpamFilter(string emailId, bool enabled, string type = null)
        {
            return MailServiceProvider.SetEmailSpamFilter(emailId, enabled, type, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool SetEmailVirusCheck(string emailId, bool enabled)
        {
            return MailServiceProvider.SetEmailVirusCheck(emailId, enabled, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool SetEmailForwardingCopy(string emailId, bool enabled)
        {
            return MailServiceProvider.SetEmailForwardingCopy(emailId, enabled, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Messages

        /// <inheritdoc/>
        public IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.ListMailMessageHeaders(emailId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public MailMessage GetMailMessage(string emailId, string messageId)
        {
            return MailServiceProvider.GetMailMessage(emailId, messageId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Attachment GetMailAttachment(string emailId, string messageId, string attachmentId)
        {
            return MailServiceProvider.GetMailAttachment(emailId, messageId, attachmentId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteMailMessage(string emailId, string messageId)
        {
            return MailServiceProvider.DeleteMailMessage(emailId, messageId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region WebHooks

        /// <inheritdoc/>
        public EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword)
        {
            return MailServiceProvider.CreateEmailWebHook(emailId, webhookUrl, keyword, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public EmailWebHook GetEmailWebHook(string emailId)
        {
            return MailServiceProvider.GetEmailWebHook(emailId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public EmailWebHook UpdateEmailWebHook(string emailId, string webhookUrl, string keyword)
        {
            return MailServiceProvider.UpdateEmailWebHook(emailId, webhookUrl, keyword, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteEmailWebHook(string emailId)
        {
            return MailServiceProvider.DeleteEmailWebHook(emailId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Filtering

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.GetEmailWhiteList(emailId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets)
        {
            return MailServiceProvider.UpdateWhiteList(emailId, targets, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.GetEmailBlackList(emailId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets)
        {
            return MailServiceProvider.UpdateBlackList(emailId, targets, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Forwardings

        /// <inheritdoc/>
        public EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress)
        {
            return MailServiceProvider.CreateEmailForwarding(emailId, toForwardAddress, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<EmailForwarding> ListEmailForwardings(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return MailServiceProvider.ListEmailForwardings(emailId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public EmailForwarding GetEmailForwarding(string forwardingId)
        {
            return MailServiceProvider.GetEmailForwarding(forwardingId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress)
        {
            return MailServiceProvider.UpdateEmailForwarding(forwardingId, toForwardAddress, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteEmailForwarding(string forwardingId)
        {
            return MailServiceProvider.DeleteEmailForwarding(forwardingId, this.DefaultRegion, this.Identity);
        }

        #endregion
    }
}
