using Microsoft.EntityFrameworkCore;
using PurchaseOrder.API.Models;
using PurchaseOrder.API.Utilities;

namespace PurchaseOrder.API.Services;

public class StockService
{
    private readonly ILogger<StockService> _logger;

    private readonly AppDbContext _appDbContext;

    public StockService(ILogger<StockService> logger, AppDbContext appDbContext)
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

    public async Task<Result<StockResponseModel>> CreateStockAsync(StockRequestModel model)
    {
        try
        {
            var item = new StockContextModel()
            {
                Id = Utils.Generate32BitString(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity
            };

            _appDbContext.Stocks.Add(item);
            await _appDbContext.SaveChangesAsync();

            var response = new StockResponseModel()
            {
                Id = item.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity
            };

            return Result<StockResponseModel>.Success(response);
        }
        catch (Exception ex)
        {
            string message = "An error occurred when creating Stock " + ex.ToString();
            _logger.LogError(message);
            return Result<StockResponseModel>.Failure(message);
        }
    }
}
