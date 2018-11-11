using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Haikunator.Tests
{
    public static class ReflectionExtensions
    {
        public static object InvokeWithNamedParameters(this MethodBase self, object obj,
            IDictionary<string, object> namedParameters)
        {
            return self.Invoke(obj, MapParameters(self, namedParameters));
        }

        public static object[] MapParameters(MethodBase method, IDictionary<string, object> namedParameters)
        {
            var paramNames = method.GetParameters().Select(p => p.Name).ToArray();
            var parameters = new object[paramNames.Length];
            for (var i = 0; i < parameters.Length; ++i)
            {
                parameters[i] = Type.Missing;
            }

            foreach (var (paramName, value) in namedParameters)
            {
                var paramIndex = Array.IndexOf(paramNames, paramName);
                parameters[paramIndex] = value;
            }

            return parameters;
        }
    }
}