using Microsoft.EntityFrameworkCore;
using Project0.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project0.Data
{
    public partial class project0Context : DbContext
    {
        public project0Context()
        {
        }

        public project0Context(DbContextOptions<project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Defaultstore> Defaultstore { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Orderlist> Orderlist { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =(localdb)\\127.0.0.1;user id=root;Database=My;Trusted_Connection=True;");
            }
        }

    }
}
