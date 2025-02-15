namespace netpaypro.Data.DataModels
{
    public class PayRollEntriesSummary : BaseClass
    {
        public int RecordsCount { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public bool IsSubmitted { get; set; } = false;

        public DateTime SubmitedAt { get; set; }

        public ApplicationUser SubmittedBy { get; set; }

        public string? SubmittedByUserId { get; set; }

        public bool IsProcessedSuccessfully { get; set; } = false;

        public string? FailedReason { get; set; }

        public int? PayrollMonth { get; set; }

        public int? PayrollYear { get; set; }

        public ICollection<PayrollEntry> PayrollEntries { get; set; }

    }
}
