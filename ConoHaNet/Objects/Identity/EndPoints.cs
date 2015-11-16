namespace ConoHaNet.Objects.Identity
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON response used for the List Endpoints request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_listEndpointsForToken_v2.0_tokens__tokenId__endpoints_Token_Operations.html">List Token Endpoints (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_listEndpoints__v2.0_tenants__tenantId__OS-KSCATALOG_endpoints_Endpoint_Operations_OS-KSCATALOG.html">List Service Catalog Endpoints (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class ListEndpointsResponse
    {
        /// <summary>
        /// Gets additional information about the endpoints.
        /// </summary>
        /// <seealso cref="UserAccess"/>
        [JsonProperty("endpoints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ExtendedEndpoint[] Endpoints { get; private set; }
    }

    /// <summary>
    /// This class models the JSON representation of the response to the <strong>Get endpoint</strong> HTTP API call in
    /// the OpenStack Identity Service V2.
    /// </summary>
    /// <remarks>
    /// <para>This call is part of the <c>OS-KSCATALOG</c> extension to the OpenStack Identity Service V2.</para>
    /// </remarks>
    /// <seealso href="http://developer.openstack.org/api-ref-identity-v2.html#os-kscatalog-ext">OS-KSCATALOG admin extension (Identity API v2.0 - OpenStack Complete API Reference)</seealso>
    /// <seealso cref="ExtendedEndpoint"/>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class GetEndpointResponse
    {
#pragma warning disable 649 // Field 'fieldName' is never assigned to, and will always have its default value {value}
        /// <summary>
        /// This is the backing field for the <see cref="Endpoint"/> property.
        /// </summary>
        [JsonProperty("endpoint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private ExtendedEndpoint _endpoint;
#pragma warning restore 649

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEndpointResponse"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected GetEndpointResponse()
        {
        }

        /// <summary>
        /// Gets additional information about the endpoint.
        /// </summary>
        /// <value>
        /// <para>An <see cref="ExtendedEndpoint"/> object containing the details of the endpoint.</para>
        /// <token>NullIfNotIncluded</token>
        /// </value>
        public ExtendedEndpoint Endpoint
        {
            get
            {
                return _endpoint;
            }
        }
    }

    /// <summary>
    /// This models the JSON request used for the <strong>Add endpoint</strong> HTTP API request in the OpenStack
    /// Identity Service V2.
    /// </summary>
    /// <remarks>
    /// <para>This object is part of the <c>OS-KSCATALOG</c> extension to the OpenStack Identity Service V2.</para>
    /// </remarks>
    /// <seealso href="http://developer.openstack.org/api-ref-identity-v2.html#os-kscatalog-ext">OS-KSCATALOG admin extension (Identity API v2.0 - OpenStack Complete API Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    /// <preliminary/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AddServiceCatalogEndpointRequest
    {
        /// <summary>
        /// This is the backing field for the <see cref="EndpointTemplateId"/> property.
        /// </summary>
        /// <remarks>
        /// <para>This API call wraps the endpoint template identifier inside an "EndpointTemplateWithOnlyId"
        /// resource.</para>
        /// </remarks>
        [JsonProperty("OS-KSCATALOG:endpointTemplate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private EndpointTemplate _endpointTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceCatalogEndpointRequest"/> class
        /// during JSON deserialization.
        /// </summary>
        [JsonConstructor]
        protected AddServiceCatalogEndpointRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddServiceCatalogEndpointRequest"/> class with the specified
        /// endpoint template identifier.
        /// </summary>
        /// <param name="endpointTemplateId">
        /// The unique identifier of the endpoint template to use for the endpoint.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="endpointTemplateId"/> is <see langword="null"/>.
        /// </exception>
        public AddServiceCatalogEndpointRequest(EndpointTemplateId endpointTemplateId)
        {
            if (endpointTemplateId == null)
                throw new ArgumentNullException("endpointTemplateId");

            _endpointTemplate = new EndpointTemplate(endpointTemplateId);
        }

        /// <summary>
        /// Gets the unique identifier of the endpoint template to use when creating the endpoint.
        /// </summary>
        /// <value>
        /// <para>The unique identifier of the endpoint template to use when creating the endpoint.</para>
        /// <token>NullIfNotIncluded</token>
        /// </value>
        public EndpointTemplateId EndpointTemplateId
        {
            get
            {
                if (_endpointTemplate == null)
                    return null;

                return _endpointTemplate.Id;
            }
        }
    }
}
