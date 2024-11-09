using InventoryManagmentSystem.DAL.Repository;
using InventoryManagmentSystem.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagmentSystem.DAL.Repository.IRepository;

namespace InventoryManagmentSystem.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;

        public ICategoryRepository categoryRepository { get; private set; }



        public IProductRepository productRepository { get; private set; }




       

        public UnitOfWork(ApplicationDbContext _db)
        {
            this._db = _db;

           
            categoryRepository = new CategoryRepository(_db);
            productRepository = new ProductRepository(_db);
          



        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
