using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
       
        [StringLength(30)]
        [Column(TypeName ="VARCHAR")]
        public string Name { get; set; }
       

        public decimal Price { get; set; }
       
        public int Quantity { get; set; }
        [ForeignKey("cat")]
        public int CId {  get; set; }
        public virtual Category cat { get; set; }


    }
}
