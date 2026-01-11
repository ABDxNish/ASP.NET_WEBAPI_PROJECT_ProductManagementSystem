using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDTO
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name should not exceeds more than 20 characters")]
       
        public string Name { get; set; }
    }
}
