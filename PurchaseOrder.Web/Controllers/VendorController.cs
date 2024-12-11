using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
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
                var apiResponse = jsonStr.ToObject<VendorListResponseModel>();
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
    public async Task<IActionResult> SaveAsync(VendorModel item)
    {
        string jsonStr = JsonConvert.SerializeObject(item);
        HttpContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _httpClient.PostAsync("/api/vendor", content);

        if (!response.IsSuccessStatusCode)
        {
            return View("New");
        }

        return RedirectToAction("Index");
    }

    [ActionName("Edit")]
    public async Task<IActionResult> EditAsync(string Id)
    {
        var item = new VendorModel();
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/vendor/{Id}");

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var apiResponse = jsonStr.ToObject<VendorItemResponseModel>();
                item = apiResponse.Data;

                return View(item);
            }

            return View(item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [ActionName("Update")]
    public async Task<IActionResult> UpdateAsync(string Id, VendorModel model)
    {
        try
        {
            string jsonString = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, Application.Json);

            var response = await _httpClient.PutAsync($"api/vendor/{Id}", content);
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Edit");

            return Redirect("/vendor");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
