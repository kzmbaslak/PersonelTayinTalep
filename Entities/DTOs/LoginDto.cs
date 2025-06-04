using Core.Entities;

namespace Entities.DTOs
{
    public class LoginDto : IDto
    {
        public string RegistryName { get; set; }
        public string Password { get; set; }
    }
}
