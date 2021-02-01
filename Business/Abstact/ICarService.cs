using System;
using System.Collections.Generic;
using System.Text;

using Entities.Concrete;

namespace Business.Abstact
{
    public interface ICarService
    {
        List<Car> GetAll();
    }
}
