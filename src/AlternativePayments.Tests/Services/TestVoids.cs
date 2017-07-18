using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestVoids
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void GetVoidById()
        {
            // Arange
            var transactionId = "trn_90d4464b83df";
            var voidId = "";

            // Act
            var refund = _alternativePayments.VoidService.Get(transactionId, voidId);

            // Assert
            Assert.That(transactionId, Is.EqualTo(refund.Id));
        }

        [Test]
        public void VoidTransaction()
        {
            // Arange
            var transactionId = "trn_2e1f9aced20b43";
            var reason = ReturnReason.ChargebackAvoidance;

            // Act
            var voidTransaction = _alternativePayments.VoidService.Void(transactionId, reason);

            // Assert
            Assert.That(transactionId, Is.EqualTo(voidTransaction.OriginalTransactionId));
        }
    }
}
