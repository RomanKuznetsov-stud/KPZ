using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_storage
{

    public interface IPrice
    {
        Money Price { get; }
        void DecreasePrice(decimal amount);
    }

    public class Money
    {
        public int Units { get; private set; }
        public int Cents { get; private set; }

        public Money(int units, int cents)
        {
            if (units < 0 || cents < 0 || cents >= 100)
                throw new ArgumentException("Неправильне значення грошей");
            Units = units;
            Cents = cents;
        }

        public decimal Total => Units + Cents / 100m;

        public void Display()
        {
            Console.WriteLine($"{Units} грн {Cents} коп");
        }

    }

    public enum Unit
    {
        Штука,
        Кілограм,
        Літр
    }

    public class Product : IPrice
    {
        public string Name { get; }
        public string Category { get; set; }
        public Unit Unit { get; }
        public Money Price { get; private set; }

        public Product(string name, string category, Unit unit, Money price)
        {
            Name = name;
            Category = category;
            Unit = unit;
            Price = price ?? throw new ArgumentNullException(nameof(price));
        }

        public void DecreasePrice(decimal amount)
        {
            if (amount <= 0) return;

            decimal newPrice = Price.Total - amount;
            if (newPrice < 0) newPrice = 0;

            int units = (int)newPrice;
            int cents = (int)((newPrice - units) * 100);
            Price = new Money(units, cents);
        }
    }

    public class StockItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }
        public DateTime LastDeliveryDate { get; private set; }

        public StockItem(Product product, int quantity, DateTime deliveryDate)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
            LastDeliveryDate = deliveryDate;
        }

        public void AddStock(int amount, DateTime date)
        {
            if (amount <= 0) throw new ArgumentException("Кількість має бути додатною");
            Quantity += amount;
            LastDeliveryDate = date;
        }

        public void RemoveStock(int amount)
        {
            if (amount <= 0 || amount > Quantity)
                throw new InvalidOperationException("Недостатньо товару");
            Quantity -= amount;
        }
    }

    public class Storage
    {
        private readonly List<StockItem> _stockItems = new();

        public void ReceiveProduct(Product product, int quantity, DateTime date)
        {
            var item = _stockItems.FirstOrDefault(i => i.Product.Name == product.Name);
            if (item != null)
                item.AddStock(quantity, date);
            else
                _stockItems.Add(new StockItem(product, quantity, date));
        }

        public void ShipProduct(string productName, int quantity)
        {
            var item = _stockItems.FirstOrDefault(i => i.Product.Name == productName);
            if (item == null) throw new InvalidOperationException("Товар не знайдено");
            item.RemoveStock(quantity);
        }

        public void InventoryReport()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------- Товарів на складі -------------");
            Console.ResetColor();
            foreach (var item in _stockItems)
            {
                Console.WriteLine($"Товар: {item.Product.Name}, Категорія: {item.Product.Category}, Кількість: {item.Quantity},Одиниця: {item.Product.Unit}, Ціна:");
                item.Product.Price.Display();
            }
        }

        public IEnumerable<StockItem> GetStockItems() => _stockItems;
    }

    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public CartItem(Product product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
        }
    }

    public class Cart
    {
        private readonly List<CartItem> _items = new();

        public void AddToCart(Product product, int quantity)
        {
            _items.Add(new CartItem(product, quantity));
        }

        public void DisplayCart()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------- Вміст кошика -------------");
            Console.ResetColor();
            foreach (var item in _items)
            {
                Console.WriteLine($"Товар: {item.Product.Name}, Кількість: {item.Quantity},Одиниця: {item.Product.Unit}, Ціна за одиницю:");
                item.Product.Price.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            var storage = new Storage();

            var pineapple = new Product("Ананас", "Фрукти", Unit.Штука, new Money(130, 50));
            var milk = new Product("Молоко", "Молочні", Unit.Літр, new Money(45, 0));

            storage.ReceiveProduct(pineapple, 100, DateTime.Today);
            storage.ReceiveProduct(milk, 50, DateTime.Today);

            storage.InventoryReport();

            storage.ShipProduct("Ананас", 10);

            pineapple.DecreasePrice(5);
            milk.DecreasePrice(10.5m);

            storage.InventoryReport();

            var cart = new Cart();
            cart.AddToCart(pineapple, 3);
            cart.AddToCart(milk, 1);
            cart.DisplayCart();
        }
    }
}