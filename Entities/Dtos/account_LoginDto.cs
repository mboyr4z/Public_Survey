using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record account_LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
    }
}