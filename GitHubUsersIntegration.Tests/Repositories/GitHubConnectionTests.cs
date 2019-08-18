using System;
using System.Threading.Tasks;
using GitHubUsersIntegration.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubUsersIntegration.Tests.Repositories
{
    [TestClass]
    public class GitHubConnectionTests
    {
        #region Tests for Getting User Repo Information e.g. assert name as expected, assert location as expected etc.
        [TestMethod]
        public async Task TestGetUserRepoInformation_For_Sohail92_As_UsernameAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("sohail92");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name == "Sohail Rahman");
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_robconery_As_Username()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("robconery");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name == "Rob Conery");
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_UserNotFoundAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("ABC123USERNOTFOUND_ABC_DEF_GHI");

            // assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Name); // we shouldnt have got details back for this user as they dont exist.
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_robconery_locationAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("robconery");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Location == "Honolulu, HI");
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_sohail92_locationAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("sohail92");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Location == "Middlesbrough, UK");
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_robconery_repos_urlAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("robconery");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ReposUrl == "https://api.github.com/users/robconery/repos");
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_sohail92_repos_urlAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("sohail92");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ReposUrl == "https://api.github.com/users/Sohail92/repos");
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_robconery_avatar_urlAsync()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserInformation("robconery");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.AvatarUrl == "https://avatars0.githubusercontent.com/u/78586?v=4");
        }

        #endregion

        #region Tests for Getting Repos information for a user e.g. where 5 or less returned.
        [TestMethod]
        public async Task TestGetUserRepoInformation_For_sohail92_repos_returned_is_lessThenOrEqualTo_5Async()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserRepoInformation("sohail92");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count <= 5);
        }

        [TestMethod]
        public async Task TestGetUserRepoInformation_For_robconery_repos_returned_is_lessThenOrEqualTo_5Async()
        {
            // arrange
            GitHubConnection gitHubConnection = new GitHubConnection();

            // act
            var result = await gitHubConnection.GetUserRepoInformation("robconery");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count <= 5);
        }
        #endregion

    }
}
