using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using AlternativePayments.Infrastructure.Constants;
using System.Net;

namespace AlternativePayments
{
    public class AlternativePaymentsClient
    {
        private readonly Lazy<CustomerService> _customerService;
        private readonly Lazy<PaymentService> _paymentService;
        private readonly Lazy<TransactionService> _transactionService;
        private readonly Lazy<PlanService> _planService;
        private readonly Lazy<SubscriptionService> _subscriptionService;
        private readonly Lazy<RefundService> _refundService;
        private readonly Lazy<VoidService> _voidService;
        private readonly Lazy<PhoneVerificationService> _phoneVerificationService;

        public AlternativePaymentsClient(string apiKey, string baseUrl = null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var apiUrl = baseUrl ?? Urls.BaseUrl;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var authInfo = apiKey + ":";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            var version = new AssemblyName(typeof(AlternativePaymentsClient).GetTypeInfo().Assembly.FullName).Version.ToString(3);

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"Alternative Payments .NET SDK v{version}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

            _customerService = new Lazy<CustomerService>(() => new CustomerService(httpClient, apiUrl));
            _paymentService = new Lazy<PaymentService>(() => new PaymentService(httpClient, apiUrl));
            _transactionService = new Lazy<TransactionService>(() => new TransactionService(httpClient, apiUrl));
            _planService = new Lazy<PlanService>(() => new PlanService(httpClient, apiUrl));
            _subscriptionService = new Lazy<SubscriptionService>(() => new SubscriptionService(httpClient, apiUrl));
            _refundService = new Lazy<RefundService>(() => new RefundService(httpClient, apiUrl));
            _voidService = new Lazy<VoidService>(() => new VoidService(httpClient, apiUrl));
            _phoneVerificationService = new Lazy<PhoneVerificationService>(() => new PhoneVerificationService(httpClient, apiUrl));
        }

        public CustomerService CustomerService => _customerService.Value;

        public PaymentService PaymentService => _paymentService.Value;

        public TransactionService TransactionService => _transactionService.Value;

        public PlanService PlanService => _planService.Value;

        public SubscriptionService SubscriptionService => _subscriptionService.Value;

        public RefundService RefundService => _refundService.Value;

        public VoidService VoidService => _voidService.Value;

        public PhoneVerificationService PhoneVerificationService => _phoneVerificationService.Value;
    }
}
