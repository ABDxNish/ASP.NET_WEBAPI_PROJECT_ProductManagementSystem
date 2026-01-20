using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
     public class CusProductOrderDTO
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalBill { get; set; }
        public List<ProductDTO> Items { get; set; }
    }
}
