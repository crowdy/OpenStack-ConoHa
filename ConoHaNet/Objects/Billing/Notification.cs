#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Billing
{
    using System;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class Notification : ExtensibleJsonObject
    {

        public class ItemFeaturesType
        {
        }

        /// <summary>
        /// Gets the "notification_code" property of this information.
        /// </summary>
        [JsonProperty("notification_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int NotificationCode { get; private set; }

        /// <summary>
        /// Gets the "language_name" property of this information.
        /// </summary>
        [JsonProperty("language_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LanguageName { get; private set; }

        /// <summary>
        /// Gets the "title" property of this information.
        /// </summary>
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; private set; }

        /// <summary>
        /// Gets the "type" property of this information.
        /// </summary>
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the "contents" property of this information.
        /// </summary>
        [JsonProperty("contents", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Contents { get; private set; }

        /// <summary>
        /// Gets the "distribution_method" property of this information.
        /// </summary>
        [JsonProperty("distribution_method", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DistributionMethod { get; private set; }

        /// <summary>
        /// Gets the "page_name" property of this information.
        /// </summary>
        [JsonProperty("page_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PageName { get; private set; }

        /// <summary>
        /// Gets the "read_status" property of this information.
        /// </summary>
        [JsonProperty("read_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReadStatus { get; private set; }

        /// <summary>
        /// Gets the "created_date" property of this information.
        /// </summary>
        [JsonProperty("created_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Gets the "created_by" property of this information.
        /// </summary>
        [JsonProperty("created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; private set; }

        /// <summary>
        /// Gets the "last_updated_date" property of this information.
        /// </summary>
        [JsonProperty("last_updated_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime LastUpdatedDate { get; private set; }

        /// <summary>
        /// Gets the "last_updated_by" property of this information.
        /// </summary>
        [JsonProperty("last_updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LastUpdatedBy { get; private set; }

    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <summary>
    /// This models the basic JSON description of a Product.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ListNotificationsResponse
    {
        [JsonProperty("notifications", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Notification[] Notifications { get; private set; }

        [JsonProperty("count_unread", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int CountUnread { get; private set; }

        [JsonProperty("count_subject_read", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int CountSubjectRead { get; private set; }

        [JsonProperty("count_body_read", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int CountBodyRead { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Create Server request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/CreateServers.html">Create Server (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetNotificationResponse
    {
        /// <summary>
        /// Gets information about the created server.
        /// </summary>
        [JsonProperty("notification", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Notification Notification { get; private set; }

    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member