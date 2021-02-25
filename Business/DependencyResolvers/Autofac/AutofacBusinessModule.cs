using System;
using System.Collections.Generic;
using System.Text;

using Autofac;

using Business.Abstact;
using Business.Concrete;

using DataAccess.Abstact;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
        }
    }
}
