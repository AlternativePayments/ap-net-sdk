using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestRefunds
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void GetRefundById()
        {
            // Arange
            var transactionId = "trn_90d4464b83df";
            var refundId = "";

            // Act
            var refund = _alternativePayments.RefundService.Get(transactionId, refundId);

            // Assert
            Assert.That(transactionId, Is.EqualTo(refund.Id));
        }

        [Test]
        public void RefundTransaction()
        {
            // Arange
            var transactionId = "trn_2e1f9aced20b43";
            var reason = ReturnReason.ChargebackAvoidance;

            // Act
            var refund = _alternativePayments.RefundService.Refund(transactionId, reason);

            // Assert
            Assert.That(transactionId, Is.EqualTo(refund.OriginalTransactionId));
        }
    }
}
