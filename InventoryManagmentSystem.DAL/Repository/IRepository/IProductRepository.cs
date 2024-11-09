using InventoryManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.DAL.Repository.IRepository
{ 
    public interface IProductRepository : IRepository<Product>
   
    {
        public void Update(Product obj);

        public decimal Sum(Func<Product, decimal> selector);


    }
}
