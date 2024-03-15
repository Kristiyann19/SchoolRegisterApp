using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SchoolRegisterApp.Models.Enums;
using System.Security.Claims;

namespace SchoolRegisterApp.Attributes
{
    public class AuthorizedDirectorAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var role = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

            if (role != RoleEnum.Director.ToString())
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
