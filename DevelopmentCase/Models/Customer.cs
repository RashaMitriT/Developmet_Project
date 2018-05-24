using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentCase.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Display(Name = "Full Name")]
        public string fullname { get; set; }
        [Required(ErrorMessage = "Select City")]
        [Display(Name = "Country Name")]
        public int Coutryid { get; set; }
      

    }
}
