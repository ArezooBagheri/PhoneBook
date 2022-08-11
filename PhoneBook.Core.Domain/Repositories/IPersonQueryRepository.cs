using PhoneBook.Core.Domain.Persons.Entities;

namespace PhoneBook.Core.Domain.Repositories
{
    public interface IPersonQueryRepository
    {
        List<Person> GetAll();
    }
}
