using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculos2.Customer.Api.Data
{
    public class ProjAndreVeiculos2CustomerApiContext : DbContext
    {
        public ProjAndreVeiculos2CustomerApiContext (DbContextOptions<ProjAndreVeiculos2CustomerApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Customer> Customer { get; set; } = default!;

        public DbSet<Models.Address> Address { get; set; } = default!;
    }
}
