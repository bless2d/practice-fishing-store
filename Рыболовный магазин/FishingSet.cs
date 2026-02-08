// TODO:
// 1. Реализовать создание тематических наборов для рыбалки
// 2. Реализовать расчет стоимости набора
// 3. Реализовать проверку комплектности набора

using System.Collections.Generic;

namespace FishingStore
{
    public class FishingSet
    {
        public int Id { get; set; }
        public string Name { get; set; }               // Название набора
        public string FishingType { get; set; }        // Тип ловли (спиннинг, фидер, зимняя)
        public string Difficulty { get; set; }         // Сложность (начальный, продвинутый, профессиональный)
        
        private Dictionary<FishingProduct, int> items = new Dictionary<FishingProduct, int>(); // Товары и их количество
        
        // TODO 1: Добавить свойство Description (описание набора)
        public string Description { get; set; }
        
        public FishingSet(int id, string name, string fishingType, string difficulty, string description)
        {
            Id = id;
            Name = name;
            FishingType = fishingType;
            Difficulty = difficulty;
            // TODO 1: Сохранить описание
            Description = description;
        }
        
        // TODO 2: Добавить товар в набор
        public void AddItem(FishingProduct product, int quantity)
        {
            // Добавить товар в словарь items
            // Если товар уже есть - увеличить количество
            if (items.ContainsKey(product))
            {
                items[product] += quantity;
            }
            else
            {
                items[product] = quantity;
            }
        }
        
        // TODO 2: Рассчитать стоимость набора
        public decimal CalculateSetPrice()
        {
            decimal total = 0;
            // Пройти по всем товарам в наборе
            // Суммировать: product.Price * quantity
            foreach (var item in items)
            {
                total += item.Key.Price * item.Value;
            }
            return total;
        }
        
        // TODO 3: Рассчитать стоимость набора со скидкой
        public decimal CalculateSetPriceWithDiscount(decimal discountPercent)
        {
            decimal basePrice = CalculateSetPrice();
            return basePrice * (100 - discountPercent) / 100;
        }
        
        // TODO 3: Проверить доступность всех товаров набора
        public bool IsSetAvailable()
        {
            // Проверить для каждого товара в наборе:
            // product.IsInStock(quantity)
            // Вернуть true только если ВСЕ товары в наличии
            foreach (var item in items)
            {
                if (!item.Key.IsInStock(item.Value))
                {
                    return false;
                }
            }
            return true;
        }
        
        // Показать состав набора
        public void ShowSetComposition()
        {
            Console.WriteLine($"=== НАБОР: {Name} ===");
            Console.WriteLine($"Тип ловли: {FishingType}");
            Console.WriteLine($"Сложность: {Difficulty}");
            
            Console.WriteLine("\nСостав набора:");
            foreach (var item in items)
            {
                Console.WriteLine($"  {item.Key.Name} x{item.Value} - {item.Key.Price * item.Value} руб.");
            }
            
            Console.WriteLine($"\nОбщая стоимость: {CalculateSetPrice()} руб.");
            Console.WriteLine($"Доступность: {(IsSetAvailable() ? "В наличии" : "Недостаточно товаров")}");
        }
    }
}