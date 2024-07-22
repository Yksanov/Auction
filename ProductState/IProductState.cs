using System.Security.Cryptography;

namespace ControlWorkOOP;

public interface IProductState
{
    void RaisePrice(Product product); //  поднять цену продукта
    void SetUp(Product product);  // выставить на торги
    void SetOff(Product product); // снять с торгов
    void GiveToTheWinner(Product product); // выдать победителю торгов

}