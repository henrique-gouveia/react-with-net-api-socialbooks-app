using System.Globalization;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;

namespace SocialBooks.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Habilita Requisições Cross-Origin
            var cors = new EnableCorsAttribute("http://localhost:8080", "*", "*");
            config.EnableCors(cors);

            // Configuração de Serialização JSON indicando:
            // 1. Não inclusão de propriedades com valores Nulls
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                Culture = CultureInfo.GetCultureInfo("pt-BR"),
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
