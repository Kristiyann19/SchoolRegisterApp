using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Enums;
using System.Security.Claims;

namespace SchoolRegisterApp.Attributes
{
    public class AuthorizedUserAttribute : Attribute, IAsyncActionFilter
    {
        private RoleEnum _role;

        public AuthorizedUserAttribute(RoleEnum role)
        {
            _role = role;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userRoleAsString = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var userRole = Enum.Parse<RoleEnum>(userRoleAsString);

            if (userRole != _role)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
