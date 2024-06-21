using System.ComponentModel.DataAnnotations;

namespace WebApiUsers.Domain.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(4)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Document number are not valid.")]
        [MaxLength(20)]
        public string Document { get; set; }

        [Required]
        [MaxLength(80)]
        [RegularExpression(@"[a-zA-Z ]{2,80}", ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
}
