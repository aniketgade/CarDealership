using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.Models.ViewModels;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }


        // GET: Reports/Inventory
        [Authorize(Roles = "Admin")]
        public ActionResult Inventory()
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            var model = new InventoryReport()
            {
                NewVehicles = repo.GetVehicleInventoryList("New"),
                UsedVehicles = repo.GetVehicleInventoryList("Used")
            };

            return View(model);
        }


        // GET: Reports/Inventory
        [Authorize(Roles = "Admin")]
        public ActionResult Sales()
        {
            var db = new ApplicationDbContext();
            var users = db.Users.ToList();

            var model = new List<string>();

            var userList = new List<UserSaleViewModel>();

            foreach (var item in users)
            {
                if (!string.IsNullOrEmpty(item.FirstName))
                {
                    var userSaleViewModel = new UserSaleViewModel()
                    {
                        FullName = item.FirstName + " " + item.LastName,
                        UserId = item.Id
                    };
                    userList.Add(userSaleViewModel);
                }

            }

            return View(userList);
        }
    }
}