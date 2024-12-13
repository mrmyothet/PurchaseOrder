using PurchaseOrder.API.Models;
using PurchaseOrder.API.Utilities;

namespace PurchaseOrder.API.Extensions
{
    public static class Mapper
    {
        public static StockResponseModel ToDto(this StockContextModel dataModel)
        {
            return new StockResponseModel
            {
                Id = dataModel.Id,
                Description = dataModel.Description,
                Name = dataModel.Name,
                Price = dataModel.Price,
                Quantity = dataModel.Quantity
            };
        }

        public static StockContextModel ToEntity(this StockRequestModel requestModel)
        {
            return new StockContextModel
            {
                Id = Utils.Generate32BitString(),
                Name = requestModel.Name,
                Description = requestModel.Description,
                Price = requestModel.Price,
                Quantity = requestModel.Quantity
            };
        }
    }
}
