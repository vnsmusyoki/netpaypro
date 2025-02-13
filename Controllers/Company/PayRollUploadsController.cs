using Microsoft.AspNetCore.Mvc;

namespace netpaypro.Controllers.Company
{
    public class PayRollUploadsController : Controller
    {
        public IActionResult Index()
        {

            return View("~/Views/Company/Payroll/AllPayrolls.cshtml");
        }

    }
}
