namespace netpaypro.Data.ViewModels.Company
{
    public class CreatePayrollEntryVM
    {


        public string EmployeeName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public string? PINNumber { get; set; }
        public string? IDNumber { get; set; }
        public string? NSSFNumber { get; set; }
        public string? NHIFNumber { get; set; }
        public string? SHANumber { get; set; }

        public string FormattedBasicPay => BasicPay.ToString("N2");
        public string FormattedHousingAllowance => HousingAllowance.ToString("N2");
        public string FormattedOtherAllowances => OtherAllowances.ToString("N2");
        public string FormattedGrossPay => GrossPay.ToString("N2");
        public string FormattedIncomeTax => IncomeTax.ToString("N2");
        public string FormattedNettPay => NettPay.ToString("N2");

        public string PayrollPeriod => $"{PayrollMonth} {PayrollYear}";

        public decimal BasicPay { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal OtherAllowances { get; set; }
        public decimal GrossPay { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal PAYERelief { get; set; }
        public decimal SHIFRelief { get; set; }
        public decimal AHLRelief { get; set; }
        public decimal PAYE { get; set; }
        public decimal NSSF { get; set; }
        public decimal RBAPension { get; set; }
        public decimal SHIF { get; set; }
        public decimal HousingLevy { get; set; }
        public decimal TotalAdvances { get; set; }
        public decimal NettPay { get; set; }

        public string PayrollMonth { get; set; }
        public int PayrollYear { get; set; }

    }
}
