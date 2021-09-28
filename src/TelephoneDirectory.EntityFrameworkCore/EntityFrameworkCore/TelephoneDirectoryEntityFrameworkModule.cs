using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using TelephoneDirectory.EntityFrameworkCore.Seed;

namespace TelephoneDirectory.EntityFrameworkCore
{
    [DependsOn(
        typeof(TelephoneDirectoryCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class TelephoneDirectoryEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TelephoneDirectoryDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        TelephoneDirectoryDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        TelephoneDirectoryDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TelephoneDirectoryEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
