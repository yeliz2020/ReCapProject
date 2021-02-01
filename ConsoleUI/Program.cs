using System;

using Business.Concrete;

using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model Yılı: {0} Özellikleri: {1} Günlük Ücreti: {2}", car.ModelYear, car.Description, car.DailyPrice);
            }
            
        }
    }
}
