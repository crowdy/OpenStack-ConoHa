using ConoHaNet.Objects.Mails;
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
    public partial class MailPage : AbstractConoHaPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer();
            var writer = new StringWriter();

            // DbService
            IEnumerable<MailService> mailServices = null;
            try
            {
                mailServices = osm.ListMailServices();
                if (mailServices.Count() == 0)
                {
                    ltSummary.Text = "no mail service.";
                }
                else
                {
                    ltSummary.Text = mailServices.Count() + " mail service(s)";

                    foreach (var mailService in mailServices)
                    {
                        writer.Write("===================================\n");
                        serializer.Serialize(writer, mailService);
                    }
                    ltMailService.Text = writer.ToString();
                }
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltMailService.Text = "Forbidden";
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }

        }
    }
}