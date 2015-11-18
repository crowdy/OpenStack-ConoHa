using ConoHaNet.Objects;
using ConoHaNet.Objects.Servers;
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
    public partial class ServerPage : AbstractConoHaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer(SerializationOptions.DefaultToStaticType); // to ignore reference type lit System.Net.IpAddres
            var writer = new StringWriter();


            // DbService
            IEnumerable<SimpleServer> servers = null;
            try
            {
                servers = osm.ListServers(region: Region);
                if (servers.Count() == 0)
                {
                    ltSummary.Text = "no server.";
                }
                else
                {
                    ltSummary.Text = servers.Count() + " servers.";

                    foreach (var s in servers)
                    {
                        writer.Write("===================================\n");
                        var server = osm.GetServer(s.Id, Region);
                        serializer.Serialize(writer, server, server.GetType());

                        var extensiondata = server.ExtensionData;
                        writer.Write("--Addresses--\n");
                        foreach (var address in server.Addresses)
                        {
                            writer.Write(String.Format("{0}\n", address.Key));
                            foreach (var addr in ((IPAddressList)(address.Value)).ToArray())
                                writer.Write(String.Format("  {0}\n", addr));
                        }
                        writer.Write("--ExtensionData--\n");
                        foreach (string key in extensiondata.Keys)
                        {
                            writer.Write(String.Format("{0} : {1}\n", key, extensiondata[key] == null ? "null" : extensiondata[key].ToString()));
                        }

                        //var metadata = server.GetMetadata();
                        //writer.Write("--Metadata--\n");
                        //foreach (var key in metadata.Keys)
                        //{
                        //    writer.Write(String.Format("{0} : {1}\n", key, metadata[key].ToString()));
                        //}

                    }
                    ltServers.Text = writer.ToString();
                }
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltServers.Text = re.Response.RawBody;
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }

        }
    }
}