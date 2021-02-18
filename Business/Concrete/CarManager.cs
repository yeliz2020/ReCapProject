﻿using System;
using System.Collections.Generic;
using System.Text;

using Business.Abstact;
using Business.Constants;

using Core.Utilities.Results;

using DataAccess.Abstact;
using DataAccess.Concrete.InMemory;

using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; //injection yaparak DataAccess'deki soyut nesneyle (interface) bağlantı kurarız ve kod şemasını alırız

        public CarManager(ICarDal carDal) // constructor
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.FailedCarAddOrUpdate);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedCar);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //iş Kodları
            // bir iş sınıfı başka sınıfları new'lemez
            //yetkisi var mı? kontrol eder geçenler için veri tabanından verileri alır
            //Business'ın tek bağlantısı DataAccess'deki ICarDal(oradan işimize yarayan GetAll() alındı.

            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>>GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.UpdatedCar);
            }
            else
            {
                return new ErrorResult(Messages.FailedCarAddOrUpdate);
            }
        }
    }
}
