namespace ConoHaNet.Objects.Identity
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This models the JSON response used for the List Roles and List User Global Roles requests.
    /// </summary>
    /// <seealso href="https://www.google.co.jp/search?q=openstack+">List Roles</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_listUserGlobalRoles_v2.0_users__user_id__roles_User_Operations.html">List User Global Roles (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class RolesResponse
    {
        /// <summary>
        /// Gets a collection of roles.
        /// </summary>
        [JsonProperty("roles")]
        public Role[] Roles { get; private set; }

        /// <summary>
        /// Gets a collection of links related to <see cref="Roles"/>.
        /// </summary>
        [JsonProperty("roles_links")]
        public string[] RoleLinks { get; private set; }
    }

    /// <summary>
    /// This models the JSON response used for the Add Role and Get Role by Name requests.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_addRole_v2.0_OS-KSADM_roles_Role_Operations_OS-KSADM.html">Add Role (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/GET_getRoleByName_v2.0_OS-KSADM_roles_Role_Operations_OS-KSADM.html">Get Role by Name (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class Roles
    {
        /// <summary>
        /// Gets information about the role.
        /// </summary>
        [JsonProperty("role")]
        public Role Role { get; private set; }
    }

    /// <summary>
    /// This models the JSON request used for the Add Role request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-identity-service/2.0/content/POST_addRole_v2.0_OS-KSADM_roles_Role_Operations_OS-KSADM.html">Add Role (OpenStack Identity Service API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class AddRoleRequest
    {
        /// <summary>
        /// Gets additional information about the role to add.
        /// </summary>
        [JsonProperty("role")]
        public Role Role { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddRoleRequest"/> class for the
        /// specified <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="role"/> is <see langword="null"/>.</exception>
        public AddRoleRequest(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            Role = role;
        }
    }
}
