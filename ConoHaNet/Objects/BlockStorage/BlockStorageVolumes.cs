namespace ConoHaNet.Objects.BlockStorage
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON request used for the Create Volume request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Create_Volume.html">Create Volume (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateCloudBlockStorageVolumeRequest
    {
        /// <summary>
        /// Gets additional details about the Create Volume request.
        /// </summary>
        [JsonProperty("volume")]
        public CreateCloudBlockStorageVolumeDetails CreateCloudBlockStorageVolumeDetails { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCloudBlockStorageVolumeRequest"/>
        /// class with the specified details.
        /// </summary>
        /// <param name="details">The details of the request.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="details"/> is <see langword="null"/>.</exception>
        public CreateCloudBlockStorageVolumeRequest(CreateCloudBlockStorageVolumeDetails details)
        {
            if (details == null)
                throw new ArgumentNullException("details");

            CreateCloudBlockStorageVolumeDetails = details;
        }
    }

    /// <summary>
    /// This models the JSON body containing details for the Create Volume request.
    /// </summary>
    /// <seealso cref="CreateCloudBlockStorageVolumeRequest"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Create_Volume.html">Create Volume (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateCloudBlockStorageVolumeDetails
    {
        /// <summary>
        /// Gets the size of the volume in GB.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; private set; }

        /// <summary>
        /// Get Source Volume Id
        /// </summary>
        [JsonProperty("source_volid")]
        public string SourceVolumeId { get; private set; }

        /// <summary>
        /// Gets the display description of the volume.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// Gets the display name of the volume.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the ID of the snapshot to create the volume from, if any.
        /// </summary>
        /// <value>The ID of the snapshot to create the volume from, or <see langword="null"/> if the volume is not created from a snapshot.</value>
        /// <seealso cref="Snapshot.Id"/>
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; private set; }

        /// <summary>
        /// Gets the ID of the type of volume to create.
        /// </summary>
        /// <seealso cref="VolumeType.Id"/>
        [JsonProperty("volume_type")]
        public string VolumeType { get; private set; }

        /// <summary>
        /// Gets the ID of the type of volume to create.
        /// </summary>
        /// <seealso cref="VolumeType.Id"/>
        [JsonProperty("imageRef")]
        public string ImageRef { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bootable")]
        public bool Bootable { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata Metadata { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCloudBlockStorageVolumeDetails"/> class.
        /// </summary>
        /// <param name="size">The size of the volume in GB.</param>
        /// <param name="sourceVolumeId"></param>
        /// <param name="description">A description of the volume.</param>
        /// <param name="name">The name of the volume.</param>
        /// <param name="snapshotId">The snapshot from which to create a volume. The value should be <see langword="null"/> or obtained from <see cref="Snapshot.Id">Snapshot.Id</see>.</param>
        /// <param name="volumeType">The type of volume to create. If not defined, then the default is used. The value should be <see langword="null"/> or obtained from <see cref="VolumeType.Id">VolumeType.Id</see>.</param>
        /// <param name="imageRef"></param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="size"/> is less than or equal to zero.</exception>
        public CreateCloudBlockStorageVolumeDetails(int size, string sourceVolumeId, string description, string name, string snapshotId, string volumeType, string imageRef)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("size");

            SourceVolumeId = sourceVolumeId;
            Size = size;
            Description = description;
            Name = name;
            SnapshotId = snapshotId;
            VolumeType = volumeType;
            ImageRef = imageRef;
        }
    }

    /// <summary>
    /// This models the JSON response used for the Create Volume and Show Volume requests.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Create_Volume.html">Create Volume (OpenStack Block Storage Service API Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Show_Volume.html">Show Volume (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class GetCloudBlockStorageVolumeResponse
    {
        /// <summary>
        /// Gets additional information about the volume.
        /// </summary>
        [JsonProperty("volume")]
        public Volume Volume { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Show Volume Type request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Volume_Show_Type.html">Show Volume Type (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class GetCloudBlockStorageVolumeTypeResponse
    {
        /// <summary>
        /// Gets additional information about the volume type.
        /// </summary>
        [JsonProperty("volume_type")]
        public VolumeType VolumeType { get; private set; }
    }

}