using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace MedicalStore
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("H", "Home", "~/Views/Home.aspx");
        }
    }
}