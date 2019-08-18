using System.Threading.Tasks;
using System.Web.Mvc;
using GitHubUsersIntegration.Controllers;
using GitHubUsersIntegration.Logging;
using GitHubUsersIntegration.Models.ViewModels;
using GitHubUsersIntegration.Repositories.GitHub;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubUsersIntegration.Tests.Controllers
{
    [TestClass]
    public class GitHubControllerTest
    {
        [TestMethod]
        public async Task TestSearchUsersAction()
        {
            // Arrange
            GitHubController controller = new GitHubController(new GitHubConnectionMock(), new ErrorLogger());

            // Act
            var result = await controller.SearchUsers("sohail92");

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async  Task TestSearchUsers_Model_As_Expected()
        {
            // Arrange
            GitHubController controller = new GitHubController(new GitHubConnectionMock(), new ErrorLogger());

            // Act
            ViewResult result = await controller.SearchUsers("sohail92") as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(UserRepoVM));
        }
    }
}
