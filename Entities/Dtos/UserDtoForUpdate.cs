namespace Entities.Dtos
{
    public record UserDtoForUpdate : UserDto
    {
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>(); // bunu mecburen başlatmak gerek
        
    }
}