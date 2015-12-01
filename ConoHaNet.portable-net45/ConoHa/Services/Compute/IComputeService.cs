namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using Compute;
    using OpenStack.Services;
    using System.Threading;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IComputeService : IHttpService, IExtensibleService<IComputeService>
    {
        #region ConoHa

        // IEnumerable<BackupService> ListBackupServices(CloudIdentity identity = null);
        Task<ListBackupServicesApiCall> PrepareListBackupServicesAsync(CancellationToken cancellationToken);

        // BackupService GetBackupService(string backupId, CloudIdentity identity = null);
        Task<GetBackupServiceApiCall> PrepareGetBackupServiceAsync(string backupId, CancellationToken cancellationToken);

        // BackupService AddBackupService(string InstanceId, CloudIdentity identity = null);
        Task<AddBackupServiceApiCall> PrepareAddBackupServiceAsync(string InstanceId, CancellationToken cancellationToken);

        // bool DeleteBackupService(string backupId, CloudIdentity identity = null);
        Task<DeleteBackupServiceApiCall> PrepareDeleteBackupServiceAsync(string backupId, CancellationToken cancellationToken);

        // bool RestoreFromBackupRun(string backupId, string backupRunId, CloudIdentity identity = null);
        Task<RestoreFromBackupRunApiCall> PrepareRestoreFromBackupRunAsync(string backupId, string backupRunId, CancellationToken cancellationToken);

        // bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null, CloudIdentity identity = null);
        Task<CreateImageFromBackupRunApiCall> PrepareCreateImageFromBackupRunAsync(string backupId, string backupRunId, string imageName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool StopBackup(string backupId, CloudIdentity identity = null);
        Task<StopBackupApiCall> PrepareStopBackupAsync(string backupId, CancellationToken cancellationToken);

        // bool ResumeBackup(string backupId, CloudIdentity identity = null);
        Task<ResumeBackupApiCall> PrepareResumeBackupAsync(string backupId, CancellationToken cancellationToken);

        // bool ChangeStorageController(string serverId, string hwDiskBus, CloudIdentity identity = null);
        Task<ChangeStorageControllerApiCall> PrepareChangeStorageControllerAsync(string serverId, string hwDiskBus, CancellationToken cancellationToken);

        // bool ChangeNetworkAdapter(string serverId, string hwVifModel, CloudIdentity identity = null);
        Task<ChangeNetworkAdapterApiCall> PrepareChangeNetworkAdapterAsync(string serverId, string hwVifModel, CancellationToken cancellationToken);

        // bool ChangeVideoDevice(string serverId, string hwVideoModel, CloudIdentity identity = null);
        Task<ChangeVideoDeviceApiCall> PrepareChangeVideoDeviceAsync(string serverId, string hwVideoModel, CancellationToken cancellationToken);

        // bool ChangeVncKeymap(string serverId, string vncKeymap, CloudIdentity identity = null);
        Task<ChangeVncKeymapApiCall> PrepareChangeVncKeymapAsync(string serverId, string vncKeymap, CancellationToken cancellationToken);

        // string GetCPUGraph(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
        Task<GetCPUGraphApiCall> PrepareGetCPUGraphAsync(string serverId, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken));

        // string GetDiskIOGraph(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
        Task<GetDiskIOGraphApiCall> PrepareGetDiskIOGraphAsync(string serverId, string deviceName = null, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken));

        // string GetNetworkGraph(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
        Task<GetNetworkGraphApiCall> PrepareGetNetworkGraphAsync(string serverId, string portId, string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken));

        // string GetSwiftRequestGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
        Task<GetSwiftRequestGraphApiCall> PrepareGetSwiftRequestGraphAsync(string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken));

        // string GetSwiftSizeGraph(string startDateRaw = null, string endDateRaw = null, string mode = null, CloudIdentity identity = null);
        Task<GetSwiftSizeGraphApiCall> PrepareGetSwiftSizeGraphAsync(string startDateRaw = null, string endDateRaw = null, string mode = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool CreateGlanceImageFromInstance(string serverId, string imageName, CloudIdentity identity = null);
        Task<CreateGlanceImageFromInstanceApiCall> PrepareCreateGlanceImageFromInstanceAsync(string serverId, string imageName, CancellationToken cancellationToken);

        // Server WaitForVMState(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CloudIdentity identity = null);
        Task<WaitForVMStateApiCall> PrepareWaitForVMStateAsync(string serverId, VirtualMachineState expectedVMState, VirtualMachineState[] errorVMState, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CancellationToken cancellationToken = default(CancellationToken));

        // Server WaitForVMState(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CloudIdentity identity = null);
        Task<WaitForVMStateApiCall> PrepareWaitForVMStateAsync(string serverId, VirtualMachineState[] expectedVMStates, VirtualMachineState[] errorVMStates, int refreshCount = 600, TimeSpan? refreshDelay = null, Action<int> progressUpdatedCallback = null, CancellationToken cancellationToken = default(CancellationToken));

        // Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null, CloudIdentity identity = null);
        Task<RebuildServerApiCall> PrepareListFlavorsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }
}
