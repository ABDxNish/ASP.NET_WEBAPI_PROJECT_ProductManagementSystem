using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryProductDTO:CategoryDTO
    {
        public List<ProductDTO> products {  get; set; }
        public CategoryProductDTO() { 
        products = new List<ProductDTO>();
        }
    }
}
