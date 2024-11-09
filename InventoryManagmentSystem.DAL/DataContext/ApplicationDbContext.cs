using Microsoft.EntityFrameworkCore;
using InventoryManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.DAL.DataContext
{
    public class ApplicationDbContext:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=InventorySystemDB;Integrated Security=True ;TrustServerCertificate=True");
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set;}
        

    }
}
