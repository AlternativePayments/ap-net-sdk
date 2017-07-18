using System;

namespace AlternativePayments
{
    public class Subscription : BaseModel
    {
        public Subscription()
        {
        }

        public string PlanId { get; set; }

        public Plan Plan { get; set; }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string Token { get; set; }

        public Payment Payment { get; set; }

        public string PaymentId { get; set; }

        public int Quantity { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public bool IsConversionRateFixed { get; set; }

        public string Status { get; set; }

        public string CancellationReason { get; set; }

        public DateTime? CancelationDate { get; set; }

        public DateTime? IntervalStartDate { get; set; }

        public DateTime? TrialEndDate { get; set; }

        public DateTime? NextCaptureDate { get; set; }

        public int CurrentBillingCycle { get; set; }

        public sealed class Builder
        {
            public string PlanId { get; set; }

            public Plan Plan { get; set; }

            public string CustomerId { get; set; }

            public Customer Customer { get; set; }

            public string Token { get; set; }

            public Payment Payment { get; set; }

            public string PaymentId { get; set; }

            public int Quantity { get; set; }

            public string IpAddress { get; set; }

            public Builder(string planId, string customerId, string ipAddress)
            {
                PlanId = planId;
                CustomerId = customerId;
                IpAddress = ipAddress;
            }

            public Builder(string planId, Customer customer, string ipAddress)
            {
                PlanId = planId;
                Customer = customer;
                IpAddress = ipAddress;
            }

            public Builder(Plan plan, Customer customer, string ipAddress)
            {
                Plan = plan;
                Customer = customer;
                IpAddress = ipAddress;
            }

            public Builder(Plan plan, string customerId, string ipAddress)
            {
                Plan = plan;
                CustomerId = customerId;
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

            public Builder WithQuantity(int quantity)
            {
                Quantity = quantity;
                return this;
            }

            public Subscription Build()
            {
                return new Subscription(this);
            }
        }

        private Subscription(Builder builder)
        {
            PlanId = builder.PlanId;
            Plan = builder.Plan;
            CustomerId = builder.CustomerId;
            Customer = builder.Customer;
            PaymentId = builder.PaymentId;
            Payment = builder.Payment;
            IpAddress = builder.IpAddress;
            Quantity = builder.Quantity;
        }
    }
}
