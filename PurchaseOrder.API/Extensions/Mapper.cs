using PurchaseOrder.API.Models;

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
    }
}
