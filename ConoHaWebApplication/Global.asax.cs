using ConoHaNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ConoHaWebApplication
{

    /*
    install-package openstack.net
    install-package YamlDotNet
    */

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class AbstractConoHaPage : System.Web.UI.Page
    {

        private IOpenStackMember _osm;
        protected IOpenStackMember osm
        {
            get
            {
                if (_osm == null)
                    _osm = new OpenStackMember(UserName, Password, TenantName, TenantId, Region, bLazyProviderSetting: false);
                return _osm;
            }
        }

        protected string UserName
        {
            get { return Session["UserName"] as string ?? "your_own_username"; }
            set { Session["UserName"] = value; }
        }

        protected string Password
        {
            get { return Session["Password"] as string ?? "your_own_password"; }
            set { Session["Password"] = value; }
        }

        protected string TenantName
        {
            get { return Session["TenantName"] as string ?? "your_own_tenantname"; }
            set { Session["TenantName"] = value; }
        }

        protected string TenantId
        {
            get { return Session["TenantId"] as string ?? "your_own_tenantid"; }
            set { Session["TenantId"] = value; }
        }

        protected string Region
        {
            get { return Session["Region"] as string; }
            set { Session["Region"] = value; }
        }

    }

}