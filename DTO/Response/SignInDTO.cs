using Domain;
using System;

namespace DTO.Response
{
    public class SignInDTO
    {
        public UserDTO User { get; set; }
        public SecurityTokenViewModel Token { get; set; }
        public PersonDTO Person { get; set; }
        public SignInDTO(User user, SecurityTokenViewModel token)
        {
            User = new UserDTO(user);
            Token = token;
        }
    }

    public class SecurityTokenViewModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public SecurityTokenViewModel(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
    }
}
