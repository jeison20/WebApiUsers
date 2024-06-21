using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUsers.Domain.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }      

        [Required]
        [RegularExpression(@"[a-zA-Z ]{2,100}", ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
