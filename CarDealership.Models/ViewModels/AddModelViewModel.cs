using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.ViewModels
{
    public class AddModelViewModel
    {
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }
        [Display(Name = "Make Name")]
        public string MakeName { get; set; }
        public int MakeId { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserEmail { get; set; }
    }
}
