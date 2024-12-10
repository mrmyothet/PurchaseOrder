using System.Security.Cryptography;
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

    public async Task<Result<VendorResponseModel>> CreateVendorAsync(VendorRequestModel model)
    {
        try
        {
            var item = new VendorContextModel()
            {
                Id = Generate32BitString(),
                Name = model.Name,
                ContactName = model.ContactName,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
            };

            _appDbContext.Vendors.Add(item);
            await _appDbContext.SaveChangesAsync();

            var response = new VendorResponseModel()
            {
                Id = item.Id,
                Name = model.Name,
                ContactName = model.ContactName,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
            };

            return Result<VendorResponseModel>.Success(response);
        }
        catch (Exception ex)
        {
            string message = "An error occurred when creating vendor " + ex.ToString();
            _logger.LogError(message);
            return Result<VendorResponseModel>.Failure(message);
        }
    }

    public string Generate32BitString()
    {
        byte[] buffer = new byte[16];
        RandomNumberGenerator.Fill(buffer);
        return BitConverter.ToString(buffer).Replace("-", "");
    }
}
