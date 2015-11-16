namespace ConoHaNet
{
    using Objects.Identity;
    using Objects;
    using System;

    public partial class OpenStackMember : IOpenStackMember
    {

        private string _defaultPublicEndPoint = "https://identity.tyo1.conoha.io/v2.0";

        /// <summary>
        /// Gets the Default public endpoint
        /// </summary>
        public string DefaultPublicEndPoint
        {
            get
            {
                return _defaultPublicEndPoint;
            }
            set
            {
                _defaultPublicEndPoint = value;
                SetProviders();
            }
        }

        /// <summary>
        /// Gets the default public endpoint uri
        /// </summary>
        public Uri DefaultPublicEndPointUri
        {
            get
            {
                return new Uri(DefaultPublicEndPoint);
            }
        }

        /// <summary>
        /// Gets or Sets user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or Sets the tenant id
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or Sets the tenant name
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Gets or Sets the default region
        /// </summary>
        public string DefaultRegion { get; set; }

        /// <summary>
        /// Initializes a new instance of the OpenStackMember class.”
        /// </summary>
        public OpenStackMember()
        {
        }

        /// <summary>
        /// Creats an OpenStack Member
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="tenantName"></param>
        /// <param name="tenantId"></param>
        /// <param name="defaultregion"></param>
        /// <param name="bLazyProviderSetting"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OpenStackMember(string username, string password, string tenantName = null, string tenantId = null, string defaultregion = "tyo1", bool bLazyProviderSetting = false)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("username cannot be empty");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");

            this.UserName = username;
            this.TenantId = tenantId;
            this.TenantName = tenantName;

            CloudIdentity identity = null;
            if (tenantName != null || tenantId != null)
            {
                identity = new CloudIdentityWithProject()
                {
                    ProjectId = (new ProjectId(tenantId ?? tenantName)),
                    ProjectName = tenantName,
                    Username = username,
                    Password = password
                };
            }
            else
            {
                identity = new CloudIdentity()
                {
                    Username = username,
                    Password = password
                };
            }

            this.Identity = identity;
            this.DefaultRegion = defaultregion;
            if (!bLazyProviderSetting)
                SetProviders();
        }

        /// <summary>
        /// Gets or Sets internal admin mode
        /// </summary>
        protected bool IsAdminMode { get; set; }

        /// <summary>
        /// Sets the default behavior
        /// </summary>
        protected virtual void SetProviders()
        {
            IsAdminMode = false;
        }

        /// <summary>
        /// Sets default region
        /// </summary>
        /// <param name="region"></param>
        public void SetDefaultRegion(string region)
        {
            this.DefaultRegion = region;
        }

        /// <summary>
        /// Convert DateTime to UnixTime
        /// </summary>
        protected string toUnixTime(DateTime pcTime)
        {
            double unixTime = pcTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return ((int)unixTime).ToString();
        }
    }
}
