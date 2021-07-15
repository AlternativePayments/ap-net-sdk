using AlternativePayments.HostedPage;
using AlternativePayments.Models.HostedPage;
using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    class TestHostedSubscriptions
    {
        private const string ApiKey = "-- please provide valid test API key --";
        private const string ApiBaseUrl = "-- please provide valid base URL --";
        private const string PlanId = "-- please provide valid planId --";
        private const string IpAddress = "91.218.229.20";
        private const string SuccessURL = "http://alternativepayments.com/message/success.html";
        private const string FailURL = "http://alternativepayments.com/message/failure.html";
        private const string FirstName = "John";
        private const string LastName = "Doe";
        private const string Email = "john@doe.com";
        private const string Country = "DE";
        private const string Address = "Address1";
        private const string Address2 = "Address2";
        private const string MandateId = "mdt123";
        private const string MandateDateOfSignature = "06/06/2020";
        private const int Quantity = 10;
        private const string MerchantPassThruData = "custom_data";

        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient(ApiKey, ApiBaseUrl);
        }


        [Test]
        public void CreateHostedPageSubscription_MinimumRequest_ReturnsRedirectUrl()
        {
            //Arrange
            var hostedSubscription = new HostedSubscription.Builder(PlanId, IpAddress, SuccessURL, FailURL).Build();

            //Act
            var response = _alternativePayments.HostedSubscriptionService.Create(hostedSubscription);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.RedirectUrl);
        }

        [Test]
        public void CreateHostedPageSubscription_AllRequestProperties_ReturnResponse()
        {
            //Arrange
            var customer = new SubscriptionCustomer.Builder()
                .WithFirstName(FirstName)
                .WithLastName(LastName)
                .WithEmail(Email)
                .WithCountry(Country)
                .WithAddress(Address)
                .WithAddress2(Address2)
                .Build();

            var payment = new SepaPaymentInfo.Builder(MandateId, MandateDateOfSignature).Build();

            var hostedSubscription = new HostedSubscription
                .Builder(PlanId, IpAddress, SuccessURL, FailURL)
                .WithCustomer(customer)
                .WithSepaPaymentInfo(payment)
                .WithMerchantPassThruData(MerchantPassThruData)
                .WithQuantity(Quantity)
                .Build();

            //Act
            var response = _alternativePayments.HostedSubscriptionService.Create(hostedSubscription);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Created);
            Assert.IsNotEmpty(response.Id);
            Assert.IsNotEmpty(response.Mode);
            Assert.IsNotEmpty(response.RedirectUrl);
            Assert.Greater(response.Amount, 0);
            Assert.IsInstanceOf<bool>(response.IsConversionRateFixed);
            Assert.AreEqual(Quantity, response.Quantity);
            Assert.AreEqual(MerchantPassThruData, response.MerchantPassThruData);

            Assert.AreEqual(FirstName, response.Customer.FirstName);
            Assert.AreEqual(LastName, response.Customer.LastName);
            Assert.AreEqual(Email, response.Customer.Email);
            Assert.AreEqual(Country, response.Customer.Country);
            Assert.AreEqual(Address, response.Customer.Address);
            Assert.AreEqual(Address2, response.Customer.Address2);

            Assert.AreEqual(MandateId, response.Payment.MandateId);
            Assert.AreEqual(MandateDateOfSignature, response.Payment.MandateDateOfSignature);
        }

        [Test]
        public void BuildCustomer()
        {
            //Arrange

            //Act
            var customer = new SubscriptionCustomer
                .Builder()
                .WithFirstName(FirstName)
                .WithLastName(LastName)
                .WithEmail(Email)
                .WithCountry(Country)
                .WithAddress(Address)
                .WithAddress2(Address2)
                .Build();

            //Assert
            Assert.AreEqual(FirstName, customer.FirstName);
            Assert.AreEqual(LastName, customer.LastName);
            Assert.AreEqual(Email, customer.Email);
            Assert.AreEqual(Country, customer.Country);
            Assert.AreEqual(Address, customer.Address);
            Assert.AreEqual(Address2, customer.Address2);
        }

        [Test]
        public void BuildSepaPaymentInfo()
        {
            //Arrange

            //Act
            var payment = new SepaPaymentInfo.Builder(MandateId, MandateDateOfSignature).Build();

            //Assert
            Assert.AreEqual(MandateId, payment.MandateId);
            Assert.AreEqual(MandateDateOfSignature, payment.MandateDateOfSignature);
        }

        [Test]
        public void BuildHostedSubscription()
        {
            //Arrange

            //Act
            var customer = new SubscriptionCustomer
                .Builder()
                .WithFirstName(FirstName)
                .WithLastName(LastName)
                .WithEmail(Email)
                .WithCountry(Country)
                .WithAddress(Address)
                .WithAddress2(Address2)
                .Build();

            var payment = new SepaPaymentInfo.Builder(MandateId, MandateDateOfSignature).Build();

            var subscription = new HostedSubscription.Builder(PlanId, IpAddress, SuccessURL, FailURL)
                .WithCustomer(customer)
                .WithSepaPaymentInfo(payment)
                .WithQuantity(Quantity)
                .WithMerchantPassThruData(MerchantPassThruData)
                .Build();

            //Assert
            Assert.AreEqual(subscription.Customer.FirstName, FirstName);
            Assert.AreEqual(subscription.Customer.LastName, LastName);
            Assert.AreEqual(subscription.Customer.Email, Email);
            Assert.AreEqual(subscription.Customer.Country, Country);
            Assert.AreEqual(subscription.Customer.Address, Address);
            Assert.AreEqual(subscription.Customer.Address2, Address2);
            Assert.AreEqual(subscription.Payment.MandateId, MandateId);
            Assert.AreEqual(subscription.Payment.MandateDateOfSignature, MandateDateOfSignature);
            Assert.AreEqual(subscription.Quantity, Quantity);
            Assert.AreEqual(subscription.MerchantPassThruData, MerchantPassThruData);
        }

    }
}
