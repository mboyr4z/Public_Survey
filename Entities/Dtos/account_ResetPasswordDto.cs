using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record account_ResetPasswordDto
    {
        public string? UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must be match.")]
        public string? ConfirmPassword { get; init; }
    }
}