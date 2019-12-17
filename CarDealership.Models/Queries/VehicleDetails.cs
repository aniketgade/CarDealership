using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Queries
{
    public class VehicleDetails
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }
        public string Interior { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Color { get; set; }
        public string BodyStyle { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool FeaturedVehicle { get; set; }
        public string Type { get; set; }
        public string ImageFileName { get; set; }
    }
}
