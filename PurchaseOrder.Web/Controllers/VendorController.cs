using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.Web.Extensions;
using PurchaseOrder.Web.Models;

namespace PurchaseOrder.Web.Controllers
{
    public class VendorController : Controller
    {
        private readonly HttpClient _httpClient;

        public VendorController(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient("HttpClient");
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<VendorModel> lst = new List<VendorModel>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("/api/vendor");
                //response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    string jsonStr = await response.Content.ReadAsStringAsync();
                    var apiResponse = jsonStr.ToObject<VendorResponseModel>();
                    lst = apiResponse.Data;
                }

                return View(lst);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
