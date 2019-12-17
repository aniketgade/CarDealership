using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class SpecialRepositoryQA : ISpecialRepository
    {

        static List<Special> specialList = new List<Special>()
        {
            new Special()
            {
                SpecialId = 1,
                Title = "College Graduate Program",
                Description = "Through the Auto Finance program, we are pleased to offer auto financing for college graduates to purchase a used vehicle."
            },
            new Special()
            {
                SpecialId = 2,
                Title = "First Time Car Buyer",
                Description = "Are you ready to purchase your first vehicle and preparing to apply for auto financing? We are here to help!"
            },
            new Special()
            {
                SpecialId = 3,
                Title = "Low Credit Special",
                Description = "Even if you don’t have perfect credit, or this is your first time financing a vehicle, we may have financing options to fit your needs."
            }
        };

        public void AddSpecial(Special special)
        {
            var maxId = specialList.Max(s => s.SpecialId);

            specialList.Add(new Special() { 
                SpecialId = maxId + 1,
                Title = special.Title,
                Description = special.Description
            });;
        }

        public void DeleteSpecial(int id)
        {
            specialList.Remove(specialList.Find(s => s.SpecialId == id));
        }

        public List<Special> GetSpecials()
        {
            return specialList;
        }
    }
}
