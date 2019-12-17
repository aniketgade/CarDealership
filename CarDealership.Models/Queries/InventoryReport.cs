using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class InventoryReport
    {
        public List<VehicleInventory> NewVehicles { get; set; }
        public List<VehicleInventory> UsedVehicles { get; set; }

    }
}
