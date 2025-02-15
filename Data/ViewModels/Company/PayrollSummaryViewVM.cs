namespace netpaypro.Data.ViewModels.Company
{
    public class PayrollSummaryViewVM
    {
        public int Id { get; set; }
        public int EntriesCount { get; set; }

        public DateTime UploadedAt { get; set; }

        public DateTime SubmittedAt { get; set; }

        public string? UploadedBy { get; set; }
        public string? SubmittedBy { get; set; }

        public int PayrollMonth { get; set; }

        public int PayrollYear { get; set; }

        public bool IsSubmitted { get; set; }

        public bool IsProcessedSuccessfully { get; set; }


    }
}
