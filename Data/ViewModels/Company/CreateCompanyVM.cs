using System.ComponentModel.DataAnnotations;

namespace netpaypro.Data.ViewModels.Company
{
    public class CreateCompanyVM
    {
        [Required]
        public string CompanyName { get; set; } = String.Empty;

        [Required]
        public string RegistrationNumber { get; set; } = String.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Company Email Address")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Company Phone Number")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Company Physical Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City/Town")]
        public int? CityId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Required]
        public string? Currency { get; set; }

        public string? PaymentMethod { get; set; }

        [Range(0, 100, ErrorMessage = "Tax rate must be between 0 and 100.")]
        public decimal? TaxRate { get; set; }

        public IFormFile? Logo { get; set; }

        [Required]
        [Display(Name = "Brief Company Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Business Type")]
        public string BusinessType { get; set; }
        [Required]
        [Display(Name = "Industry Type")]
        public string IndustryType { get; set; }
        [Required]
        [Display(Name = "Company Working Hours & Days")]
        public string WorkingHours { get; set; }

        [Required]
        [Display(Name = "Company Website")]
        [Url(ErrorMessage = "Please enter a valid website URL (e.g., https://example.com)")]
        public string Website { get; set; }



    }
}
