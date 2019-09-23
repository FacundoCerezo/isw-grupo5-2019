using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Realizar_Pedido_de_lo_que_sea
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Configuración y servicios de API web

			// Forzar salida JSON para los servicios REST

			GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
			.Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
				   "text/html",
				   StringComparison.InvariantCultureIgnoreCase,
				   true,
				   "application/json"));

			var settings =
GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;

			// Rutas de API web
			config.MapHttpAttributeRoutes();

			// Fix para uploads en Postman
			GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
