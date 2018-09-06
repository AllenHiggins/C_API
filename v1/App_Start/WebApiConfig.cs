using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace v1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /* 
             * GLOBEL CORS ACCROSS ALL CONTROLLERS - also known as a "white list"
             * 
             * Added for Cross Origin Resource Sharing (Access-Control-Allow-Origin web browser security issue)
             * Reqiured as the GUI will be its owen project THE V in MVC
             * The API should be only the Model and Controller, that was any front-facing end or device can use this API
             * For example Angular http:\//localhost:4200 or use '*' for all ports or comma seperated "one port,another port"
             * Second argument is for headers and thrid is for POST, GET, PUT... work the same as the first argument
             */
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

        }
    }
}
