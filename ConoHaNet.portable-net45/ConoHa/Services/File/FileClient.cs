namespace ConoHaNet.Services
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenStack.Collections;
    using OpenStack.Net;
    using OpenStack.ObjectModel.JsonHome;
    using OpenStack.Security.Authentication;
    using OpenStack.Services.Identity;
    using Rackspace.Net;
    using Rackspace.Threading;

    using System.Diagnostics;
    using OpenStack.Services;
    using ConoHa.Services;


    /// <summary>
    /// This class provides a default implementation of <see cref="IContentDeliveryService"/> suitable for connecting to
    /// OpenStack-compatible installations of the Content Delivery Service V1.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public class FileServiceClient : ServiceClient, IFileService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileServiceClient"/> class with the specified
        /// authentication service, default region, and value indicating whether an internal or public endpoint should
        /// be used for communicating with the service.
        /// </summary>
        /// <param name="authenticationService">The authentication service to use for authenticating requests made to
        /// this service.</param>
        /// <param name="defaultRegion">The preferred region for the service. Unless otherwise specified for a specific
        /// client, derived service clients will not use a default region if this value is <see langword="null"/> (i.e.
        /// only region-less or "global" service endpoints will be considered acceptable).</param>
        /// <param name="internalUrl"><see langword="true"/> to access the service over a local network; otherwise,
        /// <see langword="false"/> to access the service over a public network (the Internet).</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="authenticationService"/> is <see langword="null"/>.
        /// </exception>
        public FileServiceClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IFileService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<CopyObjectApiCall> PrepareCopyObjectAsync(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateContainerApiCall> PrepareCreateContainerAsync(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateObjectApiCall> PrepareCreateObjectAsync(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateObjectFromFileApiCall> PrepareCreateObjectFromFileAsync(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteContainerApiCall> PrepareDeleteContainerAsync(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteContainerMetadataApiCall> PrepareDeleteContainerMetadataAsync(string container, string key, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteContainerMetadataApiCall> PrepareDeleteContainerMetadataAsync(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteObjectApiCall> PrepareDeleteObjectAsync(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteObjectMetadataApiCall> PrepareDeleteObjectMetadataAsync(string container, string objectName, string key, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteObjectMetadataApiCall> PrepareDeleteObjectMetadataAsync(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DisableCDNOnContainerApiCall> PrepareDisableCDNOnContainerAsync(string container, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DisableStaticWebOnContainerApiCall> PrepareDisableStaticWebOnContainerAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, bool logRetention, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, long timeToLive, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<EnableCDNOnContainerApiCall> PrepareEnableCDNOnContainerAsync(string container, long timeToLive, bool logRetention, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetAccountHeadersApiCall> PrepareGetAccountHeadersAsync(string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetAccountMetaDataApiCall> PrepareGetAccountMetaDataAsync(string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetContainerCDNHeaderApiCall> PrepareGetContainerCDNHeaderAsync(string container, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetContainerHeaderApiCall> PrepareGetContainerHeaderAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetContainerMetaDataApiCall> PrepareGetContainerMetaDataAsync(string container, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectApiCall> PrepareGetObjectAsync(string container, string objectName, Stream outputStream, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectHeadersApiCall> PrepareGetObjectHeadersAsync(string container, string objectName, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectMetaDataApiCall> PrepareGetObjectMetaDataAsync(string container, string objectName, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<GetObjectSaveToFileApiCall> PrepareGetObjectSaveToFileAsync(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListCDNContainersApiCall> PrepareListCDNContainersAsync(int? limit = default(int?), string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListContainersApiCall> PrepareListContainersAsync(int? limit = default(int?), string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<ListObjectsApiCall> PrepareListObjectsAsync(string container, int? limit = default(int?), string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<MoveObjectApiCall> PrepareMoveObjectAsync(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<PurgeObjectFromCDNApiCall> PreparePurgeObjectFromCDNAsync(string container, string objectName, IEnumerable<string> emails = null, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateAccountMetadataApiCall> PrepareUpdateAccountMetadataAsync(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateContainerCdnHeadersApiCall> PrepareUpdateContainerCdnHeadersAsync(string container, Dictionary<string, string> headers, string region = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateContainerMetadataApiCall> PrepareUpdateContainerMetadataAsync(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<UpdateObjectMetadataApiCall> PrepareUpdateObjectMetadataAsync(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
