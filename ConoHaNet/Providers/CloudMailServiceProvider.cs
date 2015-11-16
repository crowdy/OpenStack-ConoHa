namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using Newtonsoft.Json;
    using Objects.Mails;
    using Objects;
    using JSIStudios.SimpleRESTServices.Client.Json;

    /// <summary>
    /// Represents a provider for the OpenStack Networking service.
    /// </summary>
    public interface ICloudMailServiceProvider
    {
        /// <summary>
        /// Gets the version data of this provider
        /// </summary>
        MailServiceVersion GetMailServiceVersion();

        /// <summary>
        /// Gets the detail of service provider
        /// </summary>
        MailServiceVersion GetMailServiceVersionDetails();

        #region Services

        /// <summary>
        /// Creates a mail service, which is a container of mail address
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="defaultSubdomain"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-mail-service.html"/>
        MailService CreateMailService(string serviceName, string defaultSubdomain, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets a collection of mail service
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-mail-service.html"/>
        IEnumerable<MailService> ListMailServices(int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the mail service with service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-service.html"/>
        MailService GetMailService(string serviceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the mail service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-mail-service.html"/>
        MailService UpdateMailService(string serviceId, string serviceName, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Toggles mail service activity
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-backup.html"/>
        bool SetMailServiceBackup(string serviceId, bool enabled, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the mail service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-mail-service.html"/>
        bool DeleteMailService(string serviceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets mail box quota available
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-email-quotas.html"/>
        MailBoxQuota GetMailBoxQuota(string serviceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates mail box quota
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="quota"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-quotas.html"/>
        MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota, string region = null, CloudIdentity identity = null);

        #endregion

        #region Domains

        /// <summary>
        /// Creates a mail domain
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="domainName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email.html"/>
        MailDomain CreateMailDomain(string serviceId, string domainName, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets a collection of mail domains using
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-domains.html"/>
        IEnumerable<MailDomain> ListMailDomains(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the mail domain with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email.html"/>
        bool DeleteMailDomain(string domainId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Get a dedicated ip for the mail domain
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-dedicated-ip.html"/>
        string GetMailDomainDedicatedIp(string domainId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Update the statusof thededicated ip for email 
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-dedicated-ip.html"/>
        string SetMailDomainDedicatedIpStatus(string domainId, bool enabled, string region = null, CloudIdentity identity = null);

        #endregion

        #region MailAddresses

        /// <summary>
        /// Creates an email address
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email.html"/>
        Email CreateEmailAddress(string serviceId, string emailAddress, string password, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets a collection of email addresses
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-domain.html"/>
        IEnumerable<Email> ListEmailAddresses(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the email address with email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-email.html"/>
        Email GetEmailAddress(string emailId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the email address with email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email.html"/>
        bool DeleteEmailAddress(string emailId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates email address password
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-password.html"/>
        bool ChangeEmailAddressPassword(string emailId, string password, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Toggles email spam filter activity
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="enabled"></param>
        /// <param name="type"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email-spam-filter.html"/>
        bool SetEmailSpamFilter(string emailId, bool enabled, string type = "tray", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Sets the activity of virus check for emails
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool SetEmailVirusCheck(string emailId, bool enabled, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Toggle the value which indicates whether the copy would be remained or not
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool SetEmailForwardingCopy(string emailId, bool enabled, string region = null, CloudIdentity identity = null);

        #endregion

        #region Messages

        /// <summary>
        /// Gets the list of email message's header
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-messages.html"/>
        IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the email message with email id and message id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="messageId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-messages.html"/>
        MailMessage GetMailMessage(string emailId, string messageId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the attachment of email by email id, message id and attachment id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="messageId"></param>
        /// <param name="attachmemntId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-messages-attachments.html"/>
        Attachment GetMailAttachment(string emailId, string messageId, string attachmemntId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the email message with message id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="messageId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-messages.html"/>
        bool DeleteMailMessage(string emailId, string messageId, string region = null, CloudIdentity identity = null);

        #endregion

        #region WebHooks

        /// <summary>
        /// Creates a email web hook
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="webhookUrl"></param>
        /// <param name="keyword"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email-webhook.html"/>
        EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the email web hook with email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-filter.html"/>
        EmailWebHook GetEmailWebHook(string emailId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates email web hook
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="webhookFilter"></param>
        /// <param name="keyword"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-filter.html"/>
        EmailWebHook UpdateEmailWebHook(string emailId, string webhookFilter, string keyword, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the email web hook
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email-filter.html"/>
        bool DeleteEmailWebHook(string emailId, string region = null, CloudIdentity identity = null);

        #endregion

        #region Filtering

        /// <summary>
        /// Gets the list of email white addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-whitelist.html"/>
        IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the list of email whilte addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="targets"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-whitelist.html"/>
        IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of email black addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-blacklist.html"/>
        IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the list of email black addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="targets"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-blacklist.html"/>
        IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets, string region = null, CloudIdentity identity = null);

        #endregion

        #region Forwardings

        /// <summary>
        /// Creates email forwarding setting
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="toForwardAddress"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email-forwarding.html"/>
        EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of email forwarding
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-forwarding.html"/>
        IEnumerable<EmailForwarding> ListEmailForwardings(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the email forward setting with forwarding id
        /// </summary>
        /// <param name="forwardingId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-email-forwarding.html"/>
        EmailForwarding GetEmailForwarding(string forwardingId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the email forward setting
        /// </summary>
        /// <param name="forwardingId"></param>
        /// <param name="toForwardAddress"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-filter.html"/>
        EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the email forwarding setting with forwarding id
        /// </summary>
        /// <param name="forwardingId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email-forwarding.html"/>
        bool DeleteEmailForwarding(string forwardingId, string region = null, CloudIdentity identity = null);

        #endregion

        /// <summary>
        /// Sets the email service activity status 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool SetMailServiceStatus(string serviceId, bool enabled, string region = null, CloudIdentity identity = null);
    }


    /// <summary>
    /// <para>The Cloud Networks Provider enable simple access to the ConoHa Cloud Network Services.
    /// Cloud Networks lets you create a virtual Layer 2 network, known as an isolated network,
    /// which gives you greater control and security when you deploy web applications.</para>
    /// <para />
    /// <para>Documentation URL: https://www.google.co.jp/search?q=openstack+</para>
    /// </summary>
    /// <see cref="CloudMailServiceProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudMailServiceProvider : ProviderBase<ICloudMailServiceProvider>, ICloudMailServiceProvider
    {
        private readonly HttpStatusCode[] _validResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFilesProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudMailServiceProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudMailServiceProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudMailServiceProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudMailServiceProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudMailServiceProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudMailServiceProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudMailServiceProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudMailServiceProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudMailServiceProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, defaultRegion, identityProvider, restService, false)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="defaultRegion"></param>
        /// <param name="identityProvider"></param>
        /// <param name="restService"></param>
        /// <param name="isAdminMode"></param>
        public CloudMailServiceProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService, bool isAdminMode)
            : base(identity, defaultRegion, identityProvider, restService, null, isAdminMode)
        { }

        #endregion


        #region Private methods

        /// <summary>
        /// Gets the public service endpoint to use for Cloud Networks requests for the specified identity and region.
        /// </summary>
        /// <remarks>
        /// This method uses <c>compute</c> for the service type, and <c>cloudServersOpenStack</c> for the preferred service name.
        /// </remarks>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <param name="region">The preferred region for the service. If this value is <see langword="null"/>, the user's default region will be used.</param>
        /// <returns>The public URL for the requested Cloud Networks endpoint.</returns>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// </exception>
        /// <exception cref="net.openstack.Core.Exceptions.NoDefaultRegionSetException">If <paramref name="region"/> is <see langword="null"/> and no default region is available for the identity or provider.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.UserAuthenticationException">If no service catalog is available for the user.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.UserAuthorizationException">If no endpoint is available for the requested service.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected string GetServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetPublicServiceEndpoint(identity, "mailhosting", "Mail Hosting Service", region ?? base.DefaultRegion ?? "tyo1");
        }

        #endregion

        /// <summary>
        /// not implemented
        /// </summary>
        public MailServiceVersion GetMailServiceVersion()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// not implemented
        /// </summary>
        public MailServiceVersion GetMailServiceVersionDetails()
        {
            throw new NotImplementedException();
        }


        #region Services

        /// <inheritdoc/>
        public MailService CreateMailService(string serviceName, string defaultSubdomain, string region = null, CloudIdentity identity = null)
        {
            if (serviceName == null)
                throw new ArgumentNullException("serviceName");
            if (string.IsNullOrEmpty(serviceName))
                throw new ArgumentException("serviceName cannot be empty");
            if (defaultSubdomain == null)
                throw new ArgumentNullException("defaultSubdomain");
            if (string.IsNullOrEmpty(defaultSubdomain))
                throw new ArgumentException("defaultSubdomain cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services", GetServiceEndpoint(identity, region)));

            var request = new Dictionary<string, string>
                {
                    {"service_name", serviceName },
                    {"default_sub_domain", defaultSubdomain }
                };

            var response = ExecuteRESTRequest<GetMailServiceResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Service;
        }

        /// <inheritdoc/>
        public IEnumerable<MailService> ListMailServices(int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services", GetServiceEndpoint(identity, region)));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<ListMailServicesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Services;
        }

        /// <inheritdoc/>
        public MailService GetMailService(string serviceId, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}", GetServiceEndpoint(identity, region), serviceId));

            var response = ExecuteRESTRequest<GetMailServiceResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Service;
        }

        /// <inheritdoc/>
        public MailService UpdateMailService(string serviceId, string serviceName, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            if (serviceName == null)
                throw new ArgumentNullException("serviceName");
            if (string.IsNullOrEmpty(serviceName))
                throw new ArgumentException("serviceName cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}", GetServiceEndpoint(identity, region), serviceId));

            var request = new Dictionary<string, string>() { { "service_name", serviceName } };
            var response = ExecuteRESTRequest<GetMailServiceResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Service;
        }

        /// <inheritdoc/>
        public bool SetMailServiceBackup(string serviceId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/action", GetServiceEndpoint(identity, region), serviceId));

            var request = new SetMailServiceBackupRequest(enabled ? "enable" : "disable");
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool DeleteMailService(string serviceId, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}", GetServiceEndpoint(identity, region), serviceId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public MailBoxQuota GetMailBoxQuota(string serviceId, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/quotas", GetServiceEndpoint(identity, region), serviceId));

            var response = ExecuteRESTRequest<GetMailBoxQuotaResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.MailBoxQuota;
        }

        /// <inheritdoc/>
        public MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/quotas", GetServiceEndpoint(identity, region), serviceId));

            var request = new Dictionary<string, int>() { { "quota", quota } };
            var response = ExecuteRESTRequest<GetMailBoxQuotaResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.MailBoxQuota;
        }

        #endregion


        #region Domains

        /// <inheritdoc/>
        public MailDomain CreateMailDomain(string serviceId, string domainName, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            if (domainName == null)
                throw new ArgumentNullException("domainName");
            if (string.IsNullOrEmpty(domainName))
                throw new ArgumentException("domainName cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/domains", GetServiceEndpoint(identity, region)));

            var request = new Dictionary<string, string>
                {
                    {"service_id", serviceId},
                    {"domain_name", domainName}
                };

            var response = ExecuteRESTRequest<GetMailDomainResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.MailDomain;
        }

        /// <inheritdoc/>
        public IEnumerable<MailDomain> ListMailDomains(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/domains", GetServiceEndpoint(identity, region)));

            var parameters = new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                };

            if (!string.IsNullOrEmpty(serviceId))
                parameters.Add("service_id", serviceId);

            var response = ExecuteRESTRequest<ListMailDomainsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: BuildOptionalParameterList(parameters));

            if (response == null || response.Data == null)
                return null;

            return response.Data.MailDomains;
        }

        /// <inheritdoc/>
        public bool DeleteMailDomain(string domainId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/domains/{1}", GetServiceEndpoint(identity, region), domainId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public string GetMailDomainDedicatedIp(string domainId, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/domains/{1}/dedicatedip", GetServiceEndpoint(identity, region), domainId));

            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(ExecuteRESTRequest(identity, urlPath, HttpMethod.GET).RawBody);

            string retVal = null;

            if (response == null || !response.TryGetValue("dedicatedip", out retVal))
                return null;

            return retVal;
        }

        /// <inheritdoc/>
        public string SetMailDomainDedicatedIpStatus(string domainId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/domains/{1}/action", GetServiceEndpoint(identity, region), domainId));

            var request = new SetMailDomainDedicatedIpStatusRequest(enabled ? "enable" : "disable");

            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(ExecuteRESTRequest(identity, urlPath, HttpMethod.PUT, request).RawBody);

            string retVal = null;

            if (response == null || !response.TryGetValue("dedicatedip", out retVal))
                return null;

            return retVal;
        }

        #endregion


        #region MailAddresses

        /// <inheritdoc/>
        public Email CreateEmailAddress(string domainId, string emailAddress, string password, string region = null, CloudIdentity identity = null)
        {
            if (domainId == null)
                throw new ArgumentNullException("domainId");
            if (string.IsNullOrEmpty(domainId))
                throw new ArgumentException("domainId cannot be empty");
            if (emailAddress == null)
                throw new ArgumentNullException("emailAddress");
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("emailAddress cannot be empty");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails", GetServiceEndpoint(identity, region)));

            var request = new Dictionary<string, string>
                {
                    {"domain_id", domainId},
                    {"email", emailAddress},
                    {"password", password}
                };

            var response = ExecuteRESTRequest<GetEmailResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Email;
        }

        /// <inheritdoc/>
        public IEnumerable<Email> ListEmailAddresses(string domainId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails", GetServiceEndpoint(identity, region)));

            var parameters = new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                };

            if (!string.IsNullOrEmpty(domainId))
                parameters.Add("domain_id", domainId);

            var response = ExecuteRESTRequest<ListMailAddressesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: BuildOptionalParameterList(parameters));

            if (response == null || response.Data == null)
                return null;

            return response.Data.Emails;
        }

        /// <inheritdoc/>
        public Email GetEmailAddress(string emailId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}", GetServiceEndpoint(identity, region), emailId));

            var response = ExecuteRESTRequest<GetEmailResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Email;
        }

        /// <inheritdoc/>
        public bool DeleteEmailAddress(string emailId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}", GetServiceEndpoint(identity, region), emailId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool ChangeEmailAddressPassword(string emailId, string password, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/password", GetServiceEndpoint(identity, region), emailId));

            var request = new Dictionary<string, string>() { { "password", password } };
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool SetEmailSpamFilter(string emailId, bool enabled, string type = "tray", string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/action", GetServiceEndpoint(identity, region), emailId));

            var request = new SpamFilterActionRequest(enabled ? "enable" : "disable", type);
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool SetEmailVirusCheck(string emailId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/action", GetServiceEndpoint(identity, region), emailId));

            var request = new UpdateVirusCheckStatusRequest(enabled ? "enable" : "disable");
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool SetEmailForwardingCopy(string emailId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/action", GetServiceEndpoint(identity, region), emailId));

            var request = new EmailForwardingCopyActionRequest(enabled ? "enable" : "disable");
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        #endregion


        #region Messages

        /// <inheritdoc/>
        public IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/messages", GetServiceEndpoint(identity, region), emailId));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<ListMailMessageHeadersResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.MailMessageHeaders;
        }

        /// <inheritdoc/>
        public MailMessage GetMailMessage(string emailId, string messageId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (messageId == null)
                throw new ArgumentNullException("messageId");
            if (string.IsNullOrEmpty(messageId))
                throw new ArgumentException("messageId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/messages", GetServiceEndpoint(identity, region), emailId));

            var response = ExecuteRESTRequest<GetMailMessageResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.MailMessage;
        }

        /// <inheritdoc/>
        public Attachment GetMailAttachment(string emailId, string messageId, string attachmemntId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (messageId == null)
                throw new ArgumentNullException("messageId");
            if (string.IsNullOrEmpty(messageId))
                throw new ArgumentException("messageId cannot be empty");
            if (attachmemntId == null)
                throw new ArgumentNullException("attachmemntId");
            if (string.IsNullOrEmpty(attachmemntId))
                throw new ArgumentException("attachmemntId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/messages/{2}/attachments/{3}", GetServiceEndpoint(identity, region), emailId, messageId, attachmemntId));

            var response = ExecuteRESTRequest<GetAttachmentResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Attachment;
        }

        /// <inheritdoc/>
        public bool DeleteMailMessage(string emailId, string messageId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (messageId == null)
                throw new ArgumentNullException("messageId");
            if (string.IsNullOrEmpty(messageId))
                throw new ArgumentException("messageId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/messages", GetServiceEndpoint(identity, region), emailId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        #endregion


        #region WebHooks

        /// <inheritdoc/>
        public EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (webhookUrl == null)
                throw new ArgumentNullException("webhookUrl");
            if (string.IsNullOrEmpty(webhookUrl))
                throw new ArgumentException("webhookUrl cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/webhook", GetServiceEndpoint(identity, region), emailId));

            var request = new Dictionary<string, string>
                {
                    {"webhook_url", webhookUrl},
                    {"webhook_keyword", keyword}
                };

            var response = ExecuteRESTRequest<EmailWebHook>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public EmailWebHook GetEmailWebHook(string emailId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/webhook", GetServiceEndpoint(identity, region), emailId));

            var response = ExecuteRESTRequest<GetEmailWebHookResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.EmailWebHook;
        }

        /// <inheritdoc/>
        public EmailWebHook UpdateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (webhookUrl == null)
                throw new ArgumentNullException("webhookUrl");
            if (string.IsNullOrEmpty(webhookUrl))
                throw new ArgumentException("webhookUrl cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/webhook", GetServiceEndpoint(identity, region), emailId));

            var request = new Dictionary<string, string>
                {
                    {"webhook_url", webhookUrl},
                    {"webhook_keyword", keyword}
                };

            var response = ExecuteRESTRequest<GetEmailWebHookResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.EmailWebHook;
        }

        /// <inheritdoc/>
        public bool DeleteEmailWebHook(string emailId, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/webhook", GetServiceEndpoint(identity, region), emailId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        #endregion


        #region Filtering

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/whitelist", GetServiceEndpoint(identity, region), emailId));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<EmailFilter>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Targets;
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (targets == null)
                throw new ArgumentNullException("targets");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/whitelist", GetServiceEndpoint(identity, region), emailId));

            var response = ExecuteRESTRequest<EmailFilter>(identity, urlPath, HttpMethod.PUT, targets);

            if (response == null || response.Data == null || response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Targets;
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = 0, int? limit = 1000, string sortKey = "target", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/blacklist", GetServiceEndpoint(identity, region), emailId));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                });

            var response = ExecuteRESTRequest<EmailFilter>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Targets;
        }

        /// <inheritdoc/>
        public IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (targets == null)
                throw new ArgumentNullException("targets");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/emails/{1}/blacklist", GetServiceEndpoint(identity, region), emailId));

            var response = ExecuteRESTRequest<EmailFilter>(identity, urlPath, HttpMethod.PUT, targets);

            if (response == null || response.Data == null || response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Targets;
        }

        #endregion


        #region Forwardings

        /// <inheritdoc/>
        public EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress, string region = null, CloudIdentity identity = null)
        {
            if (emailId == null)
                throw new ArgumentNullException("emailId");
            if (string.IsNullOrEmpty(emailId))
                throw new ArgumentException("emailId cannot be empty");
            if (toForwardAddress == null)
                throw new ArgumentNullException("toForwardAddress");
            if (string.IsNullOrEmpty(toForwardAddress))
                throw new ArgumentException("toForwardAddress cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/forwarding", GetServiceEndpoint(identity, region)));

            var request = new Dictionary<string, string>
                {
                    {"email_id", emailId},
                    {"address", toForwardAddress}
                };

            var response = ExecuteRESTRequest<GetEmailForwardingResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Forwarding;
        }

        /// <inheritdoc/>
        public IEnumerable<EmailForwarding> ListEmailForwardings(string emailId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null)
        {
            if (offset.HasValue && offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit.HasValue && limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/forwarding", GetServiceEndpoint(identity, region)));

            var parameters = new Dictionary<string, string>
                {
                    {"offset", !offset.HasValue ? null : offset.Value.ToString()},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_type", string.IsNullOrEmpty(sortType) ? null : sortType}
                };

            if (!string.IsNullOrEmpty(emailId))
                parameters.Add("email_id", emailId);

            var response = ExecuteRESTRequest<ListEmailForwardingsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: BuildOptionalParameterList(parameters));

            if (response == null || response.Data == null)
                return null;

            return response.Data.Forwardings;
        }

        /// <inheritdoc/>
        public EmailForwarding GetEmailForwarding(string forwardingId, string region = null, CloudIdentity identity = null)
        {
            if (forwardingId == null)
                throw new ArgumentNullException("forwardingId");
            if (string.IsNullOrEmpty(forwardingId))
                throw new ArgumentException("forwardingId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/forwarding/{1}", GetServiceEndpoint(identity, region), forwardingId));

            var response = ExecuteRESTRequest<GetEmailForwardingResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Forwarding;
        }

        /// <inheritdoc/>
        public EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress, string region = null, CloudIdentity identity = null)
        {
            if (forwardingId == null)
                throw new ArgumentNullException("forwardingId");
            if (string.IsNullOrEmpty(forwardingId))
                throw new ArgumentException("forwardingId cannot be empty");
            if (toForwardAddress == null)
                throw new ArgumentNullException("toForwardAddress");
            if (string.IsNullOrEmpty(toForwardAddress))
                throw new ArgumentException("toForwardAddress cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/forwarding/{1}", GetServiceEndpoint(identity, region), forwardingId));

            var request = new Dictionary<string, string> { { "address", toForwardAddress } };
            var response = ExecuteRESTRequest<GetEmailForwardingResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data.Forwarding;
        }

        /// <inheritdoc/>
        public bool DeleteEmailForwarding(string forwardingId, string region = null, CloudIdentity identity = null)
        {
            if (forwardingId == null)
                throw new ArgumentNullException("forwardingId");
            if (string.IsNullOrEmpty(forwardingId))
                throw new ArgumentException("forwardingId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/forwarding/{1}", GetServiceEndpoint(identity, region), forwardingId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        #endregion


        /// <inheritdoc/>
        public bool SetMailServiceStatus(string serviceId, bool enabled, string region = null, CloudIdentity identity = null)
        {
            if (serviceId == null)
                throw new ArgumentNullException("serviceId");
            if (string.IsNullOrEmpty(serviceId))
                throw new ArgumentException("serviceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/services/{1}/action", GetServiceEndpoint(identity, region), serviceId));

            var request = new SetMailServiceStatusRequest(enabled ? "enable" : "disable");
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

    }
}
