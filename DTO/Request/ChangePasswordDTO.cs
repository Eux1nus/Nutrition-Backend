using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO.Request
{
    public class ChangePasswordDTO
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
