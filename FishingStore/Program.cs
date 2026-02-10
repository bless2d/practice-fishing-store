using System;

namespace FishingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== РЫБОЛОВНЫЙ МАГАЗИН 'КЛЕВ' ===\n");
            
            StoreMenu menu = new StoreMenu();
            menu.ShowMainMenu();
            
            Console.WriteLine("\nНи хвоста, ни чешуи!");
            Console.ReadKey();
        }
    }
}