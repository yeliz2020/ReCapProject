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
            //DTO---> Data Transformation Object
            CarTest();

            //BrandTest();

            //ColorTest();


        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            // foreach (var car in carManager.GetAllByBrandId(2))
            // {
            //     Console.WriteLine("Model Yılı: {0}  Günlük Ücreti: {1} Özellikleri: {2}", car.ModelYear, car.DailyPrice, car.Description);
            // }
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.DailyPrice + " " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
