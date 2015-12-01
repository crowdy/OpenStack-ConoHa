namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.Compute;
    using ConoHaNet.Services.BlockStorage;

    // IEnumerable<BackupService> ListBackupServices(CloudIdentity identity = null);
    // Task<ListBackupServicesApiCall> PrepareListBackupServicesAsync(CancellationToken cancellationToken);
    public class ListBackupServicesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<BackupService>>
    {
        public ListBackupServicesApiCall(IHttpApiCall<ReadOnlyCollectionPage<BackupService>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // BackupService GetBackupService(string backupId, CloudIdentity identity = null);
    // Task<GetBackupServiceApiCall> PrepareGetBackupServiceAsync(string backupId, CancellationToken cancellationToken);
    public class GetBackupServiceApiCall : DelegatingHttpApiCall<BackupService>
    {
        public GetBackupServiceApiCall(IHttpApiCall<BackupService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // BackupService AddBackupService(string InstanceId, CloudIdentity identity = null);
    // Task<AddBackupServiceApiCall> PrepareAddBackupServiceAsync(string InstanceId, CancellationToken cancellationToken);
    public class AddBackupServiceApiCall : DelegatingHttpApiCall<BackupService>
    {
        public AddBackupServiceApiCall(IHttpApiCall<BackupService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteBackupService(string backupId, CloudIdentity identity = null);
    // Task<DeleteBackupServiceApiCall> PrepareDeleteBackupServiceAsync(string backupId, CancellationToken cancellationToken);
    public class DeleteBackupServiceApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteBackupServiceApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool RestoreFromBackupRun(string backupId, string backupRunId, CloudIdentity identity = null);
    // Task<RestoreFromBackupRunApiCall> PrepareRestoreFromBackupRunAsync(string backupId, string backupRunId, CancellationToken cancellationToken);
    public class RestoreFromBackupRunApiCall : DelegatingHttpApiCall<bool>
    {
        public RestoreFromBackupRunApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null, CloudIdentity identity = null);
    // Task<CreateImageFromBackupRunApiCall> PrepareCreateImageFromBackupRunAsync(string backupId, string backupRunId, string imageName = null, CancellationToken cancellationToken);
    public class CreateImageFromBackupRunApiCall : DelegatingHttpApiCall<bool>
    {
        public CreateImageFromBackupRunApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool StopBackup(string backupId, CloudIdentity identity = null);
    // Task<StopBackupApiCall> PrepareStopBackupAsync(string backupId, CancellationToken cancellationToken);
    public class StopBackupApiCall : DelegatingHttpApiCall<bool>
    {
        public StopBackupApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool ResumeBackup(string backupId, CloudIdentity identity = null);
    // Task<ResumeBackupApiCall> PrepareResumeBackupAsync(string backupId, CancellationToken cancellationToken);
    public class ResumeBackupApiCall : DelegatingHttpApiCall<bool>
    {
        public ResumeBackupApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool ChangeStorageController(string serverId, string hwDiskBus, CloudIdentity identity = null);
    // Task<ChangeStorageControllerApiCall> PrepareChangeStorageControllerAsync(string serverId, string hwDiskBus, CancellationToken cancellationToken);
    public class ChangeStorageControllerApiCall : DelegatingHttpApiCall<bool>
    {
        public ChangeStorageControllerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool ChangeNetworkAdapter(string serverId, string hwVifModel, CloudIdentity identity = null);
    // Task<ChangeNetworkAdapterApiCall> PrepareChangeNetworkAdapterAsync(string serverId, string hwVifModel, CancellationToken cancellationToken);
    public class ChangeNetworkAdapterApiCall : DelegatingHttpApiCall<bool>
    {
        public ChangeNetworkAdapterApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool ChangeVideoDevice(string serverId, string hwVideoModel, CloudIdentity identity = null);
    // Task<ChangeVideoDeviceApiCall> PrepareChangeVideoDeviceAsync(string serverId, string hwVideoModel, CancellationToken cancellationToken);
    public class ChangeVideoDeviceApiCall : DelegatingHttpApiCall<bool>
    {
        public ChangeVideoDeviceApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool ChangeVncKeymap(string serverId, string vncKeymap, CloudIdentity identity = null);
    // Task<ChangeVncKeymapApiCall> PrepareChangeVncKeymapAsync(string serverId, string vncKeymap, CancellationToken cancellationToken);
    public class ChangeVncKeymapApiCall : DelegatingHttpApiCall<bool>
    {
        public ChangeVncKeymapApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // string GetCPUGraph(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
    // Task<GetCPUGraphApiCall> PrepareGetCPUGraphAsync(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken);
    public class GetCPUGraphApiCall : DelegatingHttpApiCall<String>
    {
        public GetCPUGraphApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // string GetDiskIOGraph(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
    // Task<GetDiskIOGraphApiCall> PrepareGetDiskIOGraphAsync(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken);
    public class GetDiskIOGraphApiCall : DelegatingHttpApiCall<String>
    {
        public GetDiskIOGraphApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // string GetNetworkGraph(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
    // Task<GetNetworkGraphApiCall> PrepareGetNetworkGraphAsync(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken);
    public class GetNetworkGraphApiCall : DelegatingHttpApiCall<String>
    {
        public GetNetworkGraphApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // string GetSwiftRequestGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
    // Task<GetSwiftRequestGraphApiCall> PrepareGetSwiftRequestGraphAsync(string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken);
    public class GetSwiftRequestGraphApiCall : DelegatingHttpApiCall<String>
    {
        public GetSwiftRequestGraphApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // string GetSwiftSizeGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
    // Task<GetSwiftSizeGraphApiCall> PrepareGetSwiftSizeGraphAsync(string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken);
    public class GetSwiftSizeGraphApiCall : DelegatingHttpApiCall<String>
    {
        public GetSwiftSizeGraphApiCall(IHttpApiCall<String> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool CreateGlanceImageFromInstance(string serverId, string imageName, CloudIdentity identity = null);
    // Task<CreateGlanceImageFromInstanceApiCall> PrepareCreateGlanceImageFromInstanceAsync(string serverId, string imageName, CancellationToken cancellationToken);
    public class CreateGlanceImageFromInstanceApiCall : DelegatingHttpApiCall<bool>
    {
        public CreateGlanceImageFromInstanceApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Server WaitForVMState(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CloudIdentity identity = null);
    // Task<WaitForVMStateApiCall> PrepareWaitForVMStateAsync(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CancellationToken cancellationToken);
    public class WaitForVMStateApiCall : DelegatingHttpApiCall<Server>
    {
        public WaitForVMStateApiCall(IHttpApiCall<Server> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    /*
    // Server WaitForVMState(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CloudIdentity identity = null);
    // Task<WaitForVMStateApiCall> PrepareWaitForVMStateAsync(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CancellationToken cancellationToken);
    public class WaitForVMStateApiCall : DelegatingHttpApiCall<Server>
    {
        public WaitForVMStateApiCall(IHttpApiCall<Server> httpApiCall)
            : base(httpApiCall)
        {
        }
    }
    */

    // Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null, CloudIdentity identity = null);
    // Task<RebuildServerApiCall> PrepareListFlavorsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class RebuildServerApiCall : DelegatingHttpApiCall<Server>
    {
        public RebuildServerApiCall(IHttpApiCall<Server> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class SoftRebootServerApiCall : DelegatingHttpApiCall<bool>
    {
        public SoftRebootServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class HardRebootServerApiCall : DelegatingHttpApiCall<bool>
    {
        public HardRebootServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class ResizeServerApiCall : DelegatingHttpApiCall<bool>
    {
        public ResizeServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class ConfirmResizeServerApiCall : DelegatingHttpApiCall<bool>
    {
        public ConfirmResizeServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class RevertResizeServerApiCall : DelegatingHttpApiCall<bool>
    {
        public RevertResizeServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class RescueServerApiCall : DelegatingHttpApiCall<bool>
    {
        public RescueServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class UnRescueServerApiCall : DelegatingHttpApiCall<bool>
    {
        public UnRescueServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class GetVolumeApiCall : DelegatingHttpApiCall<Server>
    {
        public GetVolumeApiCall(IHttpApiCall<Server> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class GetMetadataApiCall : DelegatingHttpApiCall<Metadata>
    {
        public GetMetadataApiCall(IHttpApiCall<Metadata> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class SetMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public SetMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class AddMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public AddMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class UpdateMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class DeleteMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class DeleteMetadataItemApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteMetadataItemApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class UpdateMetadataItemApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateMetadataItemApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class ListAddressesItemApiCall : DelegatingHttpApiCall<ServerAddresses>
    {
        public ListAddressesItemApiCall(IHttpApiCall<ServerAddresses> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class ListAddressesByNetworkApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<IPAddress>>
    {
        public ListAddressesByNetworkApiCall(IHttpApiCall<ReadOnlyCollectionPage<IPAddress>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class CreateSnapshotServerApiCall : DelegatingHttpApiCall<SimpleServerImage>
    {
        public CreateSnapshotServerApiCall(IHttpApiCall<SimpleServerImage> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class DeleteServerApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteServerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class ListVirtualInterfacesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<VirtualInterface>>
    {
        public ListVirtualInterfacesApiCall(IHttpApiCall<ReadOnlyCollectionPage<VirtualInterface>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class CreateVirtualInterfaceApiCall : DelegatingHttpApiCall<VirtualInterface>
    {
        public CreateVirtualInterfaceApiCall(IHttpApiCall<VirtualInterface> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class DeleteVirtualInterfaceApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteVirtualInterfaceApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class GetServerDetailsApiCall : DelegatingHttpApiCall<Server>
    {
        public GetServerDetailsApiCall(IHttpApiCall<Server> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class ListServerVolumesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<ServerVolume>>
    {
        public ListServerVolumesApiCall(IHttpApiCall<ReadOnlyCollectionPage<ServerVolume>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class AttachVolumesApiCall : DelegatingHttpApiCall<ServerVolume>
    {
        public AttachVolumesApiCall(IHttpApiCall<ServerVolume> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    public class DetachVolumesApiCall : DelegatingHttpApiCall<bool>
    {
        public DetachVolumesApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

}
