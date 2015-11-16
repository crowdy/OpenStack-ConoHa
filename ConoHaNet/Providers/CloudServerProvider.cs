namespace ConoHaNet.Providers
{
    using System.Collections.Generic;
    using System;
    using Objects.Servers;
    using Objects;


    /// <summary>
    /// Represents a provider for the OpenStack Compute service.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/">OpenStack Compute API v2 and Extensions Reference</seealso>
    public partial interface IComputeProvider
    {
        /// <summary>
        /// Gets the list of vm instance backup service
        /// </summary>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-get_backup_list.html"/>
        IEnumerable<BackupService> ListBackupServices(string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the vm backup service with backup id
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-get_backup_list_detailed.html"/>
        BackupService GetBackupService(string backupId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Create a backup vm service
        /// </summary>
        /// <param name="InstanceId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-start_backup.html"/>
        BackupService AddBackupService(string InstanceId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the vm backup service
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-end_backup.html"/>
        bool DeleteBackupService(string backupId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Restores the VM instance with backup
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="backupRunId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-restore_backup.html"/>
        bool RestoreFromBackupRun(string backupId, string backupRunId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this might not be supported
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="backupRunId"></param>
        /// <param name="imageName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Inactivates auto backup service
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool StopBackup(string backupId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Resumes auto backup service
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool ResumeBackup(string backupId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Changes storage controller with bus name
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="hwDiskBus"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-hw_disk_bus.html"/>
        bool ChangeStorageController(string serverId, string hwDiskBus, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Changes the network adapter with model string
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="hwVifModel"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-hw_vif_model.html"/>
        bool ChangeNetworkAdapter(string serverId, string hwVifModel, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Chages the video device with model string
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="hwVideoModel"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-hw_video_model.html"/>
        bool ChangeVideoDevice(string serverId, string hwVideoModel, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Changes Vnc key map
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="vncKeymap"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-vnc_key_map.html"/>
        bool ChangeVncKeymap(string serverId, string vncKeymap, string region = null, CloudIdentity identity = null);


        /// <summary>
        /// Gets CPU graph data
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="startDateRaw"></param>
        /// <param name="endDateRaw"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_cpu_utilization_graph.html"/>
        string GetCPUGraph(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets disk graph data
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="deviceName"></param>
        /// <param name="startDateRaw"></param>
        /// <param name="endDateRaw"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_disk_io_graph.html"/>
        string GetDiskIOGraph(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets network graph data
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="portId"></param>
        /// <param name="startDateRaw"></param>
        /// <param name="endDateRaw"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_server_addresses_by_network.html"/>
        string GetNetworkGraph(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the number how much swift requests occured
        /// </summary>
        /// <param name="startDateRaw"></param>
        /// <param name="endDateRaw"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-get_objectstorage_request_rrd.html"/>
        string GetSwiftRequestGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets data of the swift network traffic amount occurred
        /// </summary>
        /// <param name="startDateRaw"></param>
        /// <param name="endDateRaw"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-get_objectstorage_size_rrd.html"/>
        string GetSwiftSizeGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="imageName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool CreateGlanceImageFromInstance(string serverId, string imageName, string region = null, CloudIdentity identity = null);

        /// <summary>
        ///  Waits until vm's status is the specific value
        /// </summary>

        Objects.Servers.Server WaitForVMState(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Waits until vm's status is the specific value
        /// </summary>
        Objects.Servers.Server WaitForVMState(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null);


        /// <summary>
        /// Rebuilds the vm instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="imageRef"></param>
        /// <param name="adminPassword"></param>
        /// <param name="keyName"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        Objects.Servers.Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null, string region = null, CloudIdentity identity = null);
    }
}

namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using JSIStudios.SimpleRESTServices.Client;
    using net.openstack.Core.Exceptions.Response;
    using ConoHaNet.Objects.Servers;
    using ConoHaNet.Objects.Networks;
    using Objects;
    using JSIStudios.SimpleRESTServices.Client.Json;

    /// <summary>
    /// <para>The Cloud Servers Provider enables simple access go the ConoHa next generation Cloud Servers powered by OpenStack.
    /// The next generation service is a fast, reliable, and scalable cloud compute solution without the risk of proprietary lock-in.
    /// It provides the core features of the OpenStack Compute API v2 and also deploys certain extensions as permitted by the OpenStack Compute API contract.
    /// Some of these extensions are generally available through OpenStack while others implement ConoHa-specific features
    /// to meet customers�f expectations and for operational compatibility. The OpenStack Compute API and the ConoHa extensions are
    /// known collectively as API v2.</para>
    /// <para />
    /// <para>Documentation URL: https://www.google.co.jp/search?q=openstack+</para>
    /// </summary>
    /// <see cref="IComputeProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudServersProvider : ProviderBase<IComputeProvider>, IComputeProvider
    {
        private readonly HttpStatusCode[] _validServerActionResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Accepted, HttpStatusCode.NonAuthoritativeInformation, HttpStatusCode.NoContent };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudServersProvider()
            : this(null, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity, no default region, and the default identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        public CloudServersProvider(CloudIdentity identity)
            : this(identity, null, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// no default identity or region, the default identity provider, and the specified
        /// REST service implementation.
        /// </summary>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudServersProvider(IRestService restService)
            : this(null, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// no default identity or region, the specified identity provider, and the default
        /// REST service implementation.
        /// </summary>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created with no default identity.</param>
        public CloudServersProvider(IIdentityProvider identityProvider)
            : this(null, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity and identity provider, no default region, and
        /// the default REST service implementation.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="identityProvider">The identity provider to use for authenticating requests to this provider. If this value is <see langword="null"/>, a new instance of <see cref="CloudIdentityProvider"/> is created using <paramref name="identity"/> as the default identity.</param>
        public CloudServersProvider(CloudIdentity identity, IIdentityProvider identityProvider)
            : this(identity, null, identityProvider, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity and REST service implementation, no default region,
        /// and the default identity provider.
        /// </summary>
        /// <param name="identity">The default identity to use for calls that do not explicitly specify an identity. If this value is <see langword="null"/>, no default identity is available so all calls must specify an explicit identity.</param>
        /// <param name="restService">The implementation of <see cref="IRestService"/> to use for executing REST requests. If this value is <see langword="null"/>, the provider will use a new instance of <see cref="JsonRestServices"/>.</param>
        public CloudServersProvider(CloudIdentity identity, IRestService restService)
            : this(identity, null, null, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity, no default region, and the specified identity
        /// provider and REST service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudServersProvider(CloudIdentity identity, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, null, identityProvider, restService)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudServersProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudServersProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService)
            : this(identity, defaultRegion, identityProvider, restService, false)
        { }

        /// <inheritdoc />
        public CloudServersProvider(CloudIdentity identity, string defaultRegion, IIdentityProvider identityProvider, IRestService restService, bool isAdminMode)
            : base(identity, defaultRegion, identityProvider, restService, null, isAdminMode)
        { }

        #endregion

        #region Servers

        /// <inheritdoc />
        public IEnumerable<SimpleServer> ListServers(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null, string region = null, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            //var urlPath = new Uri(string.Format("{0}/servers", GetServiceEndpoint(identity, region)));
            string endpint = GetServiceEndpoint(identity, region);
            var urlPath = new Uri(string.Format("{0}/servers", endpint));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"image", imageId},
                    {"flavor", flavorId},
                    {"name", name},
                    {"status", status != null ? status.Name : null},
                    {"marker", markerId},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"changes-since", !changesSince.HasValue ? null : changesSince.Value.ToString("yyyy-MM-ddThh:mm:ss")}
                });

            var response = ExecuteRESTRequest<ListServersResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return BuildCloudServersProviderAwareObject<SimpleServer>(response.Data.Servers, region, identity);
        }

        /// <inheritdoc />
        public IEnumerable<Server> ListServersWithDetails(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null, string region = null, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/detail", GetServiceEndpoint(identity, region)));

            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"image", imageId},
                    {"flavor", flavorId},
                    {"name", name},
                    {"status", status != null ? status.Name : null},
                    {"marker", markerId},
                    {"limit", !limit.HasValue ? null : limit.Value.ToString()},
                    {"changes-since", !changesSince.HasValue ? null : changesSince.Value.ToString("yyyy-MM-ddThh:mm:ss")}
                });

            var response = ExecuteRESTRequest<ListServersResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);

            if (response == null || response.Data == null)
                return null;

            return BuildCloudServersProviderAwareObject<Server>(response.Data.Servers, region, identity);
        }

        /// <inheritdoc />
        public NewServer CreateServer(string cloudServerName, string imageId, string flavorId, string adminPass, string keyName = null, string[] securityGroupNames = null, string[] attachVolumeIds = null, DiskConfiguration diskConfig = null, Metadata metadata = null, Personality[] personality = null, bool attachToServiceNetwork = false, bool attachToPublicNetwork = false, IEnumerable<string> networks = null, string region = null, CloudIdentity identity = null)
        {
            if (cloudServerName == null)
                throw new ArgumentNullException("cloudServerName");
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (flavorId == null)
                throw new ArgumentNullException("flavorId");
            if (adminPass == null)
                throw new ArgumentNullException("adminPass");
            if (string.IsNullOrEmpty(cloudServerName))
                throw new ArgumentException("cloudServerName cannot be empty");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (string.IsNullOrEmpty(flavorId))
                throw new ArgumentException("flavor cannot be empty");
            if (string.IsNullOrEmpty(adminPass))
                throw new ArgumentException("adminPass cannot be empty");
            if (diskConfig != null && diskConfig != DiskConfiguration.Auto && diskConfig != DiskConfiguration.Manual)
                throw new NotSupportedException("The specified disk configuration is not supported.");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers", GetServiceEndpoint(identity, region)));

            List<string> networksToAttach = new List<string>();
            if (attachToServiceNetwork || attachToPublicNetwork)
            {
                if (attachToPublicNetwork)
                    networksToAttach.Add("00000000-0000-0000-0000-000000000000");

                if (attachToServiceNetwork)
                    networksToAttach.Add("11111111-1111-1111-1111-111111111111");
            }

            if (networks != null)
                networksToAttach.AddRange(networks);

            const string accessIPv4 = null;
            const string accessIPv6 = null;
            var request = new CreateServerRequest(cloudServerName, imageId, flavorId, adminPass, keyName, securityGroupNames, attachVolumeIds, diskConfig, metadata, accessIPv4, accessIPv6, networksToAttach, personality);
            var response = ExecuteRESTRequest<CreateServerResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null || response.Data.Server == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
                return null; // throw new ExternalServiceException(response.StatusCode, response.Status, response.RawBody);

            return BuildCloudServersProviderAwareObject<NewServer>(response.Data.Server, region, identity);
        }

        /// <inheritdoc />
        public Server GetDetails(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<ServerDetailsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null || response.Data.Server == null)
                return null;

            return BuildCloudServersProviderAwareObject<Server>(response.Data.Server, region, identity);
        }

        /// <inheritdoc />
        public bool UpdateServer(string serverId, string name = null, IPAddress accessIPv4 = null, IPAddress accessIPv6 = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (accessIPv4 != null && !IPAddress.None.Equals(accessIPv4) && accessIPv4.AddressFamily != AddressFamily.InterNetwork)
                throw new ArgumentException("The specified value for accessIPv4 is not an IP v4 address.", "accessIPv4");
            if (accessIPv6 != null && !IPAddress.None.Equals(accessIPv6) && accessIPv6.AddressFamily != AddressFamily.InterNetworkV6)
                throw new ArgumentException("The specified value for accessIPv6 is not an IP v6 address.", "accessIPv6");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}", GetServiceEndpoint(identity, region), serverId));

            var requestJson = new UpdateServerRequest(name, accessIPv4, accessIPv6);
            var response = ExecuteRESTRequest<ServerDetailsResponse>(identity, urlPath, HttpMethod.PUT, requestJson);

            if (response == null || response.Data == null || response.Data.Server == null)
                return false;

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        /// <inheritdoc />
        public bool UpdateServerNametag(string serverId, string nametag = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool DeleteServer(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}", GetServiceEndpoint(identity, region), serverId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false; // throw new ExternalServiceException(response.StatusCode, response.Status, response.RawBody);

            return true;
        }

        /// <inheritdoc />
        public Server WaitForServerState(string serverId, ServerState expectedState, ServerState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (expectedState == null)
                throw new ArgumentNullException("expectedState");
            if (errorStates == null)
                throw new ArgumentNullException("errorStates");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            return WaitForServerState(serverId, new[] { expectedState }, errorStates, refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
        }

        /// <inheritdoc />
        public Server WaitForServerState(string serverId, ServerState[] expectedStates, ServerState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (expectedStates == null)
                throw new ArgumentNullException("expectedStates");
            if (errorStates == null)
                throw new ArgumentNullException("errorStates");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (expectedStates.Length == 0)
                throw new ArgumentException("expectedStates cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            var serverDetails = GetDetails(serverId, region, identity);

            /*
             * The polling implementation uses triple-checked polling to work around a known bug in Cloud
             * Servers status reporting. Occasionally, for a brief period of time during an asynchronous
             * server operation, the service will return incorrect values in all of the status fields.
             * Polling multiple times allows this SDK to provide reliable wait operations even when the
             * server returns unreliable values.
             */

            Func<bool> exitCondition = () => (expectedStates.Contains(serverDetails.Status) || errorStates.Contains(serverDetails.Status));
            int count = 0;
            int currentProgress = -1;
            int exitCount = exitCondition() ? 1 : 0;
            while (exitCount < 2 && count < refreshCount)
            {
                if (progressUpdatedCallback != null)
                {
                    if (serverDetails.Progress > currentProgress)
                    {
                        currentProgress = serverDetails.Progress;
                        progressUpdatedCallback(currentProgress);
                    }
                }

                Thread.Sleep(refreshDelay ?? TimeSpan.FromMilliseconds(2400));
                serverDetails = GetDetails(serverId, region, identity);
                count++;
                if (exitCondition())
                    exitCount++;
                else
                    exitCount = 0;
            }

            if (errorStates.Contains(serverDetails.Status))
                throw new ServerEnteredErrorStateException(serverDetails.Status);

            return BuildCloudServersProviderAwareObject<Server>(serverDetails, region, identity);
        }

        /// <inheritdoc />
        public Server WaitForVMState(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (expectedVMState == null)
                throw new ArgumentNullException("expectedState");
            if (errorVMState == null)
                throw new ArgumentNullException("errorStates");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            return WaitForVMState(serverId, new[] { expectedVMState }, errorVMState, refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
        }

        /// <inheritdoc />
        public Server WaitForVMState(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (expectedVMStates == null)
                throw new ArgumentNullException("expectedStates");
            if (errorVMStates == null)
                throw new ArgumentNullException("errorStates");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (expectedVMStates.Length == 0)
                throw new ArgumentException("expectedStates cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            refreshDelay = refreshDelay ?? TimeSpan.FromMilliseconds(2400);

            Server serverDetails = GetDetails(serverId, region, identity);

            Func<bool> exitCondition = () => serverDetails.TaskState == null && (expectedVMStates.Contains(serverDetails.VMState) || errorVMStates.Contains(serverDetails.VMState));
            int count = 0;
            int exitCount = exitCondition() ? 1 : 0;
            while (exitCount < 3 && count < refreshCount)
            {
                Thread.Sleep(refreshDelay ?? TimeSpan.FromMilliseconds(2400));
                serverDetails = GetDetails(serverId, region, identity);
                count++;
                if (exitCondition())
                    exitCount++;
                else
                    exitCount = 0;
            }

            if (errorVMStates.Contains(serverDetails.VMState))
                throw new ServerEnteredErrorStateException(serverDetails.Status);

            return BuildCloudServersProviderAwareObject<Server>(serverDetails, region, identity);
        }

        /// <inheritdoc />
        public Server WaitForServerActive(string serverId, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            return WaitForServerState(serverId, ServerState.Active, new[] { ServerState.Error, ServerState.Unknown, ServerState.Suspended }, refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
        }

        /// <inheritdoc />
        public void WaitForServerDeleted(string serverId, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            try
            {
                WaitForServerState(serverId, ServerState.Deleted,
                                   new[] { ServerState.Error, ServerState.Unknown, ServerState.Suspended },
                                   refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
            }
            catch (net.openstack.Core.Exceptions.Response.ItemNotFoundException)
            { } // there is the possibility that the server can be ACTIVE for one pass and then
                // by the next pass a 404 is returned.  This is due to the VERY limited window in which
                // the server goes into the DELETED state before it is removed from the system.
        }

        #endregion

        #region Server Addresses

        /// <inheritdoc />
        public ServerAddresses ListAddresses(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/ips", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<ListAddressesResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Addresses;
        }

        /// <inheritdoc />
        public ServerIps ListServerIps(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/ips", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<ListServerIpsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.ServerIps;
        }

        /// <inheritdoc />
        public IEnumerable<IPAddress> ListAddressesByNetwork(string serverId, string network, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (network == null)
                throw new ArgumentNullException("network");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(network))
                throw new ArgumentException("network cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/ips/{2}", GetServiceEndpoint(identity, region), serverId, network));

            try
            {
                var response = ExecuteRESTRequest<ServerAddresses>(identity, urlPath, HttpMethod.GET);
                if (response == null || response.Data == null)
                    return null;

                return response.Data[network];
            }
            catch (ItemNotFoundException)
            {
                // if the specified server and network exist separately, then the 404 was only caused by server
                // not being connected to the particular network
                // https://github.com/openstacknetsdk/openstack.net/issues/176
                bool foundServer = false;
                try
                {
                    Server details = GetDetails(serverId);
                    foundServer = details != null;
                }
                catch (ResponseException)
                {
                }

                if (!foundServer)
                    throw;

                bool foundNetwork = false;
                try
                {
                    INetworksProvider networksProvider = new CloudNetworksProvider(DefaultIdentity, DefaultRegion, IdentityProvider, RestService);
                    IEnumerable<CloudNetwork> networks = networksProvider.ListNetworks(region, identity);
                    if (networks != null && networks.Any(i => network.Equals(i.Label, StringComparison.OrdinalIgnoreCase)))
                        foundNetwork = true;
                }
                catch (ResponseException)
                {
                }

                if (!foundNetwork)
                    throw;

                return Enumerable.Empty<IPAddress>();
            }
        }

        #endregion

        #region Server Actions

        /// <inheritdoc />
        public bool ChangeAdministratorPassword(string serverId, string password, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("password cannot be empty");
            CheckIdentity(identity);

            var request = new ChangeServerAdminPasswordRequest(password);
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool RebootServer(string serverId, RebootType rebootType, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (rebootType == null)
                throw new ArgumentNullException("rebootType");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var request = new ServerRebootRequest(new ServerRebootDetails(rebootType));
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool AddSecurityGroup(string serverId, string groupname, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (groupname == null)
                throw new ArgumentNullException("groupname");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            string request = string.Format("{{ \"addSecurityGroup\": {{ \"name\": \"{0}\" }} }}", groupname);
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool RemoveSecurityGroup(string serverId, string groupname, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (groupname == null)
                throw new ArgumentNullException("groupname");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            string request = string.Format("{{ \"removeSecurityGroup\": {{ \"name\": \"{0}\" }} }}", groupname);
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public IEnumerable<ServerSecurityGroup> ListSecurityGroup(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-security-groups", GetServiceEndpoint(identity, region), serverId));
            var response = ExecuteRESTRequest<ListServerSecurityGroupsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.SecurityGroups;
        }

        /// <inheritdoc />
        public IEnumerable<InterfaceAttachment> ListInterfaceAttachments(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-interface", GetServiceEndpoint(identity, region), serverId));
            var response = ExecuteRESTRequest<ListInterfaceAttachmentsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.interfaceAttachments;
        }


        /// <inheritdoc />
        public InterfaceAttachment GetInterfaceAttachment(string serverId, string portId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(portId))
                throw new ArgumentException("portId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-interface/{2}", GetServiceEndpoint(identity, region), serverId, portId));
            var response = ExecuteRESTRequest<GetInterfaceAttachmentResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.interfaceAttachment;
        }


        /// <inheritdoc />
        public InterfaceAttachment AddInterfaceAttachment(string serverId, string portId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(portId))
                throw new ArgumentException("portId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-interface", GetServiceEndpoint(identity, region), serverId));
            string request = string.Format("{{ \"interfaceAttachment\": {{ \"port_id\": \"{0}\"}} }}", portId);
            var response = ExecuteRESTRequest<GetInterfaceAttachmentResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.interfaceAttachment;
        }


        /// <inheritdoc />
        public bool DeleteInterfaceAttachment(string serverId, string portId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(portId))
                throw new ArgumentException("portId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-interface/{2}", GetServiceEndpoint(identity, region), serverId, portId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false; // throw new ExternalServiceException(response.StatusCode, response.Status, response.RawBody);

            return true;
        }



        /// <inheritdoc />
        public IEnumerable<KeypairData> ListKeypair(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/os-keypairs", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListKeypairsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Keypairs;
        }

        /// <inheritdoc />
        public Keypair GetKeypair(string keyname, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/os-keypairs/{1}", GetServiceEndpoint(identity, region), keyname));
            var response = ExecuteRESTRequest<GetKeypairResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Keypair;
        }

        /// <inheritdoc />
        public Keypair AddKeypair(string name, string publickey, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/os-keypairs", GetServiceEndpoint(identity, region)));

            var request = new AddKeypairRequest(name, publickey);

            var response = ExecuteRESTRequest<AddKeypairResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Keypair;
        }

        /// <inheritdoc />
        public bool DeleteKeypair(string name, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/os-keypairs/{1}", GetServiceEndpoint(identity, region), name));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest<object>(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false; // throw new ExternalServiceException(response.StatusCode, response.Status, response.RawBody);

            return true;
        }

        /// <inheritdoc />
        public bool StartServer(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            string request = "{ \"os-start\": null }";
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        #region

        /// <summary>
        /// Stops Server
        /// </summary>
        public bool StopServer(string serverId, bool shutdown = false, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            string request = string.Empty;
            request = (shutdown == true) ? "{\"os-stop\": {\"force_shutdown\": true}}" : "{\"os-stop\": null}";

            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        #endregion

        /// <inheritdoc />
        public Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(imageRef))
                throw new ArgumentException("imageRef cannot be empty");
            if (string.IsNullOrEmpty(imageRef))
                throw new ArgumentException("imageRef cannot be empty");
            CheckIdentity(identity);

            var details = new RebuildServerDetails(imageRef, adminPassword, keyName);
            var request = new RebuildServerRequest(details);
            var resp = ExecuteServerAction<ServerDetailsResponse>(serverId, request, region, identity);

            return BuildCloudServersProviderAwareObject<Server>(resp.Server, region, identity);
        }


        /// <inheritdoc />
        public bool ResizeServer(string serverId, string flavor, DiskConfiguration diskConfig = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (flavor == null)
                throw new ArgumentNullException("flavor");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(flavor))
                throw new ArgumentException("flavor cannot be empty");
            if (diskConfig != null && diskConfig != DiskConfiguration.Auto && diskConfig != DiskConfiguration.Manual)
                throw new NotSupportedException("The specified disk configuration is not supported.");
            CheckIdentity(identity);

            var details = new ServerResizeDetails(flavor, diskConfig);
            var request = new ServerResizeRequest(details);
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool ConfirmServerResize(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var request = new ConfirmServerResizeRequest();
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool RevertServerResize(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var request = new RevertServerResizeRequest();
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public string RescueServer(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var request = new RescueServerRequest();
            var resp = ExecuteServerAction<RescueServerResponse>(serverId, request, region, identity);

            return resp.AdminPassword;
        }

        /// <inheritdoc />
        public bool UnRescueServer(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var request = new UnrescueServerRequest();
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool CreateImage(string serverId, string imageName, Metadata metadata = null, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (imageName == null)
                throw new ArgumentNullException("imageName");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(imageName))
                throw new ArgumentException("imageName cannot be empty");
            CheckIdentity(identity);

            var request = new CreateServerImageRequest(new CreateServerImageDetails(imageName, metadata));
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <summary>
        /// Execute a Cloud Servers action which returns a strongly-typed value in the body of the response.
        /// </summary>
        /// <remarks>
        /// This method executes actions using a <see cref="HttpMethod.POST"/> request to the URI
        /// <strong>servers/{serverId}/action</strong>.
        /// </remarks>
        /// <typeparam name="T">The type modeling the JSON representation of the result of executing the action.</typeparam>
        /// <param name="serverId">The server ID. This is obtained from <see cref="ServerBase.Id"/>.</param>
        /// <param name="body">The body of the action.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>The result of the web request, as an object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="serverId"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="body"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="serverId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <see langword="null"/> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected T ExecuteServerAction<T>(string serverId, object body, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (body == null)
                throw new ArgumentNullException("body");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<T>(identity, urlPath, HttpMethod.POST, body);

            if (response == null || response.Data == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return default(T);

            return response.Data;
        }

        /// <summary>
        /// Execute a Cloud Servers action which does not return a response.
        /// </summary>
        /// <remarks>
        /// This method executes actions using a <see cref="HttpMethod.POST"/> request to the URI
        /// <strong>servers/{serverId}/action</strong>.
        /// </remarks>
        /// <param name="serverId">The server ID. This is obtained from <see cref="ServerBase.Id"/>.</param>
        /// <param name="body">The body of the action.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns><see langword="true"/> if the <see cref="HttpMethod.POST"/> request is executed successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="serverId"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="body"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="serverId"/> is empty.</exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <see langword="null"/> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        protected bool ExecuteServerAction(string serverId, object body, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (body == null)
                throw new ArgumentNullException("body");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, body);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false;

            return true;
        }

        #endregion

        #region Volume Attachment Actions

        /// <inheritdoc />
        public ServerVolume AttachServerVolume(string serverId, string volumeId, string storageDevice = null, string region = null,
                                               CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (volumeId == null)
                throw new ArgumentNullException("volumeId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(volumeId))
                throw new ArgumentException("volumeId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-volume_attachments", GetServiceEndpoint(identity, region), serverId));

            var request = new AttachServerVolumeRequest(storageDevice, volumeId);
            var response = ExecuteRESTRequest<ServerVolumeResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.ServerVolume;
        }

        /// <inheritdoc />
        public IEnumerable<ServerVolume> ListServerVolumes(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-volume_attachments", GetServiceEndpoint(identity, region), serverId));

            Response<ServerVolumeListResponse> response = null;
            try
            {
                response = ExecuteRESTRequest<ServerVolumeListResponse>(identity, urlPath, HttpMethod.GET);
            }
            catch (ItemNotFoundException)
            {
                return Enumerable.Empty<ServerVolume>(); ;
            }

            if (response == null || response.Data == null)
                return null;

            return response.Data.ServerVolumes;
        }

        /// <inheritdoc />
        public ServerVolume GetServerVolumeDetails(string serverId, string volumeId, string region = null,
                                                   CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (volumeId == null)
                throw new ArgumentNullException("volumeId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(volumeId))
                throw new ArgumentException("volumeId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-volume_attachments/{2}", GetServiceEndpoint(identity, region), serverId, volumeId));

            var response = ExecuteRESTRequest<ServerVolumeResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.ServerVolume;
        }

        /// <inheritdoc />
        public bool DetachServerVolume(string serverId, string volumeId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (volumeId == null)
                throw new ArgumentNullException("volumeId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(volumeId))
                throw new ArgumentException("volumeId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-volume_attachments/{2}", GetServiceEndpoint(identity, region), serverId, volumeId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false;

            return true;
        }

        #endregion

        #region Virtual Interfaces

        /// <inheritdoc />
        public IEnumerable<VirtualInterface> ListVirtualInterfaces(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-virtual-interfacesv2", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<ListVirtualInterfacesResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.VirtualInterfaces;
        }

        /// <inheritdoc />
        public VirtualInterface CreateVirtualInterface(string serverId, string networkId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (networkId == null)
                throw new ArgumentNullException("networkId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(networkId))
                throw new ArgumentException("networkId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-virtual-interfacesv2", GetServiceEndpoint(identity, region), serverId));

            var request = new CreateVirtualInterfaceRequest(networkId);
            var response = ExecuteRESTRequest<ListVirtualInterfacesResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null || response.Data.VirtualInterfaces == null)
                return null;

            return response.Data.VirtualInterfaces.FirstOrDefault();
        }

        /// <inheritdoc />
        public bool DeleteVirtualInterface(string serverId, string virtualInterfaceId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (virtualInterfaceId == null)
                throw new ArgumentNullException("virtualInterfaceId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(virtualInterfaceId))
                throw new ArgumentException("virtualInterfaceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/os-virtual-interfacesv2/{2}", GetServiceEndpoint(identity, region), serverId, virtualInterfaceId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false;

            return true;
        }
        #endregion

        #region Flavors

        /// <inheritdoc />
        public IEnumerable<Flavor> ListFlavors(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null, string region = null, CloudIdentity identity = null)
        {
            if (minDiskInGB < 0)
                throw new ArgumentOutOfRangeException("minDiskInGB");
            if (minRamInMB < 0)
                throw new ArgumentOutOfRangeException("minRamInMB");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/flavors", GetServiceEndpoint(identity, region)));

            var queryStringParameters = BuildListFlavorsQueryStringParameters(minDiskInGB, minRamInMB, markerId, limit);

            var response = ExecuteRESTRequest<ListFlavorsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: queryStringParameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Flavors;
        }

        /// <inheritdoc />
        public IEnumerable<FlavorDetails> ListFlavorsWithDetails(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null, string region = null, CloudIdentity identity = null)
        {
            if (minDiskInGB < 0)
                throw new ArgumentOutOfRangeException("minDiskInGB");
            if (minRamInMB < 0)
                throw new ArgumentOutOfRangeException("minRamInMB");
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/flavors/detail", GetServiceEndpoint(identity, region)));

            var queryStringParameters = BuildListFlavorsQueryStringParameters(minDiskInGB, minRamInMB, markerId, limit);

            var response = ExecuteRESTRequest<ListFlavorDetailsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: queryStringParameters);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Flavors;
        }

        /// <inheritdoc />
        public FlavorDetails GetFlavor(string id, string region = null, CloudIdentity identity = null)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/flavors/{1}", GetServiceEndpoint(identity, region), id));

            var response = ExecuteRESTRequest<FlavorDetailsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Flavor;
        }

        #endregion

        #region Images

        /// <inheritdoc />
        public IEnumerable<SimpleServerImage> ListImages(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null, string region = null, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images", GetServiceEndpoint(identity, region)));

            var queryStringParameters = BuildListImagesQueryStringParameters(server, imageName, imageStatus, changesSince, markerId, limit, imageType);

            var response = ExecuteRESTRequest<ListServerImagesResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: queryStringParameters);

            if (response == null || response.Data == null)
                return null;

            return BuildCloudServersProviderAwareObject<SimpleServerImage>(response.Data.Images, region, identity);
        }

        /// <inheritdoc />
        public IEnumerable<ServerImage> ListImagesWithDetails(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null, string region = null, CloudIdentity identity = null)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException("limit");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/detail", GetServiceEndpoint(identity, region)));

            var queryStringParameters = BuildListImagesQueryStringParameters(server, imageName, imageStatus, changesSince, markerId, limit, imageType);

            var response = ExecuteRESTRequest<ListImagesDetailsResponse>(identity, urlPath, HttpMethod.GET, queryStringParameter: queryStringParameters);

            if (response == null || response.Data == null)
                return null;

            return BuildCloudServersProviderAwareObject<ServerImage>(response.Data.Images, region, identity);
        }

        private Dictionary<string, string> BuildListImagesQueryStringParameters(string serverId, string imageName, ImageState imageStatus, DateTimeOffset? changesSince, string markerId, int? limit, ImageType imageType)
        {
            var queryParameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(serverId))
                queryParameters.Add("server", serverId);

            if (!string.IsNullOrEmpty(imageName))
                queryParameters.Add("name", imageName);

            if (imageStatus != null && !string.IsNullOrEmpty(imageStatus.Name))
                queryParameters.Add("status", imageStatus.Name);

            if (changesSince != null)
                queryParameters.Add("changes-since", changesSince.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));

            if (!string.IsNullOrEmpty(markerId))
                queryParameters.Add("marker", markerId);

            if (limit > 0)
                queryParameters.Add("limit", limit.ToString());

            if (imageType != null)
                queryParameters.Add("type", imageType.Name);

            return queryParameters;
        }

        private Dictionary<string, string> BuildListFlavorsQueryStringParameters(int? minDiskInGB, int? minRamInMB, string markerId, int? limit)
        {
            var queryParameters = new Dictionary<string, string>();
            if (minDiskInGB != null)
                queryParameters.Add("minDisk", minDiskInGB.ToString());
            if (minRamInMB != null)
                queryParameters.Add("minRam", minRamInMB.ToString());
            if (!string.IsNullOrEmpty(markerId))
                queryParameters.Add("marker", markerId);
            if (limit != null)
                queryParameters.Add("limit", limit.ToString());

            return queryParameters;
        }

        /// <inheritdoc />
        public ServerImage GetImage(string imageId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}", GetServiceEndpoint(identity, region), imageId));

            var response = ExecuteRESTRequest<GetImageDetailsResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return BuildCloudServersProviderAwareObject<ServerImage>(response.Data.Image, region, identity);
        }

        /// <inheritdoc />
        public bool DeleteImage(string imageId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}", GetServiceEndpoint(identity, region), imageId));

            var defaultSettings = BuildDefaultRequestSettings(new[] { HttpStatusCode.NotFound });
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE, settings: defaultSettings);

            if (response == null || !_validServerActionResponseCode.Contains(response.StatusCode))
                return false; // throw new ExternalServiceException(response.StatusCode, response.Status, response.RawBody);

            return true;
        }

        /// <inheritdoc />
        public ServerImage WaitForImageState(string imageId, ImageState[] expectedStates, ImageState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (expectedStates == null)
                throw new ArgumentNullException("expectedStates");
            if (errorStates == null)
                throw new ArgumentNullException("errorStates");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (expectedStates.Length == 0)
                throw new ArgumentException("expectedStates cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            var details = GetImage(imageId, region, identity);

            int count = 0;
            int currentProgress = -1;
            while (!expectedStates.Contains(details.Status) && !errorStates.Contains(details.Status) && count < refreshCount)
            {
                if (progressUpdatedCallback != null)
                {
                    if (details.Progress > currentProgress)
                    {
                        currentProgress = details.Progress;
                        progressUpdatedCallback(currentProgress);
                    }
                }

                Thread.Sleep(refreshDelay ?? TimeSpan.FromMilliseconds(2400));
                details = GetImage(imageId, region, identity);
                count++;
            }

            if (errorStates.Contains(details.Status))
                throw new ImageEnteredErrorStateException(details.Status);

            return BuildCloudServersProviderAwareObject<ServerImage>(details, region, identity);
        }

        /// <inheritdoc />
        public ServerImage WaitForImageState(string imageId, ImageState expectedState, ImageState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (expectedState == null)
                throw new ArgumentNullException("expectedState");
            if (errorStates == null)
                throw new ArgumentNullException("errorStates");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            return WaitForImageState(imageId, new[] { expectedState }, errorStates, refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
        }

        /// <inheritdoc />
        public ServerImage WaitForImageActive(string imageId, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            return WaitForImageState(imageId, ImageState.Active, new[] { ImageState.Error, ImageState.Unknown }, refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
        }

        /// <inheritdoc />
        public void WaitForImageDeleted(string imageId, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (refreshCount < 0)
                throw new ArgumentOutOfRangeException("refreshCount");
            if (refreshDelay < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("refreshDelay");
            CheckIdentity(identity);

            try
            {
                WaitForImageState(imageId, ImageState.Deleted,
                                  new[] { ImageState.Error, ImageState.Unknown },
                                  refreshCount, refreshDelay ?? TimeSpan.FromMilliseconds(2400), progressUpdatedCallback, region, identity);
            }
            catch (net.openstack.Core.Exceptions.Response.ItemNotFoundException)
            { } // there is the possibility that the image can be ACTIVE for one pass and then
                // by the next pass a 404 is returned.  This is due to the VERY limited window in which
                // the image goes into the DELETED state before it is removed from the system.
        }

        #endregion

        #region Server BackupServices

        /// <inheritdoc/>
        public IEnumerable<BackupService> ListBackupServices(string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup", GetServiceEndpoint(identity, region)));

            var response = ExecuteRESTRequest<ListBackupServicesResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null || response.Data.BackupServices == null)
                return Enumerable.Empty<BackupService>();

            return response.Data.BackupServices;
        }

        /// <inheritdoc/>
        public BackupService GetBackupService(string backupId, string region = null, CloudIdentity identity = null)
        {
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup/{1}", GetServiceEndpoint(identity, region), backupId));

            var response = ExecuteRESTRequest<BackupService>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data;
        }

        /// <inheritdoc/>
        public BackupService AddBackupService(string instanceId, string region = null, CloudIdentity identity = null)
        {
            if (instanceId == null)
                throw new ArgumentNullException("instanceId");
            if (string.IsNullOrEmpty(instanceId))
                throw new ArgumentException("instanceId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup", GetServiceEndpoint(identity, region)));

            string request = string.Format("{{ \"backup\": {{ \"instance_id\": \"{0}\" }} }}", instanceId);
            var response = ExecuteRESTRequest<GetBackupServiceResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.Created)
                return null;

            return response.Data.BackupServices;
        }

        /// <inheritdoc/>
        public bool DeleteBackupService(string backupId, string region = null, CloudIdentity identity = null)
        {
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup/{1}", GetServiceEndpoint(identity, region), backupId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);

            if (response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool RestoreFromBackupRun(string backupId, string backupRunId, string region = null, CloudIdentity identity = null)
        {
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            if (backupRunId == null)
                throw new ArgumentNullException("backupRunId");
            if (string.IsNullOrEmpty(backupRunId))
                throw new ArgumentException("backupRunId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup/{1}/action", GetServiceEndpoint(identity, region), backupId));

            string request = string.Format("{{ \"restore\": {{ \"backuprun_id\": \"{0}\" }} }}", backupRunId);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null, string region = null, CloudIdentity identity = null)
        {
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            if (backupRunId == null)
                throw new ArgumentNullException("backupRunId");
            if (string.IsNullOrEmpty(backupRunId))
                throw new ArgumentException("backupRunId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup/{1}/action", GetServiceEndpoint(identity, region), backupId));

            var request = new CreateImageFromBackupRunRequest(backupRunId, imageName);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.Accepted)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool StopBackup(string backupId, string region = null, CloudIdentity identity = null)
        {
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup/{1}/action", GetServiceEndpoint(identity, region), backupId));

            var request = @"{""backup-stop"": null}";
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool ResumeBackup(string backupId, string region = null, CloudIdentity identity = null)
        {
            if (backupId == null)
                throw new ArgumentNullException("backupId");
            if (string.IsNullOrEmpty(backupId))
                throw new ArgumentException("backupId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/backup/{1}/action", GetServiceEndpoint(identity, region), backupId));

            var request = @"{""backup-start"": null}";
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }


        #endregion

        #region Server Metadata

        /// <inheritdoc />
        public Metadata ListServerMetadata(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/metadata", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<MetaDataResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null)
                return null;

            return response.Data.Metadata;
        }

        /// <inheritdoc />
        public bool SetServerMetadata(string serverId, Metadata metadata, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (metadata.Any(i => string.IsNullOrEmpty(i.Key)))
                throw new ArgumentException("metadata cannot contain any values with empty keys");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/metadata", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, new UpdateMetadataRequest(metadata));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        /// <inheritdoc />
        public bool UpdateServerMetadata(string serverId, Metadata metadata, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (metadata.Any(i => string.IsNullOrEmpty(i.Key)))
                throw new ArgumentException("metadata cannot contain any values with empty keys");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/metadata", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, new UpdateMetadataRequest(metadata));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        /// <inheritdoc />
        public string GetServerMetadataItem(string serverId, string key, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (key == null)
                throw new ArgumentNullException("key");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/metadata/{2}", GetServiceEndpoint(identity, region), serverId, key));

            var response = ExecuteRESTRequest<MetadataItemResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NonAuthoritativeInformation) || response.Data == null || response.Data.Metadata == null || response.Data.Metadata.Count == 0)
                return null;

            return response.Data.Metadata[key];
        }

        /// <inheritdoc />
        public bool SetServerMetadataItem(string serverId, string key, string value, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null)
                throw new ArgumentNullException("value");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/metadata/{2}", GetServiceEndpoint(identity, region), serverId, key));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, new UpdateMetadataItemRequest(key, value));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        /// <inheritdoc />
        public bool DeleteServerMetadataItem(string serverId, string key, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (key == null)
                throw new ArgumentNullException("key");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/metadata/{2}", GetServiceEndpoint(identity, region), serverId, key));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        /// <inheritdoc />
        public bool LockServer(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            string request = "{ \"lock\": null }";
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        /// <inheritdoc />
        public bool UnlockServer(string serverId, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            string request = "{ \"unlock\": null }";
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

        #endregion

        #region Image Metadata

        /// <inheritdoc />
        public Metadata ListImageMetadata(string imageId, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}/metadata", GetServiceEndpoint(identity, region), imageId));

            var response = ExecuteRESTRequest<MetaDataResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null)
                return null;

            return response.Data.Metadata;
        }

        /// <inheritdoc />
        public bool SetImageMetadata(string imageId, Metadata metadata, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (metadata.Any(i => string.IsNullOrEmpty(i.Key)))
                throw new ArgumentException("metadata cannot contain any values with empty keys");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}/metadata", GetServiceEndpoint(identity, region), imageId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.PUT, new UpdateMetadataRequest(metadata));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        /// <inheritdoc />
        public bool UpdateImageMetadata(string imageId, Metadata metadata, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (metadata == null)
                throw new ArgumentNullException("metadata");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (metadata.Any(i => string.IsNullOrEmpty(i.Key)))
                throw new ArgumentException("metadata cannot contain any values with empty keys");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}/metadata", GetServiceEndpoint(identity, region), imageId));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, new UpdateMetadataRequest(metadata));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        /// <inheritdoc />
        public string GetImageMetadataItem(string imageId, string key, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (key == null)
                throw new ArgumentNullException("key");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}/metadata/{2}", GetServiceEndpoint(identity, region), imageId, key));

            var response = ExecuteRESTRequest<MetadataItemResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null || response.Data.Metadata == null || response.Data.Metadata.Count == 0)
                return null;

            return response.Data.Metadata[key];
        }

        /// <inheritdoc />
        public bool SetImageMetadataItem(string imageId, string key, string value, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null)
                throw new ArgumentNullException("value");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}/metadata/{2}", GetServiceEndpoint(identity, region), imageId, key));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.PUT, new UpdateMetadataItemRequest(key, value));

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        /// <inheritdoc />
        public bool DeleteImageMetadataItem(string imageId, string key, string region = null, CloudIdentity identity = null)
        {
            if (imageId == null)
                throw new ArgumentNullException("imageId");
            if (key == null)
                throw new ArgumentNullException("key");
            if (string.IsNullOrEmpty(imageId))
                throw new ArgumentException("imageId cannot be empty");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/images/{1}/metadata/{2}", GetServiceEndpoint(identity, region), imageId, key));

            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.DELETE);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return true;

            return false;
        }

        #endregion

        #region ConoHa

        /// <inheritdoc/>
        public bool ChangeStorageController(string serverId, string hwDiskBus, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (hwDiskBus == null)
                throw new ArgumentNullException("hwDiskBus");
            if (string.IsNullOrEmpty(hwDiskBus))
                throw new ArgumentException("hwDiskBus cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            string request = string.Format("{{ \"hwDiskBus\": \"{0}\" }}", hwDiskBus);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool ChangeNetworkAdapter(string serverId, string hwVifModel, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (hwVifModel == null)
                throw new ArgumentNullException("hwVifModel");
            if (string.IsNullOrEmpty(hwVifModel))
                throw new ArgumentException("hwVifModel cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            string request = string.Format("{{ \"hwVifModel\": \"{0}\" }}", hwVifModel);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool ChangeVideoDevice(string serverId, string hwVideoModel, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (hwVideoModel == null)
                throw new ArgumentNullException("hwVideoModel");
            if (string.IsNullOrEmpty(hwVideoModel))
                throw new ArgumentException("hwVideoModel cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            string request = string.Format("{{ \"hwVideoModel\": \"{0}\" }}", hwVideoModel);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }

        /// <inheritdoc/>
        public bool ChangeVncKeymap(string serverId, string vncKeymap, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (vncKeymap == null)
                throw new ArgumentNullException("vncKeymap");
            if (string.IsNullOrEmpty(vncKeymap))
                throw new ArgumentException("vncKeymap cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            string request = string.Format("{{ \"vncKeymap\": \"{0}\" }}", vncKeymap);
            var response = ExecuteRESTRequest(identity, urlPath, HttpMethod.POST, request);

            if (response.StatusCode != HttpStatusCode.NoContent)
                return false;

            return true;
        }
        #endregion

        #region Protected methods

        /// <summary>
        /// Gets the public service endpoint to use for Cloud Servers requests for the specified identity and region.
        /// </summary>
        /// <remarks>
        /// This method uses <c>compute</c> for the service type, and <c>cloudServersOpenStack</c> for the preferred service name.
        /// </remarks>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <param name="region">The preferred region for the service. If this value is <see langword="null"/>, the user's default region will be used.</param>
        /// <returns>The public URL for the requested Cloud Servers endpoint.</returns>
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
        protected string GetServiceEndpoint(CloudIdentity identity, string region = "tyo1")
        {
            // return base.GetPublicServiceEndpoint(identity, "compute", "cloudServersOpenStack", region);
            return base.GetPublicServiceEndpoint(identity, "compute", "Compute Service", region ?? base.DefaultRegion ?? "tyo1");
        }

        #endregion


        #region Graph

        /// <summary>
        /// change time to unix time
        /// </summary>
        protected string toUnixTime(DateTime pcTime)
        {
            double unixTime = pcTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return ((int)unixTime).ToString();
        }

        /// <inheritdoc/>
        public string GetCPUGraph(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null)
        {
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");

            CheckIdentity(identity);

            string endPoint = GetServiceEndpoint(identity, region);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/rrd/cpu", endPoint, serverId));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"start_date_raw", startDateRaw},
                    {"end_date_raw", endDateRaw},
                    {"mode", mode }
                });

            string retValue = string.Format("{{\"cpu\":{{\"schema\":[\"unixtime\",\"value\"],\"data\":[[{0},null],[{1},null]]}}}}", startDateRaw, endDateRaw);

            if (startDateRaw != null && Int32.Parse(startDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)) ||
                endDateRaw != null && Int32.Parse(endDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)))
            {
                return retValue;
            }

            try
            {
                Response response = ExecuteRESTRequest(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);
                return (response.RawBody.Length == 0) ? retValue : response.RawBody;
            }
            catch (BadServiceRequestException)
            {
                return retValue;
            }
        }

        /// <inheritdoc/>
        public string GetDiskIOGraph(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null)
        {
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");

            CheckIdentity(identity);

            string endPoint = GetServiceEndpoint(identity, region);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/rrd/disk", endPoint, serverId));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"device", deviceName},
                    {"start_date_raw", startDateRaw},
                    {"end_date_raw", endDateRaw},
                    {"mode", mode }
                });

            string retValue = string.Format("{{\"disk\":{{\"schema\":[\"unixtime\",\"read\",\"write\"],\"data\":[[{0},null,null],[{1},null,null]]}}}}", startDateRaw, endDateRaw);

            if (startDateRaw != null && Int32.Parse(startDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)) ||
                endDateRaw != null && Int32.Parse(endDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)))
            {
                return retValue;
            }

            try
            {
                Response response = ExecuteRESTRequest(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);
                return (response.RawBody.Length == 0) ? retValue : response.RawBody;
            }
            catch (BadServiceRequestException)
            {
                return retValue;
            }
        }

        /// <inheritdoc/>
        public string GetNetworkGraph(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null)
        {
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (string.IsNullOrEmpty(portId))
                throw new ArgumentException("portId cannot be empty");

            CheckIdentity(identity);

            string endPoint = GetServiceEndpoint(identity, region);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/rrd/interface", endPoint, serverId));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"port_id", portId},
                    {"start_date_raw", startDateRaw},
                    {"end_date_raw", endDateRaw},
                    {"mode", mode }
                });

            string retValue = string.Format("{{\"interface\":{{\"schema\":[\"unixtime\",\"rx\",\"tx\"],\"data\":[[{0},null,null],[{1},null,null]]}}}}", startDateRaw, endDateRaw);

            if (startDateRaw != null && Int32.Parse(startDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)) ||
                endDateRaw != null && Int32.Parse(endDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)))
            {
                return retValue;
            }

            try
            {
                Response response = ExecuteRESTRequest(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);
                return (response.RawBody.Length == 0) ? retValue : response.RawBody;
            }
            catch (BadServiceRequestException)
            {
                return retValue;
            }
        }

        /// <inheritdoc/>
        public string GetSwiftRequestGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            string endPoint = GetPublicServiceEndpoint(identity, "account", "Account Service", region);

            var urlPath = new Uri(string.Format("{0}/object-storage/rrd/request", endPoint));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"start_date_raw", startDateRaw},
                    {"end_date_raw", endDateRaw},
                    {"mode", mode }
                });

            string retValue = string.Format("{{\"request\":{{\"schema\":[\"unixtime\",\"get\",\"put\",\"delete\"],\"data\":[[{0},null,null,null],[{1},null,null,null]]}}}}", startDateRaw, endDateRaw);

            if (startDateRaw != null && Int32.Parse(startDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)) ||
                endDateRaw != null && Int32.Parse(endDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)))
            {
                return retValue;
            }

            try
            {
                Response response = ExecuteRESTRequest(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);
                return (response.RawBody.Length == 0) ? retValue : response.RawBody;
            }
            catch (BadServiceRequestException)
            {
                return retValue;
            }
        }

        /// <inheritdoc/>
        public string GetSwiftSizeGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, string region = null, CloudIdentity identity = null)
        {
            CheckIdentity(identity);

            string endPoint = GetPublicServiceEndpoint(identity, "account", "Account Service", region);

            var urlPath = new Uri(string.Format("{0}/object-storage/rrd/size", endPoint));
            var parameters = BuildOptionalParameterList(new Dictionary<string, string>
                {
                    {"start_date_raw", startDateRaw},
                    {"end_date_raw", endDateRaw},
                    {"mode", mode }
                });

            string retValue = string.Format("{{\"size\":{{\"schema\":[\"unixtime\",\"value\"],\"data\":[[{0},null],[{1},null]]}}}}", startDateRaw, endDateRaw);

            if (startDateRaw != null && Int32.Parse(startDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)) ||
                endDateRaw != null && Int32.Parse(endDateRaw) > Int32.Parse(toUnixTime(DateTime.Now)))
            {
                return retValue;
            }

            try
            {
                Response response = ExecuteRESTRequest(identity, urlPath, HttpMethod.GET, queryStringParameter: parameters);
                return (response.RawBody.Length == 0) ? retValue : response.RawBody;
            }
            catch (BadServiceRequestException)
            {
                return retValue;
            }
        }
        #endregion

        #region

        /// <summary>
        /// Gets Vnc Console Url
        /// </summary>
        public VncConsole GetVncConsole(string serverId, string region = null, CloudIdentity identity = null)
        {
            string request = "{ \"os-getVNCConsole\": {\"type\": \"novnc\"} }";
            return GetConsole(serverId, request, region, identity);
        }

        #endregion

        #region

        /// <summary>
        /// Gets Nova Console Url
        /// </summary>
        public VncConsole GetNovaConsole(string serverId, string region = null, CloudIdentity identity = null)
        {
            string request = "{ \"os-getSerialConsole\": {\"type\": \"serial\"} }";
            return GetConsole(serverId, request, region, identity);
        }

        #endregion

        #region Httpコンソール取得処理

        /// <summary>
        /// Gets http console
        /// </summary>
        public VncConsole GetHttpConsole(string serverId, string region = null, CloudIdentity identity = null)
        {
            string request = "{ \"os-getWebConsole\": {\"type\": \"serial\"} }";
            return GetConsole(serverId, request, region, identity);
        }

        #endregion

        #region 各コンソール取得処理

        /// <summary>
        /// Gets a console
        /// </summary>
        private VncConsole GetConsole(string serverId, string request, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            var response = ExecuteRESTRequest<GetVncConsoleResponse>(identity, urlPath, HttpMethod.POST, request);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Console;

        }

        #endregion

        /// <inheritdoc/>
        public bool CreateGlanceImageFromInstance(string serverId, string imageName, string region = null, CloudIdentity identity = null)
        {
            if (serverId == null)
                throw new ArgumentNullException("serverId");
            if (string.IsNullOrEmpty(serverId))
                throw new ArgumentException("serverId cannot be empty");
            if (imageName == null)
                throw new ArgumentNullException("imageName");
            if (string.IsNullOrEmpty(imageName))
                throw new ArgumentException("imageName cannot be empty");
            CheckIdentity(identity);

            var urlPath = new Uri(string.Format("{0}/servers/{1}/action", GetServiceEndpoint(identity, region), serverId));

            string request = string.Format("{{ \"createImage\": {{ \"name\": \"{0}\" }} }}", imageName);
            var resp = ExecuteServerAction(serverId, request, region, identity);

            return resp;
        }

    }
}
