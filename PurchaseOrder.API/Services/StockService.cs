using Microsoft.EntityFrameworkCore;
using PurchaseOrder.API.Extensions;
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
        Result<List<StockResponseModel>> result;
        try
        {
            var lst = await _appDbContext.Stocks.ToListAsync();
            var model = lst.Select(item => item.ToDto()).ToList();

            result = Result<List<StockResponseModel>>.Success(model);
        }
        catch (Exception ex)
        {
            result = Result<List<StockResponseModel>>.Failure(ex);
        }

    result:
        return result;
    }

    public async Task<Result<StockResponseModel>> CreateStockAsync(StockRequestModel model)
    {
        Result<StockResponseModel> result;
        try
        {
            var item = new StockContextModel()
            {
                Id = Utils.Generate32BitString(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
            };

            await _appDbContext.Stocks.AddAsync(item);
            await _appDbContext.SaveChangesAsync();

            var response = new StockResponseModel()
            {
                Id = item.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
            };

            result = Result<StockResponseModel>.Success(response);
        }
        catch (Exception ex)
        {
            string message = "An error occurred when creating Stock " + ex.ToString();
            _logger.LogError(message);

            result = Result<StockResponseModel>.Failure(message);
        }

    result:
        return result;
    }
}
