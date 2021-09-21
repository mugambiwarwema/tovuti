using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using tovuti.Authorization;

namespace tovuti
{
    [DependsOn(
        typeof(tovutiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class tovutiApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<tovutiAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(tovutiApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
