using System.Net.Http;
using AlternativePayments.Infrastructure.Constants;

namespace AlternativePayments
{ 
    public class PaymentService : BaseService<Payment>
    {
        public PaymentService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        public Payment Get(string paymentId)
        {
            return GetResource($"{Urls.Payments}/{paymentId}");
        }

        public Payment Create(Payment payment)
        {
            return CreateResource(Urls.Payments, payment);
        }
    }
}
