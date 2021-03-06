﻿using System;
using System.Collections.Generic;
using System.Text;

using Business.Abstact;
using Business.Constants;
using Business.ValidationRules.FluentValidation;

using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;

using DataAccess.Abstact;

using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.AddedBrand);
            }
            return new ErrorResult(Messages.FailedBrandAddOrUpdate);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DeletedBrand);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);

        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.UpdatedBrand);
            }
            return new ErrorResult(Messages.FailedBrandAddOrUpdate);
        }
    }
}
