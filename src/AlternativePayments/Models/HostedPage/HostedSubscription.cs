using AlternativePayments.Models.HostedPage;
using Newtonsoft.Json;

namespace AlternativePayments.HostedPage
{
    public class HostedSubscription : BaseModel
    {
        public HostedSubscription() { }
        private HostedSubscription(Builder builder)
        {
            PlanId = builder.PlanId;
            IpAddress = builder.IpAddress;
            RedirectUrls = builder.RedirectUrls;
            Customer = builder.Customer;
            Payment = builder.Payment;
            Quantity = builder.Quantity;
            MerchantPassThruData = builder.MerchantPassThruData;
        }

        [JsonProperty]
        public string PlanId { get; private set; }
        [JsonProperty]
        public RedirectUrls RedirectUrls { get; private set; }
        [JsonProperty]
        public string RedirectUrl { get; private set; }
        [JsonProperty]
        public SubscriptionCustomer Customer { get; private set; }
        [JsonProperty]
        public SepaPaymentInfo Payment { get; private set; }
        [JsonProperty]
        public int Quantity { get; private set; }
        [JsonProperty]
        public string MerchantPassThruData { get; private set; }
        [JsonProperty]
        public string Mode { get; private set; }
        [JsonProperty]
        public bool IsConversionRateFixed { get; private set; }
        [JsonProperty]
        public int Amount { get; private set; }
        [JsonProperty]
        public string Currency { get; private set; }


        public sealed class Builder
        {
            internal RedirectUrls RedirectUrls { get; }
            internal string PlanId { get; }
            internal string IpAddress { get; }
            internal int Quantity { get; private set; }
            internal SubscriptionCustomer Customer { get; private set; }
            internal SepaPaymentInfo Payment { get; private set; }
            internal string MerchantPassThruData { get; private set; }

            public Builder(string planId, string ipAddress, string returnUrl, string cancelUrl, int quantity = 1)
            {
                PlanId = planId;
                IpAddress = ipAddress;
                RedirectUrls = new RedirectUrls
                {
                    ReturnUrl = returnUrl,
                    CancelUrl = cancelUrl
                };
                Quantity = quantity;
            }

            public Builder WithQuantity(int quantity)
            {
                Quantity = quantity;
                return this;
            }

            public Builder WithCustomer(SubscriptionCustomer customer)
            {
                Customer = customer;
                return this;
            }

            public Builder WithSepaPaymentInfo(SepaPaymentInfo payment)
            {
                Payment = payment;
                return this;
            }

            public Builder WithMerchantPassThruData(string merchantPassThruData)
            {
                MerchantPassThruData = merchantPassThruData;
                return this;
            }

            public HostedSubscription Build()
            {
                return new HostedSubscription(this);
            }
        }
    }
}
