namespace netpaypro.Data.DataModels
{
    public class EmployeeDetail : BaseClass
    {
        public ApplicationUser Employee { get; set; }
        public string? EmployeeId { get; set; }

        public netpaypro.Data.DataModels.Company Company { get; set; }
        public int? CompanyId { get; set; }
        public string PinNo { get; set; }

        public int IdNo { get; set; }

        public string NssfNo { get; set; }

        public string NhifNo { get; set; }

        public string ShaNo { get; set; }

        public int BasicPay { get; set; } = 0;
        public int GrossPay { get; set; } = 0;

        public int HouseAllowance { get; set; } = 0;

        public string Gender { get; set; }

        public string Designation { get; set; }
    }
}
