using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
    }
}
