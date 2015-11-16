namespace ConoHaNet
{
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Objects.Volumes;
    using Objects;
    using Objects.BlockStorage;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudBlockStorageProvider _BlockStorageProvider = null;

        /// <inheritdoc/>
        public CloudBlockStorageProvider BlockStorageProvider
        {
            get
            {
                if (_BlockStorageProvider == null)
                {
                    _BlockStorageProvider = new CloudBlockStorageProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null);
                    Trace.WriteLine("CloudBlockStorageProvider created.");
                }
                return _BlockStorageProvider;
            }
        }


        #region "types"

        /// <inheritdoc/>
        public IEnumerable<VolumeType> ListVolumeTypes(string region = null)
        {
            return BlockStorageProvider.ListVolumeTypes(region, Identity);
        }

        /// <inheritdoc/>
        public VolumeType GetVolumeType(string volumeId, string region = null)
        {
            return BlockStorageProvider.DescribeVolumeType(volumeId, region, Identity);
        }

        #endregion


        #region "volumes"

        /// <inheritdoc/>
        public IEnumerable<Volume> ListVolumes(string region = null)
        {
            return BlockStorageProvider.ListVolumes(region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Volume> ListVolumesDetails(string region = null)
        {
            return BlockStorageProvider.ListVolumesDetails(region, Identity);
        }

        /// <inheritdoc/>
        public Volume GetVolume(string volumeId, string region = null)
        {
            return BlockStorageProvider.ShowVolume(volumeId, region, Identity);
        }

        /// <inheritdoc/>
        public Volume CreateVolume(int size, string sourceVolumeId = null, string description = null, string name = null, string snapshotId = null, string volumeType = null, string imageRef = null, string region = null)
        {
            return BlockStorageProvider.CreateVolume(size, sourceVolumeId, description, name, snapshotId, volumeType, imageRef, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteVolume(string volumeId, string region = null)
        {
            return BlockStorageProvider.DeleteVolume(volumeId, region, Identity);
        }

        /// <inheritdoc/>
        public Volume WaitForVolumeAvailable(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null)
        {
            return BlockStorageProvider.WaitForVolumeAvailable(volumeId, refreshCount, refreshDelay, region, Identity);
        }

        /// <inheritdoc/>
        public bool WaitForVolumeDeleted(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null, string region = null)
        {
            return BlockStorageProvider.WaitForVolumeDeleted(volumeId, refreshCount, refreshDelay, region, Identity);
        }

        /// <inheritdoc/>
        public Volume WaitForVolumeState(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null)
        {
            return BlockStorageProvider.WaitForVolumeState(volumeId, expectedState, errorStates, refreshCount, refreshDelay, region, Identity);
        }

        /// <inheritdoc/>
        public VolumeUploadImage CreateGlanceImageFromVolume(string volumeId, string imageName, string diskFormat = null, string containerFormat = null, string region = null)
        {
            return this.BlockStorageProvider.CreateGlanceImageFromVolume(volumeId, imageName, diskFormat, containerFormat, region, Identity);
        }

        #endregion

    }
}
