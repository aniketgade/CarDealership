using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IModelRepository
    {
        void AddModel(Model model);
        string GetModelById(int modelId);
        List<string> GetModelNames();
        List<string> GetModelsByMake(string makeName);
        List<AddModelViewModel> GetAllModelDetails();
        int GetModelIdByName(string model);
        List<Model> GetAllModels();
    }
}
