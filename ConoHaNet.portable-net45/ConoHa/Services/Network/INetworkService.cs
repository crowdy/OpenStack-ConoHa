namespace ConoHaNet.Services
{
    using ConoHa.Services;
    using OpenStack.Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the base interface for the ConoHa Compute Service V1.
    /// </summary>
    /// <seealso href="">OpenStack Compute API V1 Reference</seealso>
    /// <preliminary/>
    public interface INetworkService : IHttpService, IExtensibleService<INetworkService>
    {
        #region ConoHa

        // IEnumerable<CloudNetwork> ListNetworks(CloudIdentity identity = null);
        Task<ListNetworksApiCall> PrepareListNetworksAsync(CancellationToken cancellationToken);

        // CloudNetwork CreateNetwork(string cidr, string label, CloudIdentity identity = null);
        Task<CreateNetworkApiCall> PrepareCreateNetworkAsync(string cidr, string label, CancellationToken cancellationToken);

        // CloudNetwork ShowNetwork(string networkId, CloudIdentity identity = null);
        Task<ShowNetworkApiCall> PrepareShowNetworkAsync(string networkId, CancellationToken cancellationToken);

        // bool DeleteNetwork(string networkId, CloudIdentity identity = null);
        Task<DeleteNetworkApiCall> PrepareDeleteNetworkAsync(string networkId, CancellationToken cancellationToken);

        // bool AssociateHealthMonitor(string monitorId, string poolId, CloudIdentity identity = null);
        Task<AssociateHealthMonitorApiCall> PrepareAssociateHealthMonitorAsync(string monitorId, string poolId, CancellationToken cancellationToken);

        // IEnumerable<PortBlock> GetPortBlocks(string tenantId, string portId = null, string serverId = null, CloudIdentity identity = null);
        Task<GetPortBlocksApiCall> PrepareGetPortBlocksAsync(string tenantId, string portId = null, string serverId = null, CancellationToken cancellationToken = default(CancellationToken));

        // IEnumerable<PortBlock> SetPortBlocks(string portId, int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictPortProtocol, CloudIdentity identity = null);
        Task<SetPortBlocksApiCall> PrepareSetPortBlocksAsync(string portId, int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictPortProtocol, CancellationToken cancellationToken);
        
        #endregion
    }
}
