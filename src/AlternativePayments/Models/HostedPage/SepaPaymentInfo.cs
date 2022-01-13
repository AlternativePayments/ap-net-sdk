using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativePayments.Models.HostedPage
{
    public class SepaPaymentInfo
    {
        public SepaPaymentInfo()
        {

        }
        private SepaPaymentInfo(Builder builder)
        {
            MandateId = builder.MandateId;
            MandateDateOfSignature = builder.MandateDateOfSignature;
        }
        [JsonProperty]
        public string MandateId { get; private set; }
        [JsonProperty]
        public string MandateDateOfSignature { get; private set; }

        public sealed class Builder
        {
            public string MandateId { get; private set; }
            public string MandateDateOfSignature { get; private set; }
            public Builder(string mandateId, string mandateDateOfSignature)
            {
                MandateId = mandateId;
                MandateDateOfSignature = mandateDateOfSignature;
            }

            public SepaPaymentInfo Build()
            {
                return new SepaPaymentInfo(this);
            }
        }
    }
}
