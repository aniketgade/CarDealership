using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;


namespace CarDealership.UI.Controllers
{
    public class VehicleAPIController : ApiController
    {
        [Route("api/vehicle/make/{makeName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(string makeName)
        {
            if (makeName == "Select Make")
            {
                return Ok();
            }

            var repo = ModelRepositoryFactory.GetModelRepository();

            var ModelList = repo.GetModelsByMake(makeName);

            return Ok(ModelList);
        }


        [Route("api/vehicle/makes")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetMakes()
        {

            var repo = MakeRepositoryFactory.GetMakeRepository();

            var MakeList = repo.GetMakeNames();

            return Ok(MakeList);
        }

        [Route("api/vehicle/makeDetails")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetMakeDetails()
        {

            var repo = MakeRepositoryFactory.GetMakeRepository();

            var MakeList = repo.GetMakeDetails();

            return Ok(MakeList);
        }


        [Route("api/vehicle/modelDetails")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelDetails()
        {

            var repo = ModelRepositoryFactory.GetModelRepository();

            var ModelList = repo.GetAllModelDetails();

            return Ok(ModelList);
        }


        [Route("api/vehicle/specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSpecials()
        {

            var repo = SpecialRepositoryFactory.GetSpecialRepository();

            var SpecialList = repo.GetSpecials();

            return Ok(SpecialList);
        }


        [Route("api/vehicle/deletespecial/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteSpecial(int id)
        {

            var repo = SpecialRepositoryFactory.GetSpecialRepository();

            repo.DeleteSpecial(id);

            return Ok();
        }


        [Route("api/vehicle/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string makeModelYear, int? minYear, int? maxYear, decimal? minPrice, decimal? maxPrice, string type)
        {

            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    MakeModelYear = makeModelYear,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    Type = type
                };

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/vehicle/inventorysearch")]
        [AcceptVerbs("GET")]
        public IHttpActionResult InventorySearch(string userId, DateTime? fromDate, DateTime? toDate)
        {

            var repo = SaleLogRepositoryFactory.GetSaleLogRepository();

            try
            {
                var parameters = new InventorySearchParameters()
                {
                    UserId = userId,
                    FromDate = fromDate,
                    ToDate = toDate
                };

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("api/vehicle/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVehicleDetailsById(int id)
        {

            var repo = VehicleRepositoryFactory.GetVehicleRepository();

            try
            {
                var vehicle = repo.GetVehicleById(id);

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/vehicle/delete/{vehicleId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteVehicle(int vehicleId)
        {

            var repo = VehicleRepositoryFactory.GetVehicleRepository();
            var vehicle = repo.GetVehicleById(vehicleId);

            // Remove the image
            var savepath = HostingEnvironment.MapPath("~/Images/Vehicles");

            var existingFilePath = Path.Combine(savepath, vehicle.ImageFileName);

            // Delete the existing file 
            if (File.Exists(existingFilePath))
            {
                File.Delete(existingFilePath);
            }


            // Now remove Database record
            repo.DeleteVehicle(vehicleId);

            return Ok();
        }

        
    }
}
