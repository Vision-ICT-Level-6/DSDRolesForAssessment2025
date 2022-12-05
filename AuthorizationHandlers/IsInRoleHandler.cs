using Microsoft.AspNetCore.Authorization;

using RolesForAssessment.AuthorizationRequirements;

namespace RolesForAssessment.AuthorizationHandlers
{

    public class IsInRoleHandler : AuthorizationHandler<ViewRolesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ViewRolesRequirement req)
        {
            if (context.User.IsInRole("Admin")) //does the user have the role Admin?
            {
                context.Succeed(req);
            }
            return Task.CompletedTask;
        }
    }

}
