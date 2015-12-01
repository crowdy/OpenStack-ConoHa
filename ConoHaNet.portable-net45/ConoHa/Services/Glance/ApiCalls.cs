namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.Glance;

    // IEnumerable<CloudImage> ListGlanceImages(int? limit = 1000, string marker = null, string name = null, string visibility = null, string memberStatus = "accepted", string owner = null, string status = null, int? sizeMin = Int32.MinValue, int? sizeMax = Int32.MaxValue, string sortKey = "created_at", string sortDir = "desc", string tag = null, CloudIdentity identity = null);
    // Task<ListGlanceImagesApiCall> PrepareListGlanceImagesAsync(int? limit = 1000, string marker = null, string name = null, string visibility = null, string memberStatus = "accepted", string owner = null, string status = null, int? sizeMin = Int32.MinValue, int? sizeMax = Int32.MaxValue, string sortKey = "created_at", string sortDir = "desc", string tag = null, CancellationToken cancellationToken);
    public class ListGlanceImagesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<CloudImage>>
    {
        public ListGlanceImagesApiCall(IHttpApiCall<ReadOnlyCollectionPage<CloudImage>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // CloudImage GetGlanceImage(string ImageId, CloudIdentity identity = null);
    // Task<GetGlanceImageApiCall> PrepareGetGlanceImageAsync(string ImageId, CancellationToken cancellationToken);
    public class GetGlanceImageApiCall : DelegatingHttpApiCall<CloudImage>
    {
        public GetGlanceImageApiCall(IHttpApiCall<CloudImage> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteGlanceImage(string imageId, CloudIdentity identity = null);
    // Task<DeleteGlanceImageApiCall> PrepareDeleteGlanceImageAsync(string imageId, CancellationToken cancellationToken);
    public class DeleteGlanceImageApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteGlanceImageApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // CloudImageMember CreateGlanceImageMember(string imageId, CloudIdentity identity = null);
    // Task<CreateGlanceImageMemberApiCall> PrepareCreateGlanceImageMemberAsync(string imageId, CancellationToken cancellationToken);
    public class CreateGlanceImageMemberApiCall : DelegatingHttpApiCall<CloudImageMember>
    {
        public CreateGlanceImageMemberApiCall(IHttpApiCall<CloudImageMember> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<CloudImageMember> ListGlanceImageMembers(string imageId, CloudIdentity identity = null);
    // Task<ListGlanceImageMembersApiCall> PrepareListGlanceImageMembersAsync(string imageId, CancellationToken cancellationToken);
    public class ListGlanceImageMembersApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<CloudImageMember>>
    {
        public ListGlanceImageMembersApiCall(IHttpApiCall<ReadOnlyCollectionPage<CloudImageMember>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool UpdateGlanceImageMember(string imageId, string memberId, CloudIdentity identity = null);
    // Task<UpdateGlanceImageMemberApiCall> PrepareUpdateGlanceImageMemberAsync(string imageId, string memberId, CancellationToken cancellationToken);
    public class UpdateGlanceImageMemberApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateGlanceImageMemberApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool DeleteGlanceImageMember(string imageId, string memberId, CloudIdentity identity = null);
    // Task<DeleteGlanceImageMemberApiCall> PrepareDeleteGlanceImageMemberAsync(string imageId, string memberId, CancellationToken cancellationToken);
    public class DeleteGlanceImageMemberApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteGlanceImageMemberApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // long GetImageAmount(CloudIdentity identity = null);
    // Task<GetImageAmountApiCall> PrepareGetImageAmountAsync(CancellationToken cancellationToken);
    public class GetImageAmountApiCall : DelegatingHttpApiCall<long>
    {
        public GetImageAmountApiCall(IHttpApiCall<long> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<CommonlyUsedImage> ListCommonlyUsedImages(string tenantId = null, CloudIdentity identity = null);
    // Task<ListCommonlyUsedImagesApiCall> PrepareListCommonlyUsedImagesAsync(string tenantId = null, CancellationToken cancellationToken);
    public class ListCommonlyUsedImagesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<CommonlyUsedImage>>
    {
        public ListCommonlyUsedImagesApiCall(IHttpApiCall<ReadOnlyCollectionPage<CommonlyUsedImage>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool SetWebShare(string imageId, bool sharing, CloudIdentity identity = null);
    // Task<SetWebShareApiCall> PrepareSetWebShareAsync(string imageId, bool sharing, CancellationToken cancellationToken);
    public class SetWebShareApiCall : DelegatingHttpApiCall<bool>
    {
        public SetWebShareApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // bool ImportImage(string name, string importFroUrl, CloudIdentity identity = null);
    // Task<ImportImageApiCall> PrepareImportImageAsync(string name, string importFroUrl, CancellationToken cancellationToken);
    public class ImportImageApiCall : DelegatingHttpApiCall<bool>
    {
        public ImportImageApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<CloudImageTask> ListCloudImageTasks(CloudIdentity identity = null);
    // Task<ListCloudImageTasksApiCall> PrepareListCloudImageTasksAsync(CancellationToken cancellationToken);
    public class ListCloudImageTasksApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<CloudImageTask>>
    {
        public ListCloudImageTasksApiCall(IHttpApiCall<ReadOnlyCollectionPage<CloudImageTask>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // CloudImageTaskDetail GetCloudImageTask(string taskId, CloudIdentity identity = null);
    // Task<GetCloudImageTaskApiCall> PrepareGetCloudImageTaskAsync(string taskId, CancellationToken cancellationToken);
    public class GetCloudImageTaskApiCall : DelegatingHttpApiCall<CloudImageTaskDetail>
    {
        public GetCloudImageTaskApiCall(IHttpApiCall<CloudImageTaskDetail> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


}
