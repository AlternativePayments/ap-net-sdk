using System.Collections.Generic;

namespace AlternativePayments
{
    public class TransactionAuthorization : BaseModel
    {
        public string TransactionCode { get; set; }
        
        public string TransactionStatus { get; set; }
        
        public string TransactionAuthorizationStatus { get; set; }
        
        public IEnumerable<TransactionAuthorizationCredential> Credentials { get; set; }
        
        public string RedirectUrl { get; set; }
        
        public string QrCodeUrl { get; set; }
        
        public int? RemainingLoginAttempts { get; set; }
    }
}