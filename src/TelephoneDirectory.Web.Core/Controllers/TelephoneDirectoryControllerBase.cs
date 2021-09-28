using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TelephoneDirectory.Controllers
{
    public abstract class TelephoneDirectoryControllerBase: AbpController
    {
        protected TelephoneDirectoryControllerBase()
        {
            LocalizationSourceName = TelephoneDirectoryConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
