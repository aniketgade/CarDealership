using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetSpecials();
        void AddSpecial(Special special);
        void DeleteSpecial(int id);
    }
}
