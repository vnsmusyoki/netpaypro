using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace netpaypro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
       .Property(c => c.TaxRate)
       .HasPrecision(18, 4);

            builder.Entity<ApplicationUser>()
       .HasOne(u => u.Company)
       .WithMany(c => c.Users)
       .HasForeignKey(u => u.CompanyId)
       .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Company>()
                .HasOne(c => c.Manager)
                .WithMany()
                .HasForeignKey(c => c.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Name = "administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "3b5b308f-6474-45a3-84ce-1f42e8808a45"
                },
                   new IdentityRole
                   {
                       Name = "company",
                       NormalizedName = "COMPANY",
                       Id = "10141467-4165-4862-8b96-2d77b80c827a"
                   },
                   new IdentityRole
                   {
                       Name = "employee",
                       NormalizedName = "EMPLOYEE",
                       Id = "f35eb599-d371-46c7-b2e7-624d9c0b6296"
                   }
                );

            builder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = 1,
                        CountryName = "Kenya",
                        CountryCode = "254",
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = DateTimeOffset.UtcNow
                    }
                );
            builder.Entity<City>().HasData(
                    new City
                    {
                        Id = 1,
                        CityName = "Nairobi",
                        CountryId = 1,
                        CreatedAt = DateTime.Now,
                        LastUpdatedAt = DateTimeOffset.UtcNow
                    }
                );
        }
    }
}
