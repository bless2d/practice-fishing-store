using System;
using System.Collections.Generic;

namespace FishingStore
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        // TODO 1: Добавить свойство FishingExperience (опыт: новичок, любитель, профи)
        public string FishingExperience { get; set; }
        // TODO 1: Добавить свойство PreferredFishingType (предпочитаемый вид ловли: спиннинг, фидер, поплавок)
        public string PreferredFishingType { get; set; }
        
        private List<Purchase> purchaseHistory = new List<Purchase>();
        private decimal bonusPoints = 0; // Бонусные баллы
        
        // Добавлен конструктор, принимающий 6 аргументов
        public Customer(int id, string fullName, string phone, string experience, string fishingType, DateTime registrationDate)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            FishingExperience = experience;
            PreferredFishingType = fishingType;
            RegistrationDate = registrationDate;
        }
        
        public class PurchaseItem
        {
            public FishingProduct Product { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; } // Цена на момент покупки
        }
        
        public class Purchase
        {
            public int PurchaseNumber { get; set; }
            public DateTime PurchaseDate { get; set; }
            public List<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();
            public decimal TotalAmount { get; set; }
            public decimal BonusEarned { get; set; } // Начисленные бонусы
        }
        
        // TODO 2: Создать новую покупку
        public Purchase CreatePurchase(int purchaseNumber)
        {
            // Создать новый объект Purchase
            // Установить текущую дату и номер покупки
            // Вернуть созданную покупку
            Purchase purchase = new Purchase
            {
                PurchaseNumber = purchaseNumber,
                PurchaseDate = DateTime.Now
            };
            return purchase;
        }
        
        // TODO 2: Добавить товар в покупку
        public bool AddToPurchase(Purchase purchase, FishingProduct product, int quantity)
        {
            // Проверить наличие товара на складе (product.IsInStock)
            if (product.IsInStock(quantity))
            {
                // Если товар есть:
                //   - Создать PurchaseItem
                PurchaseItem item = new PurchaseItem
                {
                    Product = product,
                    Quantity = quantity,
                    Price = product.Price // Установить актуальную цену продукта
                };
                //   - Добавить в Items покупки
                purchase.Items.Add(item);
                //   - Продать товар (product.Sell)
                product.Sell(quantity);
                //   - Вернуть true
                return true;
            }
            else
            {
                // Если товара нет:
                //   - Вернуть false
                return false;
            }
        }
        
        // TODO 3: Рассчитать стоимость покупки со скидкой
        public decimal CalculatePurchaseTotal(Purchase purchase, out decimal discount)
        {
            decimal total = 0;
            discount = 0;
            
            // Пройти по всем товарам в покупке
            // Суммировать: item.Price * item.Quantity
            foreach (var item in purchase.Items)
            {
                total += item.Price * item.Quantity;
            }
            
            // Применить скидку в зависимости от опыта рыболова:
            // Новичок: 5%, Любитель: 10%, Профи: 15%
            // ИЛИ использовать бонусные баллы (1 балл = 1 рубль)
            // Реализуем скидку на основе опыта, бонусы можно использовать отдельно (например, в методе оплаты)
            decimal discountPercent = 0;
            if (FishingExperience == "Новичок") discountPercent = 0.05m;
            else if (FishingExperience == "Любитель") discountPercent = 0.10m;
            else if (FishingExperience == "Профи") discountPercent = 0.15m;
            
            discount = total * discountPercent;
            
            return total - discount;
        }
        
        // TODO 3: Начислить бонусные баллы
        public void AddBonusPoints(decimal purchaseAmount)
        {
            // Начислить 1% от суммы покупки в бонусные баллы
            bonusPoints += purchaseAmount * 0.01m;
        }
        
        // Метод для использования бонусов (дополнительно, для системы скидок)
        public bool UseBonusPoints(decimal amount)
        {
            if (bonusPoints >= amount)
            {
                bonusPoints -= amount;
                return true;
            }
            return false;
        }
        
        // Получить текущие бонусные баллы
        public decimal GetBonusPoints()
        {
            return bonusPoints;
        }
        
        // Завершить покупку (добавить в историю)
        public void CompletePurchase(Purchase purchase)
        {
            purchaseHistory.Add(purchase);
        }
        
        // Показать информацию о рыболове
        public void ShowCustomerInfo()
        {
            Console.WriteLine($"Рыболов: {FullName}");
            Console.WriteLine($"Телефон: {Phone}");
            Console.WriteLine($"Дата регистрации: {RegistrationDate:dd.MM.yyyy}");
            // TODO 1: Вывести опыт и предпочтения
            Console.WriteLine($"Опыт: {FishingExperience}");
            Console.WriteLine($"Предпочитаемый вид ловли: {PreferredFishingType}");
            Console.WriteLine($"Бонусных баллов: {bonusPoints:F0}");
            Console.WriteLine($"Всего покупок: {purchaseHistory.Count}");
        }
        
        // Показать историю покупок
        public void ShowPurchaseHistory()
        {
            Console.WriteLine($"История покупок для {FullName}:");
            foreach (var purchase in purchaseHistory)
            {
                Console.WriteLine($"Покупка №{purchase.PurchaseNumber} от {purchase.PurchaseDate:dd.MM.yyyy HH:mm}");
                Console.WriteLine($"Сумма: {purchase.TotalAmount} руб., Бонусы начислены: {purchase.BonusEarned}");
                Console.WriteLine("Товары:");
                foreach (var item in purchase.Items)
                {
                    Console.WriteLine($"  {item.Product.Name} x{item.Quantity} - {item.Price} руб. за шт.");
                }
                Console.WriteLine();
            }
        }
    }
}