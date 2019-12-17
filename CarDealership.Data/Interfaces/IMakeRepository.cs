using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IMakeRepository
    {
        void AddMake(Make make);
        string GetMakeById(int makeId);
        List<string> GetMakeNames();
        List<MakeViewModel> GetMakeDetails();
        int GetMakeIdByName(string makeName);

    }
}
