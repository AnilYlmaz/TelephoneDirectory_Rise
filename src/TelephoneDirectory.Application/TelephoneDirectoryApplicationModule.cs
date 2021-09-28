using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TelephoneDirectory.Authorization;

namespace TelephoneDirectory
{
    [DependsOn(
        typeof(TelephoneDirectoryCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TelephoneDirectoryApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TelephoneDirectoryAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TelephoneDirectoryApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
