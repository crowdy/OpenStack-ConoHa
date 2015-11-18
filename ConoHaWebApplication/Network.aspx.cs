using ConoHaNet;
using ConoHaNet.Objects.Networks;
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
    public partial class Network : AbstractConoHaPage
    {
        protected IEnumerable<Subnet> subnets { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new Serializer();
            var writer = new StringWriter();

            // Additional Ip subnets
            var addSubnets = osm.ListSubnets(Region)
                .Where<Subnet>(s => s.IpVersion == 4 && s.Name.StartsWith("add"));
            foreach (var s in addSubnets)
            {
                writer.Write("===================================\n");
                var subnet = osm.GetSubnet(s.Id, Region);
                serializer.Serialize(writer, subnet);
            }

            ltAddSubnets.Text = writer.ToString();
            writer.GetStringBuilder().Clear();

            // Local Network subnets
            var localSubnets = osm.ListSubnets(Region)
                .Where<Subnet>(s => s.IpVersion == 4 && s.Name.StartsWith("local-"));

            foreach (var s in localSubnets)
            {
                writer.Write("===================================\n");
                var subnet = osm.GetSubnet(s.Id, Region);
                serializer.Serialize(writer, subnet);
            }

            ltLocalSubnets.Text = writer.ToString();
            writer.GetStringBuilder().Clear();

            // Ports
            var ports = osm.ListPorts(Region);
            foreach (var p in ports)
            {
                writer.Write("===================================\n");
                var subnet = osm.GetPort(p.Id, Region);
                serializer.Serialize(writer, subnet);
            }

            ltPorts.Text = writer.ToString();
            writer.GetStringBuilder().Clear();

            // Security Groups
            var groups = osm.ListNetworkSecurityGroups(Region);
            foreach (var g in groups)
            {
                writer.Write("===================================\n");
                var group = osm.GetNetworkSecurityGroup(g.Id, Region);
                serializer.Serialize(writer, group);
            }

            ltSecurityGroups.Text = writer.ToString();
            writer.GetStringBuilder().Clear();

        }
    }
}