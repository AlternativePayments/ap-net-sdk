using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestPhoneVerification
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void CreatePin()
        {
            // Arange
            var publicKey = "pk_test_qG3mJiW3kz4joQjUerpo123n2oMKz1AlckT8XBGaTqe";
            var phoneNumber = "234523623564";

            // Act
            var result = _alternativePayments.PhoneVerificationService.CreatePin(publicKey, phoneNumber);

            // Assert
            Assert.That(result.Phone, Is.EqualTo(phoneNumber));
        }
    }
}
