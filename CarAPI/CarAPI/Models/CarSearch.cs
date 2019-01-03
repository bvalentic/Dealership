using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Models
{
    public class CarSearch
    {
        public IQueryable<Car> FindCars(CarSearchModel searchModel)
        {
            //var result = "car";
            //return result;

            CarDBEntities DB = new CarDBEntities();

            var result = DB.Cars.AsQueryable();

            if (searchModel != null)
            {
                if (searchModel.VIN.HasValue)
                {
                    result = result.Where(c => c.VIN == searchModel.VIN);
                }
                if (!string.IsNullOrEmpty(searchModel.Make))
                {
                    result = result.Where(c => c.Make == searchModel.Make);
                }
                if (!string.IsNullOrEmpty(searchModel.Model))
                {
                    result = result.Where(c => c.Model == searchModel.Model);
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
                    result = result.Where(c => c.Color == searchModel.Color);
                }
            }
            return result;
        }
    }
}