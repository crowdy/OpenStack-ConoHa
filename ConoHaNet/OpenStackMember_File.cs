namespace ConoHaNet
{
    using Providers;
    using JSIStudios.SimpleRESTServices.Client;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Collections.ObjectModel;
    using Objects;
    using Objects.File;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudFilesProvider _FilesProvider = null;

        /// <inheritdoc/>
        public CloudFilesProvider FilesProvider
        {
            get
            {
                if (_FilesProvider == null)
                {
                    _FilesProvider = new CloudFilesProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudFilesProvider created.");

                }
                return _FilesProvider;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Container> ListContainers(int? limit = null, string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.ListContainers(limit, marker, markerEnd, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public ObjectStore CreateContainer(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.CreateContainer(container, headers, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteContainer(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteContainer(container, deleteObjects, region, useInternalUrl);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetContainerHeader(string container, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.GetContainerHeader(container, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetContainerMetaData(string container, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.GetContainerMetaData(container, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public ContainerCDN GetContainerCDNHeader(string container, string region = null)
        {
            return FilesProvider.GetContainerCDNHeader(container, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ContainerCDN> ListCDNContainers(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null)
        {
            return FilesProvider.ListCDNContainers(limit, markerId, markerEnd, cdnEnabled, region, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, string region = null)
        {
            return FilesProvider.EnableCDNOnContainer(container, timeToLive, region, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> EnableCDNOnContainer(string container, bool logRetention, string region = null)
        {
            return FilesProvider.EnableCDNOnContainer(container, logRetention, region, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, bool logRetention, string region = null)
        {
            return FilesProvider.EnableCDNOnContainer(container, timeToLive, logRetention, region, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> DisableCDNOnContainer(string container, string region = null)
        {
            return FilesProvider.DisableCDNOnContainer(container, region, Identity);
        }

        /// <inheritdoc/>
        public void UpdateContainerMetadata(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.UpdateContainerMetadata(container, metadata, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteContainerMetadata(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteContainerMetadata(container, keys, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteContainerMetadata(string container, string key, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteContainerMetadata(container, key, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void UpdateContainerCdnHeaders(string container, Dictionary<string, string> headers, string region = null)
        {
            FilesProvider.UpdateContainerCdnHeaders(container, headers, region, Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string index, string error, string css, bool listing, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, index, error, css, listing, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string index, string error, bool listing, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, index, error, listing, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string css, bool listing, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, css, listing, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string index, string error, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, index, error, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DisableStaticWebOnContainer(string container, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DisableStaticWebOnContainer(container, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetObjectHeaders(string container, string objectName, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.GetObjectHeaders(container, objectName, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetObjectMetaData(string container, string objectName, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.GetObjectMetaData(container, objectName, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void UpdateObjectMetadata(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.UpdateObjectMetadata(container, objectName, metadata, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteObjectMetadata(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObjectMetadata(container, objectName, keys, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteObjectMetadata(string container, string objectName, string key, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObjectMetadata(container, objectName, key, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ContainerObject> ListObjects(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.ListObjects(container, limit, marker, markerEnd, prefix, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void CreateObjectFromFile(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.CreateObjectFromFile(container, filePath, objectName, contentType, chunkSize, headers, region, progressUpdated, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void CreateObject(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.CreateObject(container, stream, objectName, contentType, chunkSize, headers, region, progressUpdated, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void GetObject(string container, string objectName, Stream outputStream, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.GetObject(container, objectName, outputStream, chunkSize, headers, region, verifyEtag, progressUpdated, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void GetObjectSaveToFile(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.GetObjectSaveToFile(container, saveDirectory, objectName, fileName, chunkSize, headers, region, verifyEtag, progressUpdated, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void CopyObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.CopyObject(sourceContainer, sourceObjectName, destinationContainer, destinationObjectName, destinationContentType, headers, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteObject(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObject(container, objectName, headers, deleteSegments, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void DeleteObjects(string container, IEnumerable<string> objects, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObjects(container, objects, headers, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void BulkDelete(IEnumerable<KeyValuePair<string, string>> items, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.BulkDelete(items, headers, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public ExtractArchiveResponse ExtractArchiveFromFile(string filePath, string uploadPath, ArchiveFormat archiveFormat, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            return FilesProvider.ExtractArchiveFromFile(filePath, uploadPath, archiveFormat, contentType, chunkSize, headers, region, progressUpdated, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public ExtractArchiveResponse ExtractArchive(Stream stream, string uploadPath, ArchiveFormat archiveFormat, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            return FilesProvider.ExtractArchive(stream, uploadPath, archiveFormat, contentType, chunkSize, headers, region, progressUpdated, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void MoveObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.MoveObject(sourceContainer, sourceObjectName, destinationContainer, destinationObjectName, destinationContentType, headers, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void PurgeObjectFromCDN(string container, string objectName, IEnumerable<string> emails = null, string region = null)
        {
            FilesProvider.PurgeObjectFromCDN(container, objectName, emails, region, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetAccountHeaders(string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.GetAccountHeaders(region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetAccountMetaData(string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.GetAccountMetaData(region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public void UpdateAccountMetadata(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false)
        {
            FilesProvider.UpdateAccountMetadata(metadata, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public Uri CreateTemporaryPublicUri(HttpMethod method, string container, string objectName, string key, DateTimeOffset expiration, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.CreateTemporaryPublicUri(method, container, objectName, key, expiration, region, useInternalUrl, Identity);
        }

        /// <inheritdoc/>
        public Tuple<Uri, ReadOnlyDictionary<string, string>> CreateFormPostUri(string container, string objectPrefix, string key, DateTimeOffset expiration, Uri redirectUri, long maxFileSize, int maxFileCount, string region = null, bool useInternalUrl = false)
        {
            return FilesProvider.CreateFormPostUri(container, objectPrefix, key, expiration, redirectUri, maxFileSize, maxFileCount, region, useInternalUrl, Identity);
        }

    }
}
