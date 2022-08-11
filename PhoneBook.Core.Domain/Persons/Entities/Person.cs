using PhoneBook.Core.Domain.Phones.Entities;
using PhoneBook.Framework.Domain;

namespace PhoneBook.Core.Domain.Persons.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Phone Phone { get; set; }
        public int PhoneId { get; set; }
    }
}
