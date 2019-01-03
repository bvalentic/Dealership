using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarApplication.Controllers
{
    public class APIController : Controller
    {
        const string userAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

        // GET list of cars
        [HttpGet]
        public ActionResult GetCars()
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:53205/api/Car/GetCars");
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                string jsonData = data.ReadToEnd();
                JObject carData = JObject.Parse("{cars:" + jsonData + "}");
                ViewBag.CarList = carData;
            }

            return View();
        }

        // search view
        
        public ActionResult Search()
        {
            return View();
        }

        // view to display cars found in search

        public ActionResult FoundCars()
        {
            return View();
        }

        // GET car by VIN
        [HttpGet]
        public ActionResult GetCarByVIN(string VIN)
        {
            if (VIN == null) { VIN = ""; }
            HttpWebRequest request = WebRequest.CreateHttp($"http://localhost:53205/api/Car/GetCarByVIN?VIN={VIN}");
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                string jsonData = data.ReadToEnd();
                if (jsonData != "null")
                {
                    JObject car = JObject.Parse("{cars:" + jsonData + "}");
                    ViewBag.FoundCarList = car;
                }
            }

            return View("FoundCars");
        }

        // GET car through any search criteria
        [HttpGet]
        public ActionResult FindCars(string vin, string make, string model, string yearFrom, string yearTo, string color)
        {
            HttpWebRequest request = WebRequest.CreateHttp
                ($"http://localhost:53205/api/Car/FoundCars?vin={vin}&make={make}&model={model}&yearFrom={yearFrom}&yearTo={yearTo}&color={color}");
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                string jsonData = data.ReadToEnd();
                if (jsonData != "[]")
                {
                    JObject cars = JObject.Parse("{cars:" + jsonData + "}");
                    ViewBag.FoundCarList = cars;
                }
                
            }
            return View("FoundCars");
        }
    }
}