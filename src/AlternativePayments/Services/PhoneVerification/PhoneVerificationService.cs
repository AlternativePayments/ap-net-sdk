using AlternativePayments.Infrastructure.Constants;
using System.Net.Http;

namespace AlternativePayments
{
    public class PhoneVerificationService : BaseService<PhoneVerification>
    {
        public PhoneVerificationService(HttpClient httpClient, string apiUrl) 
            : base(httpClient, apiUrl)
        {
        }

        public PhoneVerification CreatePin(string publicKey, string phoneNumber)
        {
            return CreateResource($"{Urls.PhoneVerification}", new PhoneVerification { Key = publicKey, Phone = phoneNumber });
        }
    }
}
