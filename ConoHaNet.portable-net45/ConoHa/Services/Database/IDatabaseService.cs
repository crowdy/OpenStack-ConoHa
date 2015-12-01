namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using OpenStack.Services;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface IDatabaseService : IHttpService, IExtensibleService<IDatabaseService>
    {
        #region ConoHa

        // DatabaseServiceVersion GetVersion();
        Task<GetVersionApiCall> PrepareGetVersionAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DatabaseServiceVersion GetVersionDetails();
        Task<GetVersionDetailsApiCall> PrepareGetVersionDetailsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbService CreateDbService(string serviceName, string region = null, CloudIdentity identity = null);
        Task<CreateDbServiceApiCall> PrepareCreateDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<DbService> ListDbServices(int? offset = null, int? limit = null, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
        Task<ListDbServicesApiCall> PrepareListDbServicesAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbService GetDbService(string serviceId, string region = null, CloudIdentity identity = null);
        Task<GetDbServiceApiCall> PrepareGetDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbService UpdateDbService(string serviceId, string serviceName, string region = null, CloudIdentity identity = null);
        Task<UpdateDbServiceApiCall> PrepareUpdateDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteDbService(string serviceId, string region = null, CloudIdentity identity = null);
        Task<DeleteDbServiceApiCall> PrepareDeleteDbServiceAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbServiceQuota GetDbServiceQuota(string serviceId, string region = null, CloudIdentity identity = null);
        Task<GetDbServiceQuotaApiCall> PrepareGetDbServiceQuotaAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota, string region = null, CloudIdentity identity = null);
        Task<UpdateDbServiceQuotaApiCall> PrepareUpdateDbServiceQuotaAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool SetDbServiceBackup(string databaseId, bool enabled, string region = null, CloudIdentity identity = null);
        Task<SetDbServiceBackupApiCall> PrepareSetDbServiceBackupAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null, string region = null, CloudIdentity identity = null);
        Task<CreateDatabaseApiCall> PrepareCreateDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<Database> ListDatabases(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
        Task<ListDatabasesApiCall> PrepareListDatabasesAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // Database GetDatabase(string databaseId, string region = null, CloudIdentity identity = null);
        Task<GetDatabaseApiCall> PrepareGetDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // Database UpdateDatabase(string databaseId, string memo = null, string region = null, CloudIdentity identity = null);
        Task<UpdateDatabaseApiCall> PrepareUpdateDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteDatabase(string databaseId, string region = null, CloudIdentity identity = null);
        Task<DeleteDatabaseApiCall> PrepareDeleteDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbGrant CreateDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null);
        Task<CreateDbGrantApiCall> PrepareCreateDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<DbGrant> ListDbGrant(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
        Task<ListDbGrantApiCall> PrepareListDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteDbGrant(string databaseId, string userId, string region = null, CloudIdentity identity = null);
        Task<DeleteDbGrantApiCall> PrepareDeleteDbGrantAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
        Task<ListDbBackupsApiCall> PrepareListDbBackupsAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool RestoreDatabase(string databaseId, string backupId, string region = null, CloudIdentity identity = null);
        Task<RestoreDatabaseApiCall> PrepareRestoreDatabaseAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null, string region = null, CloudIdentity identity = null);
        Task<CreateDbUserApiCall> PrepareCreateDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<DbUser> ListDbUsers(string serviceId = null, int? offset = 0, int? limit = 1000, string sortKey = "create_date", string sortType = "asc", string region = null, CloudIdentity identity = null);
        Task<ListDbUsersApiCall> PrepareListDbUsersAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbUser GetDbUser(string userId, string region = null, CloudIdentity identity = null);
        Task<GetDbUserApiCall> PrepareGetDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // DbUser UpdateDbUser(string userId, string password = null, string memo = null, string region = null, CloudIdentity identity = null);
        Task<UpdateDbUserApiCall> PrepareUpdateDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool DeleteDbUser(string userId, string region = null, CloudIdentity identity = null);
        Task<DeleteDbUserApiCall> PrepareDeleteDbUserAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        // bool SetDbServiceStatus(string serviceId, bool enabled, string region = null, CloudIdentity identity = null);
        Task<SetDbServiceStatusApiCall> PrepareSetDbServiceStatusAsync(string serverId, string imageRef, string adminPassword, string keyName = null, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }
}
