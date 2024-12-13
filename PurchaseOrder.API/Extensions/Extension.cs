using Newtonsoft.Json;

namespace PurchaseOrder.API.Extensions
{
    public static class Extension
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
