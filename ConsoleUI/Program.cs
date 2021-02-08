using System;

using Business.Concrete;

using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            // foreach (var car in carManager.GetAllByBrandId(2))
            // {
            //     Console.WriteLine("Model Yılı: {0}  Günlük Ücreti: {1} Özellikleri: {2}", car.ModelYear, car.DailyPrice, car.Description);
            // }

            foreach (var car in carManager.GetAllByColorId(2))
            {
                Console.WriteLine("Model Yılı: {0}  Günlük Ücreti: {1} Özellikleri: {2}", car.ModelYear, car.DailyPrice, car.Description);
            }
        }
    }
}
