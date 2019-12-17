using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<VehicleDetails> GetVehicleDetailsList();

        List<VehicleSearchResult> GetVehicleSearchResultList(string type);

        List<FeaturedVehicleViewModel> GetFeaturedVehicleList();

        List<VehicleInventory> GetVehicleInventoryList(string type);

        void AddVehicle(AddVehicleObject vehicle);

        void AddVehicleFileName(string fileName, int vehicleId);

        VehicleDetails GetVehicleById(int? vehicleId);

        void UpdateVehicle(EditVehicleViewModel vehicle);

        void DeleteVehicle(int vehicleId);

        IEnumerable<VehicleSearchResult> Search(VehicleSearchParameters parameters);

        List<int> GetYearList(string type);

        List<decimal> GetSalePriceList(string type);
        void VehicleMarkPurchased(int vehicleId);

    }
}
