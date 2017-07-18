using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestPayments
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void GetPaymentById()
        {
            // Arange
            var paymentId = "pay_7cd5a213a5f44c0e8";

            // Act
            var payment = _alternativePayments.PaymentService.Get(paymentId);

            // Assert
            Assert.That(paymentId, Is.EqualTo(payment.Id));
        }

        [Test]
        public void PaymentNotFound()
        {
            // Arange
            var paymentId = "pay_7cd5a213a5f44c0e8-";

            // Act
            var ex = Assert.Throws<AlternativePaymentsException>(() => _alternativePayments.PaymentService.Get(paymentId));

            // Assert
            Assert.That(ex.Error.Code, Is.EqualTo("requested_resource_could_not_be_found"));
        }

        [Test]
        public void CreatePayment()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("BE88271080782541")
                .Build();

            // Act
            var result = _alternativePayments.PaymentService.Create(payment);

            // Assert
            Assert.That(result.PaymentOption, Is.EqualTo("SEPA"));
        }
    }
}
