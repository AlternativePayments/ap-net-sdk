namespace AlternativePayments
{
    public class Plan : BaseModel
    {
        public Plan()
        {
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public string IntervalUnit { get; set; }

        public int IntervalCount { get; set; }

        public int BillingCycles { get; set; }

        public int TrialPeriod { get; set; }

        public bool IsConversionRateFixed { get; set; }

        public string Status { get; set; }

        public sealed class Builder
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public int Amount { get; set; }

            public string Currency { get; set; }

            public string IntervalUnit { get; set; }

            public int IntervalCount { get; set; }

            public int BillingCycles { get; set; }

            public int TrialPeriod { get; set; }

            public bool IsConversionRateFixed { get; set; }

            public string IpAddress { get; set; }

            public Builder(string name, string description, int amount, string currency, string intervalUnit, int intervalCount, string ipAddress)
            {
                Name = name;
                Description = description;
                Amount = amount;
                Currency = currency;
                IntervalUnit = intervalUnit;
                IntervalCount = intervalCount;
                IpAddress = ipAddress;
            }

            public Builder WithBillingCycles(int billingCycles)
            {
                BillingCycles = billingCycles;
                return this;
            }

            public Builder WithTrialPeriod(int trialPeriod)
            {
                TrialPeriod = trialPeriod;
                return this;
            }

            public Builder WithFixedConversioinRate()
            {
                IsConversionRateFixed = true;
                return this;
            }

            public Plan Build()
            {
                return new Plan(this);
            }
        }

        private Plan(Builder builder)
        {
            Name = builder.Name;
            Description = builder.Description;
            Amount = builder.Amount;
            Currency = builder.Currency;
            IntervalUnit = builder.IntervalUnit;
            IntervalCount = builder.IntervalCount;
            BillingCycles = builder.BillingCycles;
            TrialPeriod = builder.TrialPeriod;
            IsConversionRateFixed = builder.IsConversionRateFixed;
            IpAddress = builder.IpAddress;
        }
    }
}
