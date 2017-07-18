using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestPlans
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }

        [Test]
        public void GetPlanById()
        {
            // Arange
            var planId = "pln_144a408924c1";

            // Act
            var plan = _alternativePayments.PlanService.Get(planId);

            // Assert
            Assert.That(planId, Is.EqualTo(plan.Id));
        }

        [Test]
        public void PlanNotFound()
        {
            // Arange
            var planId = "pln_144a408924c1-";

            // Act
            var ex = Assert.Throws<AlternativePaymentsException>(() => _alternativePayments.PlanService.Get(planId));
            
            // Assert
            Assert.That(ex.Error.Code, Is.EqualTo("requested_resource_could_not_be_found"));
        }

        [Test]
        public void CreatePlan()
        {
            // Arange
            var plan = new Plan.Builder("sdk plan", "sdk plan description", 500, "USD", "Day", 1, "89.216.124.9")
                .WithTrialPeriod(1)
                .WithFixedConversioinRate()
                .Build();

            // Act
            var result = _alternativePayments.PlanService.Create(plan);

            // Assert
            Assert.That(result.Name, Is.EqualTo("sdk plan"));
        }

        [Test]
        public void UpdatePlan()
        {
            // Arange
            var planName = "sdk new plan";
            var planDescription = "sdk new plan description";
            var planId = "pln_ae0c56872c90";

            // Act
            var result = _alternativePayments.PlanService.Update(planId, planName, planDescription);

            // Assert
            Assert.That(result.Name, Is.EqualTo(planName));
        }

        [Test]
        public void DeactivatePlan()
        {
            // Arange
            var planId = "pln_ae0c56872c90";

            // Act
            var result = _alternativePayments.PlanService.Deactivate(planId);

            // Assert
            Assert.That(result.Status, Is.EqualTo("Inactive"));
        }

        [Test]
        public void DeactivatePlanAndSubscriptions()
        {
            // Arange
            var planId = "pln_ae0c56872c90";

            // Act
            var result = _alternativePayments.PlanService.Deactivate(planId, true);

            // Assert
            Assert.That(result.Status, Is.EqualTo("Inactive"));
        }
    }
}
