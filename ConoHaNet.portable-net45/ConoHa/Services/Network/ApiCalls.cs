namespace ConoHa.Services
{
    using System;
    using OpenStack.Collections;
    using OpenStack.Net;
    using ConoHaNet.Services.Network;


    // IEnumerable<CloudNetwork> ListNetworks(CloudIdentity identity = null);
    // Task<ListNetworksApiCall> PrepareListNetworksAsync(CancellationToken cancellationToken);
    public class ListNetworksApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<CloudNetwork>>
    {
        public ListNetworksApiCall(IHttpApiCall<ReadOnlyCollectionPage<CloudNetwork>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // CloudNetwork CreateNetwork(string cidr, string label, CloudIdentity identity = null);
    // Task<CreateNetworkApiCall> PrepareCreateNetworkAsync(string cidr, string label, CancellationToken cancellationToken);
    public class CreateNetworkApiCall : DelegatingHttpApiCall<CloudNetwork>
    {
        public CreateNetworkApiCall(IHttpApiCall<CloudNetwork> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // CloudNetwork ShowNetwork(string networkId, CloudIdentity identity = null);
    // Task<ShowNetworkApiCall> PrepareShowNetworkAsync(string networkId, CancellationToken cancellationToken);
    public class ShowNetworkApiCall : DelegatingHttpApiCall<CloudNetwork>
    {
        public ShowNetworkApiCall(IHttpApiCall<CloudNetwork> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool DeleteNetwork(string networkId, CloudIdentity identity = null);
    // Task<DeleteNetworkApiCall> PrepareDeleteNetworkAsync(string networkId, CancellationToken cancellationToken);
    public class DeleteNetworkApiCall : DelegatingHttpApiCall<bool>
    {
        public DeleteNetworkApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // bool AssociateHealthMonitor(string monitorId, string poolId, CloudIdentity identity = null);
    // Task<AssociateHealthMonitorApiCall> PrepareAssociateHealthMonitorAsync(string monitorId, string poolId, CancellationToken cancellationToken);
    public class AssociateHealthMonitorApiCall : DelegatingHttpApiCall<bool>
    {
        public AssociateHealthMonitorApiCall(IHttpApiCall<bool> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<PortBlock> GetPortBlocks(string tenantId, string portId = null, string serverId = null, CloudIdentity identity = null);
    // Task<GetPortBlocksApiCall> PrepareGetPortBlocksAsync(string tenantId, string portId = null, string serverId = null, CancellationToken cancellationToken);
    public class GetPortBlocksApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<PortBlock>>
    {
        public GetPortBlocksApiCall(IHttpApiCall<ReadOnlyCollectionPage<PortBlock>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

    // IEnumerable<PortBlock> SetPortBlocks(string portId, int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictPortProtocol, CloudIdentity identity = null);
    // Task<SetPortBlocksApiCall> PrepareSetPortBlocksAsync(string portId, int bandWidthIn, int bandWidthOut, Dictionary<int, string> dictPortProtocol, CancellationToken cancellationToken);
    public class SetPortBlocksApiCall : DelegatingHttpApiCall<ReadOnlyCollectionPage<PortBlock>>
    {
        public SetPortBlocksApiCall(IHttpApiCall<ReadOnlyCollectionPage<PortBlock>> httpApiCall)
            : base(httpApiCall)
        {
        }
    }

}
