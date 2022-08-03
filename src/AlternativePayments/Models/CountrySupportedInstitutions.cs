using System.Collections.Generic;

namespace AlternativePayments
{
    public class CountrySupportedInstitutions
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NumericalCode { get; set; }

        public string Iso1Code { get; set; }

        public string Iso3Code { get; set; }

        public IEnumerable<Institution> SupportedInstitutions { get; set; }
    }
}