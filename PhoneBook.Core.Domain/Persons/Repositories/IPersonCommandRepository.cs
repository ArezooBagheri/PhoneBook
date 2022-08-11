using PhoneBook.Core.Domain.Persons.Entities;

namespace PhoneBook.Core.Domain.Persons.Repositories
{
    public interface IPersonCommandRepository
    {
        void Add(Person person);
    }
}
