using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentCase.Models;

namespace DevelopmentCase.ViewModels
{
    public class CustomerModelView
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string fullname { get; set; }
        [Required(ErrorMessage = "Select City")]
        [Display(Name = "Country Name")]
        public string country{ get; set; }
    }
}
