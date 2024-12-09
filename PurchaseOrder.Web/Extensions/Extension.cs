using Newtonsoft.Json;

namespace PurchaseOrder.Web.Extensions;

public static class Extension
{
    public static T ToObject<T>(this string jsonStr)
    {
        return JsonConvert.DeserializeObject<T>(jsonStr)!;
    }
}
