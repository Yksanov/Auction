namespace ControlWorkOOP;

public class BronzeCodeStrategy : IGeneratorStrategy
{
    public void GetGode(Product product)
    {
        product.Honorary_code = IGeneratorStrategy.CalculateMD5Hash("Bronze" + product.Id);
    }
}