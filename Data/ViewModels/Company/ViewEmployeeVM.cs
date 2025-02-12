namespace netpaypro.Data.ViewModels.Company
{
    public class ViewEmployeeVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public netpaypro.Data.DataModels.Company Company { get; set; }
        public int? CompanyId { get; set; }



    }
}
