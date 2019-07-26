using Xunit;

namespace UtilsTests.Assemblies.AssemblyUtils
{
    public class AssemblyUtilsTests
    {
        [Fact]
        public void GetInformationalVersion()
        {
            var version = UtilsLib.Assemblies.AssemblyUtils.GetInformationalVersion(UtilsLib.Assemblies.RequiredAssembly.CallingAssembly);
            Assert.Equal("MYVERSION", version);
        }
    }
}
