using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Autofac;
using EVE.Data;

namespace EVE.Commons
{
    public static class DIConfig
    {
        public static IContainer Configure()
        {
            return GetContainerBuilder()
                    .Build();
        }

        public static ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EVEEntities>()
                   .As<DbContext>();
            builder.RegisterType<UnitOfWork<EVEEntities>>()
                   .As<IUnitOfWork<EVEEntities>>();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                   .InstancePerDependency();
            // Tranportlayer
            var tranportLayer = Assembly.Load("EVE.TransportLayer");
            builder.RegisterAssemblyTypes(tranportLayer)
                  .Where(t => t.Name.EndsWith("Api"));
            builder.RegisterAssemblyTypes(tranportLayer)
                   .Where(t => t.Name == "EVE.TransportLayer")
                   .As(t => t.GetInterfaces()
                             .FirstOrDefault(i => i.Name == "I" + t.Name));
            //Register for all BE Class
            var bussinessAssembly = Assembly.Load("EVE.Bussiness");
            builder.RegisterAssemblyTypes(bussinessAssembly)
                   .Where(t => t.Name.EndsWith("BE"));

            builder.RegisterAssemblyTypes(bussinessAssembly)
                   // .Where(t => t.Name.EndsWith("Repository"));
                   .Where(t => t.Name == "EVE.Bussiness")
                   .As(t => t.GetInterfaces()
                             .FirstOrDefault(i => i.Name == "I" + t.Name));

            //builder.RegisterAssemblyTypes(currentAssembly)
            //     .Where(t => t.Namespace == "EVE.Bussiness")
            //     .AsImplementedInterfaces()
            //     .InstancePerRequest();

            return builder;
        }
    }
}
