using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagmentSystem.DAL.Models

{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

  
        public decimal price { get; set; }

        public int StockQuantity { get; set; }

        [ForeignKey("Category")]
        public int Category_ID { get; set; }
        public virtual Category Category { get; set; }



    }
}
