    using Microsoft.AspNetCore.Authorization;

    namespace PizzaHub.Authorization
{
    public class CustomerOnlyAuthorizationHandler : AuthorizationHandler<CustomerOnlyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerOnlyRequirement requirement)
        {
            if (context.User.IsInRole("Customer") && !context.User.IsInRole("Courier"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
