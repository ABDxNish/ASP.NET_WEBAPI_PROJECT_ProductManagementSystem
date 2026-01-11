using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name should not exceeds more than 30 characters")]

        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Category Id must required")]
        public int CId {  get; set; }
    }
}
