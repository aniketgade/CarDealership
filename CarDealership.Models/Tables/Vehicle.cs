using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Tables
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public string Interior { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public string Type { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Color { get; set; }
        public string BodyStyle { get; set; }
        public string Description { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public bool Sold { get; set; }
        public bool FeaturedVehicle { get; set; }
        public string ImageFileName { get; set; }

    }
}
