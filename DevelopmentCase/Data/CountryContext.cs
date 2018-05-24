using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentCase.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext (DbContextOptions<CountryContext> options)
            : base(options)
        {
        }
        public CountryContext()
          : base()
        {
        }

        public DbSet<DevelopmentCase.Models.Country> Country { get; set; }
    }
}
