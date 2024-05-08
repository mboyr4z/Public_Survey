using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RoleDtoForCreation
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="UserName is required.")]
        public String? RoleName { get; init; }


    }
}