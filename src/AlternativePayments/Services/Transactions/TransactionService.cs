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

        public TransactionList GetAll()
        {
            return GetAll(null);
        }

        public TransactionList GetAll(CommonFilter filter)
        {
            var queryString = filter == null ? string.Empty : $"?{filter.GetQueryString()}";
            return GetResource<TransactionList>($"{Urls.Transactions}{queryString}");
        }

        public TransactionList GetAllSepa()
        {
            return GetAllSepa(null);
        }

        public TransactionList GetAllSepa(SepaFilter filter)
        {
            var queryString = filter == null ? string.Empty : $"?{filter.GetQueryString()}";
            return GetResource<TransactionList>($"{Urls.SepaTransactions}{queryString}");
        }

        public Transaction Create(Transaction transaction)
        {
            return CreateResource(Urls.Transactions, transaction);
        }
        
        public TransactionAuthorization Authorize(string transactionId,TransactionAuthorizationCredential credential)
        {
            var url = $"{Urls.Transactions}/{transactionId}/authorize";
            return CreateResource<TransactionAuthorization>(url, credential);
        }
    }
}
