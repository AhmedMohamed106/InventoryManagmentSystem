using InventoryManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.DAL.Repository.IRepository
{
    public interface ICategoryRepository :IRepository<Category>
    {

        public void Update(Category obj);

    }
}
