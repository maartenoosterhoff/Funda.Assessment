using System;
using System.Net.Http;

using Newtonsoft.Json;

using Funda.Assessment.Interfaces;

namespace Funda.Assessment.Implementations
{
    public class JsonDataRetriever : IDataRetriever
    {
        // An http-client is designed to be used for multiple request, so create a single (lazy) instance.
        // Source: http://codereview.stackexchange.com/a/69954/95974
        private static readonly Lazy<HttpClient> LazyHttpClientInstance = new Lazy<HttpClient>(() => new HttpClient());

        public TDataItem Get<TDataItem>(string url)
        {
            // Retrieve data from url.
            using (var response = LazyHttpClientInstance.Value.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    // Success, so parse the JSON data into objects.
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<TDataItem>(jsonData);
                    return data;
                }

                // Fail, so display error code, and throw exception.
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new InvalidOperationException();
            }
        }
    }
}
