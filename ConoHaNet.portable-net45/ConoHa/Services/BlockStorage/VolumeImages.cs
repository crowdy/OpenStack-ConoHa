#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.BlockStorage
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;


    [JsonObject(MemberSerialization.OptIn)]
    public class CreateGlanceImageFromVolumeRequest
    {
        [JsonProperty("os-volume_upload_image")]
        public VolumeUploadImage VolumeUploadImage { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class CreateGlanceImageFromVolumeResponse
    {
        [JsonProperty("os-volume_upload_image")]

        public VolumeUploadImage VolumeUploadImage { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class VolumeUploadImage : ExtensibleJsonObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        [JsonProperty("volume_type")]
        public VolumeTypeDetails VolumeType { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("container_format")]
        public string ContainerFormat { get; set; }

        [JsonProperty("size")]
        public int? Size { get; set; }

        [JsonProperty("disk_format")]
        public string DiskFormat { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("display_description")]
        public string DisplayDescription { get; set; }

        [JsonProperty("image_name")]
        public string ImageName { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class VolumeTypeDetails : ExtensibleJsonObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("qos_specs_id")]
        public string QosSpecsId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public object DeletedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    /// <summary>
    /// This models the JSON response used for the List Volume Summaries request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/List_Summary_Volumes.html">List Volume Summaries (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListVolumeResponse
    {
        /// <summary>
        /// Gets a collection of information about the volumes.
        /// </summary>
        [JsonProperty("volumes")]
        public Volume[] Volumes { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the List Volume Types request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Volume_List_Types.html">List Volume Types (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListVolumeTypeResponse
    {
        /// <summary>
        /// Gets a collection of information about the volume types.
        /// </summary>
        [JsonProperty("volume_types")]
        public VolumeType[] VolumeTypes { get; private set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member