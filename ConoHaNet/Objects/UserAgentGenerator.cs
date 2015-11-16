namespace ConoHaNet.Objects
{
    using System;

    /// <summary>
    /// Generates the User-Agent value which identifies this SDK in REST requests.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static class UserAgentGenerator
    {
        private static readonly Version _currentVersion = typeof(UserAgentGenerator).Assembly.GetName().Version;
        private static readonly string _userAgent = string.Format("conoha.net/{0}", _currentVersion);

        /// <summary>
        /// Gets the User-Agent value for this SDK.
        /// </summary>
        public static string UserAgent
        {
            get
            {
                return _userAgent;
            }
        }
    }

}
