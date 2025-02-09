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
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public int? CityId { get; set; }
        public int? CountryId { get; set; }

        [Required]
        public string? Currency { get; set; }

        public string? PaymentMethod { get; set; }

        [Range(0, 100, ErrorMessage = "Tax rate must be between 0 and 100.")]
        public decimal? TaxRate { get; set; }

        public IFormFile? Logo { get; set; }

    }
}
