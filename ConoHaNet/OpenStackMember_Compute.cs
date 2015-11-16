namespace ConoHaNet
{
    using Objects;
    using ConoHaNet.Objects.Networks;
    using ConoHaNet.Objects.Servers;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {
        private CloudServersProvider _ServersProvider = null;

        /// <inheritdoc/>
        public CloudServersProvider ServersProvider
        {
            get
            {
                if (_ServersProvider == null)
                {
                    _ServersProvider = new CloudServersProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudServersProvider created.");
                }
                return _ServersProvider;
            }
        }


        #region "flavors"

        /// <inheritdoc/>
        public IEnumerable<Flavor> ListFlavors(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null, string region = null)
        {
            return ServersProvider.ListFlavors(minDiskInGB, minRamInMB, markerId, limit, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<FlavorDetails> ListFlavorsDetails(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null, string region = null)
        {
            return ServersProvider.ListFlavorsWithDetails(minDiskInGB, minRamInMB, markerId, limit, region, Identity);
        }

        /// <inheritdoc/>
        public FlavorDetails GetFlavor(string flavorid, string region = null)
        {
            return ServersProvider.GetFlavor(flavorid, region, Identity);
        }

        #endregion


        #region "servers"

        /// <inheritdoc/>
        public IEnumerable<SimpleServer> ListServers(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null, string region = null)
        {
            return ServersProvider.ListServers(imageId, flavorId, name, status, markerId, limit, changesSince, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Server> ListServersDetails(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null, string region = null)
        {
            return ServersProvider.ListServersWithDetails(imageId, flavorId, name, status, markerId, limit, changesSince, region, Identity);
        }

        /// <inheritdoc/>
        public Server GetServer(string serverId, string region = null)
        {
            return ServersProvider.GetDetails(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public NewServer CreateServer(string cloudServerName, string imageId, string flavor, string adminPass, string keyname = null, string nametag = null, string[] securityGroupNames = null, string[] attachVolumeIds = null, DiskConfiguration diskConfig = null, Metadata metadata = null, Personality[] personality = null, bool attachToServiceNetwork = false, bool attachToPublicNetwork = false, IEnumerable<string> networks = null, string region = null)
        {
            if (metadata == null) { metadata = new Metadata(); }

            metadata.Add("instance_name_tag", nametag ?? string.Empty);

            return ServersProvider.CreateServer(cloudServerName, imageId, flavor, adminPass, keyname, securityGroupNames, attachVolumeIds, diskConfig, metadata, personality, attachToServiceNetwork, attachToPublicNetwork, networks, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteServer(string serverId, string region = null)
        {
            return ServersProvider.DeleteServer(serverId, region, Identity);
        }

        /// <inheritdoc/>
        [Obsolete(message: "change server name is not allowed by ConoHa api specification.", error:true)]
        public bool ChangeServerName(string serverId, string name, string region = null)
        {
            return ServersProvider.UpdateServer(serverId, name);
        }

        /// <inheritdoc/>
        public bool StartServer(string serverId, string region = null)
        {
            return ServersProvider.StartServer(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public bool RestartServer(string serverId, RebootType rebootType, string region = null)
        {
            return ServersProvider.RebootServer(serverId, rebootType ?? RebootType.Soft, region, Identity);
        }

        /// <inheritdoc/>
        public bool StopServer(string serverId, string region = null)
        {
            return ServersProvider.StopServer(serverId, true, region, Identity);
        }

        #region VM強制停止

        /// <inheritdoc/>
        public bool ShutdownServer(string serverId, string region = null)
        {
            return ServersProvider.StopServer(serverId, false, region, Identity);
        }

        #endregion

        /// <inheritdoc/>
        public Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null, string region = null)
        {
            return ServersProvider.RebuildServer(serverId, imageRef, adminPassword, keyName, region, Identity);
        }

        /// <inheritdoc/>
        public bool ResizeServer(string serverId, string flavorid, DiskConfiguration diskconfig, string region = null)
        {
            return ServersProvider.ResizeServer(serverId, flavorid, diskconfig, region, Identity);
        }

        /// <inheritdoc/>
        public bool ConfirmServerResized(string serverId, string region = null)
        {
            return ServersProvider.ConfirmServerResize(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public bool RevertResizeServer(string serverId, string region = null)
        {
            return ServersProvider.RevertServerResize(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public VncConsole GetVncConsole(string serverId, string region = null)
        {
            return ServersProvider.GetVncConsole(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public VncConsole GetNovaConsole(string serverId, string region = null)
        {
            return ServersProvider.GetNovaConsole(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public VncConsole GetHttpConsole(string serverId, string region = null)
        {
            return ServersProvider.GetHttpConsole(serverId, region, Identity);
        }

        /// <inheritdoc/>
        [Obsolete(message: "this function is not surpported by design", error: true)]
        public bool AttachSecurityGroup(string serverId, string groupName, string region = null)
        {
            return ServersProvider.AddSecurityGroup(serverId, groupName, region, Identity);
        }

        /// <inheritdoc/>
        [Obsolete(message: "this function is not surpported by design", error: true)]
        public bool DetachSecurityGroup(string serverId, string groupName, string region = null)
        {
            return ServersProvider.RemoveSecurityGroup(serverId, groupName, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ServerSecurityGroup> ListServerSecurityGroups(string serverId, string region = null)
        {
            return ServersProvider.ListSecurityGroup(serverId, region, Identity);
        }

        #endregion

        #region "os-keypairs"

        /// <inheritdoc/>
        public IEnumerable<KeypairData> ListKeypairs(string region = null)
        {
            return ServersProvider.ListKeypair(region, Identity);
        }

        /// <inheritdoc/>
        public Keypair GetKeypair(string keyName, string region = null)
        {
            return ServersProvider.GetKeypair(keyName, region, Identity);
        }

        /// <inheritdoc/>
        public Keypair AddKeypair(string name, string publickey = null, string region = null)
        {
            return ServersProvider.AddKeypair(name, publickey, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteKeypair(string name, string region = null)
        {
            return ServersProvider.DeleteKeypair(name, region, Identity);
        }

        #endregion


        #region "images"

        /// <inheritdoc/>
        public IEnumerable<SimpleServerImage> ListImages(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null, string region = null)
        {
            return ServersProvider.ListImages(server, imageName, imageStatus, changesSince, markerId, limit, imageType, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ServerImage> ListImagesDetails(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null, string region = null)
        {
            return ServersProvider.ListImagesWithDetails(server, imageName, imageStatus, changesSince, markerId, limit, imageType, region, Identity);
        }

        /// <inheritdoc/>
        public ServerImage GetImage(string imageId, string region = null)
        {
            return ServersProvider.GetImage(imageId, region, Identity);
        }

        #endregion


        #region "os-volume_attachments"

        /// <inheritdoc/>
        public IEnumerable<ServerVolume> ListServerVolumes(string serverId, string region = null)
        {
            return ServersProvider.ListServerVolumes(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public ServerVolume GetServerVolume(string serverId, string volumeId, string region = null)
        {
            return ServersProvider.GetServerVolumeDetails(serverId, volumeId, region, Identity);
        }

        /// <inheritdoc/>
        public ServerVolume AttachVolume(string serverId, string volumeId, string devicePath = null, string region = null)
        {
            Server s = this.GetServer(serverId, region);
            return s.AttachVolume(volumeId, devicePath);
        }

        /// <inheritdoc/>
        public bool DetachVolume(string serverId, string volumeId, string region = null)
        {
            Server s = this.GetServer(serverId, region);
            return s.DetachVolume(volumeId);
        }

        #endregion


        #region "os-interface"

        /// <inheritdoc/>
        public IEnumerable<InterfaceAttachment> ListInterfaceAttachments(string serverId, string region = null)

        {
            return ServersProvider.ListInterfaceAttachments(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public InterfaceAttachment GetInterfaceAttachment(string serverId, string portId, string region = null)
        {
            return ServersProvider.GetInterfaceAttachment(serverId, portId, region, Identity);
        }

        /// <inheritdoc/>
        public InterfaceAttachment AddInterfaceAttachment(string serverId, string portId, string region = null)
        {
            return ServersProvider.AddInterfaceAttachment(serverId, portId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteInterfaceAttachment(string serverId, string portId, string region = null)
        {
            return ServersProvider.DeleteInterfaceAttachment(serverId, portId, region, Identity);
        }

        #endregion


        #region "backup_services"

        /// <inheritdoc/>
        public IEnumerable<BackupService> ListBackupServices(string region = null)
        {
            return ServersProvider.ListBackupServices(region, Identity);
        }

        /// <inheritdoc/>
        public BackupService GetBackupService(string backupId, string region = null)
        {
            return ServersProvider.GetBackupService(backupId, region, Identity);
        }

        /// <inheritdoc/>
        public BackupService AddBackupService(string InstanceId, string region = null)
        {
            return ServersProvider.AddBackupService(InstanceId, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteBackupService(string backupId, string region = null)
        {
            return ServersProvider.DeleteBackupService(backupId, region, Identity);
        }

        /// <inheritdoc/>
        public bool RestoreFromBackupRun(string backupId, string backupRunId, string region = null)
        {
            return ServersProvider.RestoreFromBackupRun(backupId, backupRunId, region, Identity);
        }

        /// <inheritdoc/>
        public bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null, string region = null)
        {
            return ServersProvider.CreateImageFromBackupRun(backupId, backupRunId, imageName, region, Identity);
        }

        #endregion

        #region "ips"

        /// <inheritdoc/>
        public ServerIps ListServerIps(string serverId, string region = null)
        {
            return ServersProvider.ListServerIps(serverId, region, Identity);
        }

        /// <inheritdoc/>
        public ServerAddresses ListAddresses(string serverId, string region = null)
        {
            return ServersProvider.ListAddresses(serverId, region, Identity);
        }

        #endregion

        #region "ConoHa"

        /// <inheritdoc/>
        public bool ChangeStorageController(string serverId, string hwDiskBus, string region = null)
        {
            return ServersProvider.ChangeStorageController(serverId, hwDiskBus, region, Identity);
        }

        /// <inheritdoc/>
        public bool ChangeNetworkAdapter(string serverId, string hwVifModel, string region = null)
        {
            return ServersProvider.ChangeNetworkAdapter(serverId, hwVifModel, region, Identity);
        }

        /// <inheritdoc/>
        public bool ChangeVideoDevice(string serverId, string hwVideoModel, string region = null)
        {
            return ServersProvider.ChangeVideoDevice(serverId, hwVideoModel, region, Identity);
        }

        /// <inheritdoc/>
        public bool ChangeVncKeymap(string serverId, string vncKeymap, string region = null)
        {
            return ServersProvider.ChangeVncKeymap(serverId, vncKeymap, region, Identity);
        }

        #endregion

        #region "Graph"

        /// <inheritdoc/>
        public string GetCPUGraph(string serverId, DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetCPUGraph(serverId, startDate_unixtime, endDate_unixtime, mode, region, Identity);
        }

        /// <inheritdoc/>
        public string GetDiskIOGraph(string serverId, string deviceName = null, DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetDiskIOGraph(serverId, deviceName, startDate_unixtime, endDate_unixtime, mode, region, Identity);
        }

        /// <inheritdoc/>
        public string GetNetworkGraph(string serverId, string portId, DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetNetworkGraph(serverId, portId, startDate_unixtime, endDate_unixtime, mode, region, Identity);
        }

        /// <inheritdoc/>
        public string GetSwiftRequestGraph(DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetSwiftRequestGraph(startDate_unixtime, endDate_unixtime, mode, region, Identity);
        }

        /// <inheritdoc/>
        public string GetSwiftSizeGraph(DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetSwiftSizeGraph(startDate_unixtime, endDate_unixtime, mode, region, Identity);
        }

        /// <inheritdoc/>
        public bool CreateGlanceImageFromInstance(string serverId, string imageName, string region = null)
        {
            return ServersProvider.CreateGlanceImageFromInstance(serverId, imageName, region, Identity);
        }

        #endregion
    }
}