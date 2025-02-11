namespace netpaypro.Data.DataModels
{
    public class PayrollEntry : BaseClass
    {
        public ApplicationUser? ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public Company? Company { get; set; }

        public int CompanyId { get; set; }
        public string? PINNumber { get; set; }
        public string? IDNumber { get; set; }
        public string? NSSFNumber { get; set; }
        public string? NHIFNumber { get; set; }
        public string? SHANumber { get; set; }
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
