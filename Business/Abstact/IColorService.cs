using System;
using System.Collections.Generic;
using System.Text;

using Entities.Concrete;

namespace Business.Abstact
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int colorId);
    }
}
