#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Services.MailService
{
    using Newtonsoft.Json;
    using OpenStack.ObjectModel;
    using System;
    using System.Collections.Generic;

    [JsonObject(MemberSerialization.OptIn)]
    public class MailService : ExtensibleJsonObject
    {
        [JsonProperty("service_id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("service_name")]
        public string Name { get; set; }

        [JsonProperty("create_date")]
        public DateTimeOffset CreateDate { get; set; }

        [JsonProperty("default_domain")]
        public string DefaultDomain { get; set; }

        [JsonProperty("smtp")]
        public string SMTP { get; set; }

        [JsonProperty("pop")]
        public string POP { get; set; }

        [JsonProperty("imap")]
        public string IMAP { get; set; }

        [JsonProperty("mx")]
        public string MX { get; set; }

        [JsonProperty("quota")]
        public int Quota { get; set; }

        [JsonProperty("total_usage")]
        public float TotalUsage { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("backup")]
        public string Backup { get; set; }

        [JsonProperty("backup_imap")]
        public Dictionary<string, string> BackupImapHostnames { get; set; }
    }

    public class ListMailServicesResponse
    {
        [JsonProperty("services")]
        public MailService[] Services { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("current_count")]
        public int Length { get; set; }
    }

    public class GetMailServiceResponse
    {
        [JsonProperty("service")]
        public MailService Service { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class SetMailServiceStatusRequest
    {
        [JsonProperty("service")]
        public SetMailServiceStatusDetails Details { get; private set; }

        public SetMailServiceStatusRequest(string status)
        {
            Details = new SetMailServiceStatusDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SetMailServiceStatusDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public SetMailServiceStatusDetails(string status)
            {
                Status = status;
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class SetMailServiceBackupRequest
    {
        [JsonProperty("backup")]
        public SetMailServiceBackupDetails Details { get; private set; }

        public SetMailServiceBackupRequest(string status)
        {
            Details = new SetMailServiceBackupDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SetMailServiceBackupDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public SetMailServiceBackupDetails(string status)
            {
                Status = status;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member