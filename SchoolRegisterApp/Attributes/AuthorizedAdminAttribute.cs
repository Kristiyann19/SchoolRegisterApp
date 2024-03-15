using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Attributes
{
    public class AuthorizedAdminAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var role = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

            if (role != RoleEnum.Admin.ToString())
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
