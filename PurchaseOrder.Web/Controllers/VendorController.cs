using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PurchaseOrder.Web.Extensions;
using PurchaseOrder.Web.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PurchaseOrder.Web.Controllers;

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

    [ActionName("New")]
    public IActionResult New()
    {
        return View();
    }

    [ActionName("Save")]
    public async Task<IActionResult> SaveAsync(VendorModel newVendor)
    {
        string jsonStr = JsonConvert.SerializeObject(newVendor);
        HttpContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _httpClient.PostAsync("/api/vendor", content);

        if (!response.IsSuccessStatusCode)
        {
            return View("New");
        }

        return RedirectToAction("Index");
    }
}
