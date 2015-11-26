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
        public IEnumerable<Container> ListContainers(int? limit = null, string marker = null, string markerEnd = null, bool useInternalUrl = false)
        {
            return FilesProvider.ListContainers(limit, marker, markerEnd, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public ObjectStore CreateContainer(string container, Dictionary<string, string> headers = null, bool useInternalUrl = false)
        {
            return FilesProvider.CreateContainer(container, headers, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteContainer(string container, bool deleteObjects = false, bool useInternalUrl = false)
        {
            FilesProvider.DeleteContainer(container, deleteObjects, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetContainerHeader(string container, bool useInternalUrl = false)
        {
            return FilesProvider.GetContainerHeader(container, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetContainerMetaData(string container, bool useInternalUrl = false)
        {
            return FilesProvider.GetContainerMetaData(container, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public ContainerCDN GetContainerCDNHeader(string container)
        {
            return FilesProvider.GetContainerCDNHeader(container, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ContainerCDN> ListCDNContainers(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false)
        {
            return FilesProvider.ListCDNContainers(limit, markerId, markerEnd, cdnEnabled, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive)
        {
            return FilesProvider.EnableCDNOnContainer(container, timeToLive, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> EnableCDNOnContainer(string container, bool logRetention)
        {
            return FilesProvider.EnableCDNOnContainer(container, logRetention, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, bool logRetention)
        {
            return FilesProvider.EnableCDNOnContainer(container, timeToLive, logRetention, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> DisableCDNOnContainer(string container)
        {
            return FilesProvider.DisableCDNOnContainer(container, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public void UpdateContainerMetadata(string container, Dictionary<string, string> metadata, bool useInternalUrl = false)
        {
            FilesProvider.UpdateContainerMetadata(container, metadata, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteContainerMetadata(string container, IEnumerable<string> keys, bool useInternalUrl = false)
        {
            FilesProvider.DeleteContainerMetadata(container, keys, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteContainerMetadata(string container, string key, bool useInternalUrl = false)
        {
            FilesProvider.DeleteContainerMetadata(container, key, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void UpdateContainerCdnHeaders(string container, Dictionary<string, string> headers)
        {
            FilesProvider.UpdateContainerCdnHeaders(container, headers, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string index, string error, string css, bool listing, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, index, error, css, listing, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string index, string error, bool listing, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, index, error, listing, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string css, bool listing, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, css, listing, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void EnableStaticWebOnContainer(string container, string index, string error, bool useInternalUrl = false)
        {
            FilesProvider.EnableStaticWebOnContainer(container, index, error, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DisableStaticWebOnContainer(string container, bool useInternalUrl = false)
        {
            FilesProvider.DisableStaticWebOnContainer(container, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetObjectHeaders(string container, string objectName, bool useInternalUrl = false)
        {
            return FilesProvider.GetObjectHeaders(container, objectName, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetObjectMetaData(string container, string objectName, bool useInternalUrl = false)
        {
            return FilesProvider.GetObjectMetaData(container, objectName, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void UpdateObjectMetadata(string container, string objectName, Dictionary<string, string> metadata, bool useInternalUrl = false)
        {
            FilesProvider.UpdateObjectMetadata(container, objectName, metadata, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteObjectMetadata(string container, string objectName, IEnumerable<string> keys, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObjectMetadata(container, objectName, keys, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteObjectMetadata(string container, string objectName, string key, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObjectMetadata(container, objectName, key, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ContainerObject> ListObjects(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, bool useInternalUrl = false)
        {
            return FilesProvider.ListObjects(container, limit, marker, markerEnd, prefix, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void CreateObjectFromFile(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.CreateObjectFromFile(container, filePath, objectName, contentType, chunkSize, headers, this.DefaultRegion, progressUpdated, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void CreateObject(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null,  Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.CreateObject(container, stream, objectName, contentType, chunkSize, headers, this.DefaultRegion, progressUpdated, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void GetObject(string container, string objectName, Stream outputStream, int chunkSize = 4096, Dictionary<string, string> headers = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.GetObject(container, objectName, outputStream, chunkSize, headers, this.DefaultRegion, verifyEtag, progressUpdated, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void GetObjectSaveToFile(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            FilesProvider.GetObjectSaveToFile(container, saveDirectory, objectName, fileName, chunkSize, headers, this.DefaultRegion, verifyEtag, progressUpdated, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void CopyObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, bool useInternalUrl = false)
        {
            FilesProvider.CopyObject(sourceContainer, sourceObjectName, destinationContainer, destinationObjectName, destinationContentType, headers, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteObject(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObject(container, objectName, headers, deleteSegments, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void DeleteObjects(string container, IEnumerable<string> objects, Dictionary<string, string> headers = null, bool useInternalUrl = false)
        {
            FilesProvider.DeleteObjects(container, objects, headers, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void BulkDelete(IEnumerable<KeyValuePair<string, string>> items, Dictionary<string, string> headers = null, bool useInternalUrl = false)
        {
            FilesProvider.BulkDelete(items, headers, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public ExtractArchiveResponse ExtractArchiveFromFile(string filePath, string uploadPath, ArchiveFormat archiveFormat, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            return FilesProvider.ExtractArchiveFromFile(filePath, uploadPath, archiveFormat, contentType, chunkSize, headers, this.DefaultRegion, progressUpdated, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public ExtractArchiveResponse ExtractArchive(Stream stream, string uploadPath, ArchiveFormat archiveFormat, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, Action<long> progressUpdated = null, bool useInternalUrl = false)
        {
            return FilesProvider.ExtractArchive(stream, uploadPath, archiveFormat, contentType, chunkSize, headers, this.DefaultRegion, progressUpdated, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void MoveObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, bool useInternalUrl = false)
        {
            FilesProvider.MoveObject(sourceContainer, sourceObjectName, destinationContainer, destinationObjectName, destinationContentType, headers, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void PurgeObjectFromCDN(string container, string objectName, IEnumerable<string> emails = null)
        {
            FilesProvider.PurgeObjectFromCDN(container, objectName, emails, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetAccountHeaders(bool useInternalUrl = false)
        {
            return FilesProvider.GetAccountHeaders(this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetAccountMetaData(bool useInternalUrl = false)
        {
            return FilesProvider.GetAccountMetaData(this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public void UpdateAccountMetadata(Dictionary<string, string> metadata, bool useInternalUrl = false)
        {
            FilesProvider.UpdateAccountMetadata(metadata, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Uri CreateTemporaryPublicUri(HttpMethod method, string container, string objectName, string key, DateTimeOffset expiration, bool useInternalUrl = false)
        {
            return FilesProvider.CreateTemporaryPublicUri(method, container, objectName, key, expiration, this.DefaultRegion, useInternalUrl, this.Identity);
        }

        /// <inheritdoc/>
        public Tuple<Uri, ReadOnlyDictionary<string, string>> CreateFormPostUri(string container, string objectPrefix, string key, DateTimeOffset expiration, Uri redirectUri, long maxFileSize, int maxFileCount, bool useInternalUrl = false)
        {
            return FilesProvider.CreateFormPostUri(container, objectPrefix, key, expiration, redirectUri, maxFileSize, maxFileCount, this.DefaultRegion, useInternalUrl, this.Identity);
        }

    }
}
