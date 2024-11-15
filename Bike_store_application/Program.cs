using Bike_store_application.Data;
using Microsoft.EntityFrameworkCore;

namespace Bike_store_application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BikeStoreContext())
            {
                //retrive all category
                var categories = context.Categories.ToList();
                Console.WriteLine("Categories:");
                categories.ForEach(category => Console.WriteLine(category.CategoryName));

                //retrive first product
                var firstProduct = context.Products.FirstOrDefault();
                Console.WriteLine("\nFirst Product:");
                Console.WriteLine(firstProduct?.ProductName);

                //retrive product by id 
                int productId =1 ;
                var productById = context.Products.FirstOrDefault(p => p.ProductId == productId);
                Console.WriteLine("\nProduct by ID:");
                Console.WriteLine(productById?.ProductName);

                //retrive products with acertain model year
                int modelYear = 2024; 
                var productsByYear = context.Products
                                            .Where(p => p.ModelYear == modelYear)
                                            .ToList();
                Console.WriteLine("\nProducts by Model Year:");
                productsByYear.ForEach(product => Console.WriteLine(product.ProductName));

                // retrieve customer by id 
                int customerId = 1;     
                var customerById = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                Console.WriteLine("\nCustomer by ID:");
                if (customerById != null)
                {
                    Console.WriteLine($"{customerById.FirstName} {customerById.LastName}");
                }    
                else
                {
                    Console.WriteLine("Customer not found.");
                }
                // retrive list of product names
                var productBrandList = context.Products.Join
                                   (context.Brands,product => product.BrandId,
                                   brand => brand.BrandId,
                                   (product, brand) => new
                                   {
                                    ProductName = product.ProductName,
                                    BrandName = brand.BrandName
                                    }).ToList();
                Console.WriteLine("\nProduct and Brand List:");
                productBrandList.ForEach(pb => Console.WriteLine($"Product: {pb.ProductName}, Brand: {pb.BrandName}"));

                //calculate number of products in specifec category
                int categoryId = 1;  
                var productCount = context.Products.Count(p => p.CategoryId == categoryId);
                Console.WriteLine($"\nNumber of products in category {categoryId}: {productCount}");

                // calculate total prices of all products
                var totalPrice = context.Products
                                        .Where(p => p.CategoryId == categoryId)
                                        .Sum(p => p.ListPrice);
                Console.WriteLine($"\nTotal price of products in category {categoryId}: {totalPrice}");

                //calculate average products prices
                var averagePrice = context.Products.Average(p => p.ListPrice);
                Console.WriteLine($"\nAverage Price of Products: {averagePrice}");

                //retrieve orders complete
                var completedOrders = context.Orders.Where(o => o.Status == "Completed").ToList();
                Console.WriteLine("\nCompleted Orders:");
                completedOrders.ForEach(order => Console.WriteLine($"Order ID: {order.OrderId}, Status: {order.Status}"));
            }
        }
    }
}