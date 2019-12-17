using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.ViewModels
{
    public class FeaturedVehicleViewModel
    {
        public int VehicleId { get; set; }
        public decimal SalePrice { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ImageFileName { get; set; }

    }
}
