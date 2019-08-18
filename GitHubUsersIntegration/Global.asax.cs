using GitHubUsersIntegration.Ninject.Resolver;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GitHubUsersIntegration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // Set DependencyResolver to Ninject
            DependencyResolver.SetResolver(new NinjectDependencyResolver());

        }
    }
}
