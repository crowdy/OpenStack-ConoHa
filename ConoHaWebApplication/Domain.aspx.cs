using ConoHaNet;
using ConoHaNet.Objects.Dns;
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
    public partial class DomainPage : AbstractConoHaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer();
            var writer = new StringWriter();

            // DbService
            IEnumerable<Domain> domains = null;
            try
            {
                domains = osm.ListDomains();
                if (domains.Count() == 0)
                {
                    ltSummary.Text = "no domain service.";
                }
                else
                {
                    ltSummary.Text = domains.Count() + " domain(s)";

                    foreach (var domain in domains)
                    {
                        writer.Write("===================================\n");
                        serializer.Serialize(writer, domain);
                    }
                    ltDomains.Text = writer.ToString();
                }
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltDomains.Text = "Forbidden";
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }

        }
    }
}