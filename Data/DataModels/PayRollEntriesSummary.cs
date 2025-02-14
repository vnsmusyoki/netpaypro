namespace netpaypro.Data.DataModels
{
    public class PayRollEntriesSummary : BaseClass
    {
        public int RecordsCount { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}
