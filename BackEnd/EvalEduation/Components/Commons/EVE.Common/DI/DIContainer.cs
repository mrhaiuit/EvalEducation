using Autofac;

namespace EVE.Commons
{
    public static class DIContainer
    {
        public static IContainer Container;

        public static T GetInstance<T>() => Container.Resolve<T>();
    }
}
