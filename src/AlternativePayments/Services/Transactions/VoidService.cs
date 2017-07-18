using AlternativePayments.Infrastructure.Constants;
using System.Net.Http;

namespace AlternativePayments
{
    public class VoidService : BaseService<Void>
    {
        public VoidService(HttpClient httpClient, string apiUrl) 
            : base(httpClient, apiUrl)
        {
        }

        public Void Get(string transactionId, string voidId)
        {
            return GetResource($"{Urls.Transactions}/{transactionId}/voids/{voidId}");
        }

        public Void Void(string transactionId, string reason)
        {
            return CreateResource($"{Urls.Transactions}/{transactionId}/voids/", new RefundRequest { Reason = reason });
        }
    }
}
