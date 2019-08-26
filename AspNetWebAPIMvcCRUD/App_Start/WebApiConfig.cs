﻿using JsonPatch.Formatting;
using System.Web.Http;
using AspNetWebAPIMvcCRUD.Filters;

namespace AspNetWebAPIMvcCRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ValidationExceptionFilterAttribute());
        }
    }
}