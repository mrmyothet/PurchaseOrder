using System.Security.Cryptography;

namespace PurchaseOrder.API.Utilities;

public static class Utils
{
    public static string Generate32BitString()
    {
        byte[] buffer = new byte[16];
        RandomNumberGenerator.Fill(buffer);
        return BitConverter.ToString(buffer).Replace("-", "");
    }
}
