using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolRegisterApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
