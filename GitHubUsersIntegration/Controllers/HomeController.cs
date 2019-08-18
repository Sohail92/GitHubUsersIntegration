using System.Web.Mvc;

namespace GitHubUsersIntegration.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the homepage view for the index action.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the About page view
        /// </summary>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Returns the Contact page view
        /// </summary>
        public ActionResult Contact()
        {
            return View();
        }
    }
}