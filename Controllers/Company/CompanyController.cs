using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using netpaypro.Data;
using netpaypro.Data.ViewModels.Company;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace netpaypro.Controllers.Company
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CompanyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

                        // Ensure the folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Generate a unique filename
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(createCompanyVM.Logo.FileName);

                        // Full server path
                        var fullLogoPath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Save the file to the server
                        using (var stream = new FileStream(fullLogoPath, FileMode.Create))
                        {
                            await createCompanyVM.Logo.CopyToAsync(stream);
                        }

                        // Store the relative path for the database
                        logoPath = Path.Combine("uploads", "logos", uniqueFileName).Replace("\\", "/");
                    }

                    // Create a new company entity
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
                        PaymentMethod = createCompanyVM.PaymentMethod,
                        TaxRate = createCompanyVM.TaxRate,
                        ManagerId = userId,
                        CreatedAt = DateTime.Now,
                        Logo = logoPath, // Save relative path to DB
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
            var CompanyDetails = await _context.Companies.Include(c => c.Manager).Include(c => c.Users).Where(c => c.Id == Id).FirstOrDefaultAsync();

            if (CompanyDetails == null)
            {
                return RedirectToAction(nameof(AllCompanies));
            }

            return View("~/Views/Company/CompanyDetails.cshtml", CompanyDetails);

        }

    }

}
