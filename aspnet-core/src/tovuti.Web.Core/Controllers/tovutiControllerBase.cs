using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace tovuti.Controllers
{
    public abstract class tovutiControllerBase: AbpController
    {
        protected tovutiControllerBase()
        {
            LocalizationSourceName = tovutiConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
