namespace ConoHaNet.Objects.Servers
{
    using System;
    using Newtonsoft.Json;
    using Providers;

    /// <summary>
    /// This models the basic JSON description of a server.
    /// </summary>
    /// <seealso cref="IComputeProvider.ListServers"/>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleServer : ServerBase
    {
        /// <summary>
        /// Gets the server name.
        /// <note type="warning">The value of this property is not defined by OpenStack, and may not be consistent across vendors.</note>
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

        /// <inheritdoc/>
        protected override void UpdateThis(ServerBase server)
        {
            if (server == null)
                throw new ArgumentNullException("server");

            base.UpdateThis(server);

            var details = server as SimpleServer;

            if (details == null)
                return;

            Name = details.Name;
        }
    }
}
