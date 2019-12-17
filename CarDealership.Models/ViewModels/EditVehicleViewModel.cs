﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarDealership.Models.ViewModels
{
    public class EditVehicleViewModel
    {
        public int? VehicleId { get; set; }
        [Required(ErrorMessage = "Please enter the VIN")]
        public string VIN { get; set; }
        public string Interior { get; set; }
        public string Transmission { get; set; }
        public string Type { get; set; }
        public string Mileage { get; set; }
        public decimal? MSRP { get; set; }
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }
        public string Color { get; set; }
        public string BodyStyle { get; set; }
        [Required(ErrorMessage = "Please enter the Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the Make")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Please enter the Model")]
        public string Model { get; set; }
        public int? Year { get; set; }
        [Display(Name = "Feature this vehicle")]
        public bool FeaturedVehicle { get; set; }
        public string ImageFileName { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
