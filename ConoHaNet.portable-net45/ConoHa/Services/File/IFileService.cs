namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using OpenStack.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IFileService : IHttpService, IExtensibleService<IFileService>
    {
        #region ConoHa

        // IEnumerable<Container> ListContainers(int? limit = null, string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<ListContainersApiCall> PrepareListContainersAsync(int? limit = null, string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // ObjectStore CreateContainer(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<CreateContainerApiCall> PrepareCreateContainerAsync(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void DeleteContainer(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DeleteContainerApiCall> PrepareDeleteContainerAsync(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> GetContainerHeader(string container, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetContainerHeaderApiCall> PrepareGetContainerHeaderAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> GetContainerMetaData(string container, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetContainerMetaDataApiCall> PrepareGetContainerMetaDataAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // ContainerCDN GetContainerCDNHeader(string container, string region = null, CloudIdentity identity = null);
        Task<GetContainerCDNHeaderApiCall> PrepareGetContainerCDNHeaderAsync(string container, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<ContainerCDN> ListCDNContainers(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null, CloudIdentity identity = null);
        Task<ListCDNContainersApiCall> PrepareListCDNContainersAsync(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, string region = null, CloudIdentity identity = null);
        Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, long timeToLive, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> EnableCDNOnContainer(string container, bool logRetention, string region = null, CloudIdentity identity = null);
        Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, bool logRetention, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, bool logRetention, string region = null, CloudIdentity identity = null);
        Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, long timeToLive, bool logRetention, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> DisableCDNOnContainer(string container, string region = null, CloudIdentity identity = null);
        Task<DisableCDNOnContainerApiCall> PrepareDisableCDNOnContainerAsync(string container, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // void UpdateContainerMetadata(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<UpdateContainerMetadataApiCall> PrepareUpdateContainerMetadataAsync(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void DeleteContainerMetadata(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DeleteContainerMetadataApiCall> PrepareDeleteContainerMetadataAsync(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void DeleteContainerMetadata(string container, string key, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DeleteContainerMetadataApiCall> PrepareDeleteContainerMetadataAsync(string container, string key, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void UpdateContainerCdnHeaders(string container, Dictionary<string, string> headers, string region = null, CloudIdentity identity = null);
        Task<UpdateContainerCdnHeadersApiCall> PrepareUpdateContainerCdnHeadersAsync(string container, Dictionary<string, string> headers, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // void DisableStaticWebOnContainer(string container, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DisableStaticWebOnContainerApiCall> PrepareDisableStaticWebOnContainerAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> GetObjectHeaders(string container, string objectName, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetObjectHeadersApiCall> PrepareGetObjectHeadersAsync(string container, string objectName, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> GetObjectMetaData(string container, string objectName, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetObjectMetaDataApiCall> PrepareGetObjectMetaDataAsync(string container, string objectName, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void UpdateObjectMetadata(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<UpdateObjectMetadataApiCall> PrepareUpdateObjectMetadataAsync(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void DeleteObjectMetadata(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DeleteObjectMetadataApiCall> PrepareDeleteObjectMetadataAsync(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void DeleteObjectMetadata(string container, string objectName, string key, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DeleteObjectMetadataApiCall> PrepareDeleteObjectMetadataAsync(string container, string objectName, string key, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<ContainerObject> ListObjects(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<ListObjectsApiCall> PrepareListObjectsAsync(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void CreateObjectFromFile(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<CreateObjectFromFileApiCall> PrepareCreateObjectFromFileAsync(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void CreateObject(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<CreateObjectApiCall> PrepareCreateObjectAsync(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void GetObject(string container, string objectName, Stream outputStream, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetObjectApiCall> PrepareGetObjectAsync(string container, string objectName, Stream outputStream, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void GetObjectSaveToFile(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetObjectSaveToFileApiCall> PrepareGetObjectSaveToFileAsync(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void CopyObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<CopyObjectApiCall> PrepareCopyObjectAsync(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void MoveObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<MoveObjectApiCall> PrepareMoveObjectAsync(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void DeleteObject(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<DeleteObjectApiCall> PrepareDeleteObjectAsync(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void PurgeObjectFromCDN(string container, string objectName, IEnumerable<string> emails = null, string region = null, CloudIdentity identity = null);
        Task<PurgeObjectFromCDNApiCall> PreparePurgeObjectFromCDNAsync(string container, string objectName, IEnumerable<string> emails = null, string region = null, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> GetAccountHeaders(string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetAccountHeadersApiCall> PrepareGetAccountHeadersAsync(string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // Dictionary<string, string> GetAccountMetaData(string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<GetAccountMetaDataApiCall> PrepareGetAccountMetaDataAsync(string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        // void UpdateAccountMetadata(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CloudIdentity identity = null);
        Task<UpdateAccountMetadataApiCall> PrepareUpdateAccountMetadataAsync(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }
}
