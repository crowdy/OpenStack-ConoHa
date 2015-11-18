using ConoHaNet;
using ConoHaNet.Objects.Database;
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

    public partial class DatabasePage : AbstractConoHaPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            var serializer = new Serializer();
            var writer = new StringWriter();

            // DbService
            IEnumerable<DbService> dbServices = null;
            try
            {
                dbServices = osm.ListDbServices(region: Region);
                if (dbServices.Count() == 0)
                {
                    ltSummary.Text = "no db service.";
                }
                else
                {
                    ltSummary.Text = dbServices.Count() + " database(s)";

                    foreach (var dbService in dbServices)
                    {
                        writer.Write("===================================\n");
                        serializer.Serialize(writer, dbService);
                    }
                    ltDbService.Text = writer.ToString();
                }
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltDbService.Text = "Forbidden";
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }


            // Databases
            IEnumerable<Database> databases = null;
            try
            {
                databases = osm.ListDatabases(region: Region);
                foreach (var db in databases)
                {
                    writer.Write("===================================\n");
                    var database = osm.GetDatabase(db.Id, Region);
                    serializer.Serialize(writer, database);
                }
                ltDatabases.Text = writer.ToString();
            }
            catch (ResponseException re)
            {
                if (re.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    ltDatabases.Text = "Forbidden";
            }
            finally
            {
                writer.GetStringBuilder().Clear();
            }

        }
    }
}