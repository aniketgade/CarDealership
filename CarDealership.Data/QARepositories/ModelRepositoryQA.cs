using CarDealership.Data.Factories;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class ModelRepositoryQA : IModelRepository
    {

        static List<Model> modelList = new List<Model>() {
        
            new Model()
            {
                ModelId = 1,
                ModelName = "X1",
                MakeId = 1,
                DateAdded = new DateTime(2002,10,08),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 2,
                ModelName = "5 Series",
                MakeId = 1,
                DateAdded = new DateTime(2012,11,18),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 3,
                ModelName = "Focus",
                MakeId = 2,
                DateAdded = new DateTime(2018,08,03),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 4,
                ModelName = "Mustang",
                MakeId = 2,
                DateAdded = new DateTime(2016,12,09),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 5,
                ModelName = "Charger",
                MakeId = 3,
                DateAdded = new DateTime(2004,07,08),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 6,
                ModelName = "Challenger",
                MakeId = 3,
                DateAdded = new DateTime(2008,08,09),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 7,
                ModelName = "Benz C-Class",
                MakeId = 4,
                DateAdded = new DateTime(2007,10,08),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 8,
                ModelName = "Benz A-Class",
                MakeId = 4,
                DateAdded = new DateTime(2013,10,08),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 9,
                ModelName = "Forester",
                MakeId = 5,
                DateAdded = new DateTime(2017,10,08),
                UserId = "11111"
            },
            new Model()
            {
                ModelId = 10,
                ModelName = "Outback",
                MakeId = 5,
                DateAdded = new DateTime(2015,10,08),
                UserId = "11111"
            }
        };

        public void AddModel(Model model)
        {
            int maxModelId = modelList.Max(m => m.ModelId);

            modelList.Add(new Model()
            {
                ModelId = maxModelId + 1,
                ModelName = model.ModelName,
                DateAdded = model.DateAdded,
                MakeId = model.MakeId,
                UserId = model.UserId
            });
        }

        public List<AddModelViewModel> GetAllModelDetails()
        {
            var list = new List<AddModelViewModel>();

            var makeRepo = MakeRepositoryFactory.GetMakeRepository();


            foreach (var model in modelList)
            {
                var addModelViewModel = new AddModelViewModel();
                addModelViewModel.ModelName = model.ModelName;
                addModelViewModel.MakeName = makeRepo.GetMakeById(model.MakeId);
                addModelViewModel.MakeId = model.MakeId;
                addModelViewModel.UserEmail = "abc";
                addModelViewModel.DateAdded = model.DateAdded;

                list.Add(addModelViewModel);
            }

            return list;

        }

        public List<Model> GetAllModels()
        {
            return modelList;
        }

        public string GetModelById(int modelId)
        {
            return modelList.First(m => m.ModelId == modelId).ModelName;
        }

        public int GetModelIdByName(string model)
        {
            return modelList.First(m => m.ModelName == model).ModelId;
        }

        public List<string> GetModelNames()
        {
            return modelList.Select(m => m.ModelName).ToList();
        }

        public List<string> GetModelsByMake(string makeName)
        {
            var makeRepo = MakeRepositoryFactory.GetMakeRepository();

            var makeId = makeRepo.GetMakeIdByName(makeName);

            return modelList.Where(m => m.MakeId == makeId).Select(mo => mo.ModelName).ToList();
        }
    }
}
