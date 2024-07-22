namespace ControlWorkOOP;

public class SilverCodeStrategy : IGeneratorStrategy
{
    public void GetGode(Product product)
    {
        product.Honorary_code = IGeneratorStrategy.CalculateMD5Hash("Silver" + product.Id);
    }
}