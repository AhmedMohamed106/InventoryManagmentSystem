using InventoryManagmentSystem.DAL.Repository.IRepository;
using InventoryManagmentSystem.DAL.Models;
using InventoryManagmentSystem.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;

namespace InventoryManagmentSystem.DAL.Repository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) :base(db)
        {
            _db= db;
        }

        public decimal Sum(Func<Product, decimal> selector)
        {
            return _db.products.Sum(selector);
        }

        public void Update(Product obj)
        {

           _db.products.Update(obj);

        }
    }
}
