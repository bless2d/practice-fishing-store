using System;
using System.Collections.Generic;

namespace GroceryStore
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        
        // TODO 1: Добавить свойство Balance (баланс) типа decimal
        public decimal Balance { get; set; }
        
        private ShoppingCart cart = new ShoppingCart();
        private List<Purchase> purchaseHistory = new List<Purchase>();
        
        public class Purchase
        {
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public Dictionary<string, int> Items { get; set; } = new Dictionary<string, int>();
        }
        
        // TODO 2: Добавить товар в корзину покупателя
        public bool AddToCart(Product product, int quantity)
        {
            // Использовать cart.AddItem() для добавления товара
            // Вернуть результат операции
            return cart.AddItem(product, quantity);
        }
        
        // TODO 3: Обработать покупку
        public bool Checkout()
        {
            // Рассчитать сумму корзины через cart.CalculateTotal()
            decimal total = cart.CalculateTotal();
            
            // Проверить достаточно ли средств на балансе
            if (Balance >= total)
            {
                // Если достаточно:
                //   - Списать сумму с баланса
                Balance -= total;
                
                //   - Создать запись в purchaseHistory
                Purchase purchase = new Purchase
                {
                    Date = DateTime.Now,
                    Amount = total,
                    Items = new Dictionary<string, int>(cart.GetItems()) // Предполагаем, что ShoppingCart имеет GetItems()
                };
                purchaseHistory.Add(purchase);
                
                //   - Очистить корзину через cart.Clear()
                cart.Clear();
                
                //   - Вернуть true
                return true;
            }
            else
            {
                // Если недостаточно:
                //   - Вернуть false
                return false;
            }
        }
        
        // TODO 1: Реализовать пополнение баланса
        public void TopUpBalance(decimal amount)
        {
            // Увеличить Balance на amount
            Balance += amount;
        }
        
        // Показать информацию о покупателе
        public void ShowCustomerInfo()
        {
            Console.WriteLine($"Покупатель: {Name}");
            Console.WriteLine($"Телефон: {Phone}");
            // TODO 1: Вывести текущий баланс
            Console.WriteLine($"Баланс: {Balance} руб.");
            Console.WriteLine($"История покупок: {purchaseHistory.Count} чеков");
        }
        
        // Получить корзину (готовый метод)
        public ShoppingCart GetCart()
        {
            return cart;
        }
        
        // TODO 3: Показать историю покупок
        public void ShowPurchaseHistory()
        {
            Console.WriteLine($"История покупок для {Name}:");
            foreach (var purchase in purchaseHistory)
            {
                Console.WriteLine($"Дата: {purchase.Date}, Сумма: {purchase.Amount} руб.");
                Console.WriteLine("Товары:");
                foreach (var item in purchase.Items)
                {
                    Console.WriteLine($"  {item.Key} x{item.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}