using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace netpaypro.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole(Roles.Company))
            {
                return View("~/Views/Company/Dashboard.cshtml");
            }
            else if (User.IsInRole(Roles.Administrator))
            {
                return View("~/Views/Administrator/Dashboard");
            }
            else
            {
                return View("~/Views/Employee/Dashboard");
            }
        }
    }
}
