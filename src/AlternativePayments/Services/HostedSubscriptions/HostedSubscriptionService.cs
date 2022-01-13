using AlternativePayments.HostedPage;
using AlternativePayments.Infrastructure.Constants;
using System.Net.Http;

namespace AlternativePayments.Services.HostedSubscriptions
{
    public class HostedSubscriptionService : BaseService<HostedSubscription>
    {
        public HostedSubscriptionService(HttpClient httpClient, string apiUrl) : base(httpClient, apiUrl)
        {
        }

        public HostedSubscription Create(HostedSubscription hostedSubscription)
        {
            return CreateResource(Urls.SubscriptionsHosted, hostedSubscription);
        }
    }
}
