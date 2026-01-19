using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace apiFumetti22
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Servizi e configurazione dell'API Web

            var cors = new EnableCorsAttribute(
                "http://localhost:4200", // Angular
                "*",
                "*"
            );

            config.EnableCors(cors);

            // Route dell'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{p1}/{p2}/{p3}",                  
                defaults: new { action = RouteParameter.Optional,
                                p1 = RouteParameter.Optional,
                                p2 = RouteParameter.Optional,
                                p3 = RouteParameter.Optional
                }
            );
        }
    }
}
