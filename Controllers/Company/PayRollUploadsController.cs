using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netpaypro.Data;
using OfficeOpenXml;
using System.Data;

namespace netpaypro.Controllers.Company
{
    public class PayRollUploadsController : Controller
    {
        protected readonly ILogger<PayRollUploadsController> _logger;
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<ApplicationUser> _userManager;

        public PayRollUploadsController(ILogger<PayRollUploadsController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            return View("~/Views/Company/Payroll/AllPayrolls.cshtml");
        }

        public IActionResult DownloadTemplate()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/templates/PayrollTemplate.xlsx");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PayrollTemplate.xlsx");
        }


        [HttpPost]
        public async Task<IActionResult> UploadPayroll(IFormFile payrollFile)
        {
            if (payrollFile == null || payrollFile.Length == 0)
            {
                TempData["Error"] = "Please select a valid Excel file.";
                return RedirectToAction(nameof(Index));
            }

            var allowedExtensions = new[] { ".xls", ".xlsx" };
            var extension = Path.GetExtension(payrollFile.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
            {
                TempData["Error"] = "Invalid file format. Please upload an Excel file.";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                var expectedHeaders = new List<string>
        {
            "MONTH", "YEAR", "IDNO", "INCOME_TAX", "PAYE_RELIEF_INCOME_TAX", "SHIF_RELIEF",
            "AHL_RELIEF", "PAYE", "NSSF", "RBA_PENSION", "SHIF", "HOUSING_LEVY",
            "TOTAL_ADVANCES", "NET_PAY"
        };
                int currentYear = DateTime.Now.Year;
                var userId = _userManager.GetUserId(User);
                var company = await _context.Companies.Where(q => q.ManagerId == userId).FirstOrDefaultAsync();
                if (company == null)
                {
                    throw new Exception("Unable to retrieve the company details. Please contact support for assistance");
                }

                using (var stream = new MemoryStream())
                {
                    payrollFile.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // First sheet

                        int colCount = worksheet.Dimension.Columns;

                        List<string> actualHeaders = new List<string>();

                        for (int col = 1; col <= colCount; col++)
                        {
                            actualHeaders.Add(worksheet.Cells[1, col].Text.Trim()); // Extract headers
                        }

                        // Validate headers
                        if (!actualHeaders.SequenceEqual(expectedHeaders))
                        {
                            _logger.LogError("Invalid column headers: {Headers}", string.Join(", ", actualHeaders));
                            throw new Exception("Excel file has invalid column headers.");
                        }
                        int rowCount = worksheet.Dimension.Rows;
                        DataTable dt = new DataTable();
                        for (int col = 1; col <= colCount; col++)
                        {
                            dt.Columns.Add(worksheet.Cells[1, col].Text); // Add column names
                        }


                        for (int row = 2; row <= rowCount; row++)
                        {
                            DataRow dr = dt.NewRow();
                            string monthText = worksheet.Cells[row, 1].Text.Trim();
                            string yearText = worksheet.Cells[row, 2].Text.Trim();
                            string idText = worksheet.Cells[row, 3].Text.Trim();

                            // Validate MONTH
                            if (!int.TryParse(monthText, out int month) || month < 1 || month > 12)
                            {
                                _logger.LogError("Invalid MONTH value at row {Row}: {Value}", row, monthText);
                                throw new Exception($"Invalid MONTH value at row {row}: {monthText}");
                            }

                            // Validate YEAR
                            if (!int.TryParse(yearText, out int year) || year > currentYear)
                            {
                                _logger.LogError("Invalid YEAR value at row {Row}: {Value}", row, yearText);
                                throw new Exception($"Invalid YEAR value at row {row}: {yearText}");
                            }
                            // Validate IDNO (Must be a valid number and exist in the database)
                            if (!long.TryParse(idText, out long IdNumber))
                            {
                                _logger.LogError("Invalid IDNO format at row {Row}: {Value}", row, idText);
                                throw new Exception($"Invalid IDNO format at row {row}: {idText}");
                            }

                            // Check if IDNO exists in the employees table for the given company
                            if (!await CheckIDExists(IdNumber, company))
                            {
                                _logger.LogInformation("Employee idno {id} at row {row} does not exist in company {companyid}", IdNumber, row, company.Id);
                                throw new Exception($"Employee with ID NO {IdNumber} at row {row} does not exist in company {company.CompanyName}");
                            }


                            var EmployeeId = await EmployeeProfile(IdNumber, company) ?? "";

                            if (await EmployeeAlreadyexists(monthText, yearText, EmployeeId, company))
                            {
                                _logger.LogInformation("You already have an existing payroll entry for the employee {IdNumber} for the {monthText} - {yearText}", IdNumber, monthText, yearText);
                                throw new Exception($"You already have an existing payroll entry for the employee {IdNumber} for the {monthText} - {yearText}");

                            }


                            for (int col = 1; col <= colCount; col++)
                            {
                                dr[col - 1] = worksheet.Cells[row, col].Text;
                            }
                            dt.Rows.Add(dr);
                            _logger.LogInformation("Row {Row}: {Data}", row - 1, dr);
                            _logger.LogInformation("Row {Row}: {Data}", row - 1, string.Join(", ", dr.ItemArray));
                        }


                    }
                }

                TempData["Success"] = "Payroll file uploaded successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error processing file: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        private async Task<bool> CheckIDExists(long IdNumber, netpaypro.Data.DataModels.Company company)
        {

            return await _context.EmployeeDetails.AnyAsync(q => q.IdNo == IdNumber && q.CompanyId == company.Id);
        }
        private async Task<string?> EmployeeProfile(long IdNumber, netpaypro.Data.DataModels.Company company)
        {

            return await _context.EmployeeDetails.Where(q => q.IdNo == IdNumber && q.CompanyId == company.Id).Select(q => (string?)q.EmployeeId).FirstOrDefaultAsync();
        }

        private async Task<bool> EmployeeAlreadyexists(string Month, string Year, string EmployeeId, netpaypro.Data.DataModels.Company company)
        {

            return await _context.PayrollEntries.AnyAsync(q => q.PayrollMonth == Month && q.PayrollYear == int.Parse(Year) && q.EmployeeId == EmployeeId && q.CompanyId == company.Id);
        }
    }
}
