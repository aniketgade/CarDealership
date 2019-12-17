using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager; 
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


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Admin/Makes
        [Authorize(Roles = "Admin")]
        public ActionResult Makes()
        {
            var model = new Make();
            return View(model);

        }


        // POST: Admin/Makes
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Makes(Make make)
        {
            var repo = MakeRepositoryFactory.GetMakeRepository();

            make.UserId = User.Identity.GetUserId();
            make.DateAdded = DateTime.Today;

            repo.AddMake(make);

            var model = new Make();
            return View(model);

        }


        // GET: Admin/Models
        [Authorize(Roles = "Admin")]
        public ActionResult Models()
        {
            var viewModel = new AddModelViewModel();
            return View(viewModel);

        }


        // POST: Admin/Models
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Models(AddModelViewModel addModelViewModel)
        {
            var repo = ModelRepositoryFactory.GetModelRepository();

            var makeRepo = MakeRepositoryFactory.GetMakeRepository();

            var vehicleModel = new Model()
            {
                ModelName = addModelViewModel.ModelName,
                MakeId = makeRepo.GetMakeIdByName(addModelViewModel.MakeName),
                UserId = User.Identity.GetUserId(),
                DateAdded = DateTime.Today
            };



            repo.AddModel(vehicleModel);

            var viewModel = new AddModelViewModel();
            return View(viewModel);

        }


        // GET: Admin/Index
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Vehicles
        [Authorize(Roles = "Admin")]
        public ActionResult Vehicles()
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            var yearList = repo.GetYearList("");

            var salePriceList = repo.GetSalePriceList("");

            var model = new InventoryViewModel()
            {

                YearList = yearList,
                SalePriceList = salePriceList
            };

            return View(model);
        }


        //
        // GET: /Account/EditVehicle
        [Authorize(Roles = "Admin")]
        public ActionResult EditVehicle(int? id)
        {
            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            var vehicle = repo.GetVehicleById(id);

            var model = new EditVehicleViewModel()
            {

                VehicleId = vehicle.VehicleId,
                VIN = vehicle.VIN,
                Interior = vehicle.Interior,
                Transmission = vehicle.Transmission,
                Type = vehicle.Type,
                Mileage = vehicle.Mileage,
                MSRP = vehicle.MSRP,
                SalePrice = vehicle.SalePrice,
                Color = vehicle.Color,
                BodyStyle = vehicle.BodyStyle,
                Description = vehicle.Description,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                FeaturedVehicle = vehicle.FeaturedVehicle,
                ImageFileName = vehicle.ImageFileName
            };


            return View(model);
        }


        //
        // POST: /Account/EditVehicle
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditVehicle(EditVehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var repo = VehicleRepositoryFactory.GetVehicleRepository();

                    if (viewModel.ImageUpload != null)
                    {
                        var savepath = Server.MapPath("~/Images/Vehicles");

                        var existingFilePath = Path.Combine(savepath, viewModel.ImageFileName);

                        var newFilepath = existingFilePath; // Copy the existing file path details before deleting it

                        // Delete the existing file first
                        if (System.IO.File.Exists(existingFilePath))
                        {
                            System.IO.File.Delete(existingFilePath);
                        }

                        string extension = Path.GetExtension(viewModel.ImageUpload.FileName);

                        viewModel.ImageUpload.SaveAs(newFilepath);

                    }

                    repo.UpdateVehicle(viewModel);

                    return RedirectToAction("Index", "Home");

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else
            {
                var vehicleViewObject = new AddVehicleViewModel();

                return View(vehicleViewObject);
            }

        }

        //
        // GET: /Account/AddVehicle
        [Authorize(Roles = "Admin")]
        public ActionResult AddVehicle()
        {
            var model = new AddVehicleViewModel();

            return View(model);
        }

        //
        // POST: /Account/AddVehicle
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddVehicle(AddVehicleViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var newVehicle = new AddVehicleObject()
                    {
                        Make = viewModel.Make,
                        Model = viewModel.Model,
                        Type = viewModel.Type,
                        BodyStyle = viewModel.BodyStyle,
                        Year = viewModel.Year,
                        Transmission = viewModel.Transmission,
                        Color = viewModel.Color,
                        Interior = viewModel.Interior,
                        Mileage = viewModel.Mileage,
                        VIN = viewModel.VIN,
                        MSRP = viewModel.MSRP,
                        SalePrice = viewModel.SalePrice,
                        Description = viewModel.Description
                    };

                    var repo = VehicleRepositoryFactory.GetVehicleRepository();

                    repo.AddVehicle(newVehicle);


                    var savepath = Server.MapPath("~/Images/Vehicles");

                    string extension = Path.GetExtension(viewModel.ImageUpload.FileName);

                    var filePath = Path.Combine(savepath, "inventory-" + newVehicle.VehicleId.ToString() + extension);

                    viewModel.ImageUpload.SaveAs(filePath);

                    var fileName = Path.GetFileName(filePath);

                    repo.AddVehicleFileName(fileName, newVehicle.VehicleId);

                    return RedirectToAction("EditVehicle", new { id = newVehicle.VehicleId });

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else
            {
                var vehicleViewObject = new AddVehicleViewModel();

                return View(vehicleViewObject);
            }


        }


        //
        // GET: /Account/Users
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            var userList = UserManager.Users.ToList();

            var userQueryList = new List<UserQuery>();

            foreach (var user in userList)
            {
                var userQuery = new UserQuery();

                userQuery.LastName = user.LastName;
                userQuery.FirstName = user.FirstName;
                userQuery.Email = user.Email;
                if (user.Roles.Any())
                {
                    userQuery.Role = UserManager.GetRoles(user.Id)[0];
                }
                userQuery.UserId = user.Id;

                userQueryList.Add(userQuery);
            }

            return View(userQueryList);
        }


        //
        // GET: /Account/AddUser
        public ActionResult AddUser()
        {
            return View();
        }

        //
        // POST: /Account/AddUser
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    var currentUser = UserManager.FindByName(user.UserName);

                    var roleresult = UserManager.AddToRole(currentUser.Id, model.Role);

                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //
        // GET: /Account/EditUser
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(string userId) // UserId will be passed from Users list page
        {
            var editUserObject = new EditUserViewModel();

            var user = UserManager.FindById(userId);

            editUserObject.FirstName = user.FirstName;
            editUserObject.LastName = user.LastName;
            editUserObject.Email = user.Email;
            editUserObject.Role = UserManager.GetRoles(userId).FirstOrDefault();
            editUserObject.Id = userId;

            return View(editUserObject);
        }


        //
        // POST: /Account/EditUser
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserViewModel model)
        {
            var user = UserManager.FindById(model.Id);

            if (model.Password != null)
            {
                if (UserManager.HasPassword(model.Id))
                {
                    UserManager.RemovePassword(model.Id);
                }

                UserManager.AddPassword(model.Id, model.Password);

            }

            // Update it with the values from the view model
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            UserManager.Update(user);



            if (!UserManager.IsInRole(model.Id, model.Role))
            {
                var oldRole = UserManager.GetRoles(model.Id)[0];

                UserManager.RemoveFromRole(model.Id, oldRole);

                UserManager.AddToRole(model.Id, model.Role);
            }

            return RedirectToAction("Index", "Home");

        }


        //
        // GET: /Admin/Specials
        [Authorize(Roles = "Admin")]
        public ActionResult Specials()
        {
            var special = new Special();

            return View(special);
        }


        //
        // POST: /Admin/Specials
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Specials(Special special)
        {
            var repo = SpecialRepositoryFactory.GetSpecialRepository();

            repo.AddSpecial(special);

            var newSpecial = new Special();

            return View(newSpecial);
        }


    }
}