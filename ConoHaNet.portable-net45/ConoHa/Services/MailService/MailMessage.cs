#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.MailService
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class MailMessageHeader : ExtensibleJsonObject
    {
        [JsonProperty("message_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class MailMessage : ExtensibleJsonObject
    {
        [JsonProperty("message_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Attachment : ExtensibleJsonObject
    {
        [JsonProperty("attachment_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("attachment_file_name")]
        public string FileName { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("attachment_file")]
        public object File { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetAttachmentResponse : ExtensibleJsonObject
    {
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetMailMessageResponse : ExtensibleJsonObject
    {
        [JsonProperty("message")]
        public MailMessage MailMessage { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListMailMessageHeadersResponse : ExtensibleJsonObject
    {
        [JsonProperty("messages")]
        public MailMessageHeader[] MailMessageHeaders { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member