using Abp.Authorization;
using tovuti.Authorization.Roles;
using tovuti.Authorization.Users;

namespace tovuti.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
