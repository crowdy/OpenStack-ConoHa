namespace ConoHaNet
{
    using Objects.Images;
    using Objects.Networks;
    using Objects.Servers;
    using Objects.Database;
    using Objects.Dns;
    using Objects.Mails;

    using JSIStudios.SimpleRESTServices.Client;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Providers;
    using Objects.Billing;
    using Objects.Identity;
    using Objects.Volumes;
    using System.Collections.ObjectModel;
    using Objects;
    using Objects.BlockStorage;
    using Objects.File;

    /// <summary>
    /// Provides functionality to OpenStackMember.
    /// </summary>
    public interface IOpenStackMember
    {
        // constructor
        /*
        OpenstackMember(string username, string password, string tenantId= null, string defaultregion= null);
	    OpenstackMember(string tokenid, string defaultregion= null);
        */

        /// <summary>
        /// Gets the CloudIdentity
        /// </summary>
        CloudIdentity Identity { get; }

        /// <summary>
        /// Gets the CloudIdentityProvider
        /// </summary>
        CloudIdentityProvider IdentityProvider { get; }

        /// <summary>
        /// Gets the CloudServersProvider
        /// </summary>
        CloudServersProvider ServersProvider { get; }

        /// <summary>
        /// Gets the CloudNetworksProvider
        /// </summary>
        CloudNetworksProvider NetworksProvider { get; }

        /// <summary>
        /// Gets the CloudBlockStorageProvider
        /// </summary>
        CloudBlockStorageProvider BlockStorageProvider { get; }

        /// <summary>
        /// Gets the CloudAccountServiceProvider
        /// </summary>
        CloudAccountServiceProvider AccountServiceProvider { get; }

        /// <summary>
        /// Gets the CloudImagesProvider
        /// </summary>
        CloudImagesProvider ImagesProvider { get; }

        /// <summary>
        /// Gets the CloudDatabaseProvider
        /// </summary>
        CloudDatabaseProvider DatabaseProvider { get; }

        /// <summary>
        /// Gets the CloudDnsProvider
        /// </summary>
        CloudDnsProvider DnsProvider { get; }

        /// <summary>
        /// Gets the CloudMailServiceProvider
        /// </summary>
        CloudMailServiceProvider MailServiceProvider { get; }

        /// <summary>
        /// Gets the CloudFilesProvider
        /// </summary>
        CloudFilesProvider FilesProvider { get; }

        /// <summary>
        /// Gets the default public endpoint uri
        /// </summary>
        Uri DefaultPublicEndPointUri { get; }

        /// <summary>
        /// Gets the default public endpoint uri string
        /// </summary>
        string DefaultPublicEndPoint { get; set; }

        /// <summary>
        /// Gets user name
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Gets the tenant id
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// Gets the tenant name
        /// </summary>
        string TenantName { get; }

        /// <summary>
        /// Gets the default region string
        /// </summary>
        string DefaultRegion { get; set; }

        #region identity api functions

        /// <summary>
        /// Creates and returns user access
        /// </summary>
        /// <returns>An <see cref="UserAccess"/> that contains token and catalog</returns>
        UserAccess CreateUserAccess();

        /// <summary>
        /// Creates and returns user access
        /// </summary>
        /// <returns>An <see cref="UserAccess"/> that contains token and catalog</returns>
        UserAccess CreateUserAccess(string username, string password, string tenantid = null, string tenantname = null);

        /// <summary>
        /// Gets an array of RegionEndpoint for current user
        /// </summary>
        IEnumerable<RegionEndpoint> ListEndpoints();

        /// <summary>
        /// Sets the default region
        /// </summary>
        void SetDefaultRegion(string region);

        /// <summary>
        /// Gets an array of Tenant
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        IEnumerable<User> ListTenantUsers(string tenantId = null);

        #endregion


        #region billing api functions

        /// <summary>
        /// Gets a collection of order itmes
        /// </summary>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-order-item-list.html"/>
        IEnumerable<SimpleOrderItem> ListOrderItems();

        /// <summary>
        /// Gets an order itedm
        /// </summary>
        /// <param name="itemid">an item id</param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-order-item-detail-specified.html"/>
        OrderItem GetOrderItem(string itemid);

        /// <summary>
        /// Gets the list of product
        /// </summary>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-products.html"/>
        IEnumerable<ProdctBase> ListProducts();

        /// <summary>
        /// Gets the list of payment history
        /// </summary>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-payment-histories.html"/>
        IEnumerable<SimplePayment> ListPaymentHistory();

        /// <summary>
        /// Gets the information of payment summary
        /// </summary>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-payment-summary.html"/>
        PaymentSummary GetPaymentSummary();

        /// <summary>
        /// Gets the list of billing invoice
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-billing-invoices-list.html"/>
        IEnumerable<BillingInvoice> ListBillingInvoices(int offset = 0, int limit = 1000);

        /// <summary>
        /// Gets the billing invoice with invoice id
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-billing-invoices-detail-specified.html"/>
        BillingInvoice GetBillingInvoice(int invoiceId);

        /// <summary>
        /// Gets the list of notification
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-informations-list.html"/>
        IEnumerable<Notification> ListNotifications(string lang = "en", int offset = 0, int limit = 1000);

        /// <summary>
        /// Gets the notification with id
        /// </summary>
        /// <param name="infoCode"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-informations-detail-specified.html"/>
        Notification GetNotification(int infoCode, string lang = "en");

        /// <summary>
        /// Updates the notification status
        /// </summary>
        /// <param name="infoCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-informations-marking.html"/>
        Notification SetNotification(int infoCode, string status); // status in {"Unread", "ReadTitleOnly", "Read"}

        #endregion


        #region compute api functions

        /// <summary>
        /// Gets the list of flavor
        /// </summary>
        /// <param name="minDiskInGB"></param>
        /// <param name="minRamInMB"></param>
        /// <param name="markerId"></param>
        /// <param name="limit"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_flavors_list.html"/>
        IEnumerable<Flavor> ListFlavors(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null, string region = null);

        /// <summary>
        /// Gets a collection of flavor details
        /// </summary>
        /// <param name="minDiskInGB"></param>
        /// <param name="minRamInMB"></param>
        /// <param name="markerId"></param>
        /// <param name="limit"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_flavors_detail.html"/>
        IEnumerable<FlavorDetails> ListFlavorsDetails(int? minDiskInGB = null, int? minRamInMB = null, string markerId = null, int? limit = null, string region = null);

        /// <summary>
        /// Gets the flavor details with flavor id
        /// </summary>
        /// <param name="flavorid"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_flavors_detail_specified_.html"/>
        FlavorDetails GetFlavor(string flavorid, string region = null);

        /// <summary>
        /// Gets a collection of server instance
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="flavorId"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="markerId"></param>
        /// <param name="limit"></param>
        /// <param name="changesSince"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_vms_list.html"/>
        IEnumerable<SimpleServer> ListServers(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null, string region = null);

        /// <summary>
        /// Gets a collection of server details
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="flavorId"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="markerId"></param>
        /// <param name="limit"></param>
        /// <param name="changesSince"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_vms_detail.html"/>
        IEnumerable<Server> ListServersDetails(string imageId = null, string flavorId = null, string name = null, ServerState status = null, string markerId = null, int? limit = null, DateTimeOffset? changesSince = null, string region = null);

        /// <summary>
        /// Gets the server details with server id
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_vms_detail_specified.html"/>
        Server GetServer(string serverId, string region = null);

        /// <summary>
        /// Creates a server instance. be careful since newly created server instance is not free in charge.
        /// </summary>
        /// <param name="cloudServerName"></param>
        /// <param name="imageId"></param>
        /// <param name="flavorId"></param>
        /// <param name="adminPass"></param>
        /// <param name="keyName"></param>
        /// <param name="nametag"></param>
        /// <param name="securityGroupNames"></param>
        /// <param name="attachVolumeIds"></param>
        /// <param name="diskConfig"></param>
        /// <param name="metadata"></param>
        /// <param name="personality"></param>
        /// <param name="attachToServiceNetwork"></param>
        /// <param name="attachToPublicNetwork"></param>
        /// <param name="networks"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-create_vm.html"/>
        NewServer CreateServer(string cloudServerName, string imageId, string flavorId, string adminPass, string keyName = null, string nametag = null, string[] securityGroupNames = null, string[] attachVolumeIds = null, DiskConfiguration diskConfig = null, Metadata metadata = null, Personality[] personality = null, bool attachToServiceNetwork = false, bool attachToPublicNetwork = false, IEnumerable<string> networks = null, string region = null);

        /// <summary>
        /// Deletes the server instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-delete_vm.html"/>
        bool DeleteServer(string serverId, string region = null);

        /// <summary>
        /// Changes the server name. ConoHa seems like not support this command, though openstack does.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="name"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        bool ChangeServerName(string serverId, string name, string region = null);

        /// <summary>
        /// Sends 'power-on' signal to the server instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-power_on_vm.html"/>
        bool StartServer(string serverId, string region = null);

        /// <summary>
        /// Sends 'shutdown' signal to the server instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-stop_cleanly_vm.html"/>
        bool ShutdownServer(string serverId, string region = null);

        /// <summary>
        /// Sends 'restart' signal to the server instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="rebootType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-reboot_vm.html"/>
        bool RestartServer(string serverId, RebootType rebootType = null, string region = null);

        /// <summary>
        /// Sends 'power-off' signal to the server instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-stop_forcibly_vm.html"/>
        bool StopServer(string serverId, string region = null);

        // Server RebuildServer(string serverId, string serverName, string imageName, string flavor, string adminPassword, System.Net.IPAddress accessIPv4 = null, System.Net.IPAddress accessIPv6 = null, Metadata metadata = null, DiskConfiguration diskConfig = null, Personality personality = null, string region = null);

        /// <summary>
        /// Sends 'reinstall' signal to the server instance.
        /// this command throws exception when the server instance is not stopped.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="imageRef"></param>
        /// <param name="adminPassword"></param>
        /// <param name="keyName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-re_install.html"/>
        Server RebuildServer(string serverId, string imageRef, string adminPassword, string keyName = null, string region = null);

        /// <summary>
        /// Sends 'resize' signal to the server instance.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="flavorid"></param>
        /// <param name="diskconfig"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-vm_resize.html"/>
        bool ResizeServer(string serverId, string flavorid, DiskConfiguration diskconfig, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-vm_resize_confirm.html"/>
        bool ConfirmServerResized(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-vm_resize_revert.html"/>
        bool RevertResizeServer(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-vnc_console.html"/>
        VncConsole GetVncConsole(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-web_serial_console.html"/>
        VncConsole GetNovaConsole(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-web_http_serial_console.html"/>
        VncConsole GetHttpConsole(string serverId, string region = null);

        /// <summary>
        /// Changes storage controller with bus name
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="hwDiskBus"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-hw_disk_bus.html"/>
        bool ChangeStorageController(string serverId, string hwDiskBus, string region = null);

        /// <summary>
        /// Changes the network adapter with model string
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="hwVifModel"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-hw_vif_model.html"/>
        bool ChangeNetworkAdapter(string serverId, string hwVifModel, string region = null);

        /// <summary>
        /// Chages the video device with model string
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="hwVideoModel"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-hw_video_model.html"/>
        bool ChangeVideoDevice(string serverId, string hwVideoModel, string region = null);

        /// <summary>
        /// Changes Vnc key map
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="vncKeymap"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-vnc_key_map.html"/>
        bool ChangeVncKeymap(string serverId, string vncKeymap, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_secgroups_status.html"/>
        IEnumerable<ServerSecurityGroup> ListServerSecurityGroups(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_keypairs.html"/>
        IEnumerable<KeypairData> ListKeypairs(string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_keypairs_detail_specified.html"/>
        Keypair GetKeypair(string keyName, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="publickey"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-add_keypair.html"/>
        Keypair AddKeypair(string name, string publickey = null, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-delete_keypair.html"/>
        bool DeleteKeypair(string name, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="imageName"></param>
        /// <param name="imageStatus"></param>
        /// <param name="changesSince"></param>
        /// <param name="markerId"></param>
        /// <param name="limit"></param>
        /// <param name="imageType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_images_list.html"/>
        IEnumerable<SimpleServerImage> ListImages(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="imageName"></param>
        /// <param name="imageStatus"></param>
        /// <param name="changesSince"></param>
        /// <param name="markerId"></param>
        /// <param name="limit"></param>
        /// <param name="imageType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_images_detail.html"/>
        IEnumerable<ServerImage> ListImagesDetails(string server = null, string imageName = null, ImageState imageStatus = null, DateTimeOffset? changesSince = null, string markerId = null, int? limit = null, ImageType imageType = null, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_images_detail_specified.html"/>
        ServerImage GetImage(string imageId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_volume_attachments.html"/>
        IEnumerable<ServerVolume> ListServerVolumes(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="volumeId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_volume_attachment_specified.html"/>
        ServerVolume GetServerVolume(string serverId, string volumeId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="volumeId"></param>
        /// <param name="devicePath"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-attach_volume.html"/>
        ServerVolume AttachVolume(string serverId, string volumeId, string devicePath = null, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="volumeId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-dettach_volume.html"/>
        bool DetachVolume(string serverId, string volumeId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_attached_ports_list.html"/>
        IEnumerable<InterfaceAttachment> ListInterfaceAttachments(string serverId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="portId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_attached_port_specified.html"/>
        InterfaceAttachment GetInterfaceAttachment(string serverId, string portId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="portId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-attach_port.html"/>
        InterfaceAttachment AddInterfaceAttachment(string serverId, string portId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="portId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see hjref="https://www.conoha.jp/docs/compute-dettach_port.html"/>
        bool DeleteInterfaceAttachment(string serverId, string portId, string region = null);

        /// <summary>
        /// Gets the list of vm instance backup service
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-get_backup_list.html"/>
        IEnumerable<BackupService> ListBackupServices(string region = null);

        /// <summary>
        /// Gets the vm backup service with backup id
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-get_backup_list_detailed.html"/>
        BackupService GetBackupService(string backupId, string region = null);

        /// <summary>
        /// Creates a backup vm service 
        /// </summary>
        /// <param name="InstanceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-start_backup.html"/>
        BackupService AddBackupService(string InstanceId, string region = null);

        /// <summary>
        /// Deletes the vm backup service
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-end_backup.html"/>
        bool DeleteBackupService(string backupId, string region = null);

        /// <summary>
        /// Restores the VM instance with backup
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="backupRunId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/backup-restore_backup.html"/>
        bool RestoreFromBackupRun(string backupId, string backupRunId, string region = null);

        /// <summary>
        /// this might not be supported
        /// </summary>
        /// <param name="backupId"></param>
        /// <param name="backupRunId"></param>
        /// <param name="imageName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        bool CreateImageFromBackupRun(string backupId, string backupRunId, string imageName = null, string region = null);

        /// <summary>
        /// Gets the list of server ips
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_server_addresses.html"/>
        ServerIps ListServerIps(string serverId, string region = null);

        /// <summary>
        /// Creates the glance image from vm instance
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="imageName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        bool CreateGlanceImageFromInstance(string serverId, string imageName, string region = null);

        /// <summary>
        /// Gets the list of the server addresses
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        ServerAddresses ListAddresses(string serverId, string region = null);

        #endregion


        #region blockstorage api functions

        /// <summary>
        /// Gets the list of volume types
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-get_volume_types_list.html"/>
        IEnumerable<VolumeType> ListVolumeTypes(string region = null);

        /// <summary>
        /// Gets the volume type with volume id
        /// </summary>
        /// <param name="volumeId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-get_volume_type_specified.html"/>
        VolumeType GetVolumeType(string volumeId, string region = null);

        /// <summary>
        /// Gets the collection of volume
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-get_volumes_list.html"/>
        IEnumerable<Volume> ListVolumes(string region = null);

        /// <summary>
        /// Gets the list of the volume details
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-get_volumes_detail.html"/>
        IEnumerable<Volume> ListVolumesDetails(string region = null);

        /// <summary>
        /// Gets the volume with volume id
        /// </summary>
        /// <param name="volumeId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-get_volume_detail_specified.html"/>
        Volume GetVolume(string volumeId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="sourceVolumeId"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="snapshotId"></param>
        /// <param name="volumeType"></param>
        /// <param name="imageRef"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-create_volume.html"/>
        Volume CreateVolume(int size, string sourceVolumeId = null, string description = null, string name = null, string snapshotId = null, string volumeType = null, string imageRef = null, string region = null);

        /// <summary>
        /// Deletes the volume with volume id
        /// </summary>
        /// <param name="volumeId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-delete_volume.html"/>
        bool DeleteVolume(string volumeId, string region = null);

        /// <summary>
        /// Waits until volume is available
        /// </summary>
        Volume WaitForVolumeAvailable(string volumeId, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null);

        /// <summary>
        /// Waits until volume is deleted
        /// </summary>
        bool WaitForVolumeDeleted(string volumeId, int refreshCount = 360, TimeSpan? refreshDelay = null, string region = null);

        /// <summary>
        /// Waits until volume's status is the specific value
        /// </summary>
        Volume WaitForVolumeState(string volumeId, VolumeState expectedState, VolumeState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volumeId"></param>
        /// <param name="imageName"></param>
        /// <param name="diskFormat"></param>
        /// <param name="containerFormat"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/cinder-create_volume_specified.html"/>
        VolumeUploadImage CreateGlanceImageFromVolume(string volumeId = null, string imageName = null, string diskFormat = null, string containerFormat = null, string region = null);

        #endregion


        #region image api functions

        /// <summary>
        /// Gets a collection of glance image
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="marker"></param>
        /// <param name="name"></param>
        /// <param name="visibility"></param>
        /// <param name="memberStatus"></param>
        /// <param name="owner"></param>
        /// <param name="status"></param>
        /// <param name="sizeMin"></param>
        /// <param name="sizeMax"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortDir"></param>
        /// <param name="tag"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/image-get_images_list.html"/>
        IEnumerable<CloudImage> ListGlanceImages(int? limit = null, string marker = null, string name = null, string visibility = null, string memberStatus = null, string owner = null, string status = null, int? sizeMin = null, int? sizeMax = null, string sortKey = null, string sortDir = null, string tag = null, string region = null);

        /// <summary>
        /// Gets the glance image with image id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/image-get_images_detail_specified.html"/>
        CloudImage GetGlanceImage(string imageId, string region = null);

        /// <summary>
        /// Deletes the glance image with image id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/image-remove_image.html"/>
        bool DeleteGlanceImage(string imageId, string region = null);

        /// <summary>
        /// Gets the value of how much image quota using
        /// </summary>
        Dictionary<string, string> SetImageQuota(string quota, string region = null);

        /// <summary>
        /// Gets glance image quota
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        long GetImageAmount(string region = null);

        /// <summary>
        /// this is not supported by design.
        /// </summary>
        bool SetWebShare(string imageId, bool sharing, string region = null);

        /// <summary>
        /// this is not supported by design.
        /// </summary>
        bool ImportImage(string name, string importFromUrl, string region = null);

        /// <summary>
        /// this is not supported by design.
        /// </summary>
        IEnumerable<CloudImageTask> ListCloudImageTasks(string region = null);

        /// <summary>
        /// this is not supported by design.
        /// </summary>
        CloudImageTaskDetail GetCloudImageTask(string taskId, string region = null);

        #endregion


        #region network api functions

        /// <summary>
        /// Gets the list of the networks
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_networks_list.html"/>
        IEnumerable<Network> ListNetworks(string region = null);

        /// <summary>
        /// Creates a network
        /// </summary>
        /// <param name="name"></param>
        /// <param name="admin_state_up"></param>
        /// <param name="networkType"></param>
        /// <param name="segmentationId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_network.html"/>
        Network CreateNetwork(string name, bool admin_state_up = true, string networkType = "vxlan", string segmentationId = null, string region = null);

        /// <summary>
        /// Deletes the network with network id
        /// </summary>
        /// <param name="networkId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-remove_network.html"/>
        bool DeleteNetwork(string networkId, string region = null);

        /// <summary>
        /// Gets the list of the port
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_ports_list.html"/>
        IEnumerable<Port> ListPorts(string region = null);

        /// <summary>
        /// Gets the port with port id
        /// </summary>
        /// <param name="portid"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_ports_detail_specified.html"/>
        Port GetPort(string portid, string region = null);

        /// <summary>
        /// Creates a network port
        /// </summary>
        /// <param name="networkId"></param>
        /// <param name="fixedIps"></param>
        /// <param name="allowedAddressPairs"></param>
        /// <param name="tenantId"></param>
        /// <param name="securityGroups"></param>
        /// <param name="status"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_port.html"/>
        Port CreatePort(string networkId, FixedIp[] fixedIps = null, Dictionary<string, string> allowedAddressPairs = null, string tenantId = null, string[] securityGroups = null, string status = null, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portId"></param>
        /// <param name="adminStateUp"></param>
        /// <param name="securityGroups"></param>
        /// <param name="fixedIps"></param>
        /// <param name="allowedAddressPairs"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-update_port.html"/>
        Port UpdatePort(string portId, bool? adminStateUp = true, string[] securityGroups = null, FixedIp[] fixedIps = null, AllowedAddressPair[] allowedAddressPairs = null, string region = null);

        /// <summary>
        /// Deletes the port with port id
        /// </summary>
        /// <param name="portId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-remove_port.html"/>
        bool DeletePort(string portId, string region = null);

        /// <summary>
        /// Gets the list of the subnet
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_subnet.html"/>
        IEnumerable<Subnet> ListSubnets(string region = null);

        /// <summary>
        /// Gets the subnet with subnet id
        /// </summary>
        /// <param name="subnetId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_subnets_detail_specified.html"/>
        Subnet GetSubnet(string subnetId, string region = null);

        /// <summary>
        /// Creates a subnet
        /// </summary>
        /// <param name="name"></param>
        /// <param name="networkId"></param>
        /// <param name="ipVersion"></param>
        /// <param name="cidr"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_subnet.html"/>
        Subnet CreateSubnet(string name, string networkId, int ipVersion, string cidr, string region = null);

        /// <summary>
        /// Updates the subnet
        /// </summary>
        /// <param name="subnetId"></param>
        /// <param name="name"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        Subnet UpdateSubnet(string subnetId, string name, string region = null);

        /// <summary>
        /// Deletes the subnet with subnet id
        /// </summary>
        /// <param name="subnetId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-remove_subnet.html"/>
        bool DeleteSubnet(string subnetId, string region = null);

        /// <summary>
        /// Gets the list of virtual ip
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_vips_list.html"/>
        IEnumerable<VIP> ListVIPs(string region = null);

        /// <summary>
        /// Gets the virtual ip with vid
        /// </summary>
        /// <param name="vipId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_vips_detail_specified.html"/>
        VIP GetVIP(string vipId, string region = null);

        /// <summary>
        /// Creates a virtual ip
        /// </summary>
        /// <param name="name"></param>
        /// <param name="protocol"></param>
        /// <param name="protocolPort"></param>
        /// <param name="poolId"></param>
        /// <param name="subnetId"></param>
        /// <param name="address"></param>
        /// <param name="adminStateUp"></param>
        /// <param name="description"></param>
        /// <param name="sessionPpersistence"></param>
        /// <param name="connectionLimit"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-create_vip.html"/>
        VIP CreateVIP(string name, string protocol, string protocolPort, string poolId, string subnetId, string address, bool adminStateUp, string description = null, string sessionPpersistence = null, int? connectionLimit = null, string region = null);

        /// <summary>
        /// Updates the virtual ip
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-remove_vip.html"/>
        VIP UpdateVIP(string region = null);

        /// <summary>
        /// Deletes the virtual ip
        /// </summary>
        /// <param name="vipId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-remove_vip.html"/>
        bool DeleteVIP(string vipId, string region = null);

        /// <summary>
        /// Gets the list of monitoring pool
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_pools_list.html"/>
        IEnumerable<Pool> ListPools(string region = null);

        /// <summary>
        /// Gets the monitoring pools with pool id
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_pools_detail_specified.html"/>
        Pool GetPool(string poolId, string region = null);

        /// <summary>
        /// Creates a pool
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subnetId"></param>
        /// <param name="lbMethod"></param>
        /// <param name="protocol"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_pool.html"/>
        Pool CreatePool(string name, string subnetId, string lbMethod = "ROUND_ROBIN", string protocol = "TCP", string region = null);

        /// <summary>
        /// Updates the pool
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="name"></param>
        /// <param name="lbMethod"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-change_balancer_type.html"/>
        Pool UpdatePool(string poolId, string name = null, string lbMethod = null, string region = null);

        /// <summary>
        /// Deletes the pool with pool id
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-delete_pool.html"/>
        bool DeletePool(string poolId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monitorId"></param>
        /// <param name="poolId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-set_health_monitor_on_pool.html"/>
        bool AssociateHealthMonitor(string monitorId, string poolId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monitorId"></param>
        /// <param name="poolId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-delete_health_monitor.html"/>
        bool DisassociateHealthMonitor(string monitorId, string poolId, string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_healthmonitors_list.html"/>
        IEnumerable<HealthMonitor> ListHealthMonitors(string region = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monitorId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_healthmonitors_detail_specified.html"/>
        HealthMonitor GetHealthMonitor(string monitorId, string region = null);

        /// <summary>
        /// Creates a health monitor
        /// </summary>
        /// <param name="monitorType"></param>
        /// <param name="delay"></param>
        /// <param name="maxRetries"></param>
        /// <param name="urlPath"></param>
        /// <param name="expectedCodes"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-create_health_monitor.html"/>
        HealthMonitor CreateHealthMonitor(string monitorType, int delay, int maxRetries, string urlPath = null, string expectedCodes = null, string region = null);

        /// <summary>
        /// Updates the health monitor
        /// </summary>
        /// <param name="monitorId"></param>
        /// <param name="delay"></param>
        /// <param name="maxRetries"></param>
        /// <param name="urlPath"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-change_health_monitor.html"/>
        HealthMonitor UpdateHealthMonitor(string monitorId, int delay, int maxRetries, string urlPath, string region = null);

        /// <summary>
        /// Deltes the health monitor with monitor id
        /// </summary>
        /// <param name="monitorId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-delete_health_monitor.html"/>
        bool DeleteHealthMonitor(string monitorId, string region = null);

        /// <summary>
        /// Gets the list of load banlancer member
        /// </summary>
        /// <param name="subnetId"></param>
        /// <param name="poolId"></param>
        /// <param name="protocolPort"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_members_list.html"/>
        IEnumerable<LBMember> ListLBMembers(string subnetId = null, string poolId = null, string protocolPort = null, string region = null);

        /// <summary>
        /// Gets load banlancer member with member id
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_members_detail_specified.html"/>
        LBMember GetLBMember(string memberId, string region = null);

        /// <summary>
        /// Creates a load banlancer member
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="address"></param>
        /// <param name="protocolPort"></param>
        /// <param name="weight"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_member.html"/>
        LBMember CreateLBMember(string poolId, string address, string protocolPort, int weight = 1, string region = null);

        /// <summary>
        /// Updates the load banlancer member
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="weight"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-update_member.html"/>
        LBMember UpdateLBMember(string memberId, int weight, string region = null);

        /// <summary>
        /// Deletes the load banlancer member with member id
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-remove_member.html"/>
        bool DeleteLBMember(string memberId, string region = null);

        /// <summary>
        /// Gets the list of the network security group
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_secgroups_list.html"/>
        IEnumerable<NetworkSecurityGroup> ListNetworkSecurityGroups(string region = null);

        /// <summary>
        /// Gets the the network security group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_secgroups_detail_specified.html"/>
        NetworkSecurityGroup GetNetworkSecurityGroup(string groupId, string region = null);

        /// <summary>
        /// Creates a network security group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-create_secgroup.html"/>
        NetworkSecurityGroup CreateNetworkSecurityGroup(string name, string description, string region = null);

        /// <summary>
        /// Deletes the network security group with group id
        /// </summary>
        /// <param name="securityGroupId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-delete_secgroup.html"/>
        bool DeleteNetworkSecurityGroup(string securityGroupId, string region = null);

        /// <summary>
        /// Gets the list of the security rule
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_rules_on_secgroup.html"/>
        IEnumerable<NetworkSecurityGroupRule> ListNetworkSecurityGroupRules(string region = null);

        /// <summary>
        /// Gets the security rule
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-get_rules_detail_specified.html"/>
        NetworkSecurityGroupRule GetNetworkSecurityGroupRule(string ruleId, string region = null);

        /// <summary>
        /// Creates the security rule
        /// </summary>
        /// <param name="securityGroupId"></param>
        /// <param name="direction"></param>
        /// <param name="etherType"></param>
        /// <param name="portRangeMin"></param>
        /// <param name="portRangeMax"></param>
        /// <param name="protocol"></param>
        /// <param name="remoteGroupId"></param>
        /// <param name="remoteIpPrefix"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-create_rule_on_secgroup.html"/>
        NetworkSecurityGroupRule CreateNetworkSecurityGroupRule(string securityGroupId, string direction, string etherType, string portRangeMin = null, string portRangeMax = null, string protocol = null, string remoteGroupId = null, string remoteIpPrefix = null, string region = null);

        /// <summary>
        /// Deletes the security rule
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-delete_rule_on_secgroup.html"/>
        bool DeleteNetworkSecurityGroupRule(string ruleId, string region = null);

        /// <summary>
        /// Creates a subnet for additional ip
        /// </summary>
        /// <param name="bitmask"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_subnet_for_addip.html"/>
        Subnet AddSubnetForAdditionalIp(int bitmask, string region = null);

        /// <summary>
        /// Creates a subnet for load balancer
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/neutron-add_subnet_for_lb.html"/>
        Subnet AddSubnetForLb(string region = null);

        #endregion


        #region database api functions

        #region services

        /// <summary>
        /// Creates a DB service
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-service.html"/>
        DbService CreateDbService(string serviceName, string region = null);

        /// <summary>
        /// Gets the list of DB service
        /// </summary>
        /// <param name="lineCount"></param>
        /// <param name="pageNo"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database-service.html"/>
        IEnumerable<DbService> ListDbServices(int? lineCount = null, int? pageNo = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Gets the DB service with service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database-service.html"/>
        DbService GetDbService(string serviceId, string region = null);

        /// <summary>
        /// Updates the DB service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-update-database-service.html"/>
        DbService UpdateDbService(string serviceId, string serviceName, string region = null);

        /// <summary>
        /// Deletes the DB Service with service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-database-service.html"/>
        bool DeleteDbService(string serviceId, string region = null);

        /// <summary>
        /// Gets the value of DB service quota
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database-quotas.html"/>
        DbServiceQuota GetDbServiceQuota(string serviceId, string region = null);

        /// <summary>
        /// Update the value of DB service quota
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="quota"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-update-database-quotas.html"/>
        DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota, string region = null);

        /// <summary>
        /// Sets DB service backup 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-backup.html"/>
        bool SetDbServiceBackup(string serviceId, bool enabled, string region = null);

        #endregion

        #region databases

        /// <summary>
        /// Creates a database in the DB service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="dbName"></param>
        /// <param name="type"></param>
        /// <param name="charset"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database.html"/>
        Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null, string region = null);

        /// <summary>
        /// Gets the list of database
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database.html"/>
        IEnumerable<Database> ListDatabases(string serviceId = null, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Get the database with database id
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database.html"/>
        Database GetDatabase(string databaseId, string region = null);

        /// <summary>
        /// Updates the database
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-backup.html"/>
        Database UpdateDatabase(string databaseId, string memo = null, string region = null);

        /// <summary>
        /// Deletes the database with database id
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-databases.html"/>
        bool DeleteDatabase(string databaseId, string region = null);

        #endregion

        #region db grant

        /// <summary>
        /// Create a database grant data
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-grant.html"/>
        DbGrant CreateDbGrant(string databaseId, string userId, string region = null);

        /// <summary>
        /// Get the list of a database grant data
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-grant.html"/>
        IEnumerable<DbGrant> ListDbGrant(string databaseId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Deletes the database grant data with userid
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-grant.html"/>
        bool DeleteDbGrant(string databaseId, string userId, string region = null);

        #endregion

        #region backups

        /// <summary>
        /// Gets the list of the database backups
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database-backup.html"/>
        IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Restores the database with backup id
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="backupId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-restore-database-backup.html"/>
        bool RestoreDatabase(string databaseId, string backupId, string region = null);

        #endregion

        #region db users

        /// <summary>
        /// Creates a database user
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hostname"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-create-database-account.html"/>
        DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null, string region = null);

        /// <summary>
        /// Gets the list of database user
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-list-database-account.html"/>
        IEnumerable<DbUser> ListDbUsers(string serviceId = null, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Get the database user with userid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-get-database-account.html"/>
        DbUser GetDbUser(string userId, string region = null);

        /// <summary>
        /// Updates the database user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="memo"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-update-database-account.html"/>
        DbUser UpdateDbUser(string userId, string password = null, string memo = null, string region = null);

        /// <summary>
        /// Deletes the database user with userid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-database-delete-database-account.html"/>
        bool DeleteDbUser(string userId, string region = null);

        #endregion

        #endregion


        #region dns api functions

        #region domains

        /// <summary>
        /// Gets the collection of DNS service details
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-get-servers-hosting-a-domain.html"/>
        IEnumerable<DnsServer> GetDnsServiceDetails(string domainId, string region = null);

        /// <summary>
        /// Gets the collection of domains
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-list-domains.html"/>
        IEnumerable<Domain> ListDomains(string region = null);

        /// <summary>
        /// Registers a domain to the DNS service
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="email"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslb"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-create-domain.html"/>
        Domain CreateDomain(string domainName, string email, int? ttl = null, string description = null, int? gslb = null, string region = null);

        /// <summary>
        /// Deletes the domain with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-delete-a-domain.html"/>
        bool DeleteDomain(string domainId, string region = null);

        /// <summary>
        /// Gets the domain details with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-get-a-domain.html"/>
        Domain GetDomain(string domainId, string region = null);

        /// <summary>
        /// Updates the domain resources
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="domainName"></param>
        /// <param name="email"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslb"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-update-a-domain.html"/>
        Domain UpdateDomain(string domainId, string domainName = null, string email = null, int? ttl = null, string description = null, int? gslb = null, string region = null);

        #endregion

        #region records

        /// <summary>
        /// Gets the list of DNS records with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-list-records-in-a-domain.html"/>
        IEnumerable<DnsRecord> ListDnsRecords(string domainId, string region = null);

        /// <summary>
        /// Creates a DNS record
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslbRegion"></param>
        /// <param name="gslbWeight"></param>
        /// <param name="gslbCheck"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-create-record.html"/>
        DnsRecord CreateDnsRecord(string domainId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null);

        /// <summary>
        /// Deletes the DNS record with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-delete-a-record.html"/>
        bool DeleteDnsRecord(string domainId, string recordId, string region = null);

        /// <summary>
        /// Gets the DNS record with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-get-a-record.html"/>
        DnsRecord GetDnsRecord(string domainId, string recordId, string region = null);

        /// <summary>
        /// Updates the DNS record details
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="recordId"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <param name="description"></param>
        /// <param name="gslbRegion"></param>
        /// <param name="gslbWeight"></param>
        /// <param name="gslbCheck"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-update-a-record.html"/>
        DnsRecord UpdateDnsRecord(string domainId, string recordId, string name, string type, string data, int? priority = null, int? ttl = null, string description = null, string gslbRegion = null, int? gslbWeight = null, int? gslbCheck = null, string region = null);

        #endregion

        #region zone

        /// <summary>
        /// Imports zone data
        /// </summary>
        /// <param name="zoneContent"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-import-zone.html"/>
        Zone ImportZone(string zoneContent, string region = null);

        /// <summary>
        /// Export zone data
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-dns-export-zone.html"/>
        string ExportZone(string zoneId, string region = null);

        #endregion

        #endregion


        #region mail api functions

        #region services

        /// <summary>
        /// Creates a mail service, which is a container of mail address
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="defaultSubdomain"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-mail-service.html"/>
        MailService CreateMailService(string serviceName, string defaultSubdomain, string region = null);

        /// <summary>
        /// Gets a collection of mail service
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-mail-service.html"/>
        IEnumerable<MailService> ListMailServices(int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Gets the mail service with service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-service.html"/>
        MailService GetMailService(string serviceId, string region = null);

        /// <summary>
        /// Updates the mail service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-mail-service.html"/>
        MailService UpdateMailService(string serviceId, string serviceName, string region = null);

        /// <summary>
        /// Toggles mail service activity
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-backup.html"/>
        bool SetMailServiceBackup(string serviceId, bool enabled, string region = null);

        /// <summary>
        /// Deletes the mail service
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-mail-service.html"/>
        bool DeleteMailService(string serviceId, string region = null);

        /// <summary>
        /// Gets mail box quota available
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-email-quotas.html"/>
        MailBoxQuota GetMailBoxQuota(string serviceId, string region = null);

        /// <summary>
        /// Updates mail box quota
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="quota"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-quotas.html"/>
        MailBoxQuota UpdateMailBoxQuota(string serviceId, int quota, string region = null);

        #endregion

        #region domains

        /// <summary>
        /// Creates a mail domain
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="domainName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email.html"/>
        MailDomain CreateMailDomain(string serviceId, string domainName, string region = null);

        /// <summary>
        /// Gets a collection of mail domains using
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-domains.html"/>
        IEnumerable<MailDomain> ListMailDomains(string serviceId = null, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Deletes the mail domain with domain id
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email.html"/>
        bool DeleteMailDomain(string domainId, string region = null);

        /// <summary>
        /// Get a dedicated ip for the mail domain
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-dedicated-ip.html"/>
        string GetMailDomainDedicatedIp(string domainId, string region = null);

        /// <summary>
        /// Update the statusof thededicated ip for email 
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-dedicated-ip.html"/>
        string SetMailDomainDedicatedIpStatus(string domainId, bool enabled, string region = null);

        #endregion

        #region mailaddresses

        /// <summary>
        /// Creates an email address
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email.html"/>
        Email CreateEmailAddress(string domainId, string emailAddress, string password, string region = null);

        /// <summary>
        /// Gets a collection of email addresses
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-domain.html"/>
        IEnumerable<Email> ListEmailAddresses(string domainId = null, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Gets the email address with email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-email.html"/>
        Email GetEmailAddress(string emailId, string region = null);

        /// <summary>
        /// Deletes the email address with email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email.html"/>
        bool DeleteEmailAddress(string emailId, string region = null);

        /// <summary>
        /// Updates email address password
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-password.html"/>
        bool ChangeEmailAddressPassword(string emailId, string password, string region = null);

        /// <summary>
        /// Toggles email spam filter activity
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="enabled"></param>
        /// <param name="type"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email-spam-filter.html"/>
        bool SetEmailSpamFilter(string emailId, bool enabled, string type = null, string region = null);

        /// <summary>
        /// Sets the virus check activity
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        bool SetEmailVirusCheck(string emailId, bool enabled, string region = null);

        /// <summary>
        /// Toggle the value which indicates whether the copy would be remained or not
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="enabled"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        bool SetEmailForwardingCopy(string emailId, bool enabled, string region = null);

        #endregion

        #region messages

        /// <summary>
        /// Gets the list of email message's header
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-messages.html"/>
        IEnumerable<MailMessageHeader> ListMailMessageHeaders(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Gets the email message with email id and message id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="messageId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-messages.html"/>
        MailMessage GetMailMessage(string emailId, string messageId, string region = null);

        /// <summary>
        /// Gets the attachment of email by email id, message id and attachment id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="messageId"></param>
        /// <param name="attachmemntId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-messages-attachments.html"/>
        Attachment GetMailAttachment(string emailId, string messageId, string attachmemntId, string region = null);

        /// <summary>
        /// Deletes the email message with message id
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="messageId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-messages.html"/>
        bool DeleteMailMessage(string emailId, string messageId, string region = null);

        #endregion

        #region webhooks

        /// <summary>
        /// Creates a email web hook
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="webhookUrl"></param>
        /// <param name="keyword"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email-webhook.html"/>
        EmailWebHook CreateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null);

        /// <summary>
        /// Gets the email web hook with emailid
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-filter.html"/>
        EmailWebHook GetEmailWebHook(string emailId, string region = null);

        /// <summary>
        /// Updates email web hook
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="webhookUrl"></param>
        /// <param name="keyword"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-filter.html"/>
        EmailWebHook UpdateEmailWebHook(string emailId, string webhookUrl, string keyword, string region = null);

        /// <summary>
        /// Deletes the email web hook
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email-filter.html"/>
        bool DeleteEmailWebHook(string emailId, string region = null);

        #endregion

        #region Filtering

        /// <summary>
        /// Gets the list of email white addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-whitelist.html"/>
        IEnumerable<EmailFilterDetails> GetEmailWhiteList(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Updates the list of email whilte addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="targets"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-whitelist.html"/>
        IEnumerable<EmailFilterDetails> UpdateWhiteList(string emailId, EmailFilterDetails[] targets, string region = null);

        /// <summary>
        /// Gets the list of email black addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-blacklist.html"/>
        IEnumerable<EmailFilterDetails> GetEmailBlackList(string emailId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Updates the list of email black addresses
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="targets"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-blacklist.html"/>
        IEnumerable<EmailFilterDetails> UpdateBlackList(string emailId, EmailFilterDetails[] targets, string region = null);

        #endregion

        #region forwardings

        /// <summary>
        /// Creates email forwarding setting
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="toForwardAddress"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-create-email-forwarding.html"/>
        EmailForwarding CreateEmailForwarding(string emailId, string toForwardAddress, string region = null);

        /// <summary>
        /// Gets the list of email forwarding
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="sortKey"></param>
        /// <param name="sortType"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-list-email-forwarding.html"/>
        IEnumerable<EmailForwarding> ListEmailForwardings(string emailId = null, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null);

        /// <summary>
        /// Gets the email forward setting with forwarding id
        /// </summary>
        /// <param name="forwardingId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-get-email-forwarding.html"/>
        EmailForwarding GetEmailForwarding(string forwardingId, string region = null);

        /// <summary>
        /// Updates the email forward setting
        /// </summary>
        /// <param name="forwardingId"></param>
        /// <param name="toForwardAddress"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-update-email-forwarding.html"/>
        EmailForwarding UpdateEmailForwarding(string forwardingId, string toForwardAddress, string region = null);

        /// <summary>
        /// Deletes the email forwarding setting with forwarding id
        /// </summary>
        /// <param name="forwardingId"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/paas-mail-delete-email-forwarding.html"/>
        bool DeleteEmailForwarding(string forwardingId, string region = null);

        #endregion

        #endregion


        #region Object Storage

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Gets the list of object storage containers
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="marker"></param>
        /// <param name="markerEnd"></param>
        /// <param name="region"></param>
        /// <param name="useInternalUrl"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/swift-show_account_details_and_list_containers.html"/>
        IEnumerable<Container> ListContainers(int? limit = null, string marker = null, string markerEnd = null, string region = null, bool useInternalUrl = false);

        /// <summary>
        /// Creates a object storage container
        /// </summary>
        /// <param name="container"></param>
        /// <param name="headers"></param>
        /// <param name="region"></param>
        /// <param name="useInternalUrl"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/swift-create_container.html"/>
        ObjectStore CreateContainer(string container, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false);

        /// <summary>
        /// Deletes the object storage container with container name
        /// </summary>
        /// <param name="container"></param>
        /// <param name="deleteObjects"></param>
        /// <param name="region"></param>
        /// <param name="useInternalUrl"></param>
        /// <see href="https://www.conoha.jp/docs/swift-delete_container.html"/>
        void DeleteContainer(string container, bool deleteObjects = false, string region = null, bool useInternalUrl = false);

        Dictionary<string, string> GetContainerHeader(string container, string region = null, bool useInternalUrl = false);

        Dictionary<string, string> GetContainerMetaData(string container, string region = null, bool useInternalUrl = false);

        ContainerCDN GetContainerCDNHeader(string container, string region = null);

        IEnumerable<ContainerCDN> ListCDNContainers(int? limit = null, string markerId = null, string markerEnd = null, bool cdnEnabled = false, string region = null);

        Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, string region = null);

        Dictionary<string, string> EnableCDNOnContainer(string container, bool logRetention, string region = null);

        Dictionary<string, string> EnableCDNOnContainer(string container, long timeToLive, bool logRetention, string region = null);

        Dictionary<string, string> DisableCDNOnContainer(string container, string region = null);

        void UpdateContainerMetadata(string container, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false);

        void DeleteContainerMetadata(string container, IEnumerable<string> keys, string region = null, bool useInternalUrl = false);

        void DeleteContainerMetadata(string container, string key, string region = null, bool useInternalUrl = false);

        void UpdateContainerCdnHeaders(string container, Dictionary<string, string> headers, string region = null);

        void EnableStaticWebOnContainer(string container, string index, string error, string css, bool listing, string region = null, bool useInternalUrl = false);

        void EnableStaticWebOnContainer(string container, string index, string error, bool listing, string region = null, bool useInternalUrl = false);

        void EnableStaticWebOnContainer(string container, string css, bool listing, string region = null, bool useInternalUrl = false);

        void EnableStaticWebOnContainer(string container, string index, string error, string region = null, bool useInternalUrl = false);

        void DisableStaticWebOnContainer(string container, string region = null, bool useInternalUrl = false);

        Dictionary<string, string> GetObjectHeaders(string container, string objectName, string region = null, bool useInternalUrl = false);

        Dictionary<string, string> GetObjectMetaData(string container, string objectName, string region = null, bool useInternalUrl = false);

        void UpdateObjectMetadata(string container, string objectName, Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false);

        void DeleteObjectMetadata(string container, string objectName, IEnumerable<string> keys, string region = null, bool useInternalUrl = false);

        void DeleteObjectMetadata(string container, string objectName, string key, string region = null, bool useInternalUrl = false);

        IEnumerable<ContainerObject> ListObjects(string container, int? limit = null, string marker = null, string markerEnd = null, string prefix = null, string region = null, bool useInternalUrl = false);

        void CreateObjectFromFile(string container, string filePath, string objectName = null, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false);

        void CreateObject(string container, Stream stream, string objectName, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false);

        void GetObject(string container, string objectName, Stream outputStream, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false);

        void GetObjectSaveToFile(string container, string saveDirectory, string objectName, string fileName = null, int chunkSize = 65536, Dictionary<string, string> headers = null, string region = null, bool verifyEtag = false, Action<long> progressUpdated = null, bool useInternalUrl = false);

        void CopyObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false);

        void DeleteObject(string container, string objectName, Dictionary<string, string> headers = null, bool deleteSegments = true, string region = null, bool useInternalUrl = false);

        void DeleteObjects(string container, IEnumerable<string> objects, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false);

        void BulkDelete(IEnumerable<KeyValuePair<string, string>> items, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false);

        ExtractArchiveResponse ExtractArchiveFromFile(string filePath, string uploadPath, ArchiveFormat archiveFormat, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false);

        ExtractArchiveResponse ExtractArchive(Stream stream, string uploadPath, ArchiveFormat archiveFormat, string contentType = null, int chunkSize = 4096, Dictionary<string, string> headers = null, string region = null, Action<long> progressUpdated = null, bool useInternalUrl = false);

        void MoveObject(string sourceContainer, string sourceObjectName, string destinationContainer, string destinationObjectName, string destinationContentType = null, Dictionary<string, string> headers = null, string region = null, bool useInternalUrl = false);

        void PurgeObjectFromCDN(string container, string objectName, IEnumerable<string> emails = null, string region = null);

        Dictionary<string, string> GetAccountHeaders(string region = null, bool useInternalUrl = false);

        Dictionary<string, string> GetAccountMetaData(string region = null, bool useInternalUrl = false);

        void UpdateAccountMetadata(Dictionary<string, string> metadata, string region = null, bool useInternalUrl = false);

        Uri CreateTemporaryPublicUri(HttpMethod method, string container, string objectName, string key, DateTimeOffset expiration, string region = null, bool useInternalUrl = false);

        Tuple<Uri, ReadOnlyDictionary<string, string>> CreateFormPostUri(string container, string objectPrefix, string key, DateTimeOffset expiration, Uri redirectUri, long maxFileSize, int maxFileCount, string region = null, bool useInternalUrl = false);

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        #endregion


        #region Graph api functions

        /// <summary>
        /// Gets CPU graph data
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_cpu_utilization_graph.html"/>
        string GetCPUGraph(string serverId, DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null);

        /// <summary>
        /// Gets disk graph data
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="deviceName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_disk_io_graph.html"/>
        string GetDiskIOGraph(string serverId, string deviceName = null, DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null);

        /// <summary>
        /// Gets network graph data
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="portId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/compute-get_server_addresses_by_network.html"/>
        string GetNetworkGraph(string serverId, string portId, DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null);

        /// <summary>
        /// Gets the number how much swift requests occured
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-get_objectstorage_request_rrd.html"/>
        string GetSwiftRequestGraph(DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null);

        /// <summary>
        /// Gets data of the swift network traffic amount occurred
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="mode"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        /// <see href="https://www.conoha.jp/docs/account-get_objectstorage_size_rrd.html"/>
        string GetSwiftSizeGraph(DateTime? startDate = null, DateTime? endDate = null, string mode = null, string region = null);
        #endregion
    }
}