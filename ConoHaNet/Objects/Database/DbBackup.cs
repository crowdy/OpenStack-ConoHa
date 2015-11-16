#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Database
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class DbBackup : ExtensibleJsonObject
    {
        [JsonProperty("backup_id", DefaultValueHandling = DefaultValueHandling.Include)]
        public string BackupId { get; set; }

        [JsonProperty("backup_name", DefaultValueHandling = DefaultValueHandling.Include)]
        public string Name { get; set; }

        [JsonProperty("create_date", DefaultValueHandling = DefaultValueHandling.Include)]
        public DateTimeOffset CreatedDate { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListDbBackupsResponse
    {
        [JsonProperty("backup", DefaultValueHandling = DefaultValueHandling.Include)]
        public DbBackup[] Backups { get; set; }

        [JsonProperty("total_count", DefaultValueHandling = DefaultValueHandling.Include)]
        public int TotalCount { get; set; }

        [JsonProperty("current_count", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Length { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class SetDbServiceBackupRequest
    {
        [JsonProperty("backup")]
        public SetDbServiceBackupDetails Details { get; private set; }

        public SetDbServiceBackupRequest(string status)
        {
            Details = new SetDbServiceBackupDetails(status);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SetDbServiceBackupDetails
        {
            [JsonProperty("status")]
            public string Status { get; private set; }

            public SetDbServiceBackupDetails(string status)
            {
                Status = status;
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class RestoreDatabaseRequest
    {
        [JsonProperty("restore")]
        public RestoreDatabaseRequestDetails Details { get; private set; }

        public RestoreDatabaseRequest(string backupId)
        {
            Details = new RestoreDatabaseRequestDetails(backupId);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class RestoreDatabaseRequestDetails
        {
            [JsonProperty("backup_id")]
            public string BackupId { get; private set; }

            public RestoreDatabaseRequestDetails(string backupId)
            {
                BackupId = backupId;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member