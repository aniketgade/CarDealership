using CarDealership.Data;
using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationSignInManager _signInManager;
        

        // Copied the below 3 methods from AccountController while transitioning methods from AccountController to AdminController
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ActionResult Index()
        {

            if (Settings.GetRepositoryType() == "QA")
            {
                var context = new ApplicationDbContext();

                var allUsers = context.Users.ToList();

                SignInManager.SignIn(allUsers.Find(u => u.FirstName == "Admin"), true, false);
                
            }

           
            var vehicleRepo = VehicleRepositoryFactory.GetVehicleRepository();

            var specailRepo = SpecialRepositoryFactory.GetSpecialRepository();

            HomeViewModel model = new HomeViewModel()
            {

                vehicleList = vehicleRepo.GetFeaturedVehicleList(),
                specialList = specailRepo.GetSpecials()
            };


            return View(model);
        }


        public ActionResult Specials()
        {
            var specailRepo = SpecialRepositoryFactory.GetSpecialRepository();

            var specialList = specailRepo.GetSpecials();

            return View(specialList);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string vin)
        {
            var model = new ContactViewModel();


            if (!string.IsNullOrEmpty(vin))
            {
                model.VIN = vin;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Contact(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var repo = ContactRepositoryFactory.GetContactRepository();

                var contact = new Contact()
                {
                    Name = contactViewModel.Name,
                    Email = contactViewModel.Email,
                    Phone = contactViewModel.Phone,
                    Message = contactViewModel.Message
                };

                repo.AddContact(contact);

                return RedirectToAction("Index", "Home");
            }
            else // found errors, so return back with same model object
            {
                return View(contactViewModel);
            }

        }
    }
}