﻿using System;
using System.Collections.Generic;
using System.Text;

using Entities.Concrete;

namespace Business.Abstact
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        
    }
}