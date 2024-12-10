namespace PurchaseOrder.Web.Models;

public class StockResponseModel
{
    public bool IsSuccess { get; set; }
    public bool IsError { get; set; }
    public bool IsValidationError { get; set; }
    public List<StockModel> Data { get; set; }
}
