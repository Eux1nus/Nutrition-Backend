using System.ComponentModel.DataAnnotations;

namespace DTO.Request
{
    public class AuthDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
