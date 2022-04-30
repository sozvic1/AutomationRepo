using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Core.Components
{
    internal static class Utilities
    {
        public static Type GetTypeByName(string type)
        {
            var assamblies = new List<Assembly>();
            foreach (var assembly in Assembly.GetCallingAssembly().GetReferencedAssemblies())
            {
                assamblies.Add(Assembly.Load(assembly));
            }
            return assamblies.SelectMany(i => i.GetTypes()).
            FirstOrDefault(i => i.FullName.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}
