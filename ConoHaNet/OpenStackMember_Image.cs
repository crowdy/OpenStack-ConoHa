namespace ConoHaNet
{
    using Providers;
    using Objects.Images;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudImagesProvider _ImagesProvider = null;

        /// <summary>
        /// Defines an instance of CloudImagesProvider
        /// </summary>
        public CloudImagesProvider ImagesProvider
        {
            get
            {
                if (_ImagesProvider == null)
                {
                    _ImagesProvider = new CloudImagesProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudImagesProvider created.");

                }
                return _ImagesProvider;
            }
        }


        #region "images"

        /// <inheritdoc/>
        public IEnumerable<CloudImage> ListGlanceImages(int? limit = null, string marker = null, string name = null, string visibility = null, string memberStatus = null, string owner = null, string status = null, int? sizeMin = null, int? sizeMax = null, string sortKey = null, string sortDir = null, string tag = null, string region = null)
        {
            return ImagesProvider.ListGlanceImages(limit, marker, name, visibility, memberStatus, owner, status, sizeMin, sizeMax, sortKey, sortDir, tag, region, Identity);
        }

        /// <inheritdoc/>
        public CloudImage GetGlanceImage(string imageId, string region = null)
        {
            return ImagesProvider.GetGlanceImage(imageId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteGlanceImage(string imageId, string region = null)
        {
            return ImagesProvider.DeleteGlanceImage(imageId, region, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> SetImageQuota(string quota, string region = null)
        {
            return ImagesProvider.SetImageQuota(quota, region, Identity);
        }

        /// <inheritdoc/>
        public long GetImageAmount(string region = null)
        {
            return this.ImagesProvider.GetImageAmount(region, Identity);
        }

        /// <inheritdoc/>
        public bool SetWebShare(string imageId, bool sharing, string region = null)
        {
            return ImagesProvider.SetWebShare(imageId, sharing, region, Identity);
        }

        /// <inheritdoc/>
        public bool ImportImage(string name, string importFromUrl, string region = null)
        {
            return ImagesProvider.ImportImage(name, importFromUrl, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<CloudImageTask> ListCloudImageTasks(string region = null)
        {
            return ImagesProvider.ListCloudImageTasks(region, Identity);
        }

        /// <inheritdoc/>
        public CloudImageTaskDetail GetCloudImageTask(string taskId, string region = null)
        {
            return ImagesProvider.GetCloudImageTask(taskId, region, Identity);
        }

        #endregion

    }
}
