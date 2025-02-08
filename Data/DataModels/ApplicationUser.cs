using Microsoft.AspNetCore.Identity;

namespace netpaypro.Data.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTimeOffset LastUpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
