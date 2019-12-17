using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class SaleLogRepositoryQA : ISaleLogRepository
    {

        static ApplicationDbContext context = new ApplicationDbContext();

        private static List<ApplicationUser> allUsers = context.Users.ToList();


        static List<SaleLog> saleLogList = new List<SaleLog>() {

            new SaleLog()
            {
                SaleId = 1,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 19000,
                PurchaseType = "Dealer Finance",
                VehicleId = 9,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User1").Id,
                PurchaseDate = new DateTime(2002,10,04)
            },
            new SaleLog()
            {
                SaleId = 2,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 9000,
                PurchaseType = "Dealer Finance",
                VehicleId = 10,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User2").Id,
                PurchaseDate = new DateTime(2004,10,04)
            },
            new SaleLog()
            {
                SaleId = 3,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 29000,
                PurchaseType = "Dealer Finance",
                VehicleId = 11,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User3").Id,
                PurchaseDate = new DateTime(2008,10,04)
            },
            new SaleLog()
            {
                SaleId = 4,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 5000,
                PurchaseType = "Dealer Finance",
                VehicleId = 12,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User4").Id,
                PurchaseDate = new DateTime(2012,10,04)
            },
            new SaleLog()
            {
                SaleId = 5,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 22000,
                PurchaseType = "Dealer Finance",
                VehicleId = 13,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User1").Id,
                PurchaseDate = new DateTime(2014,10,04)
            },
            new SaleLog()
            {
                SaleId = 6,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 7000,
                PurchaseType = "Dealer Finance",
                VehicleId = 14,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User2").Id,
                PurchaseDate = new DateTime(2018,10,04)
            },
            new SaleLog()
            {
                SaleId = 7,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 19000,
                PurchaseType = "Dealer Finance",
                VehicleId = 15,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User3").Id,
                PurchaseDate = new DateTime(2010,10,04)
            },
            new SaleLog()
            {
                SaleId = 8,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 33000,
                PurchaseType = "Dealer Finance",
                VehicleId = 16,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User4").Id,
                PurchaseDate = new DateTime(2016,10,04)
            },
            new SaleLog()
            {
                SaleId = 9,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 3000,
                PurchaseType = "Dealer Finance",
                VehicleId = 17,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User1").Id,
                PurchaseDate = new DateTime(2007,10,04)
            },
            new SaleLog()
            {
                SaleId = 10,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 55000,
                PurchaseType = "Dealer Finance",
                VehicleId = 18,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User2").Id,
                PurchaseDate = new DateTime(2011,10,04)
            },
            new SaleLog()
            {
                SaleId = 11,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 6000,
                PurchaseType = "Dealer Finance",
                VehicleId = 19,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User3").Id,
                PurchaseDate = new DateTime(2005,10,04)
            },
            new SaleLog()
            {
                SaleId = 12,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 11000,
                PurchaseType = "Dealer Finance",
                VehicleId = 20,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User4").Id,
                PurchaseDate = new DateTime(2015,10,04)
            },
            new SaleLog()
            {
                SaleId = 13,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 32000,
                PurchaseType = "Dealer Finance",
                VehicleId = 21,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User1").Id,
                PurchaseDate = new DateTime(2007,10,04)
            },
            new SaleLog()
            {
                SaleId = 14,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 4000,
                PurchaseType = "Dealer Finance",
                VehicleId = 22,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User2").Id,
                PurchaseDate = new DateTime(2011,10,04)
            },
            new SaleLog()
            {
                SaleId = 15,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 22000,
                PurchaseType = "Dealer Finance",
                VehicleId = 23,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User3").Id,
                PurchaseDate = new DateTime(2006,10,04)
            },
            new SaleLog()
            {
                SaleId = 16,
                BuyerName = "Aniket",
                Email = "aniket@gmail.com",
                Street1 = "112 Awesome st",
                Street2 = "",
                City = "Chicago",
                State = "MI",
                ZipCode = "97787",
                PurchasePrice = 66000,
                PurchaseType = "Dealer Finance",
                VehicleId = 24,
                Phone = "2223334444",
                SalesUserId = allUsers.First(u=>u.LastName == "User4").Id,
                PurchaseDate = new DateTime(2016,10,04)
            }
        };

        public void AddSaleLog(SaleLog saleLog)
        {
            int maxId = saleLogList.Max(s => s.SaleId);

            saleLogList.Add(new SaleLog()
            {
                SaleId = maxId + 1,
                BuyerName = saleLog.BuyerName,
                Email = saleLog.Email,
                Street1 = saleLog.Street1,
                Street2 = saleLog.Street2,
                City = saleLog.City,
                State = saleLog.State,
                ZipCode = saleLog.ZipCode,
                PurchasePrice = saleLog.PurchasePrice,
                PurchaseType = saleLog.PurchaseType,
                VehicleId = saleLog.VehicleId,
                Phone = saleLog.Phone,
                SalesUserId = saleLog.SalesUserId,
                PurchaseDate = saleLog.PurchaseDate
            });
        }

        public List<UserSaleObject> Search(InventorySearchParameters parameters)
        {
            var context = new ApplicationDbContext();

            var allUsers = context.Users.ToList();

            var list = new List<UserSaleObject>();

            var query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };


            if (!string.IsNullOrEmpty(parameters.UserId) && !parameters.FromDate.HasValue && !parameters.ToDate.HasValue)
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where u.Id == parameters.UserId
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }

            else if (parameters.FromDate.HasValue && parameters.ToDate.HasValue && !string.IsNullOrEmpty(parameters.UserId))
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where u.Id == parameters.UserId && s.PurchaseDate >= parameters.FromDate && s.PurchaseDate <= parameters.ToDate
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }

            else if (!parameters.FromDate.HasValue && parameters.ToDate.HasValue && !string.IsNullOrEmpty(parameters.UserId))
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where u.Id == parameters.UserId && s.PurchaseDate <= parameters.ToDate
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }

            else if (parameters.FromDate.HasValue && !parameters.ToDate.HasValue && !string.IsNullOrEmpty(parameters.UserId))
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where u.Id == parameters.UserId && s.PurchaseDate >= parameters.FromDate 
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }

            else if (parameters.FromDate.HasValue && !parameters.ToDate.HasValue && string.IsNullOrEmpty(parameters.UserId))
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where s.PurchaseDate >= parameters.FromDate
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }

            else if (!parameters.FromDate.HasValue && parameters.ToDate.HasValue && string.IsNullOrEmpty(parameters.UserId))
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where s.PurchaseDate <= parameters.ToDate
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }

            else if (parameters.FromDate.HasValue && parameters.ToDate.HasValue && string.IsNullOrEmpty(parameters.UserId))
            {
                query = from s in saleLogList
                        join u in allUsers on s.SalesUserId equals u.Id
                        where s.PurchaseDate >= parameters.FromDate && s.PurchaseDate <= parameters.ToDate
                        group s by new
                        {
                            u.FirstName,
                            u.LastName,
                        } into grp
                        select new
                        {
                            User = grp.Key.FirstName + " " + grp.Key.LastName,
                            TotalVehicles = grp.Count(),
                            TotalSales = grp.Sum(s => s.PurchasePrice)
                        };
            }





            foreach (var item in query)
            {
                var record = new UserSaleObject();
                record.TotalSales = item.TotalSales;
                record.TotalVehicles = item.TotalVehicles;
                record.User = item.User;

                list.Add(record);
            }

            return list;
        }

        public List<SaleLog> GetAllSales()
        {
            return saleLogList;
        }
    }
}
