using System.Net.Http;
using AlternativePayments.Infrastructure.Constants;

namespace AlternativePayments
{
    public class TransactionService : BaseService<Transaction>
    {
        public TransactionService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        public Transaction Get(string transactionId)
        {
            return GetResource($"{Urls.Transactions}/{transactionId}");
        }

        public Transaction Create(Transaction transaction)
        {
            return CreateResource(Urls.Transactions, transaction);
        }
    }
}
