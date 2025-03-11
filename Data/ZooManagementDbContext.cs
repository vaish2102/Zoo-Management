using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext (DbContextOptions<ZooManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Animal> Animal { get; set; } = default!;
        public DbSet<Models.Enclosure> Enclosure { get; set; } = default!;
    }
