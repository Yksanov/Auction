using System.Text.Json;

namespace ControlWorkOOP;

public class ProductFile
{
    public static string path => "../../../data.json";
    public static Product[] Products { get; set;}
    public static void OverrideFile() => File.WriteAllText(path,JsonSerializer.Serialize(Products,new JsonSerializerOptions(){WriteIndented = true}));

    public static Product[] GetProducts()
    {
        try
        {
            if (Products == null)
            {
                Products = JsonSerializer.Deserialize<Product[]>(File.ReadAllText(path));
                if(Products.Length == 0)
                    GenerateProducts();
                foreach (var p in Products)
                    p.FillProductState();
            }
            return Products;
        }
        catch (FileNotFoundException)
        {
             File.WriteAllText(path, "[]");
             return GetProducts();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            GenerateProducts();
            return Products;
        }
    }
    
    public static void GenerateProducts()
    {
        string[] names = { "Iphone", "Galaxy", "Redmi MI" };
        try
        {
            Console.WriteLine("Продукты не найдены, сколько хочешь завести на склад?");
            int amount = Convert.ToInt32(Console.ReadLine());
            Products = new Product[amount];
            Random rnd = new Random();
            for (int i = 1; i <= amount; i++)
            {
                Products[i - 1] = new Product(){ Id = i, 
                    Honorary_code = null, 
                    Name = names[rnd.Next(3)], 
                    Price = rnd.Next(1, 1000), 
                    State = "in_stock", 
                    ProductState = new InStockState()};
            }
            OverrideFile();
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Неправильный ввод, попробуй снова!");
            GenerateProducts();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}