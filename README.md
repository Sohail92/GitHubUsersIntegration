# GitHub Users Integration
A Web App integrating with the GitHub REST API
When you search for a GitHub username the users top 5 repos (ordered by highest stargazer counts) will be displayed

In this project I have aimed to keep my code SOLID and DRY. Some of the techniques and technologies used include:
- .NET Framework Web Application with MVC structure.
- Latest stable version of Bootstrap (v4.3.1) for responsiveness and elements such as nav-bar and text input box.
- Dependency Inversion via an IoC Container (Ninject).
- Generics (when making Web Requests) to limit code duplication / aid re-use.
- Seperate classes for seperate areas (e.g. ErrorLogger, WebRequestHelper etc).
- Configuration values used from Web.Config where applicable.
- Error logging to file in project root. The repo could be swapped out to log to a DB e.g. CosmosDB.
- Unit Testing (MSTest and nUnit).

![AppImage](https://raw.githubusercontent.com/Sohail92/GitHubUsersIntegration/master/screenshot.jpg)
