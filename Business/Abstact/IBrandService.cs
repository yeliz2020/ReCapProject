using System;
using System.Collections.Generic;
using System.Text;

using Core.Utilities.Results;

using Entities.Concrete;

namespace Business.Abstact
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
    }
}
