using CarDealership.Data.Factories;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class VehicleRepositoryQA : IVehicleRepository
    {

        // Define VehicleList as static so that its contents are retained across all instances of VehicleRepositoryQA
        static List<Vehicle> vehicleList = new List<Vehicle>() {

            new Vehicle()
            {
                VehicleId = 1,
                VIN = "JTEBU11F470092662",
                Interior = "White",
                Transmission = "Automatic",
                Mileage = "5500",
                MSRP = 25000,
                SalePrice = 24500,
                Color = "Red",
                BodyStyle = "SUV",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2008,
                Sold = false,
                FeaturedVehicle = true,
                Type = "Used",
                ImageFileName = "inventory-1.jpg"
            },

            new Vehicle()
            {
                VehicleId = 2,
                VIN = "JT4RN56D0F0061406",
                Interior = "Red",
                Transmission = "Manual",
                Mileage = "50",
                MSRP = 20000,
                SalePrice = 19500,
                Color = "Black",
                BodyStyle = "Car",
                Description = "A Sporty Coupe for Adrenaline junkies",
                MakeId = 3,
                ModelId = 6,
                Year = 2015,
                Sold = false,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-2.jpg"
            },

            new Vehicle()
            {
                VehicleId = 3,
                VIN = "JKAEXMJ18ADA55383",
                Interior = "Silver",
                Transmission = "Automatic",
                Mileage = "2100",
                MSRP = 65000,
                SalePrice = 62500,
                Color = "Silver",
                BodyStyle = "SUV",
                Description = "Mighty Mouse crossover, small but effortlessly playful",
                MakeId = 1,
                ModelId = 1,
                Year = 2009,
                Sold = false,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-3.jpg"
            },

            new Vehicle()
            {
                VehicleId = 4,
                VIN = "1HGCM56747A071243",
                Interior = "Black",
                Transmission = "Manual",
                Mileage = "500",
                MSRP = 65000,
                SalePrice = 62500,
                Color = "White",
                BodyStyle = "Car",
                Description = "Poised and sophisticated; an executive sedan for the driver in charge",
                MakeId = 1,
                ModelId = 2,
                Year = 2018,
                Sold = false,
                FeaturedVehicle = true,
                Type = "New",
                ImageFileName = "inventory-4.jpg"
            },

            new Vehicle()
            {
                VehicleId = 5,
                VIN = "JTEBU11F470112662",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "32550",
                MSRP = 20000,
                SalePrice = 18000,
                Color = "Silver",
                BodyStyle = "Car",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2004,
                Sold = false,
                FeaturedVehicle = true,
                Type = "Used",
                ImageFileName = "inventory-5.jpg"
            },

            new Vehicle()
            {
                VehicleId = 6,
                VIN = "JTEVC11F470112662",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "3300",
                MSRP = 22000,
                SalePrice = 20000,
                Color = "Silver",
                BodyStyle = "Van",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2005,
                Sold = false,
                FeaturedVehicle = true,
                Type = "Used",
                ImageFileName = "inventory-6.jpg"
            },

            new Vehicle()
            {
                VehicleId = 7,
                VIN = "JT4R126D0F0061406",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "300",
                MSRP = 22000,
                SalePrice = 20000,
                Color = "Silver",
                BodyStyle = "Van",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 2,
                ModelId = 3,
                Year = 2019,
                Sold = false,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-7.jpg"
            },

            new Vehicle()
            {
                VehicleId = 8,
                VIN = "J35126D0F0061406",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "100",
                MSRP = 10000,
                SalePrice = 9500,
                Color = "Silver",
                BodyStyle = "Truck",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 5,
                ModelId = 9,
                Year = 2017,
                Sold = false,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-8.jpg"
            },


            new Vehicle()
            {
                VehicleId = 9,
                VIN = "JTEBU11F470092662",
                Interior = "White",
                Transmission = "Automatic",
                Mileage = "5500",
                MSRP = 25000,
                SalePrice = 24500,
                Color = "Red",
                BodyStyle = "SUV",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2008,
                Sold = true,
                FeaturedVehicle = true,
                Type = "Used",
                ImageFileName = "inventory-9.jpg"
            },

            new Vehicle()
            {
                VehicleId = 10,
                VIN = "JT4RN56D0F0061406",
                Interior = "Red",
                Transmission = "Manual",
                Mileage = "50",
                MSRP = 20000,
                SalePrice = 19500,
                Color = "Black",
                BodyStyle = "Car",
                Description = "A Sporty Coupe for Adrenaline junkies",
                MakeId = 3,
                ModelId = 6,
                Year = 2015,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-10.jpg"
            },

            new Vehicle()
            {
                VehicleId = 11,
                VIN = "JKAEXMJ18ADA55383",
                Interior = "Silver",
                Transmission = "Automatic",
                Mileage = "2100",
                MSRP = 65000,
                SalePrice = 62500,
                Color = "Silver",
                BodyStyle = "SUV",
                Description = "Mighty Mouse crossover, small but effortlessly playful",
                MakeId = 1,
                ModelId = 1,
                Year = 2009,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-11.jpg"
            },

            new Vehicle()
            {
                VehicleId = 12,
                VIN = "1HGCM56747A071243",
                Interior = "Black",
                Transmission = "Manual",
                Mileage = "500",
                MSRP = 65000,
                SalePrice = 62500,
                Color = "White",
                BodyStyle = "Car",
                Description = "Poised and sophisticated; an executive sedan for the driver in charge",
                MakeId = 1,
                ModelId = 2,
                Year = 2018,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-12.jpg"
            },

            new Vehicle()
            {
                VehicleId = 13,
                VIN = "JTEBU11F470112662",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "32550",
                MSRP = 20000,
                SalePrice = 18000,
                Color = "Silver",
                BodyStyle = "Car",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2004,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-13.jpg"
            },

            new Vehicle()
            {
                VehicleId = 14,
                VIN = "JTEVC11F470112662",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "3300",
                MSRP = 22000,
                SalePrice = 20000,
                Color = "Silver",
                BodyStyle = "Van",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2005,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-14.jpg"
            },

            new Vehicle()
            {
                VehicleId = 15,
                VIN = "JT4R126D0F0061406",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "300",
                MSRP = 22000,
                SalePrice = 20000,
                Color = "Silver",
                BodyStyle = "Van",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 2,
                ModelId = 3,
                Year = 2019,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-15.jpg"
            },

            new Vehicle()
            {
                VehicleId = 16,
                VIN = "J35126D0F0061406",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "100",
                MSRP = 10000,
                SalePrice = 9500,
                Color = "Silver",
                BodyStyle = "Truck",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 5,
                ModelId = 9,
                Year = 2017,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-16.jpg"
            },

            new Vehicle()
            {
                VehicleId = 17,
                VIN = "JTEBU11F470092662",
                Interior = "White",
                Transmission = "Automatic",
                Mileage = "5500",
                MSRP = 25000,
                SalePrice = 24500,
                Color = "Red",
                BodyStyle = "SUV",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2008,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-17.jpg"
            },

            new Vehicle()
            {
                VehicleId = 18,
                VIN = "JT4RN56D0F0061406",
                Interior = "Red",
                Transmission = "Manual",
                Mileage = "50",
                MSRP = 20000,
                SalePrice = 19500,
                Color = "Black",
                BodyStyle = "Car",
                Description = "A Sporty Coupe for Adrenaline junkies",
                MakeId = 3,
                ModelId = 6,
                Year = 2015,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-18.jpg"
            },

            new Vehicle()
            {
                VehicleId = 19,
                VIN = "JKAEXMJ18ADA55383",
                Interior = "Silver",
                Transmission = "Automatic",
                Mileage = "2100",
                MSRP = 65000,
                SalePrice = 62500,
                Color = "Silver",
                BodyStyle = "SUV",
                Description = "Mighty Mouse crossover, small but effortlessly playful",
                MakeId = 1,
                ModelId = 1,
                Year = 2009,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-19.jpg"
            },

            new Vehicle()
            {
                VehicleId = 20,
                VIN = "1HGCM56747A071243",
                Interior = "Black",
                Transmission = "Manual",
                Mileage = "500",
                MSRP = 65000,
                SalePrice = 62500,
                Color = "White",
                BodyStyle = "Car",
                Description = "Poised and sophisticated; an executive sedan for the driver in charge",
                MakeId = 1,
                ModelId = 2,
                Year = 2018,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-20.jpg"
            },

            new Vehicle()
            {
                VehicleId = 21,
                VIN = "JTEBU11F470112662",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "32550",
                MSRP = 20000,
                SalePrice = 18000,
                Color = "Silver",
                BodyStyle = "Car",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2004,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-21.jpg"
            },

            new Vehicle()
            {
                VehicleId = 22,
                VIN = "JTEVC11F470112662",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "3300",
                MSRP = 22000,
                SalePrice = 20000,
                Color = "Silver",
                BodyStyle = "Van",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 3,
                ModelId = 5,
                Year = 2005,
                Sold = true,
                FeaturedVehicle = false,
                Type = "Used",
                ImageFileName = "inventory-22.jpg"
            },

            new Vehicle()
            {
                VehicleId = 23,
                VIN = "JT4R126D0F0061406",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "300",
                MSRP = 22000,
                SalePrice = 20000,
                Color = "Silver",
                BodyStyle = "Van",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 2,
                ModelId = 3,
                Year = 2019,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-23.jpg"
            },

            new Vehicle()
            {
                VehicleId = 24,
                VIN = "J35126D0F0061406",
                Interior = "Black",
                Transmission = "Automatic",
                Mileage = "100",
                MSRP = 10000,
                SalePrice = 9500,
                Color = "Silver",
                BodyStyle = "Truck",
                Description = "A Shiny Sedan with great comfort and ample leg room",
                MakeId = 5,
                ModelId = 9,
                Year = 2017,
                Sold = true,
                FeaturedVehicle = false,
                Type = "New",
                ImageFileName = "inventory-24.jpg"
            },

        };

        public void AddVehicle(AddVehicleObject vehicle)
        {
            int maxVehicleId = vehicleList.Max(v => v.VehicleId);

            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var modelRepo = ModelRepositoryFactory.GetModelRepository();

            vehicleList.Add(
                new Vehicle()
                {
                    VehicleId = maxVehicleId + 1,
                    VIN = vehicle.VIN,
                    Interior = vehicle.Interior,
                    Transmission = vehicle.Transmission,
                    Mileage = vehicle.Mileage,
                    MSRP = vehicle.MSRP ?? default(decimal),
                    SalePrice = vehicle.SalePrice ?? default(decimal),
                    Color = vehicle.Color,
                    BodyStyle = vehicle.BodyStyle,
                    Description = vehicle.Description,
                    MakeId = makeRepo.GetMakeIdByName(vehicle.Make),
                    ModelId = modelRepo.GetModelIdByName(vehicle.Model),
                    Year = vehicle.Year ?? default(int),
                    Sold = false, // default value
                    FeaturedVehicle = false, // default value
                    Type = vehicle.Type,
                    // ImageFileName will be added in a different method
                }
                );

            vehicle.VehicleId = maxVehicleId + 1;
        }

        public void AddVehicleFileName(string fileName, int vehicleId)
        {
            var index = vehicleList.FindIndex(v => v.VehicleId == vehicleId);

            vehicleList[index].ImageFileName = fileName;
        }

        public void DeleteVehicle(int vehicleId)
        {
            vehicleList.Remove(vehicleList.Find(v => v.VehicleId == vehicleId));
        }

        public List<FeaturedVehicleViewModel> GetFeaturedVehicleList()
        {
            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var modelRepo = ModelRepositoryFactory.GetModelRepository();

            var featuredVehicleList = new List<FeaturedVehicleViewModel>();

            var list = vehicleList.Where(v => v.FeaturedVehicle);

            foreach (var item in list)
            {
                var vehicle = new FeaturedVehicleViewModel();
                vehicle.Make = makeRepo.GetMakeById(item.MakeId);
                vehicle.Model = modelRepo.GetModelById(item.ModelId);
                vehicle.SalePrice = item.SalePrice;
                vehicle.Year = item.Year;
                vehicle.VehicleId = item.VehicleId;
                vehicle.ImageFileName = item.ImageFileName;

                featuredVehicleList.Add(vehicle);
            }

            return featuredVehicleList;
        }

        public List<decimal> GetSalePriceList(string type) // This is an exact copy of method in Prod
        {
            if (!string.IsNullOrEmpty(type)) // Need either New or Old 
            {
                var salePriceList = GetVehicleSearchResultList(type);

                var unsortedList = salePriceList.Select(v => v.SalePrice).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(s => s).ToList();

                var formatedList = new List<decimal>();

                foreach (var price in sortedList)
                {
                    formatedList.Add(Decimal.Truncate(price)); // Remove the decimal and leading zeroes
                }

                return formatedList;

            }

            else
            { // Need all type Vehicles , both New and Old
                var salePriceList = GetVehicleDetailsList();


                var unsortedList = salePriceList.Select(v => v.SalePrice).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(s => s).ToList();

                var formatedList = new List<decimal>();

                foreach (var price in sortedList)
                {
                    formatedList.Add(Decimal.Truncate(price)); // Remove the decimal and leading zeroes
                }

                return formatedList;
            }

        }


        private VehicleDetails ConvertToVehicleDetails(Vehicle vehicle)
        {
            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var modelRepo = ModelRepositoryFactory.GetModelRepository();

            var vehicleDetails = new VehicleDetails()
            {

                VehicleId = vehicle.VehicleId,
                VIN = vehicle.VIN,
                Interior = vehicle.Interior,
                Transmission = vehicle.Transmission,
                Mileage = vehicle.Mileage,
                MSRP = vehicle.MSRP,
                SalePrice = vehicle.SalePrice,
                Color = vehicle.Color,
                BodyStyle = vehicle.BodyStyle,
                Description = vehicle.Description,
                Make = makeRepo.GetMakeById(vehicle.MakeId),
                Model = modelRepo.GetModelById(vehicle.ModelId),
                Year = vehicle.Year,
                Type = vehicle.Type,
                ImageFileName = vehicle.ImageFileName
            };
            return vehicleDetails;
        }


        private VehicleSearchResult ConvertToVehicleSearchResult(Vehicle vehicle)
        {
            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var modelRepo = ModelRepositoryFactory.GetModelRepository();

            var vehicleSearchResult = new VehicleSearchResult()
            {

                VehicleId = vehicle.VehicleId,
                VIN = vehicle.VIN,
                Interior = vehicle.Interior,
                Transmission = vehicle.Transmission,
                Mileage = vehicle.Mileage,
                MSRP = vehicle.MSRP,
                SalePrice = vehicle.SalePrice,
                Color = vehicle.Color,
                BodyStyle = vehicle.BodyStyle,
                Make = makeRepo.GetMakeById(vehicle.MakeId),
                Model = modelRepo.GetModelById(vehicle.ModelId),
                Year = vehicle.Year,
                ImageFileName = vehicle.ImageFileName
            };
            return vehicleSearchResult;
        }

        public VehicleDetails GetVehicleById(int? vehicleId)
        {
            var vehicle = vehicleList.First(v => v.VehicleId == vehicleId);

            return ConvertToVehicleDetails(vehicle);
        }

        public List<VehicleDetails> GetVehicleDetailsList()
        {
            var vehicleDetailsList = new List<VehicleDetails>();

            foreach (var item in vehicleList)
            {
                var vehicleDetail = ConvertToVehicleDetails(item);
                vehicleDetailsList.Add(vehicleDetail);
            }

            return vehicleDetailsList;
        }

        public List<VehicleInventory> GetVehicleInventoryList(string type)
        {
            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var makes = makeRepo.GetMakeDetails();

            var modelRepo = ModelRepositoryFactory.GetModelRepository();
            var models = modelRepo.GetAllModels();

            var list = new List<VehicleInventory>();

            var query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where v.Type == type && v.Sold == false
                        group v by new
                        {
                            mk.MakeName,
                            mo.ModelName,
                            v.Year
                        } into grp
                        select new
                        {
                            grp.Key.Year,
                            grp.Key.MakeName,
                            grp.Key.ModelName,
                            Count = grp.Count(),
                            StockValue = grp.Sum(v => v.MSRP)
                        };

            foreach (var item in query)
            {
                var inventoryRecord = new VehicleInventory();
                inventoryRecord.Year = item.Year;
                inventoryRecord.Make = item.MakeName;
                inventoryRecord.Model = item.ModelName;
                inventoryRecord.Count = item.Count;
                inventoryRecord.StockValue = item.StockValue;

                list.Add(inventoryRecord);
            }

            return list;
        }

        public List<VehicleSearchResult> GetVehicleSearchResultList(string type)
        {
            var vehicleSearchResultList = new List<VehicleSearchResult>();

            var list = vehicleList.Where(v => v.Sold == false && v.Type == type);

            foreach (var item in list)
            {
                var searchResult = ConvertToVehicleSearchResult(item);
                vehicleSearchResultList.Add(searchResult);
            }

            return vehicleSearchResultList;
        }

        public List<int> GetYearList(string type)  // This is an exact copy of method in Prod
        {
            if (!string.IsNullOrEmpty(type)) //Need either New or Old
            {
                var vehicleList = GetVehicleSearchResultList(type);
                var unsortedList = vehicleList.Select(v => v.Year).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(y => y).ToList();

                return sortedList;

            }
            else
            { // Need all type Vehicles , both New and Old
                var vehicleList = GetVehicleDetailsList();
                var unsortedList = vehicleList.Select(v => v.Year).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(y => y).ToList();

                return sortedList;
            }
        }

        public IEnumerable<VehicleSearchResult> Search(VehicleSearchParameters parameters)
        {

            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var makes = makeRepo.GetMakeDetails();

            var modelRepo = ModelRepositoryFactory.GetModelRepository();
            var models = modelRepo.GetAllModels();

            var list = new List<VehicleSearchResult>();

            var query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };

            if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue && parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }


            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue && parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }



            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue && parameters.MaxPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && v.SalePrice <= parameters.MaxPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }




            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue && parameters.MinPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && v.SalePrice >= parameters.MinPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }



            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year <= parameters.MaxYear && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MinYear.HasValue && parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue && parameters.MaxPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && v.SalePrice <= parameters.MaxPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }


            if (parameters.MaxYear.HasValue && parameters.MinYear.HasValue && parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && parameters.MinYear.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }


            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year <= parameters.MaxYear && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }



            if ( parameters.MaxYear.HasValue && parameters.MinYear.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }


            if (parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (parameters.MaxYear.HasValue && parameters.MinYear.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Year >= parameters.MinYear && v.Year <= parameters.MaxYear)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (parameters.MaxPrice.HasValue && parameters.MinPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.SalePrice >= parameters.MinPrice && v.SalePrice <= parameters.MaxPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && !string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxYear.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year <= parameters.MaxYear)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MinYear.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.Year >= parameters.MinYear)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MaxPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.SalePrice <= parameters.MaxPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type) && parameters.MinPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type && v.SalePrice >= parameters.MinPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }



            else if (!string.IsNullOrEmpty(parameters.MakeModelYear))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && (mk.MakeName.Contains(parameters.MakeModelYear) || mo.ModelName.Contains(parameters.MakeModelYear) || v.Year.ToString().Contains(parameters.MakeModelYear)))
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (!string.IsNullOrEmpty(parameters.Type))
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Type == parameters.Type)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (parameters.MaxYear.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Year <= parameters.MaxYear)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (parameters.MinYear.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.Year >= parameters.MinYear)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (parameters.MaxPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.SalePrice <= parameters.MaxPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }

            else if (parameters.MinPrice.HasValue)
            {
                query = from v in vehicleList
                        join mk in makes on v.MakeId equals mk.MakeId
                        join mo in models on v.ModelId equals mo.ModelId
                        where (v.Sold == false && v.SalePrice >= parameters.MinPrice)
                        select new
                        {
                            VehicleId = v.VehicleId,
                            VIN = v.VIN,
                            Interior = v.Interior,
                            Transmission = v.Transmission,
                            Mileage = v.Mileage,
                            MSRP = v.MSRP,
                            SalePrice = v.SalePrice,
                            Color = v.Color,
                            BodyStyle = v.BodyStyle,
                            Make = mk.MakeName,
                            Model = mo.ModelName,
                            Year = v.Year,
                            ImageFileName = v.ImageFileName,
                            v.Type
                        };
            }


            foreach (var v in query)
            {
                var vehicle = new VehicleSearchResult();
                vehicle.VehicleId = v.VehicleId;
                vehicle.VIN = v.VIN;
                vehicle.Interior = v.Interior;
                vehicle.Transmission = v.Transmission;
                vehicle.Mileage = v.Mileage;
                vehicle.MSRP = v.MSRP;
                vehicle.SalePrice = v.SalePrice;
                vehicle.Color = v.Color;
                vehicle.BodyStyle = v.BodyStyle;
                vehicle.Make = v.Make;
                vehicle.Model = v.Model;
                vehicle.Year = v.Year;
                vehicle.ImageFileName = v.ImageFileName;

                list.Add(vehicle);
            };

            return list;

        }

        public void UpdateVehicle(EditVehicleViewModel vehicle)
        {

            var makeRepo = MakeRepositoryFactory.GetMakeRepository();
            var modelRepo = ModelRepositoryFactory.GetModelRepository();

            var index = vehicleList.FindIndex(v => v.VehicleId == vehicle.VehicleId);

            vehicleList[index].VIN = vehicle.VIN;
            vehicleList[index].Interior = vehicle.Interior;
            vehicleList[index].Transmission = vehicle.Transmission;
            vehicleList[index].Mileage = vehicle.Mileage;
            vehicleList[index].MSRP = vehicle.MSRP ?? default(decimal);
            vehicleList[index].SalePrice = vehicle.SalePrice ?? default(decimal);
            vehicleList[index].Color = vehicle.Color;
            vehicleList[index].BodyStyle = vehicle.BodyStyle;
            vehicleList[index].Description = vehicle.Description;
            vehicleList[index].MakeId = makeRepo.GetMakeIdByName(vehicle.Make);
            vehicleList[index].ModelId = modelRepo.GetModelIdByName(vehicle.Model);
            vehicleList[index].Year = vehicle.Year ?? default(int);
            vehicleList[index].Type = vehicle.Type;
            vehicleList[index].ImageFileName = vehicle.ImageFileName;
            vehicleList[index].FeaturedVehicle = vehicle.FeaturedVehicle;
        }

        public void VehicleMarkPurchased(int vehicleId)
        {
            var index = vehicleList.FindIndex(v => v.VehicleId == vehicleId);

            vehicleList[index].Sold = true;
        }
    }
}
