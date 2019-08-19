using System;
using System.Reflection;

[assembly: AssemblyCompany("Cycloid")]
[assembly: AssemblyProduct("Cycloid Interviews")]
[assembly: AssemblyCopyright("Copyright © Cycloid 2019")]
[assembly: AssemblyMetadata("ProjectUrl", "http://www.cycloid.pt")]
[assembly: AssemblyMetadata("Authors", "Anderson Sousa, João Almeida")]
[assembly: AssemblyMetadata("Tags", "Cycloid Interview")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion(Cycloid.Info.VersionDescriptor)]
[assembly: AssemblyFileVersion(Cycloid.Info.VersionDescriptor)]
[assembly: AssemblyInformationalVersion(Cycloid.Info.VersionDescriptor)]

namespace Cycloid
{
    internal static class Info
    {
        public const string VersionDescriptor = "0.5.0.0";
        public static Version Version = Assembly.GetExecutingAssembly().GetName().Version;
    }
}