#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using BlockStorage;
    using Providers;

    /// <summary>
    /// Represents a volume in a block storage provider.
    /// </summary>
    /// <seealso cref="IBlockStorageProvider"/>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class Volume : ExtensibleJsonObject
    {
        /// <summary>
        /// Gets the unique identifier for the volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the "display_name" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        /// <remarks>
        /// <note>
        /// This property is a Rackspace-specific extension to the OpenStack Block Storage Service.
        /// </note>
        /// </remarks>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the "display_description" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        /// <remarks>
        /// <note>
        /// This property is a Rackspace-specific extension to the OpenStack Block Storage Service.
        /// </note>
        /// </remarks>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// Gets the "size" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; private set; }

        /// <summary>
        /// Gets the "volume_type" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("volume_type")]
        public string VolumeType { get; private set; }

        /// <summary>
        /// Gets the "snapshot_id" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        /// <seealso cref="Snapshot.Id"/>
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; private set; }

        /// <summary>
        /// Gets the "attachments" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("attachments")]
        public Dictionary<string, string>[] Attachments { get; private set; }

        /// <summary>
        /// Gets the "status" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("status")]
        public VolumeState Status
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the "availability_zone" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("availability_zone")]
        public string AvailabilityZone { get; private set; }

        /// <summary>
        /// Gets the "created_at" property of this volume.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; private set; }

        [JsonProperty("volume_image_metadata")]
        public Metadata VolumeImageMetadata { get; private set; }

        [JsonProperty("os-vol-tenant-attr:tenant_id")]
        public string TenantId { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member