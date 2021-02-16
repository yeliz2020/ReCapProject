using System;
using System.Collections.Generic;
using System.Text;

using Core.Utilities.Results;

using Entities.Concrete;

namespace Business.Abstact
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
    }
}
