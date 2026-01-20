using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustOrderDTO
    {
        public int CustomerId { get; set; }
        public List<int> PId { get; set; }
    }
}
