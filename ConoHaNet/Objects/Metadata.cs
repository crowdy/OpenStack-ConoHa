namespace ConoHaNet.Objects
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents metadata for servers and images in the Compute Service.
    /// </summary>
    /// <remarks>
    /// The metadata keys for the compute provider are case-sensitive.
    /// </remarks>
    /// <threadsafety static="true" instance="false"/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2229:ImplementSerializationConstructors"), JsonDictionary]
    [Serializable]
    public class Metadata : Dictionary<string, string>
    {
    }
}
