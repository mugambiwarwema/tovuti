using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using tovuti.EntityFrameworkCore;
using tovuti.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace tovuti.Web.Tests
{
    [DependsOn(
        typeof(tovutiWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class tovutiWebTestModule : AbpModule
    {
        public tovutiWebTestModule(tovutiEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(tovutiWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(tovutiWebMvcModule).Assembly);
        }
    }
}