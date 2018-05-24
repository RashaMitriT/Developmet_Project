using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentCase.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Display(Name = "Country Name")]
        public string name { get; set; }

    }
}

