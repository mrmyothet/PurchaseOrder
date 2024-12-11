using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using PurchaseOrder.API.Models;
using PurchaseOrder.API.Utilities;

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

    public async Task<Result<VendorResponseModel>> GetVendorAsync(string Id)
    {
        var item = _appDbContext.Vendors.FirstOrDefault(x => x.Id == Id);
        if (item == null)
        {
            return Result<VendorResponseModel>.Failure("There is no vendor with Id: " + Id);
        }

        var responseModel = new VendorResponseModel()
        {
            Id = item.Id,
            Name = item.Name,
            ContactName = item.ContactName,
            Phone = item.Phone,
            Email = item.Email,
            Address = item.Address,
        };
        return Result<VendorResponseModel>.Success(responseModel);
    }

    public async Task<Result<VendorResponseModel>> CreateVendorAsync(VendorRequestModel model)
    {
        try
        {
            var item = new VendorContextModel()
            {
                Id = Utils.Generate32BitString(),
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

    public async Task<Result<VendorResponseModel>> UpdateVendorAsync(
        string Id,
        VendorRequestModel requestModel
    )
    {
        try
        {
            var item = await _appDbContext.Vendors.FirstOrDefaultAsync(x => x.Id == Id);
            if (item is null)
            {
                return Result<VendorResponseModel>.Failure("There is no vendor with Id: " + Id);
            }

            item.Name = requestModel.Name;
            item.ContactName = requestModel.ContactName;
            item.Phone = requestModel.Phone;
            item.Email = requestModel.Email;
            item.Address = requestModel.Address;

            await _appDbContext.SaveChangesAsync();

            var responseModel = new VendorResponseModel()
            {
                Id = item.Id,
                Name = item.Name,
                ContactName = item.ContactName,
                Phone = item.Phone,
                Email = item.Email,
                Address = item.Address,
            };
            return Result<VendorResponseModel>.Success(responseModel);
        }
        catch (Exception ex)
        {
            string message = "An error occurred when creating vendor " + ex.ToString();
            _logger.LogError(message);
            return Result<VendorResponseModel>.Failure(message);
        }
    }
}
