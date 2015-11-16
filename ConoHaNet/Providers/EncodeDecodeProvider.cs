namespace ConoHaNet.Providers
{
    using ConoHaNet.Objects;

    /// <summary>
    /// Provides a default implementation of <see cref="IEncodeDecodeProvider"/> for
    /// use with ConoHa services. This implementation encodes text using
    /// <see cref="net.openstack.Core.UriUtility"/> with <see cref="net.openstack.Core.UriPart.AnyUrl"/>,
    /// and decodes text with <see cref="net.openstack.Core.UriUtility.UriDecode(string)"/>.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    internal class EncodeDecodeProvider : IEncodeDecodeProvider
    {
        /// <summary>
        /// A default instance of <see cref="EncodeDecodeProvider"/>.
        /// </summary>
        private static readonly EncodeDecodeProvider _default = new EncodeDecodeProvider();

        /// <summary>
        /// Gets a default instance of <see cref="EncodeDecodeProvider"/>.
        /// </summary>
        public static EncodeDecodeProvider Default
        {
            get
            {
                return _default;
            }
        }

        /// <inheritdoc/>
        public string UrlEncode(string stringToEncode)
        {
            if (stringToEncode == null)
                return null;

            return net.openstack.Core.UriUtility.UriEncode(stringToEncode, net.openstack.Core.UriPart.AnyUrl);
        }

        /// <inheritdoc/>
        public string UrlDecode(string stringToDecode)
        {
            if (stringToDecode == null)
                return null;

            return net.openstack.Core.UriUtility.UriDecode(stringToDecode);
        }
    }
}
