// TODO:
// 1. Добавить свойство для типа товара (снасти, приманки, экипировка)
// 2. Реализовать проверку корректности цены и остатка на складе
// 3. Реализовать информативное строковое представление товара

namespace FishingStore
{
    public class FishingProduct
    {
        public int Id { get; set; }                    // Артикул
        public string Name { get; set; }               // Название
        public string Brand { get; set; }              // Бренд (Shimano, Daiwa, Salmo)
        public decimal Price { get; set; }             // Цена
        public int StockQuantity { get; set; }         // Количество на складе
        
        // TODO 1: Добавить свойство ProductType (тип: удочки, катушки, лески, приманки, одежда)
        public string ProductType { get; set; }
        
        public FishingProduct(int id, string name, string brand, decimal price, int stock, string type)
        {
            Id = id;
            Name = name;
            Brand = brand;
            
            // TODO 2: Проверить что цена не отрицательная
            // Если цена < 0, установить минимальную цену 10
            if (Price < 0) Price = 10;
            else Price = price;
            
            // TODO 2: Проверить что остаток на складе не отрицательный
            // Если stock < 0, установить 0
            if (stock < 0) StockQuantity = 0;
            else StockQuantity = stock;
            
            // TODO 1: Сохранить тип товара
            ProductType = type;
        }
        
        public override string ToString()
        {
            // TODO 3: Вернуть строку в формате "Удочка Shimano (снасти) - 4500 руб. (8 шт.)"
            return $"{Name} {Brand} ({ProductType}) - {Price} руб. ({StockQuantity} шт.)";
        }
        
        // Проверить наличие на складе
        public bool IsInStock(int quantity = 1)
        {
            return StockQuantity >= quantity;
        }
        
        // Продать товар (уменьшить остаток)
        public bool Sell(int quantity)
        {
            if (StockQuantity >= quantity)
            {
                StockQuantity -= quantity;
                return true;
            }
            return false;
        }
        
        // Пополнить склад
        public void Restock(int quantity)
        {
            StockQuantity += quantity;
        }
    }
}