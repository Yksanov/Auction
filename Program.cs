namespace ControlWorkOOP;

class Program
{
    public static Product[] products;
    private static Random rnd = new Random();
    static void Main(string[] args)
    {
        try
        {
            ShowAllProducts();
            while (true)
            {
                Console.Write("1. Показать продукты\n2. Выбрать продукт\n3. Выйти из программмы\nВыберите действие: ");
                string userMenu = Console.ReadLine().Trim().ToLower();
                switch (userMenu)
                {
                    case "1":
                        ShowAllProducts();
                        break;
                    case "2":
                        ChooseProduct();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }
        catch
        {
            Console.WriteLine("Error!");
        }
    }


    static void ChooseProduct()
    {
        try
        {
            Console.WriteLine("Введи id продукта");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ID | Название | Цена | Состояние | Почетный код");
            Console.WriteLine(ProductFile.GetProducts()[id-1]);
            ActionWithProduct(ProductFile.GetProducts()[id-1]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Нет продукта с таким id");
        }
        catch(ArgumentException)
        {
            Console.WriteLine("Нужно вводить числа");
        }
    }

    static void ActionWithProduct(Product product)
    {
        Console.Write("1. Выставить на аукцион\n2. Поднять цену\n3. Выдать победителю\n4. Снять с торгов\n5. Вернуться на меню\nВыберите действие: ");
        string userAnswer = Console.ReadLine();
        try
        {
            switch (userAnswer)
            {
                case "1":
                    product.RaisePrice();
                    break;
                case "2":
                    product.SetUp();
                    break;
                case "3":
                    product.SetOff();
                    break;
                case "4":
                    product.GiveToTheWinner();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
            ProductFile.OverrideFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    static void ShowAllProducts()
    {
        Console.WriteLine("ID | Название ");
        foreach (var product in ProductFile.GetProducts())
        {
            Console.WriteLine($" {product.Id} | {product.Name}");
        }
    }
    
    
    static void GetRandomUserAnswer()
    {
        Console.WriteLine("Введите количества продуктов с консоли:");
        int countProduct = Convert.ToInt32(Console.ReadLine());
        
        products = new Product[countProduct];
        string[] statusProduct = {"in_stock", "for_sale", "sold" };
        
        for (int i = 0; i < products.Length; i++)
        {
            int ranProduct = rnd.Next(1, 6);
            switch (ranProduct)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
            
            Serializer.SaveProduct(products);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Файл успешно сохранено");
    }

    // static void UserAnswer()
    // {
    //     Console.WriteLine("Введите количества продуктов с консоли:");
    //     int countProduct = Convert.ToInt32(Console.ReadLine());
    //
    //     Product[] products = new Product[countProduct];
    //     for (int i = 0; i < countProduct; i++)
    //     {
    //         Product product = new Product(products[i].Id, products[i].Name, products[i].Price, products[i].Honorary_code, products[i].State);
    //         try
    //         {
    //             Console.Write("Введите ID: ");
    //             product.Id = Convert.ToInt32(Console.ReadLine());
    //             Console.Write("Наименование продукта: ");
    //             product.Name = Console.ReadLine();
    //             Console.Write("Текущая цена продукта: ");
    //             product.Price = Convert.ToInt32(Console.ReadLine());
    //             Console.Write("Почетный код: ");
    //             product.Honorary_code = Console.ReadLine();
    //             Console.Write("Текущее состояние продукта: ");
    //             product.State = Console.ReadLine();
    //             
    //             product.FillProductState();
    //             products[i] = product;
    //         }
    //         catch (FormatException)
    //         {
    //             Console.WriteLine("Введите число или стороковый символ");
    //             UserAnswer();
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine(ex.Message);   
    //             UserAnswer();
    //         }
    //         
    //         Serializer.SaveProduct(products);
    //     }
    // }
    static void Menu()
    {
        Console.WriteLine("№    | Продукт\n#    | Название продукта");
        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine($"{products[i].Id}    | {products[i].Name}");
        }

        while (true)
        {
            Console.WriteLine("Введите номер ID продукта: ");
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "exit")
            {
                break;
            }

            if (int.TryParse(input, out int productId))
            {
                Product selectProduct = null;
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Id == productId)
                    {
                        selectProduct = products[i];
                    }
                    break;
                }

                if (selectProduct != null)
                {
                    Console.WriteLine($"Id: {selectProduct.Id}\n Name: {selectProduct.Name}\n Price: {selectProduct.Price}\n Honorary Code: {selectProduct.Honorary_code}\n State: {selectProduct.State}");
                    Console.Write("1. Выставить на аукцион\n2. Поднять цену\n3. Выдать победителю\n4. Снять с торгов\n5. Для выхода введите exit\nВыберите действие: ");
                    string chooseMenu = Console.ReadLine().Trim().ToLower();
                    switch (chooseMenu)
                    {
                        case "1":
                            selectProduct.FillProductState();
                            selectProduct.SetUp();
                            Console.WriteLine("Продукт выставлен на аукцион");
                            break;
                        case "2":
                            selectProduct.FillProductState();
                            selectProduct.RaisePrice();
                            Console.WriteLine("Поднять цену");
                            break;
                        case "3":
                            selectProduct.FillProductState();
                            selectProduct.GiveToTheWinner();
                            Console.WriteLine("Выдан победителю");
                            break;
                        case "4":
                            selectProduct.FillProductState();
                            selectProduct.SetOff();
                            Console.WriteLine("Снять с торгов");
                            break;
                        case "5":
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Продукт с таким номером не найден");
                }
            }
        }
    }
}