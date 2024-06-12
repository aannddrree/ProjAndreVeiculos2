using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProjAndreVeiculos2.Repository.Data
{
    public class ProjAndreVeiculos2RepositoryContext : DbContext
    {
        public ProjAndreVeiculos2RepositoryContext (DbContextOptions<ProjAndreVeiculos2RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Customer> Customer { get; set; } = default!;

        public DbSet<Models.Address> Address { get; set; } = default;
    }
}
