using System.ComponentModel.DataAnnotations;

namespace DTO.Request
{
    public class CreateNewPasswordDTO
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
