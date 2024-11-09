using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {

       
        ICategoryRepository categoryRepository { get; }
        IProductRepository productRepository { get; }
       



        void Save();
    }
}
