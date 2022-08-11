using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Repositories;

namespace PhoneBook.Infrastructures.Data.SqlServer.Persons.Repositories
{
    public class PersonQueryRepository : IPersonQueryRepository
    {
        private readonly PhoneBookDbContext _phoneBookDbContext;

        public PersonQueryRepository(PhoneBookDbContext phoneBookDbContext)
        {
            _phoneBookDbContext = phoneBookDbContext;
        }

        public List<Person> GetAll()
        {
            return _phoneBookDbContext.Persons.AsNoTracking().Include(p => p.Phone).ToList();
        }
    }
}
