using CarDealership.Data.Factories;
using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class MakeRepositoryQA : IMakeRepository
    {
        

        static List<Make> makeList = new List<Make>() { 
        
            new Make()
            {
                MakeId = 1,
                MakeName = "BMW",
                DateAdded = new DateTime(2001,10,04),
                UserId = "11111"
            },
            new Make()
            {
                MakeId = 2,
                MakeName = "Ford",
                DateAdded = new DateTime(2011,11,08),
                UserId = "11111"
            },
            new Make()
            {
                MakeId = 3,
                MakeName = "Dodge",
                DateAdded = new DateTime(2001,06,08),
                UserId = "11111"
            },
            new Make()
            {
                MakeId = 4,
                MakeName = "Mercedes",
                DateAdded = new DateTime(2011,06,08),
                UserId = "11111"
            },
            new Make()
            {
                MakeId = 5,
                MakeName = "Subaru",
                DateAdded = new DateTime(2007,06,08),
                UserId = "11111"
            }
        };

        public void AddMake(Make make)
        {
            int maxMakeId = makeList.Max(m => m.MakeId);

            makeList.Add(new Make()
            {
                MakeId = maxMakeId + 1,
                MakeName = make.MakeName,
                DateAdded = make.DateAdded,
                UserId = make.UserId
            });
        }

        public string GetMakeById(int makeId)
        {
            return makeList.First(m => m.MakeId == makeId).MakeName;
        }

        public List<MakeViewModel> GetMakeDetails()
        {
            var list = new List<MakeViewModel>();

            var accountRepo = AccountRepositoryFactory.GetAccountRepository();

            foreach (var make in makeList)
            {
                var makeModel = new MakeViewModel();
                makeModel.MakeId = make.MakeId;
                makeModel.MakeName = make.MakeName;
                makeModel.DateAdded = make.DateAdded;
                makeModel.UserEmail = "abc";

                list.Add(makeModel);
            }

            return list;
        }

        public int GetMakeIdByName(string makeName)
        {
            return makeList.First(m => m.MakeName == makeName).MakeId;
        }

        public List<string> GetMakeNames()
        {
            return makeList.Select(m => m.MakeName).ToList();
        }
    }
}
