using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PurchaseOrder.API.Extensions;
using PurchaseOrder.API.Models;
using PurchaseOrder.API.Services;

namespace PurchaseOrder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockService _stockService;

    public StockController(StockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStocksAsync()
    {
        var model = await _stockService.GetAllStocksAsync();
        return Ok(model.ToJson());
    }

    [HttpPost]
    public async Task<IActionResult> SaveAsync(StockRequestModel requestModel)
    {
        var model = await _stockService.CreateStockAsync(requestModel);
        return Ok(model.ToJson());
    }
}
