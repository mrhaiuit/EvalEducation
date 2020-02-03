using System.Collections.Generic;
using Autofac;
using Autofac.Core;

namespace EVE.Commons.Autofac
{
    public static class AutofacExtensions
    {
        public static T ResolveWithParameters<T>(this IContainer container,
                                                 IDictionary<string, object> parameters = null)
        {
            if(parameters == null)
            {
                return container.Resolve<T>();
            }

            var _parameters = new List<Parameter>();
            foreach (var parameter in parameters)
            {
                _parameters.Add(new NamedParameter(parameter.Key, parameter.Value));
            }

            return container.Resolve<T>(_parameters);
        }
    }
}
