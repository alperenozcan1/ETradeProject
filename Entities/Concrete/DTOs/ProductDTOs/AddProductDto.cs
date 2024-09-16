using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeService.Base.Concrete.DTOs.ProductDTOs
{
    public class AddProductDto
    {
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
