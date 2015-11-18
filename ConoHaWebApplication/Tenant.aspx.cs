using ConoHaNet.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YamlDotNet.Serialization;

namespace ConoHaWebApplication
{
    public partial class Tenant : AbstractConoHaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer(SerializationOptions.DefaultToStaticType); // to ignore reference type lit System.Net.IpAddres
            var writer = new StringWriter();

            // UserAccess
            var ua = osm.CreateUserAccess();
            writer.Write("===================================\n");
            serializer.Serialize(writer, osm.CreateUserAccess());

            var extensiondata = ua.ExtensionData;
            writer.Write("--ExtensionData--\n");
            foreach (string key in extensiondata.Keys)
            {
                writer.Write(String.Format("{0} : {1}\n", key, extensiondata[key] == null ? "null" : extensiondata[key].ToString()));
            }


            ltUserAccess.Text = writer.ToString();
            writer.GetStringBuilder().Clear();

            // Owner User
            var ownerUser = osm.ListTenantUsers(osm.TenantId).SingleOrDefault<User>(u => u.Username == this.UserName);
            writer.Write("===================================\n");
            serializer.Serialize(writer, ownerUser);

            if (ownerUser == null)
            {
                ltOwnerUser.Text = "no owner user";
            }
            else
            {
                extensiondata = ownerUser.ExtensionData;
                writer.Write("--ExtensionData--\n");
                foreach (string key in extensiondata.Keys)
                {
                    writer.Write(String.Format("{0} : {1}\n", key, extensiondata[key] == null ? "null" : extensiondata[key].ToString()));
                }
                ltOwnerUser.Text = writer.ToString();
                writer.GetStringBuilder().Clear();
            }

        }
    }
}