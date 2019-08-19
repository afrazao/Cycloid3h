using System.Net.Http.Formatting;
using System.Web.Http;
using Unity;

namespace Cycloid.API
{
    /// <summary>
    /// The web api config class
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register configuration settings
        /// </summary>
        /// <param name="config">The configuration</param>
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            var container = new UnityContainer();

            config.DependencyResolver = new UnityResolver(container);
            
            config.MessageHandlers.Add(new AuthenticationHandler());
        }
    }
}
