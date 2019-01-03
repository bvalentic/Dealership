using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Models
{
    public class CarSearchModel
    {//model used to store search criteria
        public int? VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public string Color { get; set; }
    }
}