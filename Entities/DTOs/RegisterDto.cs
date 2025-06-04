using Core.Entities;

namespace Entities.DTOs
{
    public class RegisterDto : IDto
    {
        public string RegistryName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
