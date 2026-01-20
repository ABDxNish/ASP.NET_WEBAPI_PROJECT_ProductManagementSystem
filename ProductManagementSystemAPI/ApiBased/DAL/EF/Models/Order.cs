using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cus")]
        public int CId { get; set; }

        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalBill { get; set; }

        public virtual Customer Cus { get; set; }
        public virtual List<OrderItem> Items { get; set; }
        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
