using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales/Index
        [Authorize(Roles = "Sales, Admin")]
        public ActionResult Index()
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            var yearList = repo.GetYearList(""); // Empty argument will get list of both New and Used Type

            var salePriceList = repo.GetSalePriceList(""); // Empty argument will get list of both New and Used Type

            var model = new InventoryViewModel()
            {

                YearList = yearList,
                SalePriceList = salePriceList
            };

            return View(model);
        }

        // GET: Sales/Purchase/{id}
        [Authorize(Roles = "Sales, Admin")]
        public ActionResult Purchase(int? id) // This will be called from Javascript code in Index View
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            try
            {
                var model = new PurchaseViewModel()
                {
                    vehicle = repo.GetVehicleById(id),
                    saleLogViewModel = new SaleLogViewModel()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Sales/Purchase
        [HttpPost]
        [Authorize(Roles = "Sales, Admin")]
        public ActionResult Purchase(SaleLogViewModel saleLogViewModel)
        {
            if (ModelState.IsValid)
            {

                var saleLogRepo = SaleLogRepositoryFactory.GetSaleLogRepository();

                var vehicleRepo = VehicleRepositoryFactory.GetVehicleRepository();


                var saleLog = new SaleLog()
                {
                    BuyerName = saleLogViewModel.BuyerName,
                    Email = saleLogViewModel.Email,
                    Street1 = saleLogViewModel.Street1,
                    Street2 = saleLogViewModel.Street2,
                    City = saleLogViewModel.City,
                    State = saleLogViewModel.State,
                    ZipCode = saleLogViewModel.ZipCode,
                    PurchasePrice = saleLogViewModel.PurchasePrice,
                    PurchaseType = saleLogViewModel.PurchaseType,
                    VehicleId = saleLogViewModel.VehicleId,
                    Phone = saleLogViewModel.Phone,
                    SalesUserId = User.Identity.GetUserId(),
                    PurchaseDate = DateTime.Today

            };
                // Add Sale Log Record
                saleLogRepo.AddSaleLog(saleLog);

                // Mark Vehicle as Purchased
                vehicleRepo.VehicleMarkPurchased(saleLogViewModel.VehicleId);

                return RedirectToAction("Index", "Home");

            }
            else // send back the View with error list
            {
                var repo = VehicleRepositoryFactory.GetVehicleRepository();

                var model = new PurchaseViewModel()
                {
                    vehicle = repo.GetVehicleById(saleLogViewModel.VehicleId),
                    saleLogViewModel = saleLogViewModel
                };

                return View(model);
            }

        }

    }
}