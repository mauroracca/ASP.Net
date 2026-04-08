using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace server
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

            // CODICE AGGIUNTO PER LA GESTIONE DELLE CREDENZIALI (COOKIE) NELLE RICHIESTE CROSS-ORIGIN
            // SERVE PER MANTENERE LA SESSIONE ATTIVA TRA LE RICHIESTE DELL'API WEB E IL CLIENT ANGULAR
            // SENZA QUESTO CODICE, LE RICHIESTE CROSS-ORIGIN NON INCLUDEREBBERO I COOKIE DI SESSIONE,
            // E QUINDI LA SESSIONE NON SAREBBE MANTENUTA TRA LE RICHIESTE
            // AGGIUNTO ANCHE SUL WEB.CONFIG L'IMPOSTAZIONE DEL TIMING DI SESSIONE ESPRESSO IN MINUTI
            // <sessionState timeout="1" /> NELLA SEZIONE <system.web> DEL WEB.CONFIG
            // SU GLOBAL.ASAX SI DEVE ANCHE AGGIUNGERE IL CODICE PER ABILITARE LA SESSIONE
            // NELLE RICHIESTE DELL'API WEB, COME MOSTRATO NEL FILE GLOBAL.ASAX.CS
            // protected void Application_PostAuthorizeRequest()
            // {
            //    System.Web.HttpContext.Current.SetSessionStateBehavior(
            //        System.Web.SessionState.SessionStateBehavior.Required
            //    );
            // }
            cors.SupportsCredentials = true;

            config.EnableCors(cors);

            // Forza camelCase in tutti i JSON restituiti dall'API
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            // Route dell'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{p1}/{p2}",
                defaults: new {
                    action = RouteParameter.Optional,
                    p1 = RouteParameter.Optional,
                    p2 = RouteParameter.Optional
                }
            );
        }
    }
}
