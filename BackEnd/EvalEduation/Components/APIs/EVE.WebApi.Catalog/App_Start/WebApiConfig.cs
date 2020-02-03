﻿using System.Web.Http;
using EVE.WebApi.Shared.Filter;
using FluentValidation.WebApi;

namespace EVE.WebApi.Catalog
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ValidateFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new
                                                                                                             {
                                                                                                                     id = RouteParameter.Optional
                                                                                                             });

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
