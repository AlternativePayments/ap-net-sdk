using System.Net.Http;
using AlternativePayments.Infrastructure.Constants;

namespace AlternativePayments
{
    public class PlanService : BaseService<Plan>
    {
        public PlanService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }
        
        public Plan Get(string planId)
        {
            return GetResource($"{Urls.Plans}/{planId}");
        }

        public Plan Create(Plan plan)
        {
            return CreateResource(Urls.Plans, plan);
        }

        public Plan Update(string planId, string name, string description)
        {
            var plan = new PlanUpdateRequest
            {
                Name = name,
                Description = description
            };
            return UpdateResource($"{Urls.Plans}/{planId}", plan);
        }

        public Plan Deactivate(string planId, bool cancelSubscriptions = false)
        {
            return DeleteResource($"{Urls.Plans}/{planId}", new { CancelSubscriptions = cancelSubscriptions });
        }
    }
}
