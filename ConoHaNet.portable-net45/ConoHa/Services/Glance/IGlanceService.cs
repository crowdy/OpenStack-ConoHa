namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using OpenStack.Services;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IGlanceService : IHttpService, IExtensibleService<IGlanceService>
    {
        #region ConoHa

        // IEnumerable<CloudImage> ListGlanceImages(int? limit = 1000, string marker = null, string name = null, string visibility = null, string memberStatus = "accepted", string owner = null, string status = null, int? sizeMin = Int32.MinValue, int? sizeMax = Int32.MaxValue, string sortKey = "created_at", string sortDir = "desc", string tag = null, CloudIdentity identity = null);
        Task<ListGlanceImagesApiCall> PrepareListGlanceImagesAsync(int? limit = 1000, string marker = null, string name = null, string visibility = null, string memberStatus = "accepted", string owner = null, string status = null, int? sizeMin = Int32.MinValue, int? sizeMax = Int32.MaxValue, string sortKey = "created_at", string sortDir = "desc", string tag = null, CancellationToken cancellationToken = default(CancellationToken));

        // CloudImage GetGlanceImage(string ImageId, CloudIdentity identity = null);
        Task<GetGlanceImageApiCall> PrepareGetGlanceImageAsync(string ImageId, CancellationToken cancellationToken);

        // bool DeleteGlanceImage(string imageId, CloudIdentity identity = null);
        Task<DeleteGlanceImageApiCall> PrepareDeleteGlanceImageAsync(string imageId, CancellationToken cancellationToken);

        // CloudImageMember CreateGlanceImageMember(string imageId, CloudIdentity identity = null);
        Task<CreateGlanceImageMemberApiCall> PrepareCreateGlanceImageMemberAsync(string imageId, CancellationToken cancellationToken);

        // IEnumerable<CloudImageMember> ListGlanceImageMembers(string imageId, CloudIdentity identity = null);
        Task<ListGlanceImageMembersApiCall> PrepareListGlanceImageMembersAsync(string imageId, CancellationToken cancellationToken);

        // bool UpdateGlanceImageMember(string imageId, string memberId, CloudIdentity identity = null);
        Task<UpdateGlanceImageMemberApiCall> PrepareUpdateGlanceImageMemberAsync(string imageId, string memberId, CancellationToken cancellationToken);

        // bool DeleteGlanceImageMember(string imageId, string memberId, CloudIdentity identity = null);
        Task<DeleteGlanceImageMemberApiCall> PrepareDeleteGlanceImageMemberAsync(string imageId, string memberId, CancellationToken cancellationToken);

        // long GetImageAmount(CloudIdentity identity = null);
        Task<GetImageAmountApiCall> PrepareGetImageAmountAsync(CancellationToken cancellationToken);

        // IEnumerable<CommonlyUsedImage> ListCommonlyUsedImages(string tenantId = null, CloudIdentity identity = null);
        Task<ListCommonlyUsedImagesApiCall> PrepareListCommonlyUsedImagesAsync(string tenantId = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool SetWebShare(string imageId, bool sharing, CloudIdentity identity = null);
        Task<SetWebShareApiCall> PrepareSetWebShareAsync(string imageId, bool sharing, CancellationToken cancellationToken);

        // bool ImportImage(string name, string importFroUrl, CloudIdentity identity = null);
        Task<ImportImageApiCall> PrepareImportImageAsync(string name, string importFroUrl, CancellationToken cancellationToken);

        // IEnumerable<CloudImageTask> ListCloudImageTasks(CloudIdentity identity = null);
        Task<ListCloudImageTasksApiCall> PrepareListCloudImageTasksAsync(CancellationToken cancellationToken);

        // CloudImageTaskDetail GetCloudImageTask(string taskId, CloudIdentity identity = null);
        Task<GetCloudImageTaskApiCall> PrepareGetCloudImageTaskAsync(string taskId, CancellationToken cancellationToken);

        #endregion
    }
}
