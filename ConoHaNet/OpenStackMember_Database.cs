namespace ConoHaNet
{
    using Objects.Database;
    using Providers;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class OpenStackMember : IOpenStackMember
    {

        private CloudDatabaseProvider _DatabaseProvider = null;

        /// <inheritdoc/>
        public CloudDatabaseProvider DatabaseProvider
        {
            get
            {
                if (_DatabaseProvider == null)
                {
                    _DatabaseProvider = new CloudDatabaseProvider(this.Identity, this.DefaultRegion, this.IdentityProvider, null, this.IsAdminMode);
                    Trace.WriteLine("CloudDatabaseProvider created.");

                }
                return _DatabaseProvider;
            }
        }


        #region Services

        /// <inheritdoc/>
        public DbService CreateDbService(string serviceName, string region = null)
        {
            return DatabaseProvider.CreateDbService(serviceName, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<DbService> ListDbServices(int? lineCount = null, int? pageNo = null, string sortKey = null, string sortType = null, string region = null)
        {
            return DatabaseProvider.ListDbServices(lineCount, pageNo, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public DbService GetDbService(string serviceId, string region = null)
        {
            return DatabaseProvider.GetDbService(serviceId, region, Identity);
        }

        /// <inheritdoc/>
        public DbService UpdateDbService(string serviceId, string serviceName, string region = null)
        {
            return DatabaseProvider.UpdateDbService(serviceId, serviceName, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDbService(string serviceId, string region = null)
        {
            return DatabaseProvider.DeleteDbService(serviceId, region, Identity);
        }

        /// <inheritdoc/>
        public DbServiceQuota GetDbServiceQuota(string serviceId, string region = null)
        {
            return DatabaseProvider.GetDbServiceQuota(serviceId, region, Identity);
        }

        /// <inheritdoc/>
        public DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota, string region = null)
        {
            return DatabaseProvider.UpdateDbServiceQuota(serviceId, quota, region, Identity);
        }

        /// <inheritdoc/>
        public bool SetDbServiceBackup(string serviceId, bool enabled, string region = null)
        {
            return DatabaseProvider.SetDbServiceBackup(serviceId, enabled, region, Identity);
        }

        #endregion

        #region Databases

        /// <inheritdoc/>
        public Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null, string region = null)
        {
            return DatabaseProvider.CreateDatabase(serviceId, dbName, type, charset, memo, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Database> ListDatabases(string serviceId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return DatabaseProvider.ListDatabases(serviceId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public Database GetDatabase(string databaseId, string region = null)
        {
            return DatabaseProvider.GetDatabase(databaseId, region, Identity);
        }

        /// <inheritdoc/>
        public Database UpdateDatabase(string databaseId, string memo = null, string region = null)
        {
            return DatabaseProvider.UpdateDatabase(databaseId, memo, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDatabase(string databaseId, string region = null)
        {
            return DatabaseProvider.DeleteDatabase(databaseId, region, Identity);
        }

        #endregion

        #region Grant

        /// <inheritdoc/>
        public DbGrant CreateDbGrant(string databaseId, string userId, string region = null)
        {
            return DatabaseProvider.CreateDbGrant(databaseId, userId, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<DbGrant> ListDbGrant(string databaseId, int? lineCount = null, int? pageNo = null, string sortKey = null, string sortType = null, string region = null)
        {
            return DatabaseProvider.ListDbGrant(databaseId, lineCount, pageNo, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDbGrant(string databaseId, string userId, string region = null)
        {
            return DatabaseProvider.DeleteDbGrant(databaseId, userId, region, Identity);
        }

        #endregion


        #region Backups

        /// <inheritdoc/>
        public IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return DatabaseProvider.ListDbBackups(databaseId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public bool RestoreDatabase(string databaseId, string backupId, string region = null)
        {
            return DatabaseProvider.RestoreDatabase(databaseId, backupId, region, Identity);
        }

        #endregion

        #region Users

        /// <inheritdoc/>
        public DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null, string region = null)
        {
            return DatabaseProvider.CreateDbUser(serviceId, username, password, hostname, memo, region, Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<DbUser> ListDbUsers(string serviceId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null, string region = null)
        {
            return DatabaseProvider.ListDbUsers(serviceId, offset, limit, sortKey, sortType, region, Identity);
        }

        /// <inheritdoc/>
        public DbUser GetDbUser(string userId, string region = null)
        {
            return DatabaseProvider.GetDbUser(userId, region, Identity);
        }

        /// <inheritdoc/>
        public DbUser UpdateDbUser(string userId, string password = null, string memo = null, string region = null)
        {
            return DatabaseProvider.UpdateDbUser(userId, password, memo, region, Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDbUser(string userId, string region = null)
        {
            return DatabaseProvider.DeleteDbUser(userId, region, Identity);
        }

        #endregion
    }
}