﻿namespace AlternativePayments.Infrastructure.Constants
{
    internal static class Urls
    {
        internal static string BaseUrl => "https://api.local/api";

        public static string Customers => "/customers";

        public static string Payments => "/payments";

        public static string Transactions => "/transactions";

        public static string SepaTransactions => "/sepa/transactions";

        public static string Plans => "/plans";

        public static string Subscriptions => "/subscriptions";
        public static string SubscriptionsHosted => "/subscriptions/hosted";

        public static string PhoneVerification => "/phoneverification";
        
        public static string AcquirerSupportedInstitutionsByCountries => "/acquirersupportedinstitutions/countries";
    }
}
