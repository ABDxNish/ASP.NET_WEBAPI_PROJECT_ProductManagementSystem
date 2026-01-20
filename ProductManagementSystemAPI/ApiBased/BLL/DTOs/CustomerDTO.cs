using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name should not exceeds more than 30 characters")]
        [RegularExpression(
        @"^(?=.*\d)[A-Za-z0-9]+$", ErrorMessage = "Username must contain at least one number and only letters and numbers are allowed.")]

        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[@#$!%*?&])[A-Za-z\d@#$!%*?&]+$", ErrorMessage = "Password must contain at least one number and one special character.")]
        public string Password { get; set; }
    }
}
