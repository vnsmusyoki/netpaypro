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
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be between 10 to 12 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Is Active status is required.")]
        [Display(Name = "Is Account Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Please provide Tax Number")]
        [Display(Name = "KRA/Tax  Number")]
        public string PinNo { get; set; }

        [Required(ErrorMessage = "Please provide ID Number")]
        [Display(Name = "ID  Number")]
        public int IdNo { get; set; }

        [Required(ErrorMessage = "Please provide NSSF Number")]
        [Display(Name = "NSSF Number")]
        public string NssfNo { get; set; }

        [Required(ErrorMessage = "Please provide NHIF Number")]
        [Display(Name = "NHIF Number")]
        public string NhifNo { get; set; }

        [Required(ErrorMessage = "Please provide SHA Number")]
        [Display(Name = "SHA Number")]
        public string ShaNo { get; set; }

        [Required(ErrorMessage = "Please provide basic pay")]
        [Display(Name = "Basic Employee Pay")]
        public int BasicPay { get; set; } = 0;


        [Required(ErrorMessage = "Please provide House Allowance else indicate it as 0")]
        [Display(Name = "House Allowance")]
        public int HouseAllowance { get; set; } = 0;
    }

}
