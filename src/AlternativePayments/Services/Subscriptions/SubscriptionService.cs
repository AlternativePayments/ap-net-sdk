using System.Net.Http;
using AlternativePayments.Infrastructure.Constants;

namespace AlternativePayments
{
    public class SubscriptionService : BaseService<Subscription>
    {
        public SubscriptionService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        public Subscription Get(string subscriptionId)
        {
            return GetResource($"{Urls.Subscriptions}/{subscriptionId}");
        }

        public Subscription Create(Subscription subscription)
        {
            return CreateResource(Urls.Subscriptions, subscription);
        }

        public Subscription Cancel(string subscriptionId, string reason)
        {
            return DeleteResource($"{Urls.Subscriptions}/{subscriptionId}", new { CancelationReason = reason });
        }
    }
}
