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

            using var transaction = await _context.Database.BeginTransactionAsync(); // Start transaction

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
                var company = await _context.Companies.FirstOrDefaultAsync(q => q.ManagerId == userId);

                if (company == null)
                {
                    throw new Exception("Unable to retrieve the company details. Please contact support.");
                }

                using (var stream = new MemoryStream())
                {
                    payrollFile.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int colCount = worksheet.Dimension.Columns;
                        int rowCount = worksheet.Dimension.Rows;

                        List<string> actualHeaders = new List<string>();
                        for (int col = 1; col <= colCount; col++)
                        {
                            actualHeaders.Add(worksheet.Cells[1, col].Text.Trim());
                        }

                        if (!actualHeaders.SequenceEqual(expectedHeaders))
                        {
                            throw new Exception("Excel file has invalid column headers.");
                        }

                        List<PayrollEntry> payrollEntries = new List<PayrollEntry>();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            string monthText = worksheet.Cells[row, 1].Text.Trim();
                            string yearText = worksheet.Cells[row, 2].Text.Trim();
                            string idText = worksheet.Cells[row, 3].Text.Trim();

                            if (!int.TryParse(monthText, out int month) || month < 1 || month > 12)
                            {
                                throw new Exception($"Invalid MONTH at row {row}: {monthText}");
                            }

                            if (!int.TryParse(yearText, out int year) || year > currentYear)
                            {
                                throw new Exception($"Invalid YEAR at row {row}: {yearText}");
                            }

                            if (!long.TryParse(idText, out long IdNumber))
                            {
                                throw new Exception($"Invalid IDNO at row {row}: {idText}");
                            }

                            if (!await CheckIDExists(IdNumber, company))
                            {
                                throw new Exception($"Employee with ID NO {IdNumber} at row {row} does not exist in company {company.CompanyName}");
                            }

                            var EmployeeId = await EmployeeProfile(IdNumber, company) ?? "";

                            if (await EmployeeAlreadyexists(monthText, yearText, EmployeeId, company))
                            {
                                throw new Exception($"A payroll entry already exists for employee {IdNumber} for {monthText}-{yearText}.");
                            }

                            PayrollEntry payrollEntry = new PayrollEntry
                            {
                                EmployeeId = EmployeeId,
                                CompanyId = company.Id,
                                PayrollMonth = month,
                                PayrollYear = year,
                                IncomeTax = worksheet.Cells[row, 4].Text.Trim(),
                                PAYERelief = worksheet.Cells[row, 5].Text.Trim(),
                                SHIFRelief = worksheet.Cells[row, 6].Text.Trim(),
                                AHLRelief = worksheet.Cells[row, 7].Text.Trim(),
                                PAYE = worksheet.Cells[row, 8].Text.Trim(),
                                NSSF = worksheet.Cells[row, 9].Text.Trim(),
                                RBAPension = worksheet.Cells[row, 10].Text.Trim(),
                                SHIF = worksheet.Cells[row, 11].Text.Trim(),
                                HousingLevy = worksheet.Cells[row, 12].Text.Trim(),
                                TotalAdvances = worksheet.Cells[row, 13].Text.Trim(),
                                NettPay = worksheet.Cells[row, 14].Text.Trim(),
                                BasicPay = worksheet.Cells[row, 14].Text.Trim(),
                                HousingAllowance = worksheet.Cells[row, 12].Text.Trim(),
                                OtherAllowances = "0"
                            };

                            payrollEntries.Add(payrollEntry);
                        }

                        await _context.PayrollEntries.AddRangeAsync(payrollEntries);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync(); // Commit only if all rows are valid

                        TempData["Success"] = "Payroll file uploaded successfully!";
                    }
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(); // Rollback in case of any error
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

            int parsedMonth = int.Parse(Month);
            return await _context.PayrollEntries.AnyAsync(q => q.PayrollMonth == parsedMonth && q.PayrollYear == int.Parse(Year) && q.EmployeeId == EmployeeId && q.CompanyId == company.Id);
        }
    }
}
