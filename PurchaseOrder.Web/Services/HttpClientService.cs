using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PurchaseOrder.Web.Services
{
    public class HttpClientService
    {
        public async Task<T> ExecuteAsync<T>( HttpClient client, string endpoint, HttpMethod httpMethod, object? requestModel = null)
        {
            HttpResponseMessage response = null!;
            HttpContent content = null!;

            if (requestModel is not null)
            {
                string jsonStr = JsonConvert.SerializeObject(requestModel);
                content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
            }

            switch (httpMethod)
            {
                case HttpMethod.GET:
                    response = await client.GetAsync(endpoint);
                    break;
                case HttpMethod.POST:
                    response = await client.PostAsync(endpoint, content);
                    break;
                case HttpMethod.PUT:
                    response = await client.PutAsync(endpoint, content);
                    break;
                case HttpMethod.PATCH:
                    response = await client.PatchAsync(endpoint, content);
                    break;
                case HttpMethod.DELETE:
                    response = await client.DeleteAsync(endpoint);
                    break;
                default:
                    throw new Exception("Invalid Http Method.");
            }
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse)!;
        }
    }

    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE,
    }
}
