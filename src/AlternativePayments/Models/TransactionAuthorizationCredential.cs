using System.Collections.Generic;

namespace AlternativePayments
{
    public class TransactionAuthorizationCredential : BaseModel
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string AuthorizationMethodId { get; set; }
        
        public string Description { get; set; }
        
        public string AuthorizationMethodType { get; set; }
        
        public IEnumerable<string> AuthorizationOptions { get; set; }
    }
}