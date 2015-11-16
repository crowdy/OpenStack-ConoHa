namespace ConoHaNet.Providers
{
    using System;
    using System.Collections.Generic;
    using ConoHaNet.Objects;
    using Objects.Images;

    /// <summary>
    /// Represents a provider for the OpenStack Networking service.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-network/2.0/content/">OpenStack Networking API v2.0 Reference</seealso>
    public interface IImagesProvider
    {

        /// <summary>
        /// Gets a collection of glance image
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="marker"></param>
        /// <param name="name"></param>
        /// <param name="visibility"></param>
        /// <param name="memberStatus"></param>
        /// <param name="owner"></param>
        /// <param name="status"></param>
        /// <param name="sizeMin"></param>
        /// <param name="sizeMax"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortDir"></param>
        /// <param name="tag"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/image-get_images_list.html"/>
        IEnumerable<CloudImage> ListGlanceImages(int? limit = 1000, string marker = null, string name = null, string visibility = null, string memberStatus = "accepted", string owner = null, string status = null, int? sizeMin = Int32.MinValue, int? sizeMax = Int32.MaxValue, string sortKey = "created_at", string sortDir = "desc", string tag = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the glance image with image id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/image-get_images_detail_specified.html"/>
        CloudImage GetGlanceImage(string imageId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the glance image with image id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/image-remove_image.html"/>
        bool DeleteGlanceImage(string imageId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Creates a glance image member
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        CloudImageMember CreateGlanceImageMember(string imageId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets the list of glance image member
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        IEnumerable<CloudImageMember> ListGlanceImageMembers(string imageId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Updates the glance image member
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="memberId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool UpdateGlanceImageMember(string imageId, string memberId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Deletes the glance image emember with member id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="memberId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        bool DeleteGlanceImageMember(string imageId, string memberId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Gets glance image quota
        /// </summary>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        long GetImageAmount(string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this is not public command.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        IEnumerable<CommonlyUsedImage> ListCommonlyUsedImages(string tenantId = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this is not public command.
        /// </summary>
        bool SetWebShare(string imageId, bool sharing, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this is not public command.
        /// </summary>
        bool ImportImage(string name, string importFroUrl, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this is not public command.
        /// </summary>
        IEnumerable<CloudImageTask> ListCloudImageTasks(string region = null, CloudIdentity identity = null);

        /// <summary>
        /// this is not public command.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="region"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        CloudImageTaskDetail GetCloudImageTask(string taskId, string region = null, CloudIdentity identity = null);

    }
}
