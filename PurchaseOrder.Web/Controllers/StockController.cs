using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.Web.Extensions;
using PurchaseOrder.Web.Models;

namespace PurchaseOrder.Web.Controllers;

public class StockController : Controller
{
    private readonly HttpClient _httpClient;

    public StockController(IHttpClientFactory _httpClientFactory)
    {
        _httpClient = _httpClientFactory.CreateClient("HttpClient");
    }

    public async Task<IActionResult> IndexAsync()
    {
        List<StockModel> lst = new List<StockModel>();
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/stock");
            //response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var apiResponse = jsonStr.ToObject<StockResponseModel>();
                lst = apiResponse.Data;
            }

            return View(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IActionResult NewStock()
    {
        return View();
    }
}
