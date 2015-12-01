namespace ConoHaNet.Services.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using BlockStorage;
    using OpenStack.Net;

    /// <summary>
    /// Extends <see cref="SimpleServer"/> with detailed information about a server.
    /// </summary>
    /// <seealso cref="IComputeProvider.GetDetails"/>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Get_Server_Details-d1e2623.html">Get Server Details (OpenStack Compute API v2 and Extensions Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class Server : SimpleServer
    {
        private SimpleServerImage _image;

        /// <summary>
        /// Gets the disk configuration used for creating, rebuilding, or resizing the server.
        /// If the value was not explicitly specified in the create, rebuild, or resize request,
        /// the server inherits the value from the image it was created from.
        /// </summary>
        /// <remarks>
        /// <note>This property is defined by the Rackspace-specific Disk Configuration Extension to the OpenStack Compute API.</note>
        /// </remarks>
        /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/ch_extensions.html#diskconfig_attribute">Disk Configuration Extension (Rackspace Next Generation Cloud Servers Developer Guide - API v2)</seealso>
        [JsonProperty("OS-DCF:diskConfig")]
        public DiskConfiguration DiskConfig { get; private set; }

        /// <summary>
        /// Gets the power state for the server.
        /// </summary>
        /// <remarks>
        /// <note>This property is defined by the Rackspace-specific Extended Status Extension to the OpenStack Compute API.</note>
        /// </remarks>
        /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/ch_extensions.html#power_state">OS-EXT-STS:power_state (Rackspace Next Generation Cloud Servers Developer Guide - API v2)</seealso>
        [JsonProperty("OS-EXT-STS:power_state")]
        public PowerState PowerState { get; private set; }

        /// <summary>
        /// Gets the task state for the server.
        /// </summary>
        /// <remarks>
        /// <note>This property is defined by the Rackspace-specific Extended Status Extension to the OpenStack Compute API.</note>
        /// </remarks>
        /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/ch_extensions.html#task_state">OS-EXT-STS:task_state (Rackspace Next Generation Cloud Servers Developer Guide - API v2)</seealso>
        [JsonProperty("OS-EXT-STS:task_state")]
        public TaskState TaskState { get; private set; }

        /// <summary>
        /// Gets the virtual machine (VM) state for the server.
        /// </summary>
        /// <remarks>
        /// <note>This property is defined by the Rackspace-specific Extended Status Extension to the OpenStack Compute API.</note>
        /// </remarks>
        /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/ch_extensions.html#vm_state">OS-EXT-STS:vm_state (Rackspace Next Generation Cloud Servers Developer Guide - API v2)</seealso>
        [JsonProperty("OS-EXT-STS:vm_state")]
        public VirtualMachineState VMState { get; private set; }

        /// <summary>
        /// Gets the public IP version 4 access address.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("accessIPv4")]
        public string AccessIPv4 { get; private set; }

        /// <summary>
        /// Gets the public IP version 6 access address.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("accessIPv6")]
        public string AccessIPv6 { get; private set; }

        /// <summary>
        /// Gets the user ID for the server.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; private set; }

        /// <summary>
        /// Gets basic information about the image the server was created from.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("image")]
        public SimpleServerImage Image
        {
            get
            {
                // this is handled in the getter because the Provider/Region/Identity
                // properties of the current instance might not be set at the point
                // this property is set
                if (_image != null)
                {
                }

                return _image;
            }

            private set
            {
                _image = value;
            }
        }

        /// <summary>
        /// Gets the server status.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("status")]
        public ServerState Status
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets basic information about the flavor for the server.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("flavor")]
        public Flavor Flavor { get; private set; }

        /// <summary>
        /// Gets the public and private IP addresses for the server.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("addresses")]
        public ServerAddresses Addresses { get; private set; }

        /// <summary>
        /// Gets the time stamp for the creation date.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; private set; }

        /// <summary>
        /// Gets the host ID for the server.
        /// </summary>
        /// <remarks>
        /// The compute provisioning algorithm has an anti-affinity property that attempts
        /// to spread customer VMs across hosts. Under certain situations, VMs from the
        /// same customer might be placed on the same host. The Host ID represents the host
        /// your server runs on and can be used to determine this scenario if it is relevant
        /// to your application.
        ///
        /// <para><see cref="HostId"/> is unique <em>per account</em> and is not globally unique.</para>
        /// </remarks>
        [JsonProperty("hostId")]
        public string HostId { get; private set; }

        /// <summary>
        /// Gets the build completion progress, as a percentage.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        /// <value>A percentage from 0 to 100 (inclusive) representing the build completion progress.</value>
        [JsonProperty("progress")]
        public int Progress { get; private set; }

        /// <summary>
        /// Gets the tenant ID of the server.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        /// <seealso cref="Tenant.Id"/>
        [JsonProperty("tenant_id")]
        public string TenantId { get; private set; }

        /// <summary>
        /// Gets the time stamp for the last update.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; private set; }

        /// <inheritdoc/>
        protected void UpdateThis(Server server)
        {
            if (server == null)
                throw new ArgumentNullException("server");

            base.UpdateThis(server);

            var details = server as Server;

            if (details == null)
                return;

            DiskConfig = details.DiskConfig;
            PowerState = details.PowerState;
            TaskState = details.TaskState;
            VMState = details.VMState;
            AccessIPv4 = details.AccessIPv4;
            AccessIPv6 = details.AccessIPv6;
            UserId = details.UserId;
            Image = details.Image;
            Status = details.Status;
            Flavor = details.Flavor;
            Addresses = details.Addresses;
            Created = details.Created;
            HostId = details.HostId;
            Progress = details.Progress;
            TenantId = details.TenantId;
            Updated = details.Updated;
        }
    }
}
