namespace AlternativePayments
{
    public class Transaction : BaseModel
    {
        public Transaction()
        {
        }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string Token { get; set; }

        public Payment Payment { get; set; }

        public string PaymentId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string Mode { get; set; }

        public bool? IsRecurring { get; set; }

        public string InitialTransactionId { get; set; }

        public string SequenceType { get; set; }

        public string MerchantPassThruData { get; set; }

        public string MerchantTransactionId { get; set; }

        public string RedirectUrl { get; set; }

        public RedirectUrls RedirectUrls { get; set; }

        public PhoneVerification PhoneVerification { get; set; }

        public string CustomDescriptor { get; set; }

        public string CreditorID { get; set; }

        public string CreditorName { get; set; }

        public sealed class Builder
        {
            public string CustomerId { get; set; }

            public Customer Customer { get; set; }

            public string Token { get; set; }

            public Payment Payment { get; set; }

            public string PaymentId { get; set; }

            public decimal Amount { get; set; }

            public string Currency { get; set; }

            public string IpAddress { get; set; }

            public string Description { get; set; }

            public bool? IsRecurring { get; set; }

            public string InitialTransactionId { get; set; }

            public string SequenceType { get; set; }

            public string MerchantPassThruData { get; set; }

            public string MerchantTransactionId { get; set; }

            public RedirectUrls RedirectUrls { get; set; }

            public PhoneVerification PhoneVerification { get; set; }

            public string CustomDescriptor { get; set; }

            public string CreditorID { get; set; }

            public string CreditorName { get; set; }

            public Builder(string customerId, decimal amount, string currency, string ipAddress)
            {
                CustomerId = customerId;
                Amount = amount * 100;
                Currency = currency;
                IpAddress = ipAddress;
            }

            public Builder(Customer customer, decimal amount, string currency, string ipAddress)
            {
                Customer = customer;
                Amount = amount * 100;
                Currency = currency;
                IpAddress = ipAddress;
            }

            public Builder WithToken(string token)
            {
                Token = token;
                return this;
            }

            public Builder WithPaymentId(string paymentId)
            {
                PaymentId = paymentId;
                return this;
            }

            public Builder WithPayment(Payment payment)
            {
                Payment = payment;
                return this;
            }

            public Builder WithDescription(string description)
            {
                Description = description;
                return this;
            }

            public Builder WithRecurring(bool isRecurring)
            {
                IsRecurring = isRecurring;
                return this;
            }

            public Builder WithInitialTransactionId(string initialTransactionId)
            {
                InitialTransactionId = initialTransactionId;
                return this;
            }

            public Builder WithSequenceType(string sequenceType)
            {
                SequenceType = sequenceType;
                return this;
            }

            public Builder WithMerchantPassThruData(string merchantPassThruData)
            {
                MerchantPassThruData = merchantPassThruData;
                return this;
            }

            public Builder WithMerchantTransactionId(string merchantTransactionId)
            {
                MerchantTransactionId = merchantTransactionId;
                return this;
            }

            public Builder WithRedirectUrls(string returnUrl, string cancelUrl)
            {
                RedirectUrls = new RedirectUrls
                {
                    ReturnUrl = returnUrl,
                    CancelUrl = cancelUrl
                };
                return this;
            }

            public Builder WithSmsPin(string token, string pin)
            {
                PhoneVerification = new PhoneVerification
                {
                    Token = token,
                    Pin = pin
                };
                return this;
            }

            public Builder WithCustomDescriptor(string customDescriptor)
            {
                CustomDescriptor = customDescriptor;
                return this;
            }

            public Builder WithCreditorID(string creditorID)
            {
                CreditorID = creditorID;
                return this;
            }

            public Builder WithCreditorName(string creditorName)
            {
                CreditorName = creditorName;
                return this;
            }

            public Transaction Build()
            {
                return new Transaction(this);
            }
        }

        private Transaction(Builder builder)
        {
            CustomerId = builder.CustomerId;
            Customer = builder.Customer;
            Amount = builder.Amount;
            Currency = builder.Currency;
            PaymentId = builder.PaymentId;
            Payment = builder.Payment;
            Token = builder.Token;
            IpAddress = builder.IpAddress;
            Description = builder.Description;
            IsRecurring = builder.IsRecurring;
            InitialTransactionId = builder.InitialTransactionId;
            SequenceType = builder.SequenceType;
            MerchantPassThruData = builder.MerchantPassThruData;
            MerchantTransactionId = builder.MerchantTransactionId;
            RedirectUrls = builder.RedirectUrls;
            PhoneVerification = builder.PhoneVerification;
            CustomDescriptor = builder.CustomDescriptor;
            CreditorID = builder.CreditorID;
            CreditorName = builder.CreditorName;
        }
    }
}
