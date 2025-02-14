namespace netpaypro.Data.DataModels
{
    public class PayrollEntry : BaseClass
    {
        public ApplicationUser? Employee { get; set; }
        public string EmployeeId { get; set; }
        public Company? Company { get; set; }
        public int CompanyId { get; set; }
        public string BasicPay { get; set; }
        public string HousingAllowance { get; set; }
        public string OtherAllowances { get; set; }
        public string IncomeTax { get; set; }
        public string PAYERelief { get; set; }
        public string SHIFRelief { get; set; }
        public string AHLRelief { get; set; }
        public string PAYE { get; set; }
        public string NSSF { get; set; }
        public string RBAPension { get; set; }
        public string SHIF { get; set; }
        public string HousingLevy { get; set; }
        public string TotalAdvances { get; set; }
        public string NettPay { get; set; }
        public int PayrollMonth { get; set; }
        public int PayrollYear { get; set; }

    }
}
