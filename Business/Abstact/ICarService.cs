using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Core.Utilities.Results;

using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstact
{
    public interface ICarService
    {
        IDataResult <List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);


    }
}
