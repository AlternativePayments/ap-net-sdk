namespace AlternativePayments
{
    public class Payment : BaseModel
    {
        public Payment()
        {
        }

        public string PaymentOption { get; set; }

        public string Holder { get; set; }

        public string Iban { get; set; }

        public string Bic { get; set; }

        public string BankCode { get; set; }

        public string DocumentId { get; set; }

        public sealed class Builder
        {
            public string PaymentOption { get; set; }

            public string Holder { get; set; }

            public string Iban { get; set; }

            public string Bic { get; set; }

            public string BankCode { get; set; }

            public string DocumentId { get; set; }

            public string IpAddress { get; set; }

            public Builder(string paymentOption, string holder, string ipAddress)
            {
                PaymentOption = paymentOption;
                Holder = holder;
                IpAddress = ipAddress;
            }

            public Builder WithIban(string iban)
            {
                Iban = iban;
                return this;
            }

            public Builder WithBic(string bic)
            {
                Bic = bic;
                return this;
            }

            public Builder WithBankCode(string bankCode)
            {
                BankCode = bankCode;
                return this;
            }

            public Builder WithDocumentId(string documentId)
            {
                DocumentId = documentId;
                return this;
            }

            public Payment Build()
            {
                return new Payment(this);
            }
        }

        private Payment(Builder builder)
        {
            PaymentOption = builder.PaymentOption;
            Holder = builder.Holder;
            Iban = builder.Iban;
            Bic = builder.Bic;
            BankCode = builder.BankCode;
            DocumentId = builder.DocumentId;
            IpAddress = builder.IpAddress;
        }
    }
}
