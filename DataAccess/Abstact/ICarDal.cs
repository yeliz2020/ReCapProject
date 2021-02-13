﻿using System;
using System.Collections.Generic;
using System.Text;

using Core.DataAccess;

using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstact
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();

    }
}
