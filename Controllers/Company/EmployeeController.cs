using Microsoft.AspNetCore.Mvc;

namespace netpaypro.Controllers.Company
{
    public class EmployeeController : Controller
    {
        public IActionResult CreateEmployee()
        {
            return View("~/Views/Company/Employee/CreateEmployee.cshtml");
        }
    }
}
