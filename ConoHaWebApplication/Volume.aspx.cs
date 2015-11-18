using ConoHaNet;
using ConoHaNet.Objects;
using net.openstack.Core.Exceptions.Response;
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
    public partial class VolumePage : AbstractConoHaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer(SerializationOptions.DefaultToStaticType); // to ignore reference type lit System.Net.IpAddres
            var writer = new StringWriter();


            // volue
            IEnumerable<Volume> volumes = null;
            try
            {
                volumes = osm.ListVolumes(region: Region);
                if (volumes.Count() == 0)
                {
                    ltSummary.Text = "no volume.";
                }
                else
                {
                    ltSummary.Text = volumes.Count() + " volumes.";

                    foreach (var v in volumes)
                    {
                        writer.Write("===================================\n");
                        var volume = osm.GetVolume(v.Id, Region);
                        serializer.Serialize(writer, volume);

                        var extensiondata = volume.ExtensionData;
                        writer.Write("--ExtensionData--\n");
                        foreach (var key in extensiondata.Keys)
                        {
                            writer.Write(String.Format("{0} : {1}\n", key, extensiondata[key] == null ? "null" : extensiondata[key].ToString()));
                        }

                    }
                    ltVolumes.Text = writer.ToString();
                }
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltVolumes.Text = re.Response.RawBody;
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }

        }
    }
}