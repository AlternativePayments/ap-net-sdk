using System.Collections.Generic;

namespace AlternativePayments
{
    public class TransactionList
    {
        public TransactionList()
        {
        }

        public IEnumerable<Transaction> Transactions{ get; set; }

        public Pagination Pagination { get; set; }
    }
}
