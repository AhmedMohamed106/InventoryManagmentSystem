using InventoryManagmentSystem.DAL.DataContext;
using InventoryManagmentSystem.DAL.Repository;
using InventoryManagmentSystem.DAL.Models;

using InventoryManagmentSystem.DAL.Repository.IRepository;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

             ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            IUnitOfWork unitOfWork = new UnitOfWork(applicationDbContext);


            Console.WriteLine("\n\n Welcome in Inventory Managment system \n");

            while (true)
            {

                Console.WriteLine("1. Add New Category");
                Console.WriteLine("2. Add New Product ");
                Console.WriteLine("3. Update Stock Quantity ");
                Console.WriteLine("4. List Products By Category ");
                Console.WriteLine("5. Calculate Total Inventory Value ");
                Console.WriteLine("6. Exit");


                Console.Write("\n Choose Your Option ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewCategory(unitOfWork); 
                        break;

                    case "2":
                        AddNewProduct(unitOfWork);
                        break;

                    case "3":
                        UpdateStockQuantity(unitOfWork);
                        break;
                    case "4":
                        ListProductsByCategory(unitOfWork);
                        break;
                    case "5":
                        CalculateTotalValue(unitOfWork);
                        break;
                        case "6":
                        return;

                    default:
                        Console.WriteLine("\n Invalid choice : Please Try Again \n ");
                        break;
                }


            }
        }



        static void AddNewCategory(IUnitOfWork unitOfWork)
        {
            Console.Write("\n Enter Category Name  ");


            string name = Console.ReadLine();


            // check if the category is added previousely
            if (unitOfWork.categoryRepository.Any(c => c.Name.ToLower() == name.ToLower()))
            {

                Console.WriteLine("\n this category is Already exists , Please try anothet");

                return;
            }

            unitOfWork.categoryRepository.Add(new Category { Name = name });

            unitOfWork.Save();
 
             Console.WriteLine("\n Category Created Successfully");
        }


        static void AddNewProduct(IUnitOfWork unitOfWork)
        {
            Console.Write("\n Enter Product Name  ");

            string productName = Console.ReadLine();

            Console.WriteLine("\n Your Avaliable Categories ");

            foreach(var category in unitOfWork.categoryRepository.GetAll().ToList())
            {

                Console.WriteLine($" {category.Id} : {category.Name}");
            }


            Console.Write("\n Enter Category ID : ");

            if (!int.TryParse(Console.ReadLine(), out int categoryId) || !unitOfWork.categoryRepository.Any(c => c.Id == categoryId))
            {
                Console.WriteLine("\n Invalid Category Id , please try another ");

                return;
            }


            Console.Write("\n Enter product price  ");


            if(! decimal.TryParse( Console.ReadLine() , out decimal price ) || price < 0)
            {
                Console.WriteLine("\n Invalid Price , try another ");
                return;
            }

            Console.Write("\n Enter stock Qunatity  ");

            if(! int.TryParse(Console.ReadLine() , out int stock) || stock < 0)
            {
                Console.WriteLine("\n Invalid quantity , try another ");
                return;

            }

            unitOfWork.productRepository.Add(new Product
            {
                Name = productName,
                price = price,
                StockQuantity = stock,
                Category_ID = categoryId
            });

            unitOfWork.Save();

            Console.WriteLine("\n Product Added Successfully");


        }


        static void UpdateStockQuantity(IUnitOfWork unitOfWork)
        {
            Console.Write("\n Enter Product Name  ");

            string productName = Console.ReadLine();

            var product = unitOfWork.productRepository.Get(p=> p.Name.ToLower() == productName.ToLower() , tracked:true);

            if (product == null)
            {
                Console.WriteLine("\n product Not Found try another");
                return;
            }

            Console.Write("\n Enter  new stock Quantity ");

            if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
            {
                Console.WriteLine("\n Invalid quantity , try another ");
                return;

            }


            product.StockQuantity = stock;
            unitOfWork.Save();

            Console.WriteLine("\n stock Updated Successfully ");
        }



        static void ListProductsByCategory(IUnitOfWork unitOfWork)
        {
            Console.WriteLine("\n Avaliable Categories ");

            foreach(var category in unitOfWork.categoryRepository.GetAll(tracked:true).ToList())
            {
                Console.WriteLine($" {category.Id} : {category.Name}");
            }

            Console.Write("\n Enter Category Id to filter with : ");


            if (!int.TryParse(Console.ReadLine(), out int categoryId) || !unitOfWork.categoryRepository.Any(c => c.Id == categoryId))
            {
                Console.WriteLine("\n Invalid Category Id , please try another ");

                return;
            }

            var filteredProducts = unitOfWork.productRepository.GetAll(p => p.Category_ID == categoryId, "Category", tracked: true).ToList();

            if(!filteredProducts.Any())
            {
                Console.WriteLine("\n there is no products in this  category \n");
                return;
            }


            Console.WriteLine("\n Products");

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"\n Name: {product.Name} , price {product.price} , Stock {product.StockQuantity}");
            }
        }


        static void CalculateTotalValue(IUnitOfWork unitOfWork)
        {
            decimal TotalValue = unitOfWork.productRepository.Sum(p => p.price  *  p.StockQuantity);

            Console.WriteLine($"\n the Total InventoryValue : {TotalValue} \n ");
        }
    }
}