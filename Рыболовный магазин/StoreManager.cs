// TODO:
// 1. Реализовать регистрацию новых клиентов-рыболовов
// 2. Реализовать поиск клиента по телефону
// 3. Реализовать учет продаж и популярных товаров

using System.Collections.Generic;

namespace FishingStore
{
    public class StoreManager
    {
        private List<Customer> customers = new List<Customer>();
        private List<FishingProduct> products = new List<FishingProduct>();
        private List<FishingSet> fishingSets = new List<FishingSet>();
        
        private int nextCustomerId = 1;
        private int nextPurchaseNumber = 1000;
        private decimal totalRevenue = 0;
        
        // TODO 1: Зарегистрировать нового клиента
        public Customer RegisterCustomer(string fullName, string phone, string experience, string fishingType)
        {
            // Создать нового клиента с уникальным ID
            // Установить все данные (опыт, тип ловли)
            // Установить дату регистрации = сегодня
            // Добавить клиента в список customers
            // Увеличить nextCustomerId
            // Вернуть созданного клиента
            Customer customer = new Customer(nextCustomerId, fullName, phone, experience, fishingType, DateTime.Today);
            customers.Add(customer);
            nextCustomerId++;
            return customer;
        }
        
        // TODO 2: Найти клиента по номеру телефона
        public Customer FindCustomerByPhone(string phone)
        {
            // Пройти по всем клиентам в списке customers
            // Если телефон совпадает - вернуть клиента
            // Если не найден - вернуть null
            foreach (var customer in customers)
            {
                if (customer.Phone == phone)
                {
                    return customer;
                }
            }
            return null;
        }
        
        // TODO 3: Создать номер покупки
        public int GetNextPurchaseNumber()
        {
            // Вернуть nextPurchaseNumber и увеличить его на 1
            return nextPurchaseNumber++;
        }
        
        // TODO 3: Зафиксировать продажу
        public void RecordSale(decimal amount)
        {
            // Увеличить totalRevenue на amount
            totalRevenue += amount;
        }
        
        // Готовые методы:
        public void AddProduct(FishingProduct product)
        {
            products.Add(product);
        }
        
        public void AddFishingSet(FishingSet set)
        {
            fishingSets.Add(set);
        }
        
        public List<FishingProduct> GetAllProducts()
        {
            return products;
        }
        
        public List<FishingSet> GetAllFishingSets()
        {
            return fishingSets;
        }
        
        public decimal GetTotalRevenue()
        {
            return totalRevenue;
        }
        
        public int GetCustomerCount()
        {
            return customers.Count;
        }
        
        // Поиск товаров по типу
        public List<FishingProduct> FindProductsByType(string type)
        {
            List<FishingProduct> result = new List<FishingProduct>();
            foreach (var product in products)
            {
                // TODO: Добавить проверку типа товара
                if (product.ProductType == type)
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}