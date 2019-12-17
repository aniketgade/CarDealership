using CarDealership.Data.Dapper;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using CarDealership.UI.Models;
using System.Linq;

namespace CarDealership.Tests.IntegrationTests
{
    [TestFixture]
    public class DapperTests
    {
        private List<ApplicationUser> allUsers;

        [SetUp]
        public void Init()
        {
            var context = new ApplicationDbContext();

            allUsers = context.Users.ToList();

            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadFeaturedVehicles()
        {
            var repo = new VehicleRepository();

            var list = repo.GetFeaturedVehicleList();

            Assert.AreEqual(4, list.Count);

        }

        [Test]
        public void CanLoadVehicleDetailsList()
        {
            var repo = new VehicleRepository();

            var list = repo.GetVehicleDetailsList();

            Assert.AreEqual(8, list.Count);

            Assert.AreEqual(1, list[0].VehicleId);
        }

        [Test]
        public void CanLoadVehicleInventoryList()
        {
            var repo = new VehicleRepository();

            var list = repo.GetVehicleInventoryList("New");

            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(50000, list[1].StockValue);

            var list2 = repo.GetVehicleInventoryList("Used");

            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(65000, list2[0].StockValue);
        }


        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialRepository();

            var list = repo.GetSpecials();

            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("College Graduate Program", list[0].Title);
        }




        [Test]
        public void CanAddContact()
        {

            Contact contact = new Contact()
            {
                Name = "Aniket",
                Email = "abc@gmail.com",
                Phone = "7722322322",
                Message = "Howdy Howdy Bowdy"
            };

            var repo = new ContactRepository();

            repo.AddContact(contact);

            // Now check in the DB if the record was added

        }


        [Test]
        public void CanAddSpecial()
        {

            Special special = new Special()
            {
                Title = "New Special",
                Description = "This is some marketing non-sense to trick you and get your money."
            };

            var repo = new SpecialRepository();

            repo.AddSpecial(special);

            Assert.AreEqual(4, repo.GetSpecials().Count);


        }

        [Test]
        public void CanAddSaleLog()
        {

            SaleLog saleLog = new SaleLog()
            {
                BuyerName = "Karnan",
                Email = "karna@gmail.com",
                Street1 = "123 street",
                City = "Chicago",
                State = "MI",
                ZipCode = "98234",
                PurchasePrice = 25000,
                PurchaseType = "Dealer Finance",
                VehicleId = 4,
                Phone = "7711322322",
                SalesUserId = allUsers[0].Id,
                PurchaseDate = DateTime.Today
            };

            var repo = new SaleLogRepository();

            repo.AddSaleLog(saleLog);

            // Now check in the DB if the record was added

        }


        [Test]
        public void CanAddVehicle()
        {

            AddVehicleObject vehicle = new AddVehicleObject()
            {
                VIN = "1GC0KXCG9DF173160",
                Interior = "White",
                Transmission = "Automatic",
                Mileage = "11223",
                MSRP = 12000,
                SalePrice = 10455,
                Color = "Black",
                BodyStyle = "Sedan",
                Description = "Nice well maintained and hardly driven car",
                Make = "Dodge",
                Model = "Charger",
                Type = "Used",
                Year = 2001
            };

            var repo = new VehicleRepository();

            repo.AddVehicle(vehicle);

            // Now check in the DB if the record was added

        }


        [Test]
        public void CanAddModel()
        {

            Model model = new Model()
            {
                ModelName = "Dart",
                MakeId = 3,
                DateAdded = new DateTime(2012, 02, 14),
                UserId = allUsers[0].Id
            };

            var repo = new ModelRepository();

            repo.AddModel(model);

            // Now check in the DB if the record was added

        }


        [Test]
        public void CanAddMake()
        {

            Make make = new Make()
            {
                MakeName = "Ford",
                DateAdded = new DateTime(2014, 06, 09),
                UserId = allUsers[0].Id
            };

            var repo = new MakeRepository();


            repo.AddMake(make);

            // Now check in the DB if the record was added

        }
    }
}
