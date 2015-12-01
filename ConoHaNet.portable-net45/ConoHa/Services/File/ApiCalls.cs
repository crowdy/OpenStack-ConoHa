using System.Collections.Generic;

namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using System.Collections.Generic;
    using ConoHaNet.Objects;
    using ConoHaNet.Service.File;

    // IEnumerable<Container> ListContainers(int? limit = null, string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<ListContainersApiCall> PrepareListContainersAsync(int? limit = null, string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class ListContainersApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Container>>
    {
        public ListContainersApiCall(IHttpApiCall<ReadOnlyCollectionPage<Container>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // ObjectStore CreateContainer(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<CreateContainerApiCall> PrepareCreateContainerAsync(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class CreateContainerApiCall : DelegatingHttpApiCall<ObjectStore>
    {
        public CreateContainerApiCall(IHttpApiCall<ObjectStore> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void DeleteContainer(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<DeleteContainerApiCall> PrepareDeleteContainerAsync(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class DeleteContainerApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public DeleteContainerApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Dictionary<string, string> GetContainerHeader(string container, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetContainerHeaderApiCall> PrepareGetContainerHeaderAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetContainerHeaderApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public GetContainerHeaderApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Dictionary<string, string> GetContainerMetaData(string container, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetContainerMetaDataApiCall> PrepareGetContainerMetaDataAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetContainerMetaDataApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public GetContainerMetaDataApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // ContainerCDN GetContainerCDNHeader(string container, string region = null, CloudIdentity identity = null);
    // Task<GetContainerCDNHeaderApiCall> PrepareGetContainerCDNHeaderAsync(string container, string region = null, CancellationToken cancellationToken);
    public class GetContainerCDNHeaderApiCall : DelegatingHttpApiCall<ContainerCDN>
    {
        public GetContainerCDNHeaderApiCall(IHttpApiCall<ContainerCDN> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<ContainerCDN> ListCDNContainers(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null, CloudIdentity identity = null);
    // Task<ListCDNContainersApiCall> PrepareListCDNContainersAsync(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null, CancellationToken cancellationToken);
    public class ListCDNContainersApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<ContainerCDN>>
    {
        public ListCDNContainersApiCall(IHttpApiCall<ReadOnlyCollectionPage<ContainerCDN>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, string region = null, CloudIdentity identity = null);
    // Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, long timeToLive, string region = null, CancellationToken cancellationToken);
    public class EnableCDNOnContainerApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public EnableCDNOnContainerApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    
    // Dictionary<string, string> DisableCDNOnContainer(string container, string region = null, CloudIdentity identity = null);
    // Task<DisableCDNOnContainerApiCall> PrepareDisableCDNOnContainerAsync(string container, string region = null, CancellationToken cancellationToken);
    public class DisableCDNOnContainerApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public DisableCDNOnContainerApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void UpdateContainerMetadata(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<UpdateContainerMetadataApiCall> PrepareUpdateContainerMetadataAsync(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class UpdateContainerMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateContainerMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void DeleteContainerMetadata(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<DeleteContainerMetadataApiCall> PrepareDeleteContainerMetadataAsync(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class DeleteContainerMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteContainerMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void UpdateContainerCdnHeaders(string container, Dictionary<string, string> headers, string region = null, CloudIdentity identity = null);
    // Task<UpdateContainerCdnHeadersApiCall> PrepareUpdateContainerCdnHeadersAsync(string container, Dictionary<string, string> headers, string region = null, CancellationToken cancellationToken);
    public class UpdateContainerCdnHeadersApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateContainerCdnHeadersApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void DisableStaticWebOnContainer(string container, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<DisableStaticWebOnContainerApiCall> PrepareDisableStaticWebOnContainerAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class DisableStaticWebOnContainerApiCall : DelegatingHttpApiCall<bool>
    {
        public DisableStaticWebOnContainerApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Dictionary<string, string> GetObjectHeaders(string container, string objectName, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetObjectHeadersApiCall> PrepareGetObjectHeadersAsync(string container, string objectName, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetObjectHeadersApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public GetObjectHeadersApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Dictionary<string, string> GetObjectMetaData(string container, string objectName, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetObjectMetaDataApiCall> PrepareGetObjectMetaDataAsync(string container, string objectName, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetObjectMetaDataApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public GetObjectMetaDataApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void UpdateObjectMetadata(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<UpdateObjectMetadataApiCall> PrepareUpdateObjectMetadataAsync(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class UpdateObjectMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateObjectMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void DeleteObjectMetadata(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<DeleteObjectMetadataApiCall> PrepareDeleteObjectMetadataAsync(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class DeleteObjectMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteObjectMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // IEnumerable<ContainerObject> ListObjects(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<ListObjectsApiCall> PrepareListObjectsAsync(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class ListObjectsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<ContainerObject>>
    {
        public ListObjectsApiCall(IHttpApiCall<ReadOnlyCollectionPage<ContainerObject>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void CreateObjectFromFile(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<CreateObjectFromFileApiCall> PrepareCreateObjectFromFileAsync(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class CreateObjectFromFileApiCall : DelegatingHttpApiCall<bool>
    {
        public CreateObjectFromFileApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void CreateObject(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<CreateObjectApiCall> PrepareCreateObjectAsync(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class CreateObjectApiCall : DelegatingHttpApiCall<bool>
    {
        public CreateObjectApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void GetObject(string container, string objectName, Stream outputStream, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetObjectApiCall> PrepareGetObjectAsync(string container, string objectName, Stream outputStream, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetObjectApiCall : DelegatingHttpApiCall<bool>
    {
        public GetObjectApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void GetObjectSaveToFile(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetObjectSaveToFileApiCall> PrepareGetObjectSaveToFileAsync(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetObjectSaveToFileApiCall : DelegatingHttpApiCall<bool>
    {
        public GetObjectSaveToFileApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void CopyObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<CopyObjectApiCall> PrepareCopyObjectAsync(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class CopyObjectApiCall : DelegatingHttpApiCall<bool>
    {
        public CopyObjectApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void MoveObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<MoveObjectApiCall> PrepareMoveObjectAsync(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class MoveObjectApiCall : DelegatingHttpApiCall<bool>
    {
        public MoveObjectApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void DeleteObject(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<DeleteObjectApiCall> PrepareDeleteObjectAsync(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class DeleteObjectApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteObjectApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // void PurgeObjectFromCDN(string container, string objectName, IEnumerable<string> emails = null, string region = null, CloudIdentity identity = null);
    // Task<PurgeObjectFromCDNApiCall> PreparePurgeObjectFromCDNAsync(string container, string objectName, IEnumerable<string> emails = null, string region = null, CancellationToken cancellationToken);
    public class PurgeObjectFromCDNApiCall : DelegatingHttpApiCall<bool>
    {
        public PurgeObjectFromCDNApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }


    // Dictionary<string, string> GetAccountHeaders(string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetAccountHeadersApiCall> PrepareGetAccountHeadersAsync(string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetAccountHeadersApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public GetAccountHeadersApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Dictionary<string, string> GetAccountMetaData(string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<GetAccountMetaDataApiCall> PrepareGetAccountMetaDataAsync(string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class GetAccountMetaDataApiCall : DelegatingHttpApiCall<Dictionary<string, string>>
    {
        public GetAccountMetaDataApiCall(IHttpApiCall<Dictionary<string, string>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // void UpdateAccountMetadata(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
    // Task<UpdateAccountMetadataApiCall> PrepareUpdateAccountMetadataAsync(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken);
    public class UpdateAccountMetadataApiCall : DelegatingHttpApiCall<bool>
    {
        public UpdateAccountMetadataApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }



}
