using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BasicAuthenticationWebAPI.Models;

namespace BasicAuthenticationWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //To enable BasicwebAppauthentication for the entire web app
           // config.Filters.Add(new BasicAuthenticationAttribute());

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
