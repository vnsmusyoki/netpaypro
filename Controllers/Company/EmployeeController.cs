using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netpaypro.Data;
using netpaypro.Data.ViewModels.Company;

namespace netpaypro.Controllers.Company
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ILogger<EmployeeController> _logger;
        private UserManager<ApplicationUser> _userManager;
        public EmployeeController(ApplicationDbContext context, ILogger<EmployeeController> logger, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
        public IActionResult CreateEmployee()
        {
            return View("~/Views/Company/Employee/CreateEmployee.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StoreEmployee(CreateEmployeeVM createEmployeeVM)
        {
            if (await CheckIfEmailExists(createEmployeeVM.Email))
            {
                ModelState.AddModelError(nameof(createEmployeeVM.Email), "Email Already Exists");
            }
            if (await CheckIfPhoneNumberExists(createEmployeeVM.PhoneNumber))
            {
                ModelState.AddModelError(nameof(createEmployeeVM.PhoneNumber), "Phone Number Already Exists");
            }
            if (!ModelState.IsValid)
            {
                return View("~/Views/Company/Employee/CreateEmployee.cshtml", createEmployeeVM);
            }

            var signedinuser = _userManager.GetUserId(User);
            var userCompany = await _context.Companies
                .Where(c => c.ManagerId == signedinuser)
                .FirstOrDefaultAsync();

            var employeeData = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = createEmployeeVM.Email.ToLower(),
                NormalizedUserName = createEmployeeVM.Email.ToUpper(),
                Email = createEmployeeVM.Email,
                NormalizedEmail = createEmployeeVM.Email.ToUpper(),
                FullName = createEmployeeVM.FullName,
                PhoneNumber = createEmployeeVM.PhoneNumber,
                EmailConfirmed = false,
                CompanyId = userCompany?.Id
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            employeeData.PasswordHash = passwordHasher.HashPassword(employeeData, createEmployeeVM.Password);

            _context.Users.Add(employeeData);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Company", new { id = userCompany?.Id });
        }
        public async Task<IActionResult> EmployeeProfile(string id, int? companyId, string returnUrl)
        {
            _logger.LogInformation("Received ID: {Id}, Return URL: {ReturnUrl}", id, returnUrl);

            if (string.IsNullOrEmpty(id))
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Details", "Company", new { id = companyId });

            }

            // Fetch employee using string ID (GUID) 

            var employee = await _userManager.Users.Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            var employeeData = new ViewEmployeeVM
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                CompanyId = employee.CompanyId,
                Company = employee.Company
            };


            return View("~/Views/Company/Employee/EmployeeDetails.cshtml", employeeData);
        }




        private async Task<bool> CheckIfEmailExists(string Email)
        {
            var email = Email.ToLower();

            return await _context.Users.AnyAsync(q => q.Email == email);

        }
        private async Task<bool> CheckIfPhoneNumberExists(string PhoneNumber)
        {

            return await _context.Users.AnyAsync(q => q.PhoneNumber == PhoneNumber);

        }

    }
}
