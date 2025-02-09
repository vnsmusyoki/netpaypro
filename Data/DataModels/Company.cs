namespace netpaypro.Data.DataModels
{
    public class Company : BaseClass
    {
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
        public Country Country { get; set; }
        public int? CountryId { get; set; }

        // Payroll-Specific Information
        public string? Currency { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal? TaxRate { get; set; }

        public string? Logo { get; set; }


        // Relationships 

        public ICollection<ApplicationUser> Users { get; set; }

        public ApplicationUser Manager { get; set; }
        public string? ManagerId { get; set; }
    }
}
