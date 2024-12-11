namespace PurchaseOrder.Web.Models;

public class VendorItemResponseModel
{
    public bool IsSuccess { get; set; }

    public bool IsError { get; set; }

    public bool IsValidationError { get; set; }

    public VendorModel Data { get; set; }
}
