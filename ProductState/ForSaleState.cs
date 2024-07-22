using System.ComponentModel.Design;

namespace ControlWorkOOP;

public class ForSaleState : IProductState
{
    public void RaisePrice(Product product)
    {
        product.Price += 100;
        Console.WriteLine("Цена на товар поднялась!");
    }

    public void SetUp(Product product)
    {
        throw new Exception("Товар уже на аукционе, у нас нет аукциона на аукционе");
    }
    public void SetOff(Product product)
    {
        product.State = "in_stock";
        product.ProductState = new InStockState();
        Console.WriteLine("Продукт на складе");
    }

    public void GiveToTheWinner(Product product)
    {
        if (product.Price <= 0)   // Цена меньше или равно нулю
        {
            throw new Exception("Нельзя отдать продукт бесплатно!");
        }
        else
        {
            product.State = "sold";
            Generator generator = new Generator(product);
            generator.GenerateCode();
            product.ProductState = new SoldState();
            Console.WriteLine("Продано продукт успешно!");
        }
    }
}