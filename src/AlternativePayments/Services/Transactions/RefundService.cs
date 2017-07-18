using AlternativePayments.Infrastructure.Constants;
using System.Net.Http;

namespace AlternativePayments
{
    public class RefundService : BaseService<Refund>
    {
        public RefundService(HttpClient httpClient, string apiUrl) 
            : base(httpClient, apiUrl)
        {
        }

        public Refund Get(string transactionId, string refundId)
        {
            return GetResource($"{Urls.Transactions}/{transactionId}/refunds/{refundId}");
        }

        public Refund Refund(string transactionId, string reason)
        {
            return CreateResource($"{Urls.Transactions}/{transactionId}/refunds/", new RefundRequest { Reason = reason });
        }
    }
}
