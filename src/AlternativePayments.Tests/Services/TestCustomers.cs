using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestCustomers
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void GetCustomerById()
        {
            // Arange
            var customerId = "cus_a29fcd978cea4360a";

            // Act
            var customer = _alternativePayments.CustomerService.Get(customerId);

            // Assert
            Assert.That(customerId, Is.EqualTo(customer.Id));
        }

        [Test]
        public void CustomerNotFound()
        {
            // Arange
            var planId = "cus_144a408924c1-";

            // Act
            var ex = Assert.Throws<AlternativePaymentsException>(() => _alternativePayments.PlanService.Get(planId));

            // Assert
            Assert.That(ex.Error.Code, Is.EqualTo("requested_resource_could_not_be_found"));
        }

        [Test]
        public void CreateCustomer()
        {
            // Arange
            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            // Act
            var result = _alternativePayments.CustomerService.Create(customer);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("John"));
        }
    }
}
