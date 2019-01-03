using CarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarAPI.Controllers
{
    public class CarController : ApiController
    {
        CarDBEntities DB = new CarDBEntities();

        // GET list of cars
        [HttpGet]
        public List<Car> GetCars()
        {
            return DB.Cars.ToList();
        }

        // GET car by VIN

        [HttpGet]
        public Car GetCarByVIN(int? VIN)
        {
            if (VIN != null)
            {
                return DB.Cars.Find(VIN);
            }
            else return null;
        }

        // GET car by make

        [HttpGet]
        public List<Car> GetCarByMake(string make)
        {
            return DB.Cars.Where(c => c.Make == make).ToList();
        }

        // GET cars by search criteria (the real one)
        [HttpGet]
        public List<Car> FoundCars(int? vin, string make, string model, int? yearFrom, int? yearTo, string color)
        {
            CarSearchModel searchModel = new CarSearchModel
            {
                VIN = vin,
                Make = make,
                Model = model,
                YearFrom = yearFrom,
                YearTo = yearTo,
                Color = color
            };
            return FindCars(searchModel);
        }


        // GET car by search criteria (make, model, color, year range)
        //this one is a work in progress and might not actually work how I want it to
        [HttpGet]
        public List<Car> FindCars(CarSearchModel searchModel)
        {
            var search = new CarSearch();
            var list = search.FindCars(searchModel).ToList();
            return list;
        }
    }
}