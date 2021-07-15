using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativePayments.Models.HostedPage
{
    public class SubscriptionCustomer
    {
        public SubscriptionCustomer()
        {

        }
        private SubscriptionCustomer(Builder builder)
        {
            FirstName = builder.FirstName;
            LastName = builder.LastName;
            Email = builder.Email;
            Country = builder.County;
            Address = builder.Address;
            Address2 = builder.Address2;
        }
        [JsonProperty]
        public string FirstName { get; private set; }
        [JsonProperty]
        public string LastName { get; private set; }
        [JsonProperty]
        public string Email { get; private set; }
        [JsonProperty]
        public string Country { get; private set; }
        [JsonProperty]
        public string Address { get; private set; }
        [JsonProperty]
        public string Address2 { get; private set; }

        public sealed class Builder
        {
            internal string FirstName { get; private set; }
            internal string LastName { get; private set; }
            internal string Email { get; private set; }
            internal string County { get; private set; }
            internal string Address { get; private set; }
            internal string Address2 { get; private set; }

            public Builder WithFirstName(string firstName)
            {
                FirstName = firstName;
                return this;
            }

            public Builder WithLastName(string lastName)
            {
                LastName = lastName;
                return this;
            }

            public Builder WithEmail(string email)
            {
                Email = email;
                return this;
            }

            public Builder WithCountry(string country)
            {
                County = country;
                return this;
            }

            public Builder WithAddress(string address)
            {
                Address = address;
                return this;
            }

            public Builder WithAddress2(string address2)
            {
                Address2 = address2;
                return this;
            }

            public SubscriptionCustomer Build()
            {
                return new SubscriptionCustomer(this);
            }
        }


    }
}
