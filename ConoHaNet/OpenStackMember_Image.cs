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
        public IEnumerable<CloudImage> ListGlanceImages(int? limit = null, string marker = null, string name = null, string visibility = null, string memberStatus = null, string owner = null, string status = null, int? sizeMin = null, int? sizeMax = null, string sortKey = null, string sortDir = null, string tag = null)
        {
            return ImagesProvider.ListGlanceImages(limit, marker, name, visibility, memberStatus, owner, status, sizeMin, sizeMax, sortKey, sortDir, tag, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public CloudImage GetGlanceImage(string imageId)
        {
            return ImagesProvider.GetGlanceImage(imageId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteGlanceImage(string imageId)
        {
            return ImagesProvider.DeleteGlanceImage(imageId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> SetImageQuota(string quota)
        {
            return ImagesProvider.SetImageQuota(quota, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public long GetImageAmount()
        {
            return this.ImagesProvider.GetImageAmount(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool SetWebShare(string imageId, bool sharing)
        {
            return ImagesProvider.SetWebShare(imageId, sharing, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ImportImage(string name, string importFromUrl)
        {
            return ImagesProvider.ImportImage(name, importFromUrl, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<CloudImageTask> ListCloudImageTasks()
        {
            return ImagesProvider.ListCloudImageTasks(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public CloudImageTaskDetail GetCloudImageTask(string taskId)
        {
            return ImagesProvider.GetCloudImageTask(taskId, this.DefaultRegion, this.Identity);
        }

        #endregion

    }
}
