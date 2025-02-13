namespace netpaypro.Data.DataModels
{
    public class EmployeeDetail : BaseClass
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public string PinNo { get; set; }

        public int IdNo { get; set; }

        public string NssfNo { get; set; }

        public string NhifNo { get; set; }

        public string ShaNo { get; set; }

        public int BasicPay { get; set; } = 0;

        public int HouseAllowance { get; set; } = 0;
    }
}
