using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestSubscriptions
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void GetSubscriptionById()
        {
            // Arange
            var subscriptionId = "sbs_b6421071545e";

            // Act
            var subscription = _alternativePayments.SubscriptionService.Get(subscriptionId);

            // Assert
            Assert.That(subscription.Id, Is.EqualTo(subscriptionId));
        }

        [Test]
        public void SubscriptionNotFound()
        {
            // Arange
            var subscriptionId = "sbs_144a408924c1-";

            // Act
            var ex = Assert.Throws<AlternativePaymentsException>(() => _alternativePayments.SubscriptionService.Get(subscriptionId));

            // Assert
            Assert.That(ex.Error.Code, Is.EqualTo("requested_resource_could_not_be_found"));
        }

        [Test]
        public void CreateSubscription()
        {
            // Arange
            var subscription = new Subscription.Builder("pln_c08fce73065f", "cus_a29fcd978cea4360a", "89.216.124.9")
                .WithPaymentId("pay_c2f97f0475bc451fb")
                .WithQuantity(2)
                .Build();

            // Act
            var result = _alternativePayments.SubscriptionService.Create(subscription);

            // Assert
            Assert.That(result.Quantity, Is.EqualTo(2));
        }

        [Test]
        public void CancelSubscription()
        {
            // Arange
            var subscriptionId = "sbs_8e098a7bdf56";
            var reason = "Testing";

            // Act
            var result = _alternativePayments.SubscriptionService.Cancel(subscriptionId, reason);

            // Assert
            Assert.That(result.Status, Is.EqualTo("Canceled"));
        }
    }
}
