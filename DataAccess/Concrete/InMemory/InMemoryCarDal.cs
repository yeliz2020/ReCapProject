using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using DataAccess.Abstact;

using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //global değişken tanımladık
        public InMemoryCarDal()  //prg.çalıştırdığımızda bellekte otomobil listesini oluşturdu
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=750, ModelYear=2020, Description="Otomati Vites, 5 Koltuk, Sedan"},
                new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=350, ModelYear=2018, Description="Düz Vites, 5 Koltuk, Sedan"},
                new Car{Id=3, BrandId=2, ColorId=3, DailyPrice=550, ModelYear=2020, Description="Otomati Vites, 5 Koltuk, Hatchback"},
                new Car{Id=4, BrandId=2, ColorId=1, DailyPrice=440, ModelYear=2019, Description="Otomati Vites, 5 Koltuk, Sedan"},
                new Car{Id=5, BrandId=3, ColorId=2, DailyPrice=400, ModelYear=2020, Description="Düz Vites, 5 Koltuk, Sedan"},
                new Car{Id=6, BrandId=3, ColorId=1, DailyPrice=500, ModelYear=2019, Description="Otomati Vites, 5 Koltuk, Sedan"}
            };
           
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ
            //Lambda
            Car cartoDelete = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(cartoDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList(); // içindeki şarta uyan bütün elemanları  yeni bir liste haline getirir ve döndürür
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            // Gönderdiğim oto id'sine sahip olan listedeki otoyu bul
            Car cartoUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.ColorId = car.ColorId;
            cartoUpdate.Description = car.Description;
            cartoUpdate.BrandId = car.BrandId;
        }
    }
}
