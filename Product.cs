using System.Text.Json.Serialization;

namespace ControlWorkOOP;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Honorary_code { get; set; }
    public string State { get; set; }
    [JsonIgnore]
    public IProductState ProductState { get; set; }
   

    public void FillProductState()
    {
        if (State == "in_stock")
        {
            ProductState = new InStockState();
        }
        else if (State == "for_sale")
        {
            ProductState = new ForSaleState();
        }
        else
        {
            ProductState = new SoldState();
        }
    }

    public void RaisePrice() => ProductState.RaisePrice(this);
    public void SetUp() => ProductState.SetUp(this);

    public void SetOff() => ProductState.SetOff(this);
    public void GiveToTheWinner() => ProductState.GiveToTheWinner(this);

    public override string ToString() => $"{Id} | {Name}   | {Price} | {Honorary_code} | {State}";
}