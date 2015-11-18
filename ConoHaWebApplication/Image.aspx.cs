using ConoHaNet;
using ConoHaNet.Objects.Images;
using net.openstack.Core.Exceptions.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YamlDotNet.Serialization;

namespace ConoHaWebApplication
{
    public partial class Image : AbstractConoHaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer(SerializationOptions.DefaultToStaticType); // to ignore reference type lit System.Net.IpAddres
            var writer = new StringWriter();

            // DbService
            IEnumerable<CloudImage> images = null;
            try
            {
                images = osm.ListGlanceImages(region: Region);
                if (images.Count() == 0)
                {
                    ltSummary.Text = "no Image.";
                }
                else
                {
                    var sb = new StringBuilder();
                    sb.Append(images.Count() + " Images.\n");
                    sb.Append(images.Where(i => i.Visibility == "public").Count() + " public images\n");
                    sb.Append(images.Where(i => i.Visibility == "private").Count() + " private images\n");

                    ltSummary.Text = sb.ToString();

                    foreach (var i in images.Where(i => i.Visibility == "private"))
                    {
                        writer.Write("===================================\n");
                        var image = osm.GetGlanceImage(i.Id, Region);
                        serializer.Serialize(writer, image);

                        var extensiondata = image.ExtensionData;
                        writer.Write("--ExtensionData--\n");
                        foreach (var key in extensiondata.Keys)
                        {
                            writer.Write(String.Format("{0} : {1}\n", key, extensiondata[key] == null ? "null" : extensiondata[key].ToString()));
                        }

                    }
                    ltImages.Text = writer.ToString();
                }
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltImages.Text = re.Response.RawBody;
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }

        }
    }
}