using System.Text.Json;
using System.Text.Encodings.Web;

namespace ControlWorkOOP;

public static class Serializer
{
    public static Product[] Products { get; set;}
    
    private static string path = "../../../data.json";
    
    private static JsonSerializerOptions op = new JsonSerializerOptions()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };
    
    public static void SaveProduct(Product[] products) => File.WriteAllText(path, JsonSerializer.Serialize(products, op));

    public static Product[] GetProduct()
    {
        try
        {
            return JsonSerializer.Deserialize<Product[]>(File.ReadAllText(path));
        }
        catch (Exception)
        {
            File.Create("../../../data.json");
            return GetProduct();
        }
    }
}