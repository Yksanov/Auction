namespace ControlWorkOOP;

public class SoldState : IProductState
{
    public void RaisePrice(Product product)
    {
        throw new Exception("Продукт уже продан, ты не можешь с ним больше ничего сделать!");
    }

    public void SetUp(Product product)
    {
        throw new Exception("Продукт уже продан, ты не можешь с ним больше ничего сделать!");
    }

    public void SetOff(Product product)
    {
        throw new Exception("Продукт уже продан, ты не можешь с ним больше ничего сделать!"); 
    }

    public void GiveToTheWinner(Product product)
    {
        throw new Exception("Продукт уже продан, ты не можешь с ним больше ничего сделать!");
    }
}