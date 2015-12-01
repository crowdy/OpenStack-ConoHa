namespace ConoHaNet.Services.Compute
{
    using System;
    using Newtonsoft.Json;
    using OpenStack.Services.Identity;

    /// <summary>
    /// Provides basic information about an image.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Images-d1e4427.html">Images (OpenStack Compute API v2 and Extensions Reference - API v2)</seealso>
    /// <seealso href="http://docs.rackspace.com/servers/api/v2/cs-devguide/content/Images-d1e4427.html">Images (Rackspace Next Generation Cloud Servers Developer Guide  - API v2)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleServerImage
    {
        /// <summary>
        /// Gets the unique identifier for the image.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty]
        public string Id { get; private set; }

        /// <summary>
        /// Gets a collection of links related to the current image.
        /// </summary>
        /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/LinksReferences.html">Links and References (OpenStack Compute API v2 and Extensions Reference - API v2)</seealso>
        [JsonProperty]
        public Link[] Links { get; private set; }

        /// <summary>
        /// Gets the name of the image.
        /// <note type="warning">The value of this property is not defined. Do not use.</note>
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }


        /// <summary>
        /// Updates the current instance to match the information in <paramref name="serverImage"/>.
        /// </summary>
        /// <remarks>
        /// <note type="implement">
        /// This method should be overridden in derived types to ensure all properties
        /// for the current instance are updated.
        /// </note>
        /// </remarks>
        /// <param name="serverImage">The updated information for the current image.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="serverImage"/> is <see langword="null"/>.</exception>
        protected virtual void UpdateThis(SimpleServerImage serverImage)
        {
            if (serverImage == null)
                throw new ArgumentNullException("serverImage");

            Id = serverImage.Id;
            Links = serverImage.Links;
            Name = serverImage.Name;
        }

        /// <summary>
        /// Deletes the specified image.
        /// </summary>
        /// <returns><see langword="true"/> if the image was successfully deleted; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="net.openstack.Core.Exceptions.Response.ResponseException">If the REST API request failed.</exception>
        /// <seealso cref="IComputeProvider.DeleteImage"/>
        /// <seealso href="http://docs.openstack.org/api/openstack-compute/2/content/Delete_Image-d1e4957.html">Delete Image (OpenStack Compute API v2 and Extensions Reference)</seealso>
        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
