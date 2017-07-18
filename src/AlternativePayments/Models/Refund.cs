namespace AlternativePayments
{
    public class Refund : BaseModel
    {
        public string Mode { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public string Currency { get; set; }

        public string Reason { get; set; }

        public string OriginalTransactionId { get; set; }

        public Transaction OriginalTransaction { get; set; }
    }
}
