using Domain;
using Domain.Enums;

namespace DTO.Response
{ 
    public class UserDTO
    {
        public long Id { get; set; }
        public PersonDTO Person { get; set; }
        public UserRole UserRole { get; set; }
        public UserDTO() { }
        public UserDTO(User user)
        {
            if (user == null)
                return;
            Id = user.Id;
            Person = new PersonDTO(user.Person);
            UserRole = user.UserRole;
        }
    }
}
