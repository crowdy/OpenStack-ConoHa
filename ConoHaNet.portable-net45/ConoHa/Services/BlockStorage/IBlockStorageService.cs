namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using BlockStorage;
    using OpenStack.Services;
    using System.Threading;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IBlockStorageService : IHttpService, IExtensibleService<IBlockStorageService>
    {
         #region ConoHa

        // Volume CreateVolume(int size, string sourceVolumeId = null, string Description = null, string Name = null, string snapshotId = null, string volumeType = null, string imageRef = null, CloudIdentity identity = null);
        Task<CreateVolumeApiCall> PrepareCreateVolumeAsync(int size, string sourceVolumeId = null, string Description = null, string Name = null, string snapshotId = null, string volumeType = null, string imageRef = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<Volume> ListVolumes(CloudIdentity identity = null);
        Task<ListVolumesApiCall> PrepareListVolumesAsync(CancellationToken cancellationToken);

        // ShowVolume(string volumeId, CloudIdentity identity = null);
        Task<ShowVolumeApiCall> PrepareShowVolumeAsync(string volumeId, CancellationToken cancellationToken);

        // DeleteVolume(string volumeId, CloudIdentity identity = null);
        Task<DeleteVolumeApiCall> PrepareDeleteVolumeAsync(string volumeId, CancellationToken cancellationToken);

        // VolumeType DescribeVolumeType(string volumeTypeId, CloudIdentity identity = null);
        Task<DescribeVolumeTypeApiCall> PrepareDescribeVolumeTypeAsync(string volumeTypeId, CancellationToken cancellationToken);

        // WaitForVolumeAvailable(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
        Task<CreateWaitForVolumeAvailableApiCall> PrepareWaitForVolumeAvailableAsync(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool WaitForVolumeDeleted(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
        Task<WaitForVolumeDeletedApiCall> PrepareWaitForVolumeDeletedAsync(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null, CancellationToken cancellationToken = default(CancellationToken));

        // Volume WaitForVolumeState(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
        Task<WaitForVolumeStateApiCall> PrepareWaitForVolumeStateAsync(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, CancellationToken cancellationToken = default(CancellationToken));

        // Snapshot CreateSnapshot(string volumeId, bool force = false, string displayName = "None", string displayDescription = null, CloudIdentity identity = null);
        Task<CreateSnapshotApiCall> PrepareCreateSnapshotAsync(string volumeId, bool force = false, string displayName = "None", string displayDescription = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<Snapshot> ListSnapshots(CloudIdentity identity = null);
        Task<ListSnapshotsApiCall> PrepareListSnapshotsAsync(CancellationToken cancellationToken);

        // Snapshot ShowSnapshot(string snapshotId, CloudIdentity identity = null);
        Task<ShowSnapshotApiCall> PrepareShowSnapshotAsync(string snapshotId, CancellationToken cancellationToken);

        // bool DeleteSnapshot(string snapshotId, CloudIdentity identity = null);
        Task<DeleteSnapshotApiCall> PrepareDeleteSnapshotAsync(string snapshotId, CancellationToken cancellationToken);

        // Snapshot WaitForSnapshotAvailable(string snapshotId, int refreshCount = 360, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
        Task<WaitForSnapshotAvailableApiCall> PrepareWaitForSnapshotAvailableAsync(string snapshotId, int refreshCount = 360, TimeSpan? refreshDelay = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool WaitForSnapshotDeleted(string snapshotId, int refreshCount = 180, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
        Task<WaitForSnapshotDeletedApiCall> PrepareWaitForSnapshotDeletedAsync(string snapshotId, int refreshCount = 180, TimeSpan? refreshDelay = null, CancellationToken cancellationToken = default(CancellationToken));

        // Snapshot WaitForSnapshotState(string snapshotId, SnapshotState expectedState, SnapshotState[] errorStates, int refreshCount = 60, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
        Task<WaitForSnapshotStateApiCall> PrepareWaitForSnapshotStateAsync(string snapshotId, SnapshotState expectedState, SnapshotState[] errorStates, int refreshCount = 60, TimeSpan? refreshDelay = null, CancellationToken cancellationToken = default(CancellationToken));

        // VolumeUploadImage CreateGlanceImageFromVolume(string volumeId = null, string imageName = null, string diskFormat = null, string containerFormat = null, CloudIdentity identity = null);
        Task<CreateGlanceImageFromVolumeApiCall> PrepareCreateGlanceImageFromVolumeAsync(string volumeId = null, string imageName = null, string diskFormat = null, string containerFormat = null, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }
}
