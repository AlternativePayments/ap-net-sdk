namespace AlternativePayments
{
    public class Customer : BaseModel
    {
        public Customer()
        {
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }

        public string BirthDate { get; set; }

        public sealed class Builder
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Address { get; set; }

            public string Address2 { get; set; }

            public string City { get; set; }

            public string Zip { get; set; }

            public string Country { get; set; }

            public string State { get; set; }

            public string Phone { get; set; }

            public string BirthDate { get; set; }

            public string IpAddress { get; set; }

            public Builder(string firstName, string lastName, string email, string country, string ipAddress)
            {
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Country = country;
                IpAddress = ipAddress;
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

            public Builder WithCity(string city)
            {
                City = city;
                return this;
            }

            public Builder WithZip(string zip)
            {
                Zip = zip;
                return this;
            }

            public Builder WithState(string state)
            {
                State = state;
                return this;
            }

            public Builder WithPhone(string phone)
            {
                Phone = phone;
                return this;
            }

            public Builder WithBirthDate(string birthDate)
            {
                BirthDate = birthDate;
                return this;
            }

            public Customer Build()
            {
                return new Customer(this);
            }
        }

        private Customer(Builder builder)
        {
            FirstName = builder.FirstName;
            LastName = builder.LastName;
            Email = builder.Email;
            Country = builder.Country;
            IpAddress = builder.IpAddress;
            Address = builder.Address;
            Address2 = builder.Address2;
            City = builder.City;
            Zip = builder.Zip;
            State = builder.State;
            Phone = builder.Phone;
            BirthDate = builder.BirthDate;
        }
    }
}
