using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Tables
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
    }
}
