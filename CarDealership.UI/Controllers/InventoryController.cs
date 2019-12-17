using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory/New
        public ActionResult New()
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            var yearList = repo.GetYearList("New");

            var salePriceList = repo.GetSalePriceList("New");

            var model = new InventoryViewModel() {

                YearList = yearList,
                SalePriceList = salePriceList
            };

            return View(model);
        }

        // GET: Inventory/New
        public ActionResult Used()
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            var yearList = repo.GetYearList("Used");
            yearList.Sort();

            var salePriceList = repo.GetSalePriceList("Used");
            salePriceList.Sort();

            var model = new InventoryViewModel()
            {

                YearList = yearList,
                SalePriceList = salePriceList
            };

            return View(model);
        }


        // GET: Inventory/Details/{id}
        public ActionResult Details(int? id) // This will be called from Javascript code in New Vehicle View
        {

            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            try
            {
                var vehicle = repo.GetVehicleById(id);

                return View(vehicle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}