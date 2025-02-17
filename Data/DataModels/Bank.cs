using System.Collections.ObjectModel;

namespace netpaypro.Data.DataModels
{
    public class Bank : BaseClass
    {
        public int BankName { get; set; }

        public string BankCode { get; set; }

        public string? SwiftCode { get; set; }

        public Collection<BankBranch> BankBranchesList { get; set; }

    }
}
