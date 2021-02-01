using System;
using System.Collections.Generic;
using System.Text;

using Entities.Concrete;

namespace DataAccess.Abstact
{
    public interface ICarDal
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<Car> GetAllByBrand(int brandId);  //brand'a göre filtreler

    }
}
