using Contact.Models;
using Contact.Validators;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    public class ContactController: ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactValidator _contactValidator;
        public ContactController(IContactRepository contactRepository, ContactValidator contactValidator)
        {
            _contactRepository = contactRepository;
            _contactValidator = contactValidator;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreateModel model) 
        {
            var isModelValid = _contactValidator.Validate(model);
            if(!isModelValid)
                return BadRequest();

            var contact = await _contactRepository.CreateAsync(model.Name, model.Email, model.phoneNumber, model.JobTitle, model.BirthDate);

            return Ok(contact);
        }

        [HttpGet("contact")]
        public async Task<IActionResult> GetContacts() 
        {
            var contacts = await _contactRepository.ReadAllAsync();

            return Ok(contacts);
        }

    }
}
