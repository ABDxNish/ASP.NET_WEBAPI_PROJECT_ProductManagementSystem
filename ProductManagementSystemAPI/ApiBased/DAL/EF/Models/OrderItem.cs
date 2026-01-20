using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Or")]
        public int OId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Order Or { get; set; }
        public virtual Product Product { get; set; }
    }
}
