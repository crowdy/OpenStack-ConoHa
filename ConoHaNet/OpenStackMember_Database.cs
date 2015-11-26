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
        public DbService CreateDbService(string serviceName)
        {
            return DatabaseProvider.CreateDbService(serviceName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<DbService> ListDbServices(int? lineCount = null, int? pageNo = null, string sortKey = null, string sortType = null)
        {
            return DatabaseProvider.ListDbServices(lineCount, pageNo, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DbService GetDbService(string serviceId)
        {
            return DatabaseProvider.GetDbService(serviceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DbService UpdateDbService(string serviceId, string serviceName)
        {
            return DatabaseProvider.UpdateDbService(serviceId, serviceName, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDbService(string serviceId)
        {
            return DatabaseProvider.DeleteDbService(serviceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DbServiceQuota GetDbServiceQuota(string serviceId)
        {
            return DatabaseProvider.GetDbServiceQuota(serviceId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DbServiceQuota UpdateDbServiceQuota(string serviceId, int quota)
        {
            return DatabaseProvider.UpdateDbServiceQuota(serviceId, quota, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool SetDbServiceBackup(string serviceId, bool enabled)
        {
            return DatabaseProvider.SetDbServiceBackup(serviceId, enabled, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region Databases

        /// <inheritdoc/>
        public Database CreateDatabase(string serviceId, string dbName, string type = null, string charset = null, string memo = null)
        {
            return DatabaseProvider.CreateDatabase(serviceId, dbName, type, charset, memo, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<Database> ListDatabases(string serviceId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return DatabaseProvider.ListDatabases(serviceId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Database GetDatabase(string databaseId)
        {
            return DatabaseProvider.GetDatabase(databaseId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public Database UpdateDatabase(string databaseId, string memo = null)
        {
            return DatabaseProvider.UpdateDatabase(databaseId, memo, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDatabase(string databaseId)
        {
            return DatabaseProvider.DeleteDatabase(databaseId, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region Grant

        /// <inheritdoc/>
        public DbGrant CreateDbGrant(string databaseId, string userId)
        {
            return DatabaseProvider.CreateDbGrant(databaseId, userId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<DbGrant> ListDbGrant(string databaseId, int? lineCount = null, int? pageNo = null, string sortKey = null, string sortType = null)
        {
            return DatabaseProvider.ListDbGrant(databaseId, lineCount, pageNo, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDbGrant(string databaseId, string userId)
        {
            return DatabaseProvider.DeleteDbGrant(databaseId, userId, this.DefaultRegion, this.Identity);
        }

        #endregion


        #region Backups

        /// <inheritdoc/>
        public IEnumerable<DbBackup> ListDbBackups(string databaseId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return DatabaseProvider.ListDbBackups(databaseId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool RestoreDatabase(string databaseId, string backupId)
        {
            return DatabaseProvider.RestoreDatabase(databaseId, backupId, this.DefaultRegion, this.Identity);
        }

        #endregion

        #region Users

        /// <inheritdoc/>
        public DbUser CreateDbUser(string serviceId, string username, string password, string hostname, string memo = null)
        {
            return DatabaseProvider.CreateDbUser(serviceId, username, password, hostname, memo, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public IEnumerable<DbUser> ListDbUsers(string serviceId, int? offset = null, int? limit = null, string sortKey = null, string sortType = null)
        {
            return DatabaseProvider.ListDbUsers(serviceId, offset, limit, sortKey, sortType, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DbUser GetDbUser(string userId)
        {
            return DatabaseProvider.GetDbUser(userId, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public DbUser UpdateDbUser(string userId, string password = null, string memo = null)
        {
            return DatabaseProvider.UpdateDbUser(userId, password, memo, this.DefaultRegion, this.Identity);
        }

        /// <inheritdoc/>
        public bool DeleteDbUser(string userId)
        {
            return DatabaseProvider.DeleteDbUser(userId, this.DefaultRegion, this.Identity);
        }

        #endregion
    }
}