using System.Web.Http;
using WebActivatorEx;
using Cycloid.API;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Cycloid.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Cycloid.API");
                        c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Cycloid.API.xml");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
