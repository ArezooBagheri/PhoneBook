using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Domain.Persons.Commands;
using PhoneBook.Core.Domain.Persons.Entities;
using PhoneBook.Core.Domain.Persons.Queries;
using PhoneBook.Endpoints.WebUI.Models.Persons;
using PhoneBook.Framework.Commands;
using PhoneBook.Framework.Queries;
using PhoneBook.Framework.Resources;
using PhoneBook.Framework.Web;

namespace PhoneBook.Endpoints.WebUI.Controllers
{
    public class PersonsController : BaseController
    {
        public PersonsController(CommandDispatcher commandDispatcher,
            QueryDispatcher queryDispatcher, IResourceManager resourceManager)
            : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }

        public IActionResult Index()
        {
            var allPersons = _queryDispatcher.Dispatch<List<Person>>(new AllPersonQuery());
            return View(allPersons);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new AddPersonCommand
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                });

                if (result.IsSuccess)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", result.Message);
                foreach (string item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(model);
        }
    }
}
