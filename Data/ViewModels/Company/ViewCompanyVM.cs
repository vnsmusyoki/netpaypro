using System.ComponentModel.DataAnnotations;

namespace netpaypro.Data.ViewModels.Company
{
    public class ViewCompanyVM
    {

        public string CompanyName { get; set; } = String.Empty;
        public string RegistrationNumber { get; set; } = String.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public string? Currency { get; set; }

        public string? PaymentMethod { get; set; }

        public decimal? TaxRate { get; set; }

        public string? Logo { get; set; }

        public ICollection<ApplicationUser>? Users { get; set; } = new List<ApplicationUser>();


        public ApplicationUser? Manager { get; set; }
        public string? ManagerId { get; set; }

        public DateTimeOffset? LastUpdatedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int Id { get; set; }
        public string? Description { get; set; }
        public string? BusinessType { get; set; }
        public string? IndustryType { get; set; }
        public string? WorkingHours { get; set; }
        public string? Website { get; set; }

        public string? Designation { get; set; }
        public string? Gender { get; set; }
        public Dictionary<string, int>? SalaryDistribution { get; set; }

        public Dictionary<string, int>? GenderDistribution { get; set; }

        public Dictionary<string, int>? DesignationDistribution { get; set; }
    }
}
