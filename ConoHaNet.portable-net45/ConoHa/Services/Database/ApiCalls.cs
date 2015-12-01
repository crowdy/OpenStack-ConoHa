namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.Database;

    // DatabaseServiceVersion GetVersion();
    // Task<GetVersionApiCall> PrepareGetVersionAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class GetVersionApiCall : DelegatingHttpApiCall<DatabaseServiceVersion>
    {
        public GetVersionApiCall(IHttpApiCall<DatabaseServiceVersion> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DatabaseServiceVersion GetVersionDetails();
    // Task<GetVersionDetailsApiCall> PrepareGetVersionDetailsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class GetVersionDetailsApiCall : DelegatingHttpApiCall<DatabaseServiceVersion>
    {
        public GetVersionDetailsApiCall(IHttpApiCall<DatabaseServiceVersion> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbService CreateDbService(string serviceName, string region = null, CloudIdentity identity = null);
    // Task<CreateDbServiceApiCall> PrepareCreateDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class CreateDbServiceApiCall : DelegatingHttpApiCall<DbService>
    {
        public CreateDbServiceApiCall(IHttpApiCall<DbService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<DbService> ListDbServices(int? offset = null, int? limit = null, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
    // Task<ListDbServicesApiCall> PrepareListDbServicesAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class ListDbServicesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<DbService>>
    {
        public ListDbServicesApiCall(IHttpApiCall<ReadOnlyCollectionPage<DbService>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbService GetDbService(string serviceId, string region = null, CloudIdentity identity = null);
    // Task<GetDbServiceApiCall> PrepareGetDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class GetDbServiceApiCall : DelegatingHttpApiCall<DbService>
    {
        public GetDbServiceApiCall(IHttpApiCall<DbService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbService UpdateDbService(string serviceId, string serviceName, string region = null, CloudIdentity identity = null);
    // Task<UpdateDbServiceApiCall> PrepareUpdateDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class UpdateDbServiceApiCall : DelegatingHttpApiCall<DbService>
    {
        public UpdateDbServiceApiCall(IHttpApiCall<DbService> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteDbService(string serviceId, string region = null, CloudIdentity identity = null);
    // Task<DeleteDbServiceApiCall> PrepareDeleteDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class DeleteDbServiceApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteDbServiceApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbServiceQuota GetDbServiceQuota(string serviceId, string region = null, CloudIdentity identity = null);
    // Task<GetDbServiceQuotaApiCall> PrepareGetDbServiceQuotaAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class GetDbServiceQuotaApiCall : DelegatingHttpApiCall<DbServiceQuota>
    {
        public GetDbServiceQuotaApiCall(IHttpApiCall<DbServiceQuota> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota, string region = null, CloudIdentity identity = null);
    // Task<UpdateDbServiceQuotaApiCall> PrepareUpdateDbServiceQuotaAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class UpdateDbServiceQuotaApiCall : DelegatingHttpApiCall<DbServiceQuota>
    {
        public UpdateDbServiceQuotaApiCall(IHttpApiCall<DbServiceQuota> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool SetDbServiceBackup(string databaseId, bool enabled, string region = null, CloudIdentity identity = null);
    // Task<SetDbServiceBackupApiCall> PrepareSetDbServiceBackupAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class SetDbServiceBackupApiCall : DelegatingHttpApiCall<bool>
    {
        public SetDbServiceBackupApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null, string region = null, CloudIdentity identity = null);
    // Task<CreateDatabaseApiCall> PrepareCreateDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class CreateDatabaseApiCall : DelegatingHttpApiCall<Database>
    {
        public CreateDatabaseApiCall(IHttpApiCall<Database> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<Database> ListDatabases(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
    // Task<ListDatabasesApiCall> PrepareListDatabasesAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class ListDatabasesApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<Database>>
    {
        public ListDatabasesApiCall(IHttpApiCall<ReadOnlyCollectionPage<Database>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Database GetDatabase(string databaseId, string region = null, CloudIdentity identity = null);
    // Task<GetDatabaseApiCall> PrepareGetDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class GetDatabaseApiCall : DelegatingHttpApiCall<Database>
    {
        public GetDatabaseApiCall(IHttpApiCall<Database> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // Database UpdateDatabase(string databaseId, string memo = null, string region = null, CloudIdentity identity = null);
    // Task<UpdateDatabaseApiCall> PrepareUpdateDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class UpdateDatabaseApiCall : DelegatingHttpApiCall<Database>
    {
        public UpdateDatabaseApiCall(IHttpApiCall<Database> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteDatabase(string databaseId, string region = null, CloudIdentity identity = null);
    // Task<DeleteDatabaseApiCall> PrepareDeleteDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class DeleteDatabaseApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteDatabaseApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbGrant CreateDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null);
    // Task<CreateDbGrantApiCall> PrepareCreateDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class CreateDbGrantApiCall : DelegatingHttpApiCall<DbGrant>
    {
        public CreateDbGrantApiCall(IHttpApiCall<DbGrant> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<DbGrant> ListDbGrant(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
    // Task<ListDbGrantApiCall> PrepareListDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class ListDbGrantApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<DbGrant>>
    {
        public ListDbGrantApiCall(IHttpApiCall<ReadOnlyCollectionPage<DbGrant>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null);
    // Task<DeleteDbGrantApiCall> PrepareDeleteDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class DeleteDbGrantApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteDbGrantApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
    // Task<ListDbBackupsApiCall> PrepareListDbBackupsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class ListDbBackupsApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<DbBackup>>
    {
        public ListDbBackupsApiCall(IHttpApiCall<ReadOnlyCollectionPage<DbBackup>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool RestoreDatabase(string databaseId, string backupId, string region = null, CloudIdentity identity = null);
    // Task<RestoreDatabaseApiCall> PrepareRestoreDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class RestoreDatabaseApiCall : DelegatingHttpApiCall<bool>
    {
        public RestoreDatabaseApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null, string region = null, CloudIdentity identity = null);
    // Task<CreateDbUserApiCall> PrepareCreateDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class CreateDbUserApiCall : DelegatingHttpApiCall<DbUser>
    {
        public CreateDbUserApiCall(IHttpApiCall<DbUser> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<DbUser> ListDbUsers(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
    // Task<ListDbUsersApiCall> PrepareListDbUsersAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class ListDbUsersApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<DbUser>>
    {
        public ListDbUsersApiCall(IHttpApiCall<ReadOnlyCollectionPage<DbUser>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbUser GetDbUser(string userId, string region = null, CloudIdentity identity = null);
    // Task<GetDbUserApiCall> PrepareGetDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class GetDbUserApiCall : DelegatingHttpApiCall<DbUser>
    {
        public GetDbUserApiCall(IHttpApiCall<DbUser> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // DbUser UpdateDbUser(string userId, string password = null, string memo = null, string region = null, CloudIdentity identity = null);
    // Task<UpdateDbUserApiCall> PrepareUpdateDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class UpdateDbUserApiCall : DelegatingHttpApiCall<DbUser>
    {
        public UpdateDbUserApiCall(IHttpApiCall<DbUser> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteDbUser(string userId, string region = null, CloudIdentity identity = null);
    // Task<DeleteDbUserApiCall> PrepareDeleteDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class DeleteDbUserApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteDbUserApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool SetDbServiceStatus(string serviceId, bool enabled, string region = null, CloudIdentity identity = null);
    // Task<SetDbServiceStatusApiCall> PrepareSetDbServiceStatusAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken);
    public class SetDbServiceStatusApiCall : DelegatingHttpApiCall<bool>
    {
        public SetDbServiceStatusApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

}
