using System;
using System.Collections.Generic;
using System.Text;

using Entities.Concrete;

namespace Business.Abstact
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
    }
}
