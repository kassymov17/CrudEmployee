using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using CrudEmployee.Web.App_Start;

namespace CrudEmployee.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
