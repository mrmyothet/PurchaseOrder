using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.API.Models;
using PurchaseOrder.API.Services;

namespace PurchaseOrder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendorController : ControllerBase
{
    private readonly VendorService _vendorService;

    public VendorController(VendorService vendorService)
    {
        _vendorService = vendorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVendorsAsync()
    {
        var model = await _vendorService.GetAllVendorsAsync();
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVendorAsync(VendorRequestModel requestModel)
    {
        var responseModel = await _vendorService.CreateVendorAsync(requestModel);
        return Ok(responseModel);
    }
}
