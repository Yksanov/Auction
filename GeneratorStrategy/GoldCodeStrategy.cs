namespace ControlWorkOOP;

public class GoldCodeStrategy : IGeneratorStrategy
{
    public void GetGode(Product product)
    {
        product.Honorary_code = IGeneratorStrategy.CalculateMD5Hash("Gold" + product.Id);
    }
}