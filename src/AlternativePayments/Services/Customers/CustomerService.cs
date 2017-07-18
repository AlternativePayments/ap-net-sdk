using System.Net.Http;
using AlternativePayments.Infrastructure.Constants;

namespace AlternativePayments
{
    public class CustomerService : BaseService<Customer>
    {
        public CustomerService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        public Customer Get(string customerId)
        {
            return GetResource($"{Urls.Customers}/{customerId}");
        }

        public Customer Create(Customer customer)
        {
            return CreateResource(Urls.Customers, customer);
        }
    }
}
