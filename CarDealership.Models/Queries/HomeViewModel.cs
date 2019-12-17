using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class HomeViewModel
    {
        public List<FeaturedVehicleViewModel> vehicleList;

        public List<Special> specialList;
    }
}
