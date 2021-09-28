using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TelephoneDirectory.Configuration;

namespace TelephoneDirectory.Web.Host.Startup
{
    [DependsOn(
       typeof(TelephoneDirectoryWebCoreModule))]
    public class TelephoneDirectoryWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TelephoneDirectoryWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TelephoneDirectoryWebHostModule).GetAssembly());
        }
    }
}
