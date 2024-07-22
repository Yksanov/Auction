namespace ControlWorkOOP;

public class InStockState : IProductState
{
    public void RaisePrice(Product product)
    {
        throw new Exception("Нельза повышать цену!");
    }

    public void SetUp(Product product)
    {
        product.State = "for_sale";
        product.ProductState = new ForSaleState();
        Console.WriteLine("Продукт успешно отправился на торге");
    }

    public void SetOff(Product product)
    {
        throw new Exception("Нельзя снять с торгов продукт, который в них не участвует!");
    }

    public void GiveToTheWinner(Product product)
    {
        throw new Exception("Нельзя отдать продукт сразу со склада!");
    }
}