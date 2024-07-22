using System.Security.Cryptography;
using System.Text;

namespace ControlWorkOOP;

public class Generator
{
    private IGeneratorStrategy _strategy;
    private Product _product;

    public Generator(Product product)
    {
        _product = product;
        if (product.Id >= 1000)
            _strategy = new GoldCodeStrategy();
        else if (product.Price >= 500)
            _strategy = new SilverCodeStrategy();
        else
            _strategy = new BronzeCodeStrategy();
    }
    public void GenerateCode() => _strategy.GetGode(_product);
}