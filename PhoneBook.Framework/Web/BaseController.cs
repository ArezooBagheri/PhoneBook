using Microsoft.AspNetCore.Mvc;
using PhoneBook.Framework.Commands;
using PhoneBook.Framework.Queries;
using PhoneBook.Framework.Resources;

namespace PhoneBook.Framework.Web
{
    public class BaseController : Controller
    {
        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly IResourceManager _resourceManager;

        public BaseController(CommandDispatcher commandDispatcher
            , QueryDispatcher queryDispatcher
            , IResourceManager resourceManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _resourceManager = resourceManager;
        }
    }
}

