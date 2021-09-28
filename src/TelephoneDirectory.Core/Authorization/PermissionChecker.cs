using Abp.Authorization;
using TelephoneDirectory.Authorization.Roles;
using TelephoneDirectory.Authorization.Users;

namespace TelephoneDirectory.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
