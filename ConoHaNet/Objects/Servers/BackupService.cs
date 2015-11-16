#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace ConoHaNet.Objects.Servers
{
    using Newtonsoft.Json;
    using System;

    public class BackupService : ExtensibleJsonObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("instance_id")]
        public string InstanceId { get; set; }

        [JsonProperty("volume_id")]
        public string VolumeId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("backupruns")]
        public BackupRun[] BackupRuns { get; set; }
    }

    public class BackupRun : ExtensibleJsonObject
    {
        [JsonProperty("backuprun_id")]
        public string BackupRunId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("volume_id")]
        public string VolumeId { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ListBackupServicesResponse
    {
        [JsonProperty("backup", DefaultValueHandling = DefaultValueHandling.Include)]
        public BackupService[] BackupServices { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GetBackupServiceResponse
    {
        [JsonProperty("backup", DefaultValueHandling = DefaultValueHandling.Include)]
        public BackupService BackupServices { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    internal class CreateImageFromBackupRunRequest
    {
        [JsonProperty("createImage")]
        public CreateImageFromBackupRunRequestDetails Details { get; private set; }

        public CreateImageFromBackupRunRequest(string backupRunId, string imageName = null)
        {
            Details = new CreateImageFromBackupRunRequestDetails(backupRunId, imageName);
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class CreateImageFromBackupRunRequestDetails
        {
            [JsonProperty("backuprun_id")]
            public string BackupRunId { get; private set; }

            [JsonProperty("image_name")]
            public string ImageName { get; private set; }

            public CreateImageFromBackupRunRequestDetails(string backupRunId, string imageName = null)
            {
                BackupRunId = backupRunId;
                ImageName = imageName;
            }
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member