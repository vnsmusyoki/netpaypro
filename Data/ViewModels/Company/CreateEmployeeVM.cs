using System.ComponentModel.DataAnnotations;

namespace netpaypro.Data.ViewModels.Company
{
    using System.ComponentModel.DataAnnotations;

    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be between 10 to 15 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Is Active status is required.")]
        public bool IsActive { get; set; }
    }

}
