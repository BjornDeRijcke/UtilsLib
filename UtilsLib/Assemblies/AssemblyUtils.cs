using System;
using System.Reflection;

namespace UtilsLib.Assemblies
{
    public enum RequiredAssembly
    {
        ExecutingAssembly = 0,
        CallingAssembly = 1,
        EntryAssembly = 2,
    }

    public class AssemblyUtils
    {
        public static string GetInformationalVersion()
            => GetInformationalVersion(RequiredAssembly.ExecutingAssembly);

        public static string GetInformationalVersion(RequiredAssembly requiredAssembly)
        {
            Assembly assembly;

            switch (requiredAssembly)
            {
                case RequiredAssembly.ExecutingAssembly:
                    assembly = Assembly.GetExecutingAssembly();
                    break;

                case RequiredAssembly.CallingAssembly:
                    assembly = Assembly.GetCallingAssembly();
                    break;

                case RequiredAssembly.EntryAssembly:
                    assembly = Assembly.GetEntryAssembly();
                    break;

                default:
                    throw new ArgumentException("Unknown required assembly", nameof(requiredAssembly));
            }

            var attr = assembly
                .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false)
                as AssemblyInformationalVersionAttribute[];

            if (attr.Length > 0)
                return attr[0]?.InformationalVersion ?? "";

            return "";
        }
    }
}
