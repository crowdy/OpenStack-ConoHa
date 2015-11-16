namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using JSIStudios.SimpleRESTServices.Client;
    using net.openstack.Core.Exceptions;
    using net.openstack.Core.Exceptions.Response;
    using Newtonsoft.Json;
    using Objects.Images;
    using Objects;
    using JSIStudios.SimpleRESTServices.Client.Json;

    /// <summary>
    /// <para>The Cloud Images Provider enable simple access to the ConoHa Cloud Image Services.
    /// Cloud Images lets you create a virtual machine to be used for a server instance,
    /// which gives you greater control and security when you deploy web applications.</para>
    /// <para />
    /// <para>Documentation URL: http://developer.openstack.org/api-ref-image-v2.html </para>
    /// </summary>
    /// <see cref="IImagesProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudImagesProvider : ProviderBase<IImagesProvider>, IImagesProvider
    {
        private readonly HttpStatusCode[] _validResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFilesProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudImagesProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudImagesProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudImagesProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudImagesProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudImagesProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudImagesProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudImagesProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudImagesProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudImagesProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
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
        public CloudImagesProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService, bool isAdminMode)
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
        /// <exception cref="NoDefaultRegionSetException">If <paramref name="region"/> is <see langword="null"/> and no default region is available for the identity or provider.</exception>
        /// <exception cref="UserAuthenticationException">If no service catalog is available for the user.</exception>
        /// <exception cref="UserAuthorizationException">If no endpoint is available for the requested service.</exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected string GetServiceEndpoint(CloudIdentity identity, string region)
        {
            var endpoint = GetServiceEndpoint(identity, "image", "Image Service", region ?? "tyo1");
            return endpoint.PublicURL;
        }

        /// <inheritdoc/>
        protected string GetPublicServiceEndpoint(CloudIdentity identity, string region)
        {
            var endpoint = GetServiceEndpoint(identity, "image", "Image Service", region ?? "tyo1");
            return endpoint.PublicURL;
        }

        /// <inheritdoc/>
        protected string GetInternalServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetInternalServiceEndpoint(identity, "image", "Image Service", region ?? "tyo1");
        }

        /// <inheritdoc/>
        protected string GetAdminServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetAdminServiceEndpoint(identity, "image", "Image Service", region ?? "tyo1");
        }

        #endregion

        /// <inheritdoc/>
        public IEnumerable<CloudImage> ListGlanceImages(int? limit = 1000, string marker = null, string name = null, string visibility = null, string memberStatus = "accepted", string owner = null, string status = null, int? sizeMin = Int32.MinValue, int? sizeMax = Int32.MaxValue, string sortKey = "created_at", string sortDir = "desc", string tag = null, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"limit", limit.HasValue ? limit.ToString() : null},
                    {"marker", string.IsNullOrEmpty(marker) ? null : marker},
                    {"name", string.IsNullOrEmpty(name) ? null : name},
                    {"visibility", string.IsNullOrEmpty(visibility) ? null : visibility},
                    {"member_status", string.IsNullOrEmpty(memberStatus) ? null : memberStatus},
                    {"owner", string.IsNullOrEmpty(owner) ? null : owner},
                    {"status", string.IsNullOrEmpty(status) ? null : status},
                    {"size_min", sizeMin.HasValue ? sizeMin.ToString() : null},
                    {"size_max", sizeMax.HasValue ? sizeMax.ToString() : null},
                    {"sort_key", string.IsNullOrEmpty(sortKey) ? null : sortKey},
                    {"sort_dir", string.IsNullOrEmpty(sortDir) ? null : sortDir},
                    {"tag", string.IsNullOrEmpty(tag) ? null : tag}
                });

            var urlPath = new Uri(string.Format("{0}/v2/images", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListImagesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Images;
        }

        /// <inheritdoc/>
        public CloudImage GetGlanceImage(string imageId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/images/{1}", GetServiceEndpoint(identity, region), imageId));
            var response = ExecuteRESTRequest<CloudImage>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public bool DeleteGlanceImage(string imageId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/images/{1}", GetServiceEndpoint(identity, region), imageId));

            Response response = null;
            try
            {
                response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);
                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
            }
            catch (UserNotAuthorizedException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Forbidden)
                    throw new UserAuthorizationException("ERROR: Cannot delete image.");
            }

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }

        /// <inheritdoc/>
        public CloudImageMember CreateGlanceImageMember(string imageId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            var urlPath = new Uri(string.Format("{0}/v2/images/{1}/members", GetServiceEndpoint(identity, region), imageId));
            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<CloudImageMember> ListGlanceImageMembers(string imageId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            var urlPath = new Uri(string.Format("{0}/v2/images/{1}/members", GetServiceEndpoint(identity, region), imageId));
            return null;
        }

        /// <inheritdoc/>
        public CloudImageMember GetGlanceImageMember(string imageId, string memberId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (imageId == null)
                throw new ArgumentNullException("memberId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (string.IsNullOrEmpty(memberId))
                throw new ArgumentException("memberId cannot be empty");

            var urlPath = new Uri(string.Format("{0}/v2/images/{1}/members/{2}", GetServiceEndpoint(identity, region), imageId, memberId));
            return null;
        }

        /// <inheritdoc/>
        public bool UpdateGlanceImageMember(string imageId, string memberId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            var urlPath = new Uri(string.Format("{0}/v2/images/{1}/members", GetServiceEndpoint(identity, region), imageId));
            return false;
        }

        /// <inheritdoc/>
        public bool DeleteGlanceImageMember(string imageId, string memberId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            var urlPath = new Uri(string.Format("{0}/v2/images/{1}/members", GetServiceEndpoint(identity, region), imageId));
            return false;
        }

        #region

        /// <summary>
        /// Sets Image Quota
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> SetImageQuota(string quota, string region = null, CloudIdentity identity = null)
        {
            if (quota == null) { throw new ArgumentNullException("quota"); }
            if (string.IsNullOrEmpty(quota)) { throw new ArgumentException("quota cannot be empty"); }

            string request = String.Format("{{\"quota\":{{\"{0}_image_size\": \"{1}\"}}}}", region, quota);
            var urlPath = new Uri(string.Format("{0}/v2/quota", GetServiceEndpoint(identity, region)));

            var response = ExecuteRESTRequest<UpdateImageResponse>(identity, urlPath, HttpMethod.PUT, request);

            if (response == null || response.RawBody == null) { return null; }

            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(response.RawBody)["quota"];

        }

        #endregion

        #region

        /// <summary>
        /// Gets Image Amount
        /// </summary>
        public long GetImageAmount(string region = null, CloudIdentity identity = null)
        {
            var urlPath = new Uri(string.Format("{0}/v2/images/total", GetServiceEndpoint(identity, region)));
            Response<UpdateImageResponse> response = null;
            try
            {
                response = ExecuteRESTRequest<UpdateImageResponse>(identity, urlPath, HttpMethod.GET);
            }
            catch (ItemNotFoundException) { return 0; }

            if (response == null || response.RawBody == null) { return 0; }

            long retImageAmount = 0;
            long.TryParse(response.RawBody, out retImageAmount);

            return retImageAmount;
        }

        #endregion

        #region

        /// <summary>
        /// Gets the list of image which are used often
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CommonlyUsedImage> ListCommonlyUsedImages(string tenantId = null, string region = null, CloudIdentity identity = null)
        {
            string path = string.Empty;

            if (string.IsNullOrEmpty(tenantId) == true)
            {
                path = string.Format("{0}/v2/images/well-used", GetInternalServiceEndpoint(identity, region));

            }
            else
            {
                path = string.Format("{0}/v2/images/well-used?owner={1}", GetInternalServiceEndpoint(identity, region), tenantId);
            }
            var urlPath = new Uri(path);

            var response = ExecuteRESTRequest<CommonlyUsedImageResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.RawBody == null) { return null; }

            return (IEnumerable<CommonlyUsedImage>)response.Data.CommonlyUsedImages;
        }

        #endregion

        /// <summary>
        /// Sets Web Share
        /// </summary>
        public bool SetWebShare(string imageId, bool sharing, string region = null, CloudIdentity identity = null)
        {

            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/images/{1}", GetPublicServiceEndpoint(identity, region), imageId));

            string request = sharing ?
                @"[{ ""path"": ""/webshare"", ""value"": ""True"", ""op"": ""add""}]" :
                @"[{ ""path"": ""/webshare"", ""value"": ""False"", ""op"": ""replace""}]";

            RequestSettings requestSettings = BuildDefaultRequestSettings();
            requestSettings.ChunkRequest = true;
            requestSettings.ContentType = "application/openstack-images-v2.1-json-patch";

            try
            {
                var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.PATCH, request, settings: requestSettings);
                return response != null && _validResponseCode.Contains(response.StatusCode);
            }
            catch (ServiceConflictException)
            {
                if (sharing)
                {
                    request = @"[{ ""path"": ""/webshare"", ""value"": ""True"", ""op"": ""replace""}]";

                    var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.PATCH, request, settings: requestSettings);
                    return response != null && _validResponseCode.Contains(response.StatusCode);
                }

                return false;
            }
        }

        /// <summary>
        /// Imports Image
        /// </summary>
        public bool ImportImage(string name, string importFromUrl, string region = null, CloudIdentity identity = null)
        {

            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/tasks", GetPublicServiceEndpoint(identity, region)));

            string request =
                String.Format(@"{{""input"": {{""image_properties"": {{""name"": ""{0}""}}, ""import_from_format"": ""qcow2"", ""import_from"": ""{1}""}}, ""type"": ""import""}}",
                    name, importFromUrl);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            return response != null && _validResponseCode.Contains(response.StatusCode);
        }


        /// <summary>
        /// Gets the list of image task
        /// </summary>
        public IEnumerable<CloudImageTask> ListCloudImageTasks(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/tasks", GetPublicServiceEndpoint(identity, region)));

            var response = ExecuteRESTRequest<CloudImageTaskResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.RawBody == null) { return null; }

            return response.Data.Tasks;
        }

        /// <summary>
        /// Gets an image task
        /// </summary>
        public CloudImageTaskDetail GetCloudImageTask(string taskId, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/v2/tasks/{1}", GetPublicServiceEndpoint(identity, region), taskId));

            var response = ExecuteRESTRequest<CloudImageTaskDetail>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.RawBody == null) { return null; }

            return response.Data;
        }
    }
}
