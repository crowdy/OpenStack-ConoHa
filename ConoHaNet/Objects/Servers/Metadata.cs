namespace ConoHaNet.Objects.Servers
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON response used for the Get Metadata Item request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Get_Metadata_Item-d1e5507.html">Get Metadata Item (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class MetadataItemResponse
    {
        /// <summary>
        /// Gets information about the metadata item. The returned <see cref="Metadata"/> object
        /// will only have one item, containing the key and value for the metadata item.
        /// </summary>
        [JsonProperty("meta")]
        public Metadata Metadata { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Set Metadata and Update Metadata requests.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Create_or_Replace_Metadata-d1e5358.html">Set Metadata (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Update_Metadata-d1e5208.html">Update Metadata (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateMetadataRequest
    {
        /// <summary>
        /// Gets the metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata Metadata { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMetadataRequest"/> class
        /// with the given metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="metadata"/> is <see langword="null"/>.</exception>
        public UpdateMetadataRequest(Metadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");

            Metadata = metadata;
        }
    }

    /// <summary>
    /// This models the JSON response used for the List Metadata request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/List_Metadata-d1e5089.html">List Metadata (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class MetaDataResponse
    {
        /// <summary>
        /// Gets the metadata information.
        /// </summary>
        [JsonProperty("metadata")]
        public Metadata Metadata { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Set Metadata Item request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Create_or_Update_a_Metadata_Item-d1e5633.html">Set Metadata Item (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateMetadataItemRequest
    {
        /// <summary>
        /// Gets the metadata item to associate with the server or image.
        /// </summary>
        /// <remarks>
        /// The value is never <see langword="null"/> and always contains exactly one entry.
        /// </remarks>
        [JsonProperty("meta")]
        public Metadata Metadata { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMetadataItemRequest"/>
        /// class with the specified key and value.
        /// </summary>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The new value for the metadata item.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="key"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="value"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="key"/> is empty.</exception>
        public UpdateMetadataItemRequest(string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null)
                throw new ArgumentNullException("value");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("key cannot be empty");

            Metadata = new Metadata() { { key, value } };
        }
    }
}
