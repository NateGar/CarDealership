using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_5_CarDealership.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone_5_CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly GCCarDbContext _context;
        public CarController(GCCarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cars>>> GetCars()
        {
            var cars = await _context.Cars.ToListAsync();
            return cars;
        }
        //if(search != null)
        //{
        //    search = search.ToLower();
        //    var result = cars.Where(x => x.Make.ToLower() == search ||
        //    x.Model.ToLower() == search ||
        //    x.Year.ToLower() == search ||
        //    x.Color.ToLower() == search).ToList();
        //    return result;
        //}
        //GET: api/GCDealershipInventory/?Search={keyword}


        [HttpPost]
        public async Task<ActionResult<Cars>> AddCar(Cars newCar)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(newCar);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCars), new { id = newCar.Id }, newCar);
            }
            else
            {
                return BadRequest();
            }
        }


        



    }
}
