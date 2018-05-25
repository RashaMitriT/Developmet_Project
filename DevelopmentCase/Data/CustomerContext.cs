using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevelopmentCase.ViewModels;

namespace DevelopmentCase.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<DevelopmentCase.Models.Customer> Customer { get; set; }

        public DbSet<DevelopmentCase.ViewModels.CustomerModelView> CustomerModelView { get; set; }
    }
}
