using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Client.Repositories
{
    public class UserCodeRequirement : AuthorizationHandler<UserCodeRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserCodeRequirement requirement)
        {
            if (context.User.Claims.Any(c => c.Type == "usercode" && c.Value.Contains("ADMIN")))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
