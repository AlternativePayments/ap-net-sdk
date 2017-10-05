using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AlternativePayments
{
    public abstract class BaseService<T>
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        protected BaseService(HttpClient httpClient, string apiUrl)
        {
            _httpClient = httpClient;
            _apiUrl = apiUrl;
        }

        protected T GetResource(string url)
        {
            var result = SendGetRequest(url);
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected U GetResource<U>(string url)
        {
            var result = SendGetRequest(url);
            return JsonConvert.DeserializeObject<U>(result);
        }

        protected T CreateResource(string url, object model)
        {
            var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
            var result = SendPostRequest(url, JsonConvert.SerializeObject(model, settings));
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected T UpdateResource(string url, object model)
        {
            var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
            var result = SendPutRequest(url, JsonConvert.SerializeObject(model, settings));
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected T DeleteResource(string url)
        {
            var result = SendDeleteRequest(url);
            return JsonConvert.DeserializeObject<T>(result);
        }

        protected T DeleteResource(string url, object model)
        {
            var settings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
            var result = SendDeleteRequest(url, JsonConvert.SerializeObject(model, settings));
            return JsonConvert.DeserializeObject<T>(result);
        }

        private string SendGetRequest(string url)
        {
            var response = _httpClient.GetAsync(_apiUrl + url).Result;
            var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
                return responseText;

            throw BuildAlternativePaymentsException(response.StatusCode, responseText);
        }

        private string SendPostRequest(string url, string body)
        {
            var content = new StringContent(body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = _httpClient.PostAsync(_apiUrl + url, content).Result;
            var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
                return responseText;

            throw BuildAlternativePaymentsException(response.StatusCode, responseText);
        }

        private string SendPutRequest(string url, string body)
        {
            var content = new StringContent(body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = _httpClient.PutAsync(_apiUrl + url, content).Result;
            var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
                return responseText;

            throw BuildAlternativePaymentsException(response.StatusCode, responseText);
        }

        private string SendDeleteRequest(string url)
        {
            var response = _httpClient.DeleteAsync(_apiUrl + url).Result;
            var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
                return responseText;

            throw BuildAlternativePaymentsException(response.StatusCode, responseText);
        }

        private string SendDeleteRequest(string url, string body)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, _apiUrl + url) {Content = new StringContent(body)};
            var response = _httpClient.SendAsync(request).Result;
            var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
                return responseText;

            throw BuildAlternativePaymentsException(response.StatusCode, responseText);
        }

        private static AlternativePaymentsException BuildAlternativePaymentsException(HttpStatusCode statusCode, string responseContent)
        {
            var error = JsonConvert.DeserializeObject<Error>(responseContent);

            return new AlternativePaymentsException(statusCode, error, error.Message);
        }
    }
}
