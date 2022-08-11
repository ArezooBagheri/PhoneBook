using PhoneBook.Core.Resources.Resources;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Endpoints.WebUI.Models.Persons
{
    public class AddPersonViewModel
    {
        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.Address)]
        public string Address { get; set; }


        [Required(ErrorMessage = SharedResource.Required)]
        [Display(Name = SharedResource.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
