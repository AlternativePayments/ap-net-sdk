namespace AlternativePayments
{
    public static class ReturnReason
    {
        public const string ChargebackAvoidance = "CHARGEBACK_AVOIDANCE";
        public const string EndUserError = "END_USER_ERROR";
        public const string Fraud = "FRAUD";
        public const string UnsatisfiedCustomer = "UNSATISFIED_CUSTOMER";
        public const string InvalidTransaction = "INVALID_TRANSACTION";
    }
}
