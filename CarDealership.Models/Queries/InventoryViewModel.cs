using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class InventoryViewModel
    {
        public List<decimal> SalePriceList { get; set; }
        public List<int> YearList { get; set; }
    }
}
