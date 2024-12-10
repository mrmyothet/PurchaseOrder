using Microsoft.EntityFrameworkCore;
using PurchaseOrder.API.Models;

namespace PurchaseOrder.API.Services;

public class VendorService
{
    private readonly ILogger<VendorService> _logger;

    private readonly AppDbContext _appDbContext;

    public VendorService(ILogger<VendorService> logger, AppDbContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    public async Task<Result<List<VendorResponseModel>>> GetAllVendorsAsync()
    {
        var lst = await _appDbContext.Vendors.ToListAsync();

        var model = lst.Select(v => new VendorResponseModel
            {
                Id = v.Id,
                Name = v.Name,
                ContactName = v.ContactName,
                Phone = v.Phone,
                Email = v.Email,
                Address = v.Address,
            })
            .ToList();

        return Result<List<VendorResponseModel>>.Success(model);
    }
}
