using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Models
{
    public class CarSearch
    {//class is really only used for its SearchCars method; returning a list
     //of cars that fit the searchModel criteria
        public IQueryable<Car> SearchCars(CarSearchModel searchModel)
        {
            //var result = "car";
            //return result;

            CarDBEntities DB = new CarDBEntities();
            //allows list of cars to be searchable/queried
            var result = DB.Cars.AsQueryable();

            if (searchModel != null)
            {
                if (searchModel.VIN.HasValue)
                {//int values don't have "Contains" method
                    result = result.Where(c => c.VIN == searchModel.VIN);
                }
                if (!string.IsNullOrEmpty(searchModel.Make))
                {//didn't use "Contains" here because there are only 3 makes in drop-down
                    result = result.Where(c => c.Make == searchModel.Make);
                }
                if (!string.IsNullOrEmpty(searchModel.Model))
                {
                    result = result.Where(c => c.Model.Contains(searchModel.Model));
                }
                if (searchModel.YearFrom.HasValue)
                {
                    result = result.Where(c => c.Year >= searchModel.YearFrom);
                }
                if (searchModel.YearTo.HasValue)
                {
                    result = result.Where(c => c.Year <= searchModel.YearTo);
                }
                if (!string.IsNullOrEmpty(searchModel.Color))
                {
                    result = result.Where(c => c.Color.Contains(searchModel.Color));
                }
            }
            return result;
        }
    }
}