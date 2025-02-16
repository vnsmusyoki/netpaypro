using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using netpaypro.Data;
using netpaypro.Data.ViewModels.Company;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace netpaypro.Controllers.Company
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CompanyController> _logger;
        public CompanyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<CompanyController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> AllCompanies()
        {
            var companies = await _context.Companies.Include(c => c.Manager).Include(c => c.Users).ToListAsync();
            ViewBag.CompanyCount = companies.Count;
            return View("~/Views/Company/AllCompanies.cshtml", companies);
        }


        public async Task<IActionResult> AddCompany()
        {

            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.Countries = await _context.Countries.ToListAsync();

            return View("~/Views/Company/AddCompany.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            _logger.LogInformation("******************************************************");
            JsonConvert.SerializeObject(createCompanyVM, Formatting.Indented);
            var userId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                try
                {
                    string logoPath = string.Empty;

                    // Check if a logo was uploaded
                    if (createCompanyVM.Logo != null && createCompanyVM.Logo.Length > 0)
                    {
                        // Define upload directory
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "logos");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(createCompanyVM.Logo.FileName);

                        var fullLogoPath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(fullLogoPath, FileMode.Create))
                        {
                            await createCompanyVM.Logo.CopyToAsync(stream);
                        }

                        logoPath = Path.Combine("uploads", "logos", uniqueFileName).Replace("\\", "/");
                    }

                    var companyProfile = new netpaypro.Data.DataModels.Company
                    {
                        CompanyName = createCompanyVM.CompanyName,
                        RegistrationNumber = createCompanyVM.RegistrationNumber,
                        Email = createCompanyVM.Email,
                        Phone = createCompanyVM.Phone,
                        Address = createCompanyVM.Address,
                        CityId = createCompanyVM.CityId,
                        CountryId = createCompanyVM.CountryId,
                        Currency = createCompanyVM.Currency,
                        ManagerId = userId,
                        CreatedAt = DateTime.Now,
                        Logo = logoPath,
                        Description = createCompanyVM.Description,
                        BusinessType = createCompanyVM.BusinessType,
                        IndustryType = createCompanyVM.IndustryType,
                        WorkingHours = createCompanyVM.WorkingHours,
                        Website = createCompanyVM.Website,
                    };

                    // Save the company
                    _context.Companies.Add(companyProfile);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Company created successfully!";
                    return RedirectToAction(nameof(AllCompanies));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"An error occurred while creating the company: {ex.Message}";
                }
            }

            TempData["Error"] = "Invalid data! Please check the form and try again.";
            var cities = await _context.Cities.ToListAsync();
            var countries = await _context.Countries.ToListAsync();

            ViewBag.Cities = cities;
            ViewBag.Countries = countries;

            return View("~/Views/Company/AddCompany.cshtml", createCompanyVM);
        }


        public async Task<IActionResult> Details(int Id)
        {
            var companyDetails = await _context.Companies.Include(c => c.Manager).Include(c => c.Users).Where(c => c.Id == Id).FirstOrDefaultAsync();

            if (companyDetails == null)
            {
                return RedirectToAction(nameof(AllCompanies));
            }
            var salaryDistribution = await _context.EmployeeDetails
     .Where(e => e.CompanyId == Id)
     .GroupBy(e =>
         e.BasicPay <= 30000 ? "0-30K" :
         e.BasicPay <= 60000 ? "30K-60K" :
         e.BasicPay <= 90000 ? "60K-90K" :
         e.BasicPay <= 120000 ? "90K-120K" :
         e.BasicPay <= 150000 ? "120K-150K" :
         e.BasicPay <= 180000 ? "150K-180K" :
         e.BasicPay <= 210000 ? "180K-210K" :
         e.BasicPay <= 240000 ? "210K-240K" :
         e.BasicPay <= 270000 ? "240K-270K" :
         e.BasicPay <= 300000 ? "270K-300K" :
         e.BasicPay <= 330000 ? "300K-330K" :
         e.BasicPay <= 360000 ? "330K-360K" :
         e.BasicPay <= 390000 ? "360K-390K" :
         e.BasicPay <= 420000 ? "390K-420K" :
         e.BasicPay <= 450000 ? "420K-450K" :
         e.BasicPay <= 480000 ? "450K-480K" :
         "Above 480K"
     )
     .Select(g => new
     {
         SalaryRange = g.Key,
         EmployeeCount = g.Count()
     })
     .ToListAsync();

            var employees = await _context.EmployeeDetails
        .Where(e => e.CompanyId == Id)
        .ToListAsync();

            var genderDistribution = employees
                .GroupBy(e => e.Gender)
                .Select(g => new { GenderName = g.Key, GenderCount = g.Count() })
                .ToDictionary(g => g.GenderName, g => g.GenderCount);

            var designationDistribution = employees
                .GroupBy(e => e.Designation)
                .Select(g => new { DesignationName = g.Key, DesignationCount = g.Count() })
                .ToDictionary(g => g.DesignationName, g => g.DesignationCount);

            var viewDetails = new ViewCompanyVM
            {
                CompanyName = companyDetails.CompanyName,
                RegistrationNumber = companyDetails.RegistrationNumber,
                Email = companyDetails.Email,
                Phone = companyDetails.Phone,
                Address = companyDetails.Address,
                CityId = companyDetails.CityId,
                CountryId = companyDetails.CountryId,
                Currency = companyDetails.Currency,
                PaymentMethod = companyDetails.PaymentMethod,
                TaxRate = companyDetails.TaxRate,
                Users = companyDetails.Users,
                Manager = companyDetails.Manager,
                ManagerId = companyDetails.ManagerId,
                Logo = companyDetails.Logo,
                CreatedAt = companyDetails.CreatedAt,
                LastUpdatedAt = companyDetails.LastUpdatedAt,
                Id = companyDetails.Id,
                Description = companyDetails.Description,
                BusinessType = companyDetails.BusinessType,
                IndustryType = companyDetails.IndustryType,
                WorkingHours = companyDetails.WorkingHours,
                Website = companyDetails.Website,
                SalaryDistribution = salaryDistribution.ToDictionary(s => s.SalaryRange, s => s.EmployeeCount),
                GenderDistribution = genderDistribution,
                DesignationDistribution = designationDistribution

            };

            return View("~/Views/Company/CompanyDetails.cshtml", viewDetails);

        }

    }

}
