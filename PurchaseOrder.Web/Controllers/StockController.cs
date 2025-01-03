﻿using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PurchaseOrder.Web.Extensions;
using PurchaseOrder.Web.Models;
using PurchaseOrder.Web.Services;
using static System.Net.Mime.MediaTypeNames;
using HttpMethod = PurchaseOrder.Web.Services.HttpMethod;

namespace PurchaseOrder.Web.Controllers;

public class StockController : Controller
{
    private readonly HttpClient _httpClient;
    internal readonly HttpClientService _httpClientService;

    public StockController(
        IHttpClientFactory _httpClientFactory,
        HttpClientService httpClientService
    )
    {
        _httpClient = _httpClientFactory.CreateClient("HttpClient");
        _httpClientService = httpClientService;
    }

    public async Task<IActionResult> IndexAsyncV1()
    {
        List<StockModel> lst = new List<StockModel>();
        try
        {
            StockResponseModel? result = await _httpClientService.ExecuteAsync<StockResponseModel>(
                _httpClient,
                "/api/stock",
                HttpMethod.GET
            );
            lst = result.Data;

            return View(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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

    [ActionName("New")]
    public IActionResult New()
    {
        return View();
    }

    [ActionName("Save")]
    public async Task<IActionResult> SaveAsync(StockModel item)
    {
        string jsonStr = JsonConvert.SerializeObject(item);
        HttpContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _httpClient.PostAsync("/api/stock", content);

        if (!response.IsSuccessStatusCode)
        {
            return View("New");
        }

        return RedirectToAction("Index");
    }

    [ActionName("SaveV1")]
    public async Task<IActionResult> SaveAsyncV1(StockModel item)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/stock", item);

        if (!response.IsSuccessStatusCode)
        {
            return View("New");
        }

        return RedirectToAction("Index");
    }
}
