using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Business.Abstact;
using Business.Concrete;

using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //Attribute-- javada Annotation---bir classla ilgili bilgi vermeişini görür
    public class CarsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC caontainer -- inversion of coltrol
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency chain

            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
