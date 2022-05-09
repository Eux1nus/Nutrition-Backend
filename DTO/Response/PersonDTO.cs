using Domain;

namespace DTO.Response
{
    public class PersonDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }

        public PersonDTO() { }

        public PersonDTO(Person person)
        {
            if (person == null)
                return;
            Name = person.Name;
            SurName = person.SurName;
            PhoneNumber = person.PhoneNumber;
        }
    }
}
