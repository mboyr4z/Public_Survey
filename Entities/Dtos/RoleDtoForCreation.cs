using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RoleDtoForCreation
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Role Name is required.")]
        public String? Name { get; init; }
    }
}