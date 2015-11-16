namespace ConoHaNet.Objects.BlockStorage
{
    using System;
    using Newtonsoft.Json;
    using System.Globalization;
    using Servers;

    /// <summary>
    /// This models the JSON request used for the Create Snapshot request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Create_Snapshot.html">Create Snapshot (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateCloudBlockStorageSnapshotRequest
    {
        /// <summary>
        /// Gets additional details about the Create Snapshot request.
        /// </summary>
        [JsonProperty("snapshot")]
        public CreateCloudBlockStorageSnapshotDetails CreateCloudBlockStorageSnapshotDetails { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCloudBlockStorageSnapshotRequest"/>
        /// class with the specified details.
        /// </summary>
        /// <param name="details">The details of the request.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="details"/> is <see langword="null"/>.</exception>
        public CreateCloudBlockStorageSnapshotRequest(CreateCloudBlockStorageSnapshotDetails details)
        {
            if (details == null)
                throw new ArgumentNullException("details");

            CreateCloudBlockStorageSnapshotDetails = details;
        }
    }

    /// <summary>
    /// This models the JSON body containing details for the Create Snapshot request.
    /// </summary>
    /// <seealso cref="CreateCloudBlockStorageSnapshotRequest"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Create_Snapshot.html">Create Snapshot (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateCloudBlockStorageSnapshotDetails
    {
        /// <summary>
        /// Gets the ID of the volume to snapshot.
        /// </summary>
        [JsonProperty("volume_id")]
        public string VolumeId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether to create the snapshot even while the volume is attached to an active server.
        /// </summary>
        /// <value><see langword="true"/> to create the snapshot even if the server is running; otherwise, <see langword="false"/>.</value>
        [JsonProperty("force")]
        public bool Force { get; private set; }

        /// <summary>
        /// Gets the display name of the snapshot.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the display description of the snapshot.
        /// </summary>
        [JsonProperty("display_description")]
        public string DisplayDescription { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCloudBlockStorageSnapshotDetails"/>
        /// class with the specified volume ID, name, description, and value indicating whether or
        /// not to create the snapshot even if the volume is attached to an active server.
        /// </summary>
        /// <param name="volumeId">The ID of the volume to snapshot. The value should be obtained from <see cref="Volume.Id">Volume.Id</see>.</param>
        /// <param name="force"><see langword="true"/> to create the snapshot even if the volume is attached to an active server; otherwise, <see langword="false"/>.</param>
        /// <param name="displayName">Name of the snapshot.</param>
        /// <param name="displayDescription">Description of snapshot.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="volumeId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="volumeId"/> is empty.</exception>
        public CreateCloudBlockStorageSnapshotDetails(string volumeId, bool force, string displayName, string displayDescription)
        {
            if (volumeId == null)
                throw new ArgumentNullException("volumeId");
            if (string.IsNullOrEmpty(volumeId))
                throw new ArgumentException("volumeId cannot be empty");

            VolumeId = volumeId;
            Force = force;
            DisplayName = displayName;
            DisplayDescription = displayDescription;
        }
    }

    /// <summary>
    /// This models the JSON response used for the Create Snapshot and Show Snapshot requests.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Create_Snapshot.html">Create Snapshot (OpenStack Block Storage Service API Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/Show_Snapshot.html">Show Snapshot (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class GetCloudBlockStorageSnapshotResponse
    {
        /// <summary>
        /// Gets information about the snapshot.
        /// </summary>
        [JsonProperty("snapshot")]
        public Snapshot Snapshot { get; private set; }
    }

    /// <summary>
    /// Represents a unique identifier within the context of a cloud services provider.
    /// </summary>
    /// <typeparam name="T">The resource identifier type.</typeparam>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    public abstract class ResourceIdentifier<T> : IEquatable<T>
        where T : ResourceIdentifier<T>
    {
        /// <summary>
        /// This is the backing field for the <see cref="Value"/> property.
        /// </summary>
        private readonly string _id;

        /// <summary>
        /// Initialized a new instance of the <see cref="ResourceIdentifier{T}"/> class
        /// with the specified identifier.
        /// </summary>
        /// <param name="id">The resource identifier value.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="id"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="id"/> is empty.</exception>
        protected ResourceIdentifier(string id)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id cannot be empty");

            _id = id;
        }

        /// <summary>
        /// Determines whether two specified resource identifiers have the same value.
        /// </summary>
        /// <param name="left">The first resource identifier to compare, or <see langword="null"/>.</param>
        /// <param name="right">The second resource identifier to compare, or <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="left"/> is the same as the value of <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(ResourceIdentifier<T> left, ResourceIdentifier<T> right)
        {
            if (object.ReferenceEquals(left, null))
                return object.ReferenceEquals(right, null);
            else if (object.ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified resource identifiers have different values.
        /// </summary>
        /// <param name="left">The first resource identifier to compare, or <see langword="null"/>.</param>
        /// <param name="right">The second resource identifier to compare, or <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="left"/> is different from the value of <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(ResourceIdentifier<T> left, ResourceIdentifier<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Gets the value of this resource identifier.
        /// </summary>
        public string Value
        {
            get
            {
                return _id;
            }
        }

        /// <inheritdoc/>
        /// <remarks>
        /// The default implementation uses <see cref="StringComparer.Ordinal"/> to compare
        /// the <see cref="Value"/> property of two identifiers.
        ///
        /// <note type="implement">
        /// This method may be overridden to change the way unique identifiers are compared.
        /// </note>
        /// </remarks>
        public virtual bool Equals(T other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return StringComparer.Ordinal.Equals(_id, other._id);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as T);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// The default implementation uses <see cref="StringComparer.Ordinal"/> to calculate
        /// and return a hash code from the <see cref="Value"/> property.
        ///
        /// <note type="implement">
        /// This method may be overridden to change the way unique identifiers are compared.
        /// </note>
        /// </remarks>
        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(_id);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _id;
        }

        /// <summary>
        /// Provides support for serializing and deserializing <see cref="ResourceIdentifier{T}"/>
        /// objects to JSON string values.
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        public abstract class ConverterBase : SimpleStringJsonConverter<T>
        {
            /// <remarks>
            /// This method uses <see cref="Value"/> for serialization.
            /// </remarks>
            /// <inheritdoc/>
            protected override string ConvertToString(T obj)
            {
                return obj.Value;
            }

            /// <remarks>
            /// If <paramref name="str"/> is <see langword="null"/> or an empty string, this method returns <see langword="null"/>.
            /// Otherwise, this method uses <see cref="FromValue"/> for deserialization.
            /// </remarks>
            /// <inheritdoc/>
            protected override T ConvertToObject(string str)
            {
                if (string.IsNullOrEmpty(str))
                    return null;

                return FromValue(str);
            }

            /// <summary>
            /// Creates a resource identifier with the given value.
            /// </summary>
            /// <param name="id">The resource identifier value. This value is never <see langword="null"/> or empty.</param>
            /// <returns>An instance of <typeparamref name="T"/> corresponding representing the specified <paramref name="id"/>.</returns>
            protected abstract T FromValue(string id);
        }
    }


    /// <summary>
    /// Provides a base class for JSON converters that represent serialized objects
    /// as a simple string.
    /// </summary>
    /// <typeparam name="T">The deserialized object type.</typeparam>
    /// <threadsafety static="true" instance="false"/>
    public abstract class SimpleStringJsonConverter<T> : JsonConverter
    {
        /// <remarks>
        /// Serialization is performed by calling <see cref="ConvertToString"/> and writing
        /// the result as a string value.
        /// </remarks>
        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            if (!(value is T))
                throw new JsonSerializationException(string.Format(CultureInfo.InvariantCulture, "Unexpected type when converting to JSON. Expected {0}, found {1}.", typeof(T), value.GetType()));

            T entity = (T)value;
            serializer.Serialize(writer, ConvertToString(entity));
        }

        /// <remarks>
        /// Deserialization is performed by reading the raw value as a string and using
        /// <see cref="ConvertToObject"/> to convert it to an object of type
        /// <typeparamref name="T"/>.
        /// </remarks>
        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(T))
                throw new JsonSerializationException(string.Format(CultureInfo.InvariantCulture, "Expected target type {0}, found {1}.", typeof(T), objectType));

            string value = serializer.Deserialize<string>(reader);
            if (value == null)
                return null;

            return ConvertToObject(value);
        }

        /// <returns><see langword="true"/> if <paramref name="objectType"/> equals <typeparamref name="T"/>; otherwise, <see langword="false"/>.</returns>
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        /// <summary>
        /// Serializes an object of type <typeparamref name="T"/> to a string value.
        /// </summary>
        /// <remarks>
        /// The default implementation returns the result of calling <see cref="Object.ToString()"/>.
        /// </remarks>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A string representation of the object.</returns>
        protected virtual string ConvertToString(T obj)
        {
            return obj.ToString();
        }

        /// <summary>
        /// Deserializes a string value to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="str">The string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        protected abstract T ConvertToObject(string str);
    }

    /// <summary>
    /// This models the JSON response used for the List Snapshot Summaries request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-block-storage/2.0/content/List_Snapshots.html">List Snapshot Summaries (OpenStack Block Storage Service API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListSnapshotResponse
    {
        /// <summary>
        /// Gets a collection of information about the snapshots.
        /// </summary>
        [JsonProperty("snapshots")]
        public Snapshot[] Snapshots { get; private set; }
    }

}
