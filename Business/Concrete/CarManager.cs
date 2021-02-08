using System;
using System.Collections.Generic;
using System.Text;

using Business.Abstact;

using DataAccess.Abstact;
using DataAccess.Concrete.InMemory;

using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; //injection yaparak DataAccess'deki soyut nesneyle (interface) bağlantı kurarız ve kod şemasını alırız

        public CarManager(ICarDal carDal) // constructor
        {
            _carDal = carDal;
        }
         
        public List<Car> GetAll()
        {
            //iş Kodları
            // bir iş sınıfı başka sınıfları new'lemez
            //yetkisi var mı? kontrol eder geçenler için veri tabanından verileri alır
            //Business'ın tek bağlantısı DataAccess'deki ICarDal(oradan işimize yarayan GetAll() alındı.
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }
    }
}
