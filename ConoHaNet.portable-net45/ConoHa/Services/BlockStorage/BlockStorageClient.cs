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
    using BlockStorage;


    /// <summary>
    /// This class provides a default implementation of <see cref="IContentDeliveryService"/> suitable for connecting to
    /// OpenStack-compatible installations of the Content Delivery Service V1.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public class BlockStorageClient : ServiceClient, IBlockStorageService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStorageClient"/> class with the specified
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
        public BlockStorageClient(IAuthenticationService authenticationService, string defaultRegion, bool internalUrl)
            : base(authenticationService, defaultRegion, internalUrl)
        {
        }

        public TExtension GetServiceExtension<TExtension>(ServiceExtensionDefinition<IBlockStorageService, TExtension> definition)
        {
            throw new NotImplementedException();
        }

        public Task<CreateGlanceImageFromVolumeApiCall> PrepareCreateGlanceImageFromVolumeAsync(string volumeId = null, string imageName = null, string diskFormat = null, string containerFormat = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateSnapshotApiCall> PrepareCreateSnapshotAsync(string volumeId, bool force = false, string displayName = "None", string displayDescription = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateVolumeApiCall> PrepareCreateVolumeAsync(int size, string sourceVolumeId = null, string Description = null, string Name = null, string snapshotId = null, string volumeType = null, string imageRef = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<DeleteSnapshotApiCall> PrepareDeleteSnapshotAsync(string snapshotId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteVolumeApiCall> PrepareDeleteVolumeAsync(string volumeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DescribeVolumeTypeApiCall> PrepareDescribeVolumeTypeAsync(string volumeTypeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListSnapshotsApiCall> PrepareListSnapshotsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListVolumesApiCall> PrepareListVolumesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ShowSnapshotApiCall> PrepareShowSnapshotAsync(string snapshotId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ShowVolumeApiCall> PrepareShowVolumeAsync(string volumeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WaitForSnapshotAvailableApiCall> PrepareWaitForSnapshotAvailableAsync(string snapshotId, int refreshCount = 360, TimeSpan? refreshDelay = default(TimeSpan?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<WaitForSnapshotDeletedApiCall> PrepareWaitForSnapshotDeletedAsync(string snapshotId, int refreshCount = 180, TimeSpan? refreshDelay = default(TimeSpan?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<WaitForSnapshotStateApiCall> PrepareWaitForSnapshotStateAsync(string snapshotId, SnapshotState expectedState, SnapshotState[] errorStates, int refreshCount = 60, TimeSpan? refreshDelay = default(TimeSpan?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<CreateWaitForVolumeAvailableApiCall> PrepareWaitForVolumeAvailableAsync(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = default(TimeSpan?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<WaitForVolumeDeletedApiCall> PrepareWaitForVolumeDeletedAsync(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = default(TimeSpan?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<WaitForVolumeStateApiCall> PrepareWaitForVolumeStateAsync(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = default(TimeSpan?), CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Task<Uri> GetBaseUriAsyncImpl(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
