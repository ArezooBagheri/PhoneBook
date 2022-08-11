using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Persons.Repositories;

namespace PhoneBook.Infrastructures.Data.SqlServer.Persons.Repositories
{
    public class PersonCommandRepository : IPersonCommandRepository
    {
        private readonly PhoneBookDbContext _phoneBookDbContext;

        public PersonCommandRepository(PhoneBookDbContext phoneBookDbContext)
        {
            _phoneBookDbContext = phoneBookDbContext;
        }

        public void Add(Person person)
        {
            _phoneBookDbContext.Persons.Add(person);
            _phoneBookDbContext.SaveChanges();
        }
    }
}
