namespace netpaypro.Data.DataModels
{
    public class BankBranch : BaseClass
    {
        public string BranchName { get; set; }
        public Bank Bank { get; set; }
        public int BankId { get; set; }
        public string BranchCode { get; set; }

    }
}
