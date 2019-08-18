using GitHubUsersIntegration.Interfaces;
using GitHubUsersIntegration.Logging;
using GitHubUsersIntegration.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GitHubUsersIntegration.Ninject.Resolver
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        /// <summary>
        /// The bindings are specified here. If the app was to grow (or for a larger app) we could create NinjectModules that specificy logical bindings.
        /// </summary>
        private void AddBindings()
        {
            // Here I have added the repository we should be using for our GitHub Connection.
            // This could be swapped out for a mock repository or a newer version at a later date as required.
            _kernel.Bind<IConnectToGitHub>().To<GitHubConnection>();

            // Bound error logging functionality. Could swap this out for a repo in the future that logs to a database? E.g. Azure Cosmos DB or AWS DynamoDB
            _kernel.Bind<ILogErrors>().To<ErrorLogger>();
        }
    }
}