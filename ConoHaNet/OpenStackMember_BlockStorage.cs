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
        public IEnumerable<VolumeType> ListVolumeTypes()
        {
            return BlockStorageProvider.ListVolumeTypes(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VolumeType GetVolumeType(string volumeId)
        {
            return BlockStorageProvider.DescribeVolumeType(volumeId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "volumes"

        /// <inheritdoc/>
        public IEnumerable<Volume> ListVolumes()
        {
            return BlockStorageProvider.ListVolumes(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Volume> ListVolumesDetails()
        {
            return BlockStorageProvider.ListVolumesDetails(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Volume GetVolume(string volumeId)
        {
            return BlockStorageProvider.ShowVolume(volumeId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Volume CreateVolume(int size, string sourceVolumeId = null, string description = null, string name = null, string snapshotId = null, string volumeType = null, string imageRef = null)
        {
            return BlockStorageProvider.CreateVolume(size, sourceVolumeId, description, name, snapshotId, volumeType, imageRef, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteVolume(string volumeId)
        {
            return BlockStorageProvider.DeleteVolume(volumeId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Volume WaitForVolumeAvailable(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null)
        {
            return BlockStorageProvider.WaitForVolumeAvailable(volumeId, refreshCount, refreshDelay, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool WaitForVolumeDeleted(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null)
        {
            return BlockStorageProvider.WaitForVolumeDeleted(volumeId, refreshCount, refreshDelay, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Volume WaitForVolumeState(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null)
        {
            return BlockStorageProvider.WaitForVolumeState(volumeId, expectedState, errorStates, refreshCount, refreshDelay, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VolumeUploadImage CreateGlanceImageFromVolume(string volumeId, string imageName, string diskFormat = null, string containerFormat = null)
        {
            return this.BlockStorageProvider.CreateGlanceImageFromVolume(volumeId, imageName, diskFormat, containerFormat, this.DefaultRegion, this.Identity);
        }

        #endregion

    }
}
