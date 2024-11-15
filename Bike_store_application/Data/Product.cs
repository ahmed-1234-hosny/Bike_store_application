using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_store_application.Data
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelYear { get; set; }
        public decimal ListPrice { get; set; }
    }
}
