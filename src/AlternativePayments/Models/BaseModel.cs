using System;

namespace AlternativePayments
{
    public class BaseModel
    {
        public string Id { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public string IpAddress { get; set; }
    }
}
