using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TelephoneDirectory.Configuration;
using TelephoneDirectory.EntityFrameworkCore;
using TelephoneDirectory.Migrator.DependencyInjection;

namespace TelephoneDirectory.Migrator
{
    [DependsOn(typeof(TelephoneDirectoryEntityFrameworkModule))]
    public class TelephoneDirectoryMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TelephoneDirectoryMigratorModule(TelephoneDirectoryEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(TelephoneDirectoryMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TelephoneDirectoryConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TelephoneDirectoryMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
