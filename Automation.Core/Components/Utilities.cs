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
            var assemblyFiles = Directory.GetFiles(Environment.CurrentDirectory, "*.dll", SearchOption.AllDirectories);

            var assemblies = new List<Assembly>();
            foreach (var file in assemblyFiles)
            {
                assemblies.Add(Assembly.Load(AssemblyName.GetAssemblyName(file)));
            }
            return assemblies
                .SelectMany(i => i.GetTypes())
                .FirstOrDefault(i => i.FullName.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}
