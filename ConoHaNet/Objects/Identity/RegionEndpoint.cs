namespace ConoHaNet.Objects.Identity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class models the JSON representation of region endpoint resource.
    /// </summary>
    public class RegionEndpoint
    {
        /// <summary>
        /// Gets or Sets the service endpoint name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the service region, which is like "tyo1" or "sin1"
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or Sets the service type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets the region endp;oint url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RegionEndpoint(string name, string region, string type, string url)
        {
            this.Name = name;
            this.Region = region;
            this.Type = type;
            this.Url = url;
        }
    }

    /// <summary>
    /// Provides customized region sort order
    /// </summary>
    public class CustomRegionComparator : IComparer<RegionEndpoint>
    {
        /// <summary>
        /// Gets the sort order of region names which ConoHa provides
        /// </summary>
        protected readonly string[] customOrder = { "tyo1", "sin1", "sjc1" };

        /// <summary>
        /// Sorts the elements of region in ascending order according to customOrder.
        /// </summary>
        int IComparer<RegionEndpoint>.Compare(RegionEndpoint x, RegionEndpoint y)
        {
            int thisIndex = Array.FindIndex(customOrder, s => s == x.Region);
            int thatIndex = Array.FindIndex(customOrder, s => s == y.Region);
            if (thisIndex < 0 | thatIndex < 0)
                return x.Region.CompareTo(y.Region);
            else
                return thisIndex.CompareTo(thatIndex);
        }

    }
}
