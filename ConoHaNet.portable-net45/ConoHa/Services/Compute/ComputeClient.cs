namespace ConoHaNet.Services
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenStack.Collections;
    using OpenStack.Net;
    using OpenStack.ObjectModel.JsonHome;
    using OpenStack.Security.Authentication;
    using OpenStack.Services.Identity;
    using Rackspace.Net;
    using Rackspace.Threading;

    using System.Diagnostics;
    using OpenStack.Services;
    using ConoHa.Services;
    using Compute;
    using BlockStorage;


    /// <summary>
    /// This class provides a default implementation of <see cref="ComputeClient"/> suitable for connecting to
    /// OpenStack-compatible installations of the Content Delivery Service V1.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public class ComputeClient : ServiceClient, IComputeService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComputeClient"/> class with the specified
        /// authentication service, default region, and value indicating whether an internal or public endpoint should
        /// be used for communicating with the service.
        /// </summary>
        /// <param name="authenticationService">The authentication service to use for authenticating requests made to
        /// this service.</param>
        /// <param name="defaultRegion">The preferred region for the service. Unless otherwise specified for a specific
        /// client, derived service clients will not use a default region if this value is <see langword="null"/> (i.e.
        /// only region-less or "global" service endpoints will be considered acceptable).</param>
        /// <param name="internalUrl"><see langword="true"/> to access the service over a local network; otherwise,
        /// <see langword="false"/> to access the service over a public network (the Internet).</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="authenticationService"/> is <see langword="null"/>.
        /// </exception>
        public ComputeClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IComputeService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<AddBackupServiceApiCall> PrepareAddBackupServiceAsync(string InstanceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ChangeNetworkAdapterApiCall> PrepareChangeNetworkAdapterAsync(string serverId, string hwVifModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ChangeStorageControllerApiCall> PrepareChangeStorageControllerAsync(string serverId, string hwDiskBus, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ChangeVideoDeviceApiCall> PrepareChangeVideoDeviceAsync(string serverId, string hwVideoModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ChangeVncKeymapApiCall> PrepareChangeVncKeymapAsync(string serverId, string vncKeymap, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateGlanceImageFromInstanceApiCall> PrepareCreateGlanceImageFromInstanceAsync(string serverId, string imageName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CreateImageFromBackupRunApiCall> PrepareCreateImageFromBackupRunAsync(string backupId, string backupRunId, string imageName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteBackupServiceApiCall> PrepareDeleteBackupServiceAsync(string backupId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetBackupServiceApiCall> PrepareGetBackupServiceAsync(string backupId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetCPUGraphApiCall> PrepareGetCPUGraphAsync(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetDiskIOGraphApiCall> PrepareGetDiskIOGraphAsync(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetNetworkGraphApiCall> PrepareGetNetworkGraphAsync(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetSwiftRequestGraphApiCall> PrepareGetSwiftRequestGraphAsync(string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetSwiftSizeGraphApiCall> PrepareGetSwiftSizeGraphAsync(string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListBackupServicesApiCall> PrepareListBackupServicesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RebuildServerApiCall> PrepareListFlavorsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<RestoreFromBackupRunApiCall> PrepareRestoreFromBackupRunAsync(string backupId, string backupRunId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResumeBackupApiCall> PrepareResumeBackupAsync(string backupId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StopBackupApiCall> PrepareStopBackupAsync(string backupId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WaitForVMStateApiCall> PrepareWaitForVMStateAsync(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = default(TimeSpan?), Action<int> progressUpdatedCallback = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<WaitForVMStateApiCall> PrepareWaitForVMStateAsync(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = default(TimeSpan?), Action<int> progressUpdatedCallback = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<SoftRebootServerApiCall> PrepareSoftRebootServerAsyncImpl(string serverId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<HardRebootServerApiCall> PrepareHardRebootServerAsyncImpl(string serverId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ResizeServerApiCall> PrepareResizeServerAsyncImpl(string serverId, string flavorId, DiskConfiguration diskconfig, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ConfirmResizeServerApiCall> PrepareConfirmResizeServerAsyncImpl(string serverId, string flavorId, DiskConfiguration diskconfig, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ConfirmResizeServerApiCall> PrepareRevertResizeServerAsyncImpl(string serverId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<RescueServerApiCall> PrepareRescueServerAsyncImpl(string serverId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<UnRescueServerApiCall> PrepareUnRescueServerAsyncImpl(string serverId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<Uri> PrepareGetVolumeAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<GetMetadataApiCall> PrepareGetMetadataAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<SetMetadataApiCall> PrepareSetMetadataAsyncImpl(Metadata metadata, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<AddMetadataApiCall> PrepareAddMetadataAsyncImpl(Metadata metadata, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<AddMetadataApiCall> PrepareAddMetadataAsyncImpl(string key, string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<UpdateMetadataApiCall> PrepareUpdateMetadataAsyncImpl(Metadata metadata, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<DeleteMetadataApiCall> PrepareDeleteMetadataAsyncImpl(Metadata metadata, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<DeleteMetadataItemApiCall> PrepareDeleteMetadataItemAsyncImpl(string key, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<UpdateMetadataItemApiCall> PrepareUpdateMetadataItemAsyncImpl(string key, string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ListAddressesItemApiCall> PrepareListAddressesAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ListAddressesByNetworkApiCall> PrepareListAddressesByNetworkAsyncImpl(string serverId, string networkLabel, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
        protected Task<GetServerDetailsApiCall> PrepareGetServerDetailsAsyncImpl(string serverId, string networkLabel, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected Task<CreateSnapshotServerApiCall> PrepareCreateSnapshotServerAsyncImpl(string serverId, string imageName, Metadata metadata, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<DeleteServerApiCall> PrepareDeleteServerAsyncImpl(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ListVirtualInterfacesApiCall> PrepareListVirtualInterfacesAsyncImpl(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<CreateVirtualInterfaceApiCall> PrepareCreateVirtualInterfacesAsyncImpl(string networkId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<DeleteVirtualInterfaceApiCall> PrepareDeleteVirtualInterfacesAsyncImpl(string networkId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<ListVolumesApiCall> PrepareListVolumesAsyncImpl(string serverId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<AttachVolumesApiCall> PrepareAttachVolumesAsyncImpl(string serverId, string volumeId, string storageDievice, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected Task<AttachVolumesApiCall> PrepareDetachVolumesAsyncImpl(string serverId, string volumeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
