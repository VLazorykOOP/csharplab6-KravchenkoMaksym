using System;
using System.Collections;
using System.Collections.Generic;

// Base Classes
abstract class Product : IComparable<Product>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
        Console.WriteLine("Конструктор продукту");
    }
    ~Product()
    {
        Console.WriteLine("Деструктор продукту");
    }
    public abstract void Show();

    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return Price.CompareTo(other.Price);
    }
}

class Toy : Product
{
    public string Type { get; set; }
    public Toy(string name, double price, string type) : base(name, price)
    {
        Type = type;
        Console.WriteLine("Конструктор iграшки");
    }
    ~Toy()
    {
        Console.WriteLine("Деструктор iграшки");
    }
    public override void Show()
    {
        Console.WriteLine($"Iграшка Назва: {Name}, Цiна: {Price}, Тип: {Type}");
    }
}

class Item : Product
{
    public string Category { get; set; }
    public Item(string name, double price, string category) : base(name, price)
    {
        Category = category;
        Console.WriteLine("Конструктор товару");
    }
    ~Item()
    {
        Console.WriteLine("Деструктор товару");
    }
    public override void Show()
    {
        Console.WriteLine($"Товар Назва: {Name}, Цiна: {Price}, Категорiя: {Category}");
    }
}

class DairyProduct : Product
{
    public string ExpiryDate { get; set; }
    public DairyProduct(string name, double price, string expiryDate) : base(name, price)
    {
        ExpiryDate = expiryDate;
        Console.WriteLine("Конструктор молочного продукту");
    }
    ~DairyProduct()
    {
        Console.WriteLine("Деструктор молочного продукту");
    }
    public override void Show()
    {
        Console.WriteLine($"Молочний продукт Назва: {Name}, Цiна: {Price}, Термiн придатностi: {ExpiryDate}");
    }
}

// Abstract Client Class
abstract class Client : IComparable<Client>
{
    public string Name { get; set; }
    public DateTime DateOfStart { get; set; }
    public Client(string name, DateTime dateOfStart)
    {
        Name = name;
        DateOfStart = dateOfStart;
        Console.WriteLine("Конструктор клiєнта");
    }
    ~Client()
    {
        Console.WriteLine("Деструктор клiєнта");
    }
    public abstract void Show();
    public abstract bool MatchDate(DateTime date);

    public int CompareTo(Client other)
    {
        if (other == null) return 1;
        return DateOfStart.CompareTo(other.DateOfStart);
    }
}

class Depositor : Client
{
    public double Amount { get; set; }
    public double Interest { get; set; }
    public Depositor(string name, DateTime dateOfStart, double amount, double interest) : base(name, dateOfStart)
    {
        Amount = amount;
        Interest = interest;
        Console.WriteLine("Конструктор вкладника");
    }
    ~Depositor()
    {
        Console.WriteLine("Деструктор вкладника");
    }
    public override void Show()
    {
        Console.WriteLine($"Вкладник: {Name}, Дата: {DateOfStart.ToShortDateString()}, Сума: {Amount}, Вiдсоток: {Interest}%");
    }
    public override bool MatchDate(DateTime date)
    {
        return DateOfStart.Date == date.Date;
    }
}

class Creditor : Client
{
    public double CreditAmount { get; set; }
    public double CreditInterest { get; set; }
    public double RemainingDebt { get; set; }
    public Creditor(string name, DateTime dateOfStart, double creditAmount, double creditInterest, double remainingDebt) : base(name, dateOfStart)
    {
        CreditAmount = creditAmount;
        CreditInterest = creditInterest;
        RemainingDebt = remainingDebt;
        Console.WriteLine("Конструктор кредитора");
    }
    ~Creditor()
    {
        Console.WriteLine("Деструктор кредитора");
    }
    public override void Show()
    {
        Console.WriteLine($"Кредитор: {Name}, Дата: {DateOfStart.ToShortDateString()}, Сума кредиту: {CreditAmount}, Вiдсоток: {CreditInterest}%, Залишок боргу: {RemainingDebt}");
    }
    public override bool MatchDate(DateTime date)
    {
        return DateOfStart.Date == date.Date;
    }
}

class Organization : Client
{
    public string AccountNumber { get; set; }
    public double AccountBalance { get; set; }
    public Organization(string name, DateTime dateOfStart, string accountNumber, double accountBalance) : base(name, dateOfStart)
    {
        AccountNumber = accountNumber;
        AccountBalance = accountBalance;
        Console.WriteLine("Конструктор органiзацiї");
    }
    ~Organization()
    {
        Console.WriteLine("Деструктор органiзацiї");
    }
    public override void Show()
    {
        Console.WriteLine($"Органiзацiя: {Name}, Дата: {DateOfStart.ToShortDateString()}, Номер рахунку: {AccountNumber}, Баланс: {AccountBalance}");
    }
    public override bool MatchDate(DateTime date)
    {
        return DateOfStart.Date == date.Date;
    }
}

// Task 3: Implementing IEnumerable for one of the classes
class ProductCollection : IEnumerable<Product>
{
    private List<Product> products = new List<Product>();

    public void Add(Product product)
    {
        products.Add(product);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        return products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Виберiть завдання для виконання (1-3) або 'exit' для виходу:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ExecuteTask1();
                    break;
                case "2":
                    ExecuteTask2();
                    break;
                case "3":
                    ExecuteTask3();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Неправильний вибiр. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ExecuteTask1()
    {
        Console.WriteLine("Завдання 1:");
        Toy toy = new Toy("Лего", 29.99, "Будiвельний блок");
        Item item = new Item("Шампунь", 5.99, "Персональний догляд");
        DairyProduct dairyProduct = new DairyProduct("Молоко", 1.99, "01-06-2024");

        toy.Show();
        item.Show();
        dairyProduct.Show();
    }

    static void ExecuteTask2()
    {
        Console.WriteLine("Завдання 2:");
        Toy toy1 = new Toy("Машинка", 9.99, "Транспорт");
        Toy toy2 = new Toy("Лялька", 19.99, "Фiгура");
        Toy toy3 = new Toy("Пазл", 14.99, "Освiтнiй");

        toy1.Show();
        toy2.Show();
        toy3.Show();
    }

    static void ExecuteTask3()
    {
        Console.WriteLine("Завдання 3:");
        List<Client> clients = new List<Client>
        {
            new Depositor("Iван Iванов", new DateTime(2022, 1, 1), 1000, 3.5),
            new Creditor("Олена Петрiвна", new DateTime(2023, 3, 15), 5000, 5, 4500),
            new Organization("TechCorp", new DateTime(2021, 7, 30), "12345678", 100000)
        };

        foreach (var client in clients)
        {
            client.Show();
        }

        Console.WriteLine("Введiть дату пошуку (yyyy-MM-dd):");
        DateTime searchDate;
        if (DateTime.TryParse(Console.ReadLine(), out searchDate))
        {
            Console.WriteLine($"Клiєнти, що почали спiвробiтничати {searchDate.ToShortDateString()}:");
            foreach (var client in clients)
            {
                if (client.MatchDate(searchDate))
                {
                    client.Show();
                }
            }
        }
        else
        {
            Console.WriteLine("Неправильний формат дати.");
        }
    }
}
