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

        ///<summary>
        ///Gets list of cars from our proprietary car database
        ///</summary>        
        public List<Car> GetCars()
        {
            return DB.Cars.ToList();
        }

        // GET cars by search criteria (make, model, color, year range)
        [HttpGet]
        public List<Car> FoundCars(int? vin, string make, string model, int? yearFrom, int? yearTo, string color)
        {//creates instance of search model using search inputs (if any)
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

        // GET car by search criteria (using search model)
        [HttpGet]
        public List<Car> FindCars(CarSearchModel searchModel)
        {//takes search model, makes instance of another class CarSearch, 
         //and uses a method in the class to return a list of cars that 
         //fit the search criteria
            var search = new CarSearch();
            var list = search.SearchCars(searchModel).ToList();
            return list;
        }
    }
}