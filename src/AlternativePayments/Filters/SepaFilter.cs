using System;

namespace AlternativePayments
{
    public class SepaFilter : BaseFilter
    {
        public SepaFilter()
        {
        }

        public SepaFilter WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        public SepaFilter WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        public SepaFilter WithTransactionStatus(TransactionStatus transactionStatus)
        {
            TransactionStatus = transactionStatus;
            return this;
        }

        public SepaFilter WithCreatedFrom(DateTime createdFrom)
        {
            CreatedFrom = createdFrom;
            return this;
        }

        public SepaFilter WithCreatedTo(DateTime createdTo)
        {
            CreatedTo = createdTo;
            return this;
        }

        public SepaFilter WithUpdatedFrom(DateTime updatedFrom)
        {
            UpdatedFrom = updatedFrom;
            return this;
        }

        public SepaFilter WithUpdatedTo(DateTime updatedTo)
        {
            UpdatedTo = updatedTo;
            return this;
        }

        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public TransactionStatus? TransactionStatus { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public DateTime? UpdatedFrom { get; set; }
        public DateTime? UpdatedTo { get; set; }
    }
}
