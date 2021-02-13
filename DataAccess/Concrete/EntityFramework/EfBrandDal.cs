using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using Core.DataAccess.EntityFramework;

using DataAccess.Abstact;

using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, MyFirstDbContext>, IBrandDal
    {
        
    }
}
