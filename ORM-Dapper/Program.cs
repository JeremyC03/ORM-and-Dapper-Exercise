using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            Console.WriteLine("Department Section");
            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
            }

            var productRepo = new DapperProductRepository(conn);

            var products = productRepo.GetAllProducts();

            Console.WriteLine("Product Section");
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryId);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
            }
        }
    }
}
