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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVendorAsync(string Id, VendorRequestModel requestModel)
    {
        Result<VendorResponseModel> responseModel = await _vendorService.UpdateVendorAsync(
            Id,
            requestModel
        );
        return Ok(responseModel);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetVendorAsync(string Id)
    {
        var model = await _vendorService.GetVendorAsync(Id);
        return Ok(model);
    }
}
