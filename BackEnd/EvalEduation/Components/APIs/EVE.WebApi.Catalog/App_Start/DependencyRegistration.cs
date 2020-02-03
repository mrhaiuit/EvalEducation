using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.WebApi;
using AutoMapper;
using Castle.DynamicProxy;
using EVE.Data;
using EVE.LogManagement.AutoWriteLog;

namespace EVE.WebApi.Catalog
{
    public static class DependencyRegistration
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                   .EnableClassInterceptors();

            builder.RegisterType<UnitOfWork<EVEEntities>>()
                   .As<IUnitOfWork<EVEEntities>>();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                   .InstancePerDependency();

            builder.RegisterType<EVEEntities>()
                   .As<DbContext>()
                   .SingleInstance();

            builder.Register(c => new CallLogger(AppDomain.CurrentDomain.RelativeSearchPath))
                   .Named<IInterceptor>("log-calls");
            RegisterMaps(builder);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterMaps(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                   .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                   .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
                                                          {
                                                              foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                                                              {
                                                                  cfg.AddProfile(profile);
                                                              }
                                                          }))
                   .AsSelf()
                   .SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                                   .CreateMapper(c.Resolve))
                   .As<IMapper>()
                   .InstancePerLifetimeScope();
        }
    }
}
