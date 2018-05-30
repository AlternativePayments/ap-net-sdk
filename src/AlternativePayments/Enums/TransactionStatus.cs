namespace AlternativePayments
{
    public enum TransactionStatus
    {
        Pending = 1,
        Approved = 2,
        Funded = 3,
        Declined = 4,
        Voided = 5,
        VoidDeclined = 6,
        Refunded = 8,
        RefundDeclined = 9,
        Chargeback = 10,
        Isf = 11,
        Invalid = 12,
        AcquirerDown = 13,
        Aborted = 14
    }
}
