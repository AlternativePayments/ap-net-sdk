using NUnit.Framework;

namespace AlternativePayments.Tests.Services
{
    public class TestAcquirerSupportedInstitutions
    {
        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");
        }
        
        [Test]
        public void GetInstitutionsByCountryId()
        {
            // Arange
            var countryId = 314; // France

            // Act
            var countrySupportedInstitutions = _alternativePayments.AcquirerSupportedInstitutionsService.Get(countryId);

            // Assert
            Assert.That(countryId, Is.EqualTo(countrySupportedInstitutions.Id));
        }
        
        [Test]
        public void GetAll()
        {
            // Act
            var institutions = _alternativePayments.AcquirerSupportedInstitutionsService.GetAll();

            // Assert
            Assert.IsNotEmpty(institutions);
        }
    }
}