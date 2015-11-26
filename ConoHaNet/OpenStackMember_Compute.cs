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
        public IEnumerable<Flavor> ListFlavors(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null)
        {
            return ServersProvider.ListFlavors(minDiskInGB, minRamInMB, markerId, limit, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<FlavorDetails> ListFlavorsDetails(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null)
        {
            return ServersProvider.ListFlavorsWithDetails(minDiskInGB, minRamInMB, markerId, limit, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public FlavorDetails GetFlavor(string flavorid)
        {
            return ServersProvider.GetFlavor(flavorid, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "servers"

        /// <inheritdoc/>
        public IEnumerable<SimpleServer> ListServers(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null)
        {
            return ServersProvider.ListServers(imageId, flavorId, name, status, markerId, limit, changesSince, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Server> ListServersDetails(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null)
        {
            return ServersProvider.ListServersWithDetails(imageId, flavorId, name, status, markerId, limit, changesSince, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Server GetServer(string serverId)
        {
            return ServersProvider.GetDetails(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public NewServer CreateServer(string cloudServerName, string imageId, string flavor, string adminPass, string keyname = null, string nametag = null, string[] securityGroupNames = null, string[] attachVolumeIds = null, DiskConfiguration diskConfig = null, Metadata metadata = null, Personality[] personality = null, bool attachToServiceNetwork = false, bool attachToPublicNetwork = false, IEnumerable<string> networks = null)
        {
            if (metadata == null) { metadata = new Metadata(); }

            metadata.Add("instance_name_tag", nametag ?? string.Empty);

            return ServersProvider.CreateServer(cloudServerName, imageId, flavor, adminPass, keyname, securityGroupNames, attachVolumeIds, diskConfig, metadata, personality, attachToServiceNetwork, attachToPublicNetwork, networks, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteServer(string serverId)
        {
            return ServersProvider.DeleteServer(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        [Obsolete(message: "change server name is not allowed by ConoHa api specification.", error:true)]
        public bool ChangeServerName(string serverId, string name)
        {
            return ServersProvider.UpdateServer(serverId, name);
        }

        /// <inheritdoc/>
        public bool StartServer(string serverId)
        {
            return ServersProvider.StartServer(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool RestartServer(string serverId, RebootType rebootType)
        {
            return ServersProvider.RebootServer(serverId, rebootType ?? RebootType.Soft, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool StopServer(string serverId)
        {
            return ServersProvider.StopServer(serverId, true, this.DefaultRegion, this.Identity);
        }

        #region VM強制停止

        /// <inheritdoc/>
        public bool ShutdownServer(string serverId)
        {
            return ServersProvider.StopServer(serverId, false, this.DefaultRegion, this.Identity);
        }

        #endregion

        /// <inheritdoc/>
        public Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null)
        {
            return ServersProvider.RebuildServer(serverId, imageRef, adminPassword, keyName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ResizeServer(string serverId, string flavorid, DiskConfiguration diskconfig)
        {
            return ServersProvider.ResizeServer(serverId, flavorid, diskconfig, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ConfirmServerResized(string serverId)
        {
            return ServersProvider.ConfirmServerResize(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool RevertResizeServer(string serverId)
        {
            return ServersProvider.RevertServerResize(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VncConsole GetVncConsole(string serverId)
        {
            return ServersProvider.GetVncConsole(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VncConsole GetNovaConsole(string serverId)
        {
            return ServersProvider.GetNovaConsole(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public VncConsole GetHttpConsole(string serverId)
        {
            return ServersProvider.GetHttpConsole(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        [Obsolete(message: "this function is not surpported by design", error: true)]
        public bool AttachSecurityGroup(string serverId, string groupName)
        {
            return ServersProvider.AddSecurityGroup(serverId, groupName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        [Obsolete(message: "this function is not surpported by design", error: true)]
        public bool DetachSecurityGroup(string serverId, string groupName)
        {
            return ServersProvider.RemoveSecurityGroup(serverId, groupName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ServerSecurityGroup> ListServerSecurityGroups(string serverId)
        {
            return ServersProvider.ListSecurityGroup(serverId, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region "os-keypairs"

        /// <inheritdoc/>
        public IEnumerable<KeypairData> ListKeypairs()
        {
            return ServersProvider.ListKeypair(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Keypair GetKeypair(string keyName)
        {
            return ServersProvider.GetKeypair(keyName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Keypair AddKeypair(string name, string publickey = null)
        {
            return ServersProvider.AddKeypair(name, publickey, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteKeypair(string name)
        {
            return ServersProvider.DeleteKeypair(name, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "images"

        /// <inheritdoc/>
        public IEnumerable<SimpleServerImage> ListImages(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null)
        {
            return ServersProvider.ListImages(server, imageName, imageStatus, changesSince, markerId, limit, imageType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<ServerImage> ListImagesDetails(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null)
        {
            return ServersProvider.ListImagesWithDetails(server, imageName, imageStatus, changesSince, markerId, limit, imageType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public ServerImage GetImage(string imageId)
        {
            return ServersProvider.GetImage(imageId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "os-volume_attachments"

        /// <inheritdoc/>
        public IEnumerable<ServerVolume> ListServerVolumes(string serverId)
        {
            return ServersProvider.ListServerVolumes(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public ServerVolume GetServerVolume(string serverId, string volumeId)
        {
            return ServersProvider.GetServerVolumeDetails(serverId, volumeId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public ServerVolume AttachVolume(string serverId, string volumeId, string devicePath = null)
        {
            Server s = this.GetServer(serverId);
            return s.AttachVolume(volumeId, devicePath);
        }

        /// <inheritdoc/>
        public bool DetachVolume(string serverId, string volumeId)
        {
            Server s = this.GetServer(serverId);
            return s.DetachVolume(volumeId);
        }

        #endregion


        #region "os-interface"

        /// <inheritdoc/>
        public IEnumerable<InterfaceAttachment> ListInterfaceAttachments(string serverId)

        {
            return ServersProvider.ListInterfaceAttachments(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public InterfaceAttachment GetInterfaceAttachment(string serverId, string portId)
        {
            return ServersProvider.GetInterfaceAttachment(serverId, portId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public InterfaceAttachment AddInterfaceAttachment(string serverId, string portId)
        {
            return ServersProvider.AddInterfaceAttachment(serverId, portId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteInterfaceAttachment(string serverId, string portId)
        {
            return ServersProvider.DeleteInterfaceAttachment(serverId, portId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region "backup_services"

        /// <inheritdoc/>
        public IEnumerable<BackupService> ListBackupServices()
        {
            return ServersProvider.ListBackupServices(this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public BackupService GetBackupService(string backupId)
        {
            return ServersProvider.GetBackupService(backupId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public BackupService AddBackupService(string InstanceId)
        {
            return ServersProvider.AddBackupService(InstanceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteBackupService(string backupId)
        {
            return ServersProvider.DeleteBackupService(backupId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool RestoreFromBackupRun(string backupId, string backupRunId)
        {
            return ServersProvider.RestoreFromBackupRun(backupId, backupRunId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null)
        {
            return ServersProvider.CreateImageFromBackupRun(backupId, backupRunId, imageName, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region "ips"

        /// <inheritdoc/>
        public ServerIps ListServerIps(string serverId)
        {
            return ServersProvider.ListServerIps(serverId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public ServerAddresses ListAddresses(string serverId)
        {
            return ServersProvider.ListAddresses(serverId, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region "ConoHa"

        /// <inheritdoc/>
        public bool ChangeStorageController(string serverId, string hwDiskBus)
        {
            return ServersProvider.ChangeStorageController(serverId, hwDiskBus, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ChangeNetworkAdapter(string serverId, string hwVifModel)
        {
            return ServersProvider.ChangeNetworkAdapter(serverId, hwVifModel, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ChangeVideoDevice(string serverId, string hwVideoModel)
        {
            return ServersProvider.ChangeVideoDevice(serverId, hwVideoModel, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool ChangeVncKeymap(string serverId, string vncKeymap)
        {
            return ServersProvider.ChangeVncKeymap(serverId, vncKeymap, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region "Graph"

        /// <inheritdoc/>
        public string GetCPUGraph(string serverId, DateTime? startDate = null, DateTime? endDate = null, string mode = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetCPUGraph(serverId, startDate_unixtime, endDate_unixtime, mode, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string GetDiskIOGraph(string serverId, string deviceName = null, DateTime? startDate = null, DateTime? endDate = null, string mode = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetDiskIOGraph(serverId, deviceName, startDate_unixtime, endDate_unixtime, mode, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string GetNetworkGraph(string serverId, string portId, DateTime? startDate = null, DateTime? endDate = null, string mode = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetNetworkGraph(serverId, portId, startDate_unixtime, endDate_unixtime, mode, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string GetSwiftRequestGraph(DateTime? startDate = null, DateTime? endDate = null, string mode = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetSwiftRequestGraph(startDate_unixtime, endDate_unixtime, mode, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public string GetSwiftSizeGraph(DateTime? startDate = null, DateTime? endDate = null, string mode = null)
        {
            string startDate_unixtime = (startDate == null) ? string.Empty : toUnixTime((DateTime)startDate);
            string endDate_unixtime = (endDate == null) ? string.Empty : toUnixTime((DateTime)endDate);

            return ServersProvider.GetSwiftSizeGraph(startDate_unixtime, endDate_unixtime, mode, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool CreateGlanceImageFromInstance(string serverId, string imageName)
        {
            return ServersProvider.CreateGlanceImageFromInstance(serverId, imageName, this.DefaultRegion, this.Identity);
        }

        #endregion
    }
}