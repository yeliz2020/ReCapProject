using System;
using System.Collections.Generic;
using System.Text;

using Core.DataAccess;

using Entities.Concrete;

namespace DataAccess.Abstact
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
