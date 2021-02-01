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
    }
}
