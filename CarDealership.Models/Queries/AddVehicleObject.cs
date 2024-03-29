﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class AddVehicleObject
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string BodyStyle { get; set; }
        public int? Year { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal? MSRP { get; set; }
        public decimal? SalePrice { get; set; }
        public string Description { get; set; }
        
    }
}
