namespace ConoHaNet.Services.Compute
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using OpenStack.ObjectModel;

    /// <summary>
    /// This models the JSON description of a volume attachment.
    /// </summary>
    /// <remarks>
    /// <note>Volume attachments are a Rackspace-specific extension to the OpenStack Compute Service.</note>
    /// </remarks>
    /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/List_Volume_Attachments.html">List Volume Attachments (Rackspace Next Generation Cloud Servers Developer Guide - API v2)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class ServerVolume : ExtensibleJsonObject
    {
        /// <summary>
        /// Gets the "device" property associated with the volume attachment.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("device")]
        public string Device { get; private set; }

        /// <summary>
        /// Gets the "serverId" property associated with the volume attachment.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        /// <seealso cref="ServerBase.Id"/>
        [JsonProperty("serverId")]
        public string ServerId { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the volume attachment.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the "volumeId" property associated with the volume attachment.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        /// <seealso cref="Volume.Id"/>
        [JsonProperty("volumeId")]
        public string VolumeId { get; private set; }
    }


    /// <summary>
    /// This models the JSON request used for the Attach Volume to Server request.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Attach Volume to Server</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class AttachServerVolumeRequest
    {
        /// <summary>
        /// Gets additional information about the volume to attach.
        /// </summary>
        [JsonProperty("volumeAttachment")]
        public AttachServerVolumeData ServerVolumeData { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachServerVolumeRequest"/> class
        /// with the given device name and volume ID.
        /// </summary>
        /// <param name="device">
        /// The name of the device, such as <localUri>/dev/xvdb</localUri>. If the value
        /// is <see langword="null"/>, an automatically generated device name will be used.
        /// </param>
        /// <param name="volumeId">The volume ID. This is obtained from <see cref="Volume.Id"/>.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="volumeId"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="volumeId"/> is empty.</exception>
        public AttachServerVolumeRequest(string device, string volumeId)
        {
            if (volumeId == null)
                throw new ArgumentNullException("volumeId");
            if (string.IsNullOrEmpty(volumeId))
                throw new ArgumentException("volumeId cannot be empty");

            ServerVolumeData = new AttachServerVolumeData(device, volumeId);
        }

        /// <summary>
        /// This models the JSON body containing the details of the Attach Volume to Server request.
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        [JsonObject(MemberSerialization.OptIn)]
        public class AttachServerVolumeData
        {
            /// <summary>
            /// Gets the name of the device, such as <localUri>/dev/xvdb</localUri>.
            /// If the value is <see langword="null"/>, the server automatically assigns a device
            /// name.
            /// </summary>
            [JsonProperty("device")]
            public string Device { get; private set; }

            /// <summary>
            /// Gets the ID of the volume to attach to the server instance.
            /// </summary>
            [JsonProperty("volumeId")]
            public string VolumeId { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="AttachServerVolumeData"/> class
            /// with the given device name and volume ID.
            /// </summary>
            /// <param name="device">
            /// The name of the device, such as <localUri>/dev/xvdb</localUri>. If the value
            /// is <see langword="null"/>, an automatically generated device name will be used.
            /// </param>
            /// <param name="volumeId">The volume ID. This is obtained from <see cref="Volume.Id"/>.</param>
            /// <exception cref="ArgumentNullException">If <paramref name="volumeId"/> is <see langword="null"/>.</exception>
            /// <exception cref="ArgumentException">If <paramref name="volumeId"/> is empty.</exception>
            public AttachServerVolumeData(string device, string volumeId)
            {
                if (volumeId == null)
                    throw new ArgumentNullException("volumeId");
                if (string.IsNullOrEmpty(volumeId))
                    throw new ArgumentException("volumeId cannot be empty");

                Device = device;
                VolumeId = volumeId;
            }
        }
    }

    /// <summary>
    /// This models the JSON response used for the Attach Volume to Server and Get Volume Attachment Details requests.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Attach Volume to Server</seealso>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">Get Volume Attachment Details</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class ServerVolumeResponse
    {
        /// <summary>
        /// Gets information about the volume attachment.
        /// </summary>
        [JsonProperty("volumeAttachment")]
        public ServerVolume ServerVolume { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the List Volume Attachments request.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">List Volume Attachments</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class ServerVolumeListResponse
    {
        /// <summary>
        /// Gets a collection of information about the volume attachments.
        /// </summary>
        [JsonProperty("volumeAttachments")]
        public IEnumerable<ServerVolume> ServerVolumes { get; private set; }
    }
}
