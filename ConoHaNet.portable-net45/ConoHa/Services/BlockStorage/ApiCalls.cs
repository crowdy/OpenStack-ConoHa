namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.BlockStorage;

    // Volume CreateVolume(int size, string sourceVolumeId = null, string Description = null, string Name = null, string snapshotId = null, string volumeType = null, string imageRef = null, CloudIdentity identity = null);
    // Task<CreateVolumeApiCall> PrepareCreateVolumeAsync(int size, string sourceVolumeId = null, string Description = null, string Name = null, string snapshotId = null, string volumeType = null, string imageRef = null, CancellationToken cancellationToken);
    public class CreateVolumeApiCall : DelegatingHttpApiCall<Volume>
    {
        public CreateVolumeApiCall(IHttpApiCall<Volume> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<Volume> ListVolumes(CloudIdentity identity = null);
    // Task<ListVolumesApiCall> PrepareListVolumesAsync(CancellationToken cancellationToken);
    public class ListVolumesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Volume>>
    {
        public ListVolumesApiCall(IHttpApiCall<ReadOnlyCollectionPage<Volume>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Volume ShowVolume(string volumeId, CloudIdentity identity = null);
    // Task<ShowVolumeApiCall> PrepareShowVolumeAsync(string volumeId, CancellationToken cancellationToken);
    public class ShowVolumeApiCall : DelegatingHttpApiCall<Volume>
    {
        public ShowVolumeApiCall(IHttpApiCall<Volume> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteVolume(string volumeId, CloudIdentity identity = null);
    // Task<DeleteVolumeApiCall> PrepareDeleteVolumeAsync(string volumeId, CancellationToken cancellationToken);
    public class DeleteVolumeApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteVolumeApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // VolumeType DescribeVolumeType(string volumeTypeId, CloudIdentity identity = null);
    // Task<DescribeVolumeTypeApiCall> PrepareDescribeVolumeTypeAsync(string volumeTypeId, CancellationToken cancellationToken);
    public class DescribeVolumeTypeApiCall : DelegatingHttpApiCall<VolumeType>
    {
        public DescribeVolumeTypeApiCall(IHttpApiCall<VolumeType> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Volume WaitForVolumeAvailable(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
    // Task<CreateWaitForVolumeAvailableApiCall> PrepareWaitForVolumeAvailableAsync(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null, CancellationToken cancellationToken);
    public class CreateWaitForVolumeAvailableApiCall : DelegatingHttpApiCall<Volume>
    {
        public CreateWaitForVolumeAvailableApiCall(IHttpApiCall<Volume> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool WaitForVolumeDeleted(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
    // Task<WaitForVolumeDeletedApiCall> PrepareWaitForVolumeDeletedAsync(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null, CancellationToken cancellationToken);
    public class WaitForVolumeDeletedApiCall : DelegatingHttpApiCall<bool>
    {
        public WaitForVolumeDeletedApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Volume WaitForVolumeState(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
    // Task<WaitForVolumeStateApiCall> PrepareWaitForVolumeStateAsync(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, CancellationToken cancellationToken);
    public class WaitForVolumeStateApiCall : DelegatingHttpApiCall<Volume>
    {
        public WaitForVolumeStateApiCall(IHttpApiCall<Volume> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Snapshot CreateSnapshot(string volumeId, bool force = false, string displayName = "None", string displayDescription = null, CloudIdentity identity = null);
    // Task<CreateSnapshotApiCall> PrepareCreateSnapshotAsync(string volumeId, bool force = false, string displayName = "None", string displayDescription = null, CancellationToken cancellationToken);
    public class CreateSnapshotApiCall : DelegatingHttpApiCall<Snapshot>
    {
        public CreateSnapshotApiCall(IHttpApiCall<Snapshot> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<Snapshot> ListSnapshots(CloudIdentity identity = null);
    // Task<ListSnapshotsApiCall> PrepareListSnapshotsAsync(CancellationToken cancellationToken);
    public class ListSnapshotsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Snapshot>>
    {
        public ListSnapshotsApiCall(IHttpApiCall<ReadOnlyCollectionPage<Snapshot>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Snapshot ShowSnapshot(string snapshotId, CloudIdentity identity = null);
    // Task<ShowSnapshotApiCall> PrepareShowSnapshotAsync(string snapshotId, CancellationToken cancellationToken);
    public class ShowSnapshotApiCall : DelegatingHttpApiCall<Snapshot>
    {
        public ShowSnapshotApiCall(IHttpApiCall<Snapshot> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteSnapshot(string snapshotId, CloudIdentity identity = null);
    // Task<DeleteSnapshotApiCall> PrepareDeleteSnapshotAsync(string snapshotId, CancellationToken cancellationToken);
    public class DeleteSnapshotApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteSnapshotApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Snapshot WaitForSnapshotAvailable(string snapshotId, int refreshCount = 360, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
    // Task<WaitForSnapshotAvailableApiCall> PrepareWaitForSnapshotAvailableAsync(string snapshotId, int refreshCount = 360, TimeSpan? refreshDelay = null, CancellationToken cancellationToken);
    public class WaitForSnapshotAvailableApiCall : DelegatingHttpApiCall<Snapshot>
    {
        public WaitForSnapshotAvailableApiCall(IHttpApiCall<Snapshot> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool WaitForSnapshotDeleted(string snapshotId, int refreshCount = 180, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
    // Task<WaitForSnapshotDeletedApiCall> PrepareWaitForSnapshotDeletedAsync(string snapshotId, int refreshCount = 180, TimeSpan? refreshDelay = null, CancellationToken cancellationToken);
    public class WaitForSnapshotDeletedApiCall : DelegatingHttpApiCall<bool>
    {
        public WaitForSnapshotDeletedApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Snapshot WaitForSnapshotState(string snapshotId, SnapshotState expectedState, SnapshotState[] errorStates, int refreshCount = 60, TimeSpan? refreshDelay = null, CloudIdentity identity = null);
    // Task<WaitForSnapshotStateApiCall> PrepareWaitForSnapshotStateAsync(string snapshotId, SnapshotState expectedState, SnapshotState[] errorStates, int refreshCount = 60, TimeSpan? refreshDelay = null, CancellationToken cancellationToken);
    public class WaitForSnapshotStateApiCall : DelegatingHttpApiCall<Snapshot>
    {
        public WaitForSnapshotStateApiCall(IHttpApiCall<Snapshot> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // VolumeUploadImage CreateGlanceImageFromVolume(string volumeId = null, string imageName = null, string diskFormat = null, string containerFormat = null, CloudIdentity identity = null);
    // Task<CreateGlanceImageFromVolumeApiCall> PrepareCreateGlanceImageFromVolumeAsync(string volumeId = null, string imageName = null, string diskFormat = null, string containerFormat = null, CancellationToken cancellationToken);
    public class CreateGlanceImageFromVolumeApiCall : DelegatingHttpApiCall<VolumeUploadImage>
    {
        public CreateGlanceImageFromVolumeApiCall(IHttpApiCall<VolumeUploadImage> httpApiCall)
            : base(httpApiCall)
        {
        }
    }
}
