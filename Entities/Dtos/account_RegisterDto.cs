using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record account_RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "RoleId is required")]
        public string? RoleId{get; init;}
    }
}