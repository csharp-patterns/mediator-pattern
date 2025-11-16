using MediatorPattern.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MediatorPattern.Repo
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            
        }

        public DbSet<CustomerDb> Customers => Set<CustomerDb>();
    }
}
