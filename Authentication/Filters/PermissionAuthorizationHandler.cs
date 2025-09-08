namespace SurveyBasket.Authentication.Filters
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.Identity is not { IsAuthenticated: true } ||
                !context.User.Claims.Any(c => c.Value == requirement.Permission && c.Type == Permissions.Type))
                return;

            context.Succeed(requirement);
            return;

        }
    }
}
