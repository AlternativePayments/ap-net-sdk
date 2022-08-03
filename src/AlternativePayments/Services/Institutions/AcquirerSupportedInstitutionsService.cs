using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using AlternativePayments.Infrastructure.Constants;

namespace AlternativePayments
{
    public class AcquirerSupportedInstitutionsService : BaseService<CountrySupportedInstitutions>
    {
        public AcquirerSupportedInstitutionsService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }
        
        public IEnumerable<CountrySupportedInstitutions> GetAll()
        {
            return GetResource<IEnumerable<CountrySupportedInstitutions>>($"{Urls.AcquirerSupportedInstitutionsByCountries}");
        }

        public CountrySupportedInstitutions Get(int countryId)
        {
            return GetResource($"{Urls.AcquirerSupportedInstitutionsByCountries}/{countryId}");
        }
    }
}