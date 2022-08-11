using PhoneBook.Core.Domain.Persons.Commands;
using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Persons.Repositories;
using PhoneBook.Core.Domain.Phones.Entities;
using PhoneBook.Core.Resources.Resources;
using PhoneBook.Framework.Commands;
using PhoneBook.Framework.Resources;

namespace PhoneBook.Core.ApplicationServices.Persons.Commands
{
    public class AddPersonCommandHandler : CommandHandler<AddPersonCommand>
    {
        private readonly IPersonCommandRepository _personCommandRepository;
        public AddPersonCommandHandler(IResourceManager resourceManager,
            IPersonCommandRepository personCommandRepository) : base(resourceManager)
        {
            _personCommandRepository = personCommandRepository;
        }

        public override CommandResult Handle(AddPersonCommand command)
        {
            if (IsValid(command))
            {
                Person person = new Person
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Email  = command.Email,
                    Address = command.Address,
                    Phone = new Phone 
                    {
                        PhoneNumber = command.PhoneNumber
                    }
                };
                _personCommandRepository.Add(person);
                return Ok();
            }
            return Failure();
        }
        private bool IsValid(AddPersonCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.FirstName))
            {
                AddError(SharedResource.Required, SharedResource.FirstName);
                isValid = false;
            }
            return isValid;
        }
    }
    }

