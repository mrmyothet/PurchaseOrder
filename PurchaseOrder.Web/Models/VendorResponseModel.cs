namespace PurchaseOrder.Web.Models;

public class VendorResponseModel
{
    public bool IsSuccess { get; set; }
    public bool IsError { get; set; }
    public bool IsValidationError { get; set; }
    public List<VendorModel> Data { get; set; }
}
