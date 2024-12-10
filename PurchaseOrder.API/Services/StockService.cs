using Microsoft.EntityFrameworkCore;
using PurchaseOrder.API.Models;

namespace PurchaseOrder.API.Services;

public class StockService
{
    private readonly ILogger<VendorService> _logger;

    private readonly AppDbContext _appDbContext;

    public StockService(ILogger<VendorService> logger, AppDbContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    public async Task<Result<List<StockResponseModel>>> GetAllStocksAsync()
    {
        var lst = await _appDbContext.Stocks.ToListAsync();

        var model = lst.Select(item => new StockResponseModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Quantity = item.Quantity
            })
            .ToList();

        return Result<List<StockResponseModel>>.Success(model);
    }
}
