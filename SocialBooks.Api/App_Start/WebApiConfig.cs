using System.Web.Http;
using Newtonsoft.Json;

namespace SocialBooks.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Configuração de Serialização JSON indicando:
            // 1. Não inclusão de propriedades com valores Nulls
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            config.Formatters.JsonFormatter.SerializerSettings = jsonSerializerSettings;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
