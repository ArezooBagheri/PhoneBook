using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Persons.Queries;
using PhoneBook.Core.Domain.Repositories;
using PhoneBook.Framework.Queries;

namespace PhoneBook.Core.ApplicationServices.Persons.Queries
{
    public class AllPersonQueryHandler : IQueryHandler<AllPersonQuery, List<Person>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;

        public AllPersonQueryHandler(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public List<Person> Handle(AllPersonQuery query)
        {
            return _personQueryRepository.GetAll();
        }
    }
}
